using Scarborough.Drawing;
using Scarborough.PInvoke;
using Scarborough.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Triggernometry;

namespace Scarborough
{

    class Scarborough : IDisposable
    {

        public class ItemAction
        {

            public enum ActionTypeEnum
            {
                Activate,
                Deactivate,
                DeactivateAll,
                RenderingOn,
                RenderingOff,
                DeactivateRegex,
                DeactivateTrigger
            }

            public enum ItemTypeEnum
            {
                Image,
                Text
            }

            public ActionTypeEnum Action { get; set; }
            public ScarboroughItem Item { get; set; }
            public ItemTypeEnum ItemType { get; set; }
            public ManualResetEvent Completed { get; set; } = null;
            public string Id { get; set; }

        }

        private Int64 CurOrdinal = 1;
        private ManualResetEvent exitEvent = null;
        private Thread drawThread = null;
        internal bool RenderingActive { get; set; }
        internal Triggernometry.RealPlugin plug { get; set; }
        private Queue<ItemAction> ItemActions { get; set; } = new Queue<ItemAction>();

        public Dictionary<string, ScarboroughImage> imageitems = new Dictionary<string, ScarboroughImage>();
        public Dictionary<string, ScarboroughText> textitems = new Dictionary<string, ScarboroughText>();

        public Scarborough()
        {
            User32.InitializeWindowClass();
            RenderingActive = true;
            exitEvent = new ManualResetEvent(false);
            drawThread = new Thread(Render);
            drawThread.Start();
        }

        public void Dispose()
        {
            if (exitEvent != null)
            {
                exitEvent.Dispose();
                exitEvent = null;
            }
        }

        public void Shutdown()
        {
            if (exitEvent != null)
            {
                exitEvent.Set();
            }
            if (drawThread != null)
            {
                drawThread.Join();
            }
        }

        private void ExecuteActions()
        {
            lock (ItemActions)
            {
                while (ItemActions.Count > 0)
                {
                    try
                    {
                        ItemAction ia = ItemActions.Dequeue();
                        ExecuteAction(ia);
                        if (ia.Completed != null)
                        {
                            ia.Completed.Set();
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        internal void ExecuteAction(ItemAction ia)
        {
            switch (ia.Action)
            {
                case ItemAction.ActionTypeEnum.RenderingOn:
                    RenderingActive = true;
                    break;
                case ItemAction.ActionTypeEnum.RenderingOff:
                    RenderingActive = false;
                    break;
                case ItemAction.ActionTypeEnum.Activate:
                    {
                        if (ia.Item is ScarboroughImage)
                        {
                            ia.Item.Name = ia.Id;
                            ActivateImage(ia.Id, (ScarboroughImage)ia.Item);
                        }
                        else if (ia.Item is ScarboroughText)
                        {
                            ia.Item.Name = ia.Id;
                            ActivateText(ia.Id, (ScarboroughText)ia.Item);
                        }
                    }
                    break;
                case ItemAction.ActionTypeEnum.DeactivateRegex:
                    {
                        Regex rex = new Regex(ia.Id);
                        List<string> toRem = new List<string>();
                        switch (ia.ItemType)
                        {
                            case ItemAction.ItemTypeEnum.Image:
                                {
                                    toRem.AddRange(from sx in imageitems where rex.IsMatch(sx.Key) select sx.Key);
                                    foreach (string rem in toRem)
                                    {
                                        ScarboroughImage si = null;
                                        si = imageitems[rem];
                                        imageitems.Remove(rem);
                                        if (si != null)
                                        {
                                            si.Dispose();
                                        }
                                    }
                                }
                                break;
                            case ItemAction.ItemTypeEnum.Text:
                                {
                                    toRem.AddRange(from sx in textitems where rex.IsMatch(sx.Key) select sx.Key);
                                    foreach (string rem in toRem)
                                    {
                                        ScarboroughText si = null;
                                        si = textitems[rem];
                                        textitems.Remove(rem);
                                        if (si != null)
                                        {
                                            si.Dispose();
                                        }
                                    }
                                }
                                break;
                        }
                    }
                    break;
                case ItemAction.ActionTypeEnum.DeactivateTrigger:
                    {
                        List<string> toRem = new List<string>();
                        switch (ia.ItemType)
                        {
                            case ItemAction.ItemTypeEnum.Image:
                                {
                                    toRem.AddRange(from sx in imageitems where sx.Value.ctx.trig.Id.ToString() == ia.Id select sx.Key);
                                    foreach (string rem in toRem)
                                    {
                                        ScarboroughImage si = null;
                                        si = imageitems[rem];
                                        imageitems.Remove(rem);
                                        if (si != null)
                                        {
                                            si.Dispose();
                                        }
                                    }
                                }
                                break;
                            case ItemAction.ItemTypeEnum.Text:
                                {
                                    toRem.AddRange(from sx in textitems where sx.Value.ctx.trig.Id.ToString() == ia.Id select sx.Key);
                                    foreach (string rem in toRem)
                                    {
                                        ScarboroughText si = null;
                                        si = textitems[rem];
                                        textitems.Remove(rem);
                                        if (si != null)
                                        {
                                            si.Dispose();
                                        }
                                    }
                                }
                                break;
                        }
                    }
                    break;
                case ItemAction.ActionTypeEnum.Deactivate:
                    {
                        switch (ia.ItemType)
                        {
                            case ItemAction.ItemTypeEnum.Image:
                                {
                                    ScarboroughImage si = null;
                                    if (imageitems.ContainsKey(ia.Id) == true)
                                    {
                                        si = imageitems[ia.Id];
                                        imageitems.Remove(ia.Id);
                                    }
                                    if (si != null)
                                    {
                                        si.Dispose();
                                    }
                                }
                                break;
                            case ItemAction.ItemTypeEnum.Text:
                                {
                                    ScarboroughText si = null;
                                    if (textitems.ContainsKey(ia.Id) == true)
                                    {
                                        si = textitems[ia.Id];
                                        textitems.Remove(ia.Id);
                                    }
                                    if (si != null)
                                    {
                                        si.Dispose();
                                    }
                                }
                                break;
                        }
                    }
                    break;
                case ItemAction.ActionTypeEnum.DeactivateAll:
                    {
                        switch (ia.ItemType)
                        {
                            case ItemAction.ItemTypeEnum.Image:
                                {
                                    List<ScarboroughImage> toRem = new List<ScarboroughImage>();
                                    foreach (KeyValuePair<string, ScarboroughImage> si in imageitems)
                                    {
                                        toRem.Add(si.Value);
                                    }
                                    imageitems.Clear();
                                    foreach (ScarboroughImage si in toRem)
                                    {
                                        si.Dispose();
                                    }
                                }
                                break;
                            case ItemAction.ItemTypeEnum.Text:
                                {
                                    List<ScarboroughText> toRem = new List<ScarboroughText>();
                                    foreach (KeyValuePair<string, ScarboroughText> si in textitems)
                                    {
                                        toRem.Add(si.Value);
                                    }
                                    textitems.Clear();
                                    foreach (ScarboroughText si in toRem)
                                    {
                                        si.Dispose();
                                    }
                                }
                                break;

                        }
                    }
                    break;
            }
        }

        public void Activate(string id, ScarboroughItem si)
        {
            lock (ItemActions)
            {
                ItemActions.Enqueue(new ItemAction() { Action = ItemAction.ActionTypeEnum.Activate, Id = id, Item = si });
            }
        }

        public void Deactivate(string id, ItemAction.ItemTypeEnum it)
        {
            lock (ItemActions)
            {
                ItemActions.Enqueue(new ItemAction() { Action = ItemAction.ActionTypeEnum.Deactivate, Id = id, ItemType = it });
            }
        }

        public void DeactivateRegex(string rex, ItemAction.ItemTypeEnum it)
        {
            lock (ItemActions)
            {
                ItemActions.Enqueue(new ItemAction() { Action = ItemAction.ActionTypeEnum.DeactivateRegex, Id = rex, ItemType = it });
            }
        }

        public void DeactivateTrigger(Trigger t, ItemAction.ItemTypeEnum it)
        {
            lock (ItemActions)
            {
                ItemActions.Enqueue(new ItemAction() { Action = ItemAction.ActionTypeEnum.DeactivateTrigger, Id = t.Id.ToString(), ItemType = it });
            }
        }

        private Int64 GetNextOrdinal()
        {
            return Interlocked.Increment(ref CurOrdinal);
        }

        private void ActivateImage(string id, ScarboroughImage si)
        {
            ScarboroughImage existing = GetImage(id);
            if (existing != null)
            {
                existing.Ordinal = GetNextOrdinal();
                existing.Left = si.EvaluateNumericExpression(si.ctx, si.InitXExpression);
                existing.Top = si.EvaluateNumericExpression(si.ctx, si.InitYExpression);
                existing.Width = si.EvaluateNumericExpression(si.ctx, si.InitWExpression);
                existing.Height = si.EvaluateNumericExpression(si.ctx, si.InitHExpression);
                existing.Opacity = si.EvaluateNumericExpression(si.ctx, si.InitOExpression);
                existing.UpdateXExpression = si.UpdateXExpression;
                existing.UpdateYExpression = si.UpdateYExpression;
                existing.UpdateWExpression = si.UpdateWExpression;
                existing.UpdateHExpression = si.UpdateHExpression;
                existing.UpdateOExpression = si.UpdateOExpression;
                existing.TTLExpression = si.TTLExpression;
                existing.Display = si.Display;
                existing.ctx = si.ctx;
                si.ImageFilename = si.EvaluateStringExpression(si.ctx, si.ImageExpression);
                if (existing.ImageFilename != si.ImageFilename)
                {
                    existing.ImageFilename = si.ImageFilename;
                    existing.NeedImage = true;
                }
            }
            else
            {
                si.Ordinal = GetNextOrdinal();
                si.NeedImage = true;
                si.plug = plug;
                si.ImageFilename = si.EvaluateStringExpression(si.ctx, si.ImageExpression);
                si.Left = si.EvaluateNumericExpression(si.ctx, si.InitXExpression);
                si.Top = si.EvaluateNumericExpression(si.ctx, si.InitYExpression);
                si.Width = si.EvaluateNumericExpression(si.ctx, si.InitWExpression);
                si.Height = si.EvaluateNumericExpression(si.ctx, si.InitHExpression);
                si.Opacity = si.EvaluateNumericExpression(si.ctx, si.InitOExpression);
                imageitems[id] = si;
            }
        }

        private void ActivateText(string id, ScarboroughText si)
        {
            ScarboroughText existing = GetText(id);
            if (existing != null)
            {
                existing.Ordinal = GetNextOrdinal();
                existing.Left = si.EvaluateNumericExpression(si.ctx, si.InitXExpression);
                existing.Top = si.EvaluateNumericExpression(si.ctx, si.InitYExpression);
                existing.Width = si.EvaluateNumericExpression(si.ctx, si.InitWExpression);
                existing.Height = si.EvaluateNumericExpression(si.ctx, si.InitHExpression);
                existing.Opacity = si.EvaluateNumericExpression(si.ctx, si.InitOExpression);
                existing.UpdateXExpression = si.UpdateXExpression;
                existing.UpdateYExpression = si.UpdateYExpression;
                existing.UpdateWExpression = si.UpdateWExpression;
                existing.UpdateHExpression = si.UpdateHExpression;
                existing.UpdateOExpression = si.UpdateOExpression;
                existing.TTLExpression = si.TTLExpression;
                existing.TextAlignment = si.TextAlignment;
                existing.UseOutline = si.UseOutline;
                existing.TextColor = si.TextColor;
                existing.OutlineColor = si.OutlineColor;
                existing.BackgroundColor = si.BackgroundColor;
                existing.FontName = si.FontName;
                existing.FontSize = si.FontSize;
                existing.FontStyle = si.FontStyle;
                existing.Text = si.EvaluateStringExpression(si.ctx, si.TextExpression);
                existing.TextExpression = si.TextExpression;
                existing.ctx = si.ctx;
                existing.NeedFont = true;
            }
            else
            {
                si.Ordinal = GetNextOrdinal();
                si.plug = plug;
                si.Left = si.EvaluateNumericExpression(si.ctx, si.InitXExpression);
                si.Top = si.EvaluateNumericExpression(si.ctx, si.InitYExpression);
                si.Width = si.EvaluateNumericExpression(si.ctx, si.InitWExpression);
                si.Height = si.EvaluateNumericExpression(si.ctx, si.InitHExpression);
                si.Opacity = si.EvaluateNumericExpression(si.ctx, si.InitOExpression);
                si.Text = si.EvaluateStringExpression(si.ctx, si.TextExpression);
                si.NeedFont = true;
                textitems[id] = si;
            }
        }

        public ScarboroughImage GetImage(string id)
        {
            if (imageitems.ContainsKey(id) == true)
            {
                return imageitems[id];
            }
            return null;
        }

        public ScarboroughText GetText(string id)
        {
            if (textitems.ContainsKey(id) == true)
            {
                return textitems[id];
            }
            return null;
        }

        public void DeactivateAllImages()
        {
            lock (ItemActions)
            {
                ItemActions.Enqueue(new ItemAction() { Action = ItemAction.ActionTypeEnum.DeactivateAll, ItemType = ItemAction.ItemTypeEnum.Image });
            }
        }

        public void DeactivateAllText()
        {
            lock (ItemActions)
            {
                ItemActions.Enqueue(new ItemAction() { Action = ItemAction.ActionTypeEnum.DeactivateAll, ItemType = ItemAction.ItemTypeEnum.Text });
            }
        }

        public class DeferredMessage
        {

            public Triggernometry.Context ctx { get; set; } = null;
            public Triggernometry.RealPlugin plug { get; set; } = null;
            public Triggernometry.RealPlugin.DebugLevelEnum level { get; set; } = Triggernometry.RealPlugin.DebugLevelEnum.None;
            public string Message { get; set; } = "";

        }

        private void ProcessMessages(IEnumerable<DeferredMessage> msgs)
        {
            foreach (DeferredMessage msg in msgs)
            {
                if (msg.ctx != null)
                {
                    msg.ctx.trig.AddToLog(msg.plug, msg.level, msg.Message);
                }
                else
                {
                    plug.FilteredAddToLog(msg.level, msg.Message);
                }
            }
        }

        private void UpdateImages(int numTicks, ref RenderCollection rc)
        {
            List<string> toRem = new List<string>();
            List<DeferredMessage> messages = new List<DeferredMessage>();
            toRem.Clear();
            foreach (KeyValuePair<string, ScarboroughImage> si in imageitems)
            {
                try
                {
                    if (si.Value.Logic(numTicks) == false)
                    {
                        toRem.Add(si.Key);
                    }
                    else
                    {
                        if (si.Value.Changed == true)
                        {
                            si.Value.NeedRender = true;
                            si.Value.Changed = false;
                        }
                        rc.Add(si.Value);
                    }
                }
                catch (Exception ex)
                {
                    if (si.Value.ctx != null && si.Value.ctx.trig != null)
                    {
                        messages.Add(new DeferredMessage()
                        {
                            ctx = si.Value.ctx,
                            plug = plug,
                            level = Triggernometry.RealPlugin.DebugLevelEnum.Error,
                            Message = Triggernometry.I18n.Translate("internal/AuraContainer/updateerror", String.Format("Deactivating aura '{0}' from trigger '{1}' due to update exception: {2}", si.Key, si.Value.ctx.trig.LogName, ex.Message))
                        }
                        );
                    }
                    else
                    {
                        messages.Add(new DeferredMessage()
                        {
                            ctx = null,
                            plug = plug,
                            level = Triggernometry.RealPlugin.DebugLevelEnum.Error,
                            Message = Triggernometry.I18n.Translate("internal/AuraContainer/updateerror", String.Format("Deactivating aura '{0}' due to update exception: {1}", si.Key, ex.Message))
                        }
                        );
                    }
                    toRem.Add(si.Key);
                }
            }
            if (toRem.Count > 0)
            {
                foreach (string si in toRem)
                {
                    ScarboroughImage sit = imageitems[si];
                    if (sit.ctx != null && sit.ctx.trig != null)
                    {
                        messages.Add(new DeferredMessage()
                        {
                            ctx = sit.ctx,
                            plug = plug,
                            level = Triggernometry.RealPlugin.DebugLevelEnum.Verbose,
                            Message = Triggernometry.I18n.Translate("internal/AuraContainer/closingaura", "Closing aura window")
                        }
                        );
                    }
                    else
                    {
                        messages.Add(new DeferredMessage()
                        {
                            ctx = null,
                            plug = plug,
                            level = Triggernometry.RealPlugin.DebugLevelEnum.Verbose,
                            Message = Triggernometry.I18n.Translate("internal/AuraContainer/closingaura", "Closing aura window")
                        }
                        );
                    }
                    imageitems.Remove(si);
                    sit.Dispose();
                }
            }
            ProcessMessages(messages);
        }

        private void UpdateText(int numTicks, ref RenderCollection rc)
        {
            List<string> toRem = new List<string>();
            List<DeferredMessage> messages = new List<DeferredMessage>();
            toRem.Clear();
            foreach (KeyValuePair<string, ScarboroughText> si in textitems)
            {
                try
                {
                    if (si.Value.Logic(numTicks) == false)
                    {
                        toRem.Add(si.Key);
                    }
                    else
                    {
                        if (si.Value.Changed == true)
                        {
                            si.Value.NeedRender = true;
                            si.Value.Changed = false;
                        }
                        rc.Add(si.Value);
                    }
                }
                catch (Exception ex)
                {
                    if (si.Value.ctx != null && si.Value.ctx.trig != null)
                    {
                        messages.Add(new DeferredMessage()
                        {
                            ctx = si.Value.ctx,
                            plug = plug,
                            level = Triggernometry.RealPlugin.DebugLevelEnum.Error,
                            Message = Triggernometry.I18n.Translate("internal/AuraContainer/updateerror", String.Format("Deactivating aura '{0}' from trigger '{1}' due to update exception: {2}", si.Key, si.Value.ctx.trig.LogName, ex.Message))
                        }
                        );
                    }
                    else
                    {
                        messages.Add(new DeferredMessage()
                        {
                            ctx = null,
                            plug = plug,
                            level = Triggernometry.RealPlugin.DebugLevelEnum.Error,
                            Message = Triggernometry.I18n.Translate("internal/AuraContainer/updateerror", String.Format("Deactivating aura '{0}' due to update exception: {1}", si.Key, ex.Message))
                        }
                        );
                    }
                    toRem.Add(si.Key);
                }
            }
            if (toRem.Count > 0)
            {
                foreach (string si in toRem)
                {
                    ScarboroughText sit = textitems[si];
                    if (sit.ctx != null && sit.ctx.trig != null)
                    {
                        messages.Add(new DeferredMessage()
                        {
                            ctx = sit.ctx,
                            plug = plug,
                            level = Triggernometry.RealPlugin.DebugLevelEnum.Verbose,
                            Message = Triggernometry.I18n.Translate("internal/AuraContainer/closingaura", "Closing aura window")
                        }
                        );
                    }
                    else
                    {
                        messages.Add(new DeferredMessage()
                        {
                            ctx = null,
                            plug = plug,
                            level = Triggernometry.RealPlugin.DebugLevelEnum.Verbose,
                            Message = Triggernometry.I18n.Translate("internal/AuraContainer/closingaura", "Closing aura window")
                        }
                        );
                    }
                    textitems.Remove(si);
                    sit.Dispose();
                }
            }
            ProcessMessages(messages);
        }

        internal void HideAllItems()
        {
            lock (ItemActions)
            {
                ItemActions.Enqueue(new ItemAction() { Action = ItemAction.ActionTypeEnum.RenderingOff });
            }
        }

        internal void ShowAllItems()
        {
            lock (ItemActions)
            {
                ItemActions.Enqueue(new ItemAction() { Action = ItemAction.ActionTypeEnum.RenderingOn });
            }
        }

        private void Render(RenderCollection rc)
        {
            List<ScarboroughItem> toRem = new List<ScarboroughItem>();
            List<DeferredMessage> messages = new List<DeferredMessage>();            
            rc.items.Sort((a, b) => a.Ordinal.CompareTo(b.Ordinal));
            foreach (ScarboroughItem si in rc.items)
            {
                try
                {
                    si.Render();
                }
                catch (Exception ex)
                {
                    if (si.ctx != null && si.ctx.trig != null)
                    {
                        messages.Add(new DeferredMessage()
                        {
                            ctx = si.ctx,
                            plug = plug,
                            level = Triggernometry.RealPlugin.DebugLevelEnum.Error,
                            Message = Triggernometry.I18n.Translate("internal/AuraContainer/updateerror", String.Format("Deactivating aura '{0}' from trigger '{1}' due to update exception: {2}", si.Name, si.ctx.trig.LogName, ex.Message))
                        }
                        );
                    }
                    else
                    {
                        messages.Add(new DeferredMessage()
                        {
                            ctx = null,
                            plug = plug,
                            level = Triggernometry.RealPlugin.DebugLevelEnum.Error,
                            Message = Triggernometry.I18n.Translate("internal/AuraContainer/updateerror", String.Format("Deactivating aura '{0}' due to update exception: {1}", si.Name, ex.Message))
                        }
                        );
                    }
                    toRem.Add(si);
                }
            }
            if (toRem.Count > 0)
            {
                foreach (ScarboroughItem si in toRem)
                {
                    if (si.ctx != null && si.ctx.trig != null)
                    {
                        messages.Add(new DeferredMessage()
                        {
                            ctx = si.ctx,
                            plug = plug,
                            level = Triggernometry.RealPlugin.DebugLevelEnum.Verbose,
                            Message = Triggernometry.I18n.Translate("internal/AuraContainer/closingaura", "Closing aura window")
                        }
                        );
                    }
                    else
                    {
                        messages.Add(new DeferredMessage()
                        {
                            ctx = null,
                            plug = plug,
                            level = Triggernometry.RealPlugin.DebugLevelEnum.Verbose,
                            Message = Triggernometry.I18n.Translate("internal/AuraContainer/closingaura", "Closing aura window")
                        }
                        );
                    }
                    if (si is ScarboroughImage)
                    {
                        var myKey = imageitems.FirstOrDefault(x => x.Value == si).Key;
                        imageitems.Remove(myKey);
                    }
                    if (si is ScarboroughText)
                    {
                        var myKey = textitems.FirstOrDefault(x => x.Value == si).Key;
                        textitems.Remove(myKey);
                    }
                    si.Dispose();
                }
            }
            ProcessMessages(messages);
        }

        private class RenderCollection
        {

            public List<ScarboroughItem> items = new List<ScarboroughItem>();

            public RenderCollection()
            {
                Clear();
            }

            public void Clear()
            {
                items.Clear();
            }

            public void Add(ScarboroughItem si)
            {
                items.Add(si);
            }

        }

        public void Render()
        {
            int numTicks = 0;
            DateTime prevTick = DateTime.Now, tickTime;
            double msSince, lag = 0.0;
            RenderCollection rc = new RenderCollection();
            while (true)
            {
                try
                {
                    if (exitEvent.WaitOne(5) == true)
                    {
                        return;
                    }
                    tickTime = DateTime.Now;
                    msSince = (tickTime - prevTick).TotalMilliseconds + lag;
                    numTicks = (int)Math.Floor(msSince / 20.0);
                    lag = msSince - (numTicks * 20);
                    prevTick = tickTime;
                    if (numTicks > 0)
                    {
                        rc.Clear();
                        ExecuteActions();
                        UpdateImages(numTicks, ref rc);
                        UpdateText(numTicks, ref rc);
                    }
                    if (rc.items.Count > 0)
                    {
                        Render(rc);
                    }
                }
                catch (Exception)
                {
                }
            }
        }

    }

}
