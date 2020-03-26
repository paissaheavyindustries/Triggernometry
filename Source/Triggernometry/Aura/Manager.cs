using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Triggernometry.Aura
{

    class Manager : IDisposable
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
                DeactivateRegex
            }

            public enum ItemTypeEnum
            {
                Image,
                Text
            }

            public ActionTypeEnum Action { get; set; }
            public Aura Item { get; set; }
            public ItemTypeEnum ItemType { get; set; }
            public ManualResetEvent Completed { get; set; } = null;
            public string Id { get; set; }

        }

        public enum RendererEnum
        {
            Winforms,
            Scarborough
        }

        public RendererEnum Renderer { get; set; }
        private Int64 CurOrdinal = 1;
        private ManualResetEvent exitEvent = null;
        private Thread drawThread = null;
        internal bool RenderingActive { get; set; }
        internal Triggernometry.RealPlugin plug { get; set; }
        private Queue<ItemAction> ItemActions { get; set; } = new Queue<ItemAction>();

        public Dictionary<string, AuraImage> imageitems = new Dictionary<string, AuraImage>();
        public Dictionary<string, AuraText> textitems = new Dictionary<string, AuraText>();

        public Manager()
        {
            RenderingActive = true;
            exitEvent = new ManualResetEvent(false);
            drawThread = new Thread(ManagerThread);
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

        internal void ExecuteAction(Context ctx, Action a)
        {            
        }

        private void ExecuteItemActions()
        {
            lock (ItemActions)
            {
                while (ItemActions.Count > 0)
                {
                    try
                    {
                        ItemAction ia = ItemActions.Dequeue();
                        ExecuteItemAction(ia);
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

        internal void ExecuteItemAction(ItemAction ia)
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
                        if (ia.Item is AuraImage)
                        {
                            ia.Item.Name = ia.Id;
                            ActivateImage(ia.Id, (AuraImage)ia.Item);
                        }
                        else if (ia.Item is AuraText)
                        {
                            ia.Item.Name = ia.Id;
                            ActivateText(ia.Id, (AuraText)ia.Item);
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
                                        AuraImage a = null;
                                        a = imageitems[rem];
                                        imageitems.Remove(rem);
                                        if (a != null)
                                        {
                                            a.Dispose();
                                        }
                                    }
                                }
                                break;
                            case ItemAction.ItemTypeEnum.Text:
                                {
                                    toRem.AddRange(from sx in textitems where rex.IsMatch(sx.Key) select sx.Key);
                                    foreach (string rem in toRem)
                                    {
                                        AuraText a = null;
                                        a = textitems[rem];
                                        textitems.Remove(rem);
                                        if (a != null)
                                        {
                                            a.Dispose();
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
                                    AuraImage a = null;
                                    if (imageitems.ContainsKey(ia.Id) == true)
                                    {
                                        a = imageitems[ia.Id];
                                        imageitems.Remove(ia.Id);
                                    }
                                    if (a != null)
                                    {
                                        a.Dispose();
                                    }
                                }
                                break;
                            case ItemAction.ItemTypeEnum.Text:
                                {
                                    AuraText a = null;
                                    if (textitems.ContainsKey(ia.Id) == true)
                                    {
                                        a = textitems[ia.Id];
                                        textitems.Remove(ia.Id);
                                    }
                                    if (a != null)
                                    {
                                        a.Dispose();
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
                                    List<AuraImage> toRem = new List<AuraImage>();
                                    foreach (KeyValuePair<string, AuraImage> si in imageitems)
                                    {
                                        toRem.Add(si.Value);
                                    }
                                    imageitems.Clear();
                                    foreach (AuraImage si in toRem)
                                    {
                                        si.Dispose();
                                    }
                                }
                                break;
                            case ItemAction.ItemTypeEnum.Text:
                                {
                                    List<AuraText> toRem = new List<AuraText>();
                                    foreach (KeyValuePair<string, AuraText> si in textitems)
                                    {
                                        toRem.Add(si.Value);
                                    }
                                    textitems.Clear();
                                    foreach (AuraText si in toRem)
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

        public void Activate(string id, Aura a)
        {
            lock (ItemActions)
            {
                ItemActions.Enqueue(new ItemAction() { Action = ItemAction.ActionTypeEnum.Activate, Id = id, Item = a });
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

        private Int64 GetNextOrdinal()
        {
            return Interlocked.Increment(ref CurOrdinal);
        }

        private void ActivateGeneric(Aura a, Aura copyFrom)
        {
            a.Ordinal = GetNextOrdinal();
            if (copyFrom != null)
            {
                a.ctx = copyFrom.ctx;
                a.InitXExpression = copyFrom.InitXExpression;
                a.InitYExpression = copyFrom.InitYExpression;
                a.InitWExpression = copyFrom.InitWExpression;
                a.InitHExpression = copyFrom.InitHExpression;
                a.InitOExpression = copyFrom.InitOExpression;
            }
            else
            {
                a.plug = plug;
                switch (Renderer)
                {
                    case RendererEnum.Winforms:
                        a.Renderer = new Renderer.Winforms();
                        break;
                    case RendererEnum.Scarborough:
                        a.Renderer = new Renderer.Scarborough();
                        break;
                }
            }
            a.Left = a.EvaluateNumericExpression(a.ctx, a.InitXExpression);
            a.Top = a.EvaluateNumericExpression(a.ctx, a.InitYExpression);
            a.Width = a.EvaluateNumericExpression(a.ctx, a.InitWExpression);
            a.Height = a.EvaluateNumericExpression(a.ctx, a.InitHExpression);
            a.Opacity = a.EvaluateNumericExpression(a.ctx, a.InitOExpression);
            if (copyFrom != null)
            {
                a.UpdateXExpression = copyFrom.UpdateXExpression;
                a.UpdateYExpression = copyFrom.UpdateYExpression;
                a.UpdateWExpression = copyFrom.UpdateWExpression;
                a.UpdateHExpression = copyFrom.UpdateHExpression;
                a.UpdateOExpression = copyFrom.UpdateOExpression;
                a.TTLExpression = copyFrom.TTLExpression;
            }
        }

        private AuraImage ActivateImage(string id, AuraImage a)
        {
            AuraImage existing = GetImage(id);
            if (existing != null)
            {
                ActivateGeneric(existing, a);
                return existing;
            }
            else
            {
                ActivateGeneric(a, null);
                imageitems[id] = a;
                return a;
            }
        }

        private AuraText ActivateText(string id, AuraText a)
        {
            AuraText existing = GetText(id);
            if (existing != null)
            {
                ActivateGeneric(existing, a);
                existing.TextExpression = a.TextExpression;
                existing.Text = a.EvaluateStringExpression(existing.ctx, existing.TextExpression);
                return existing;
            }
            else
            {
                ActivateGeneric(a, null);
                a.Text = a.EvaluateStringExpression(a.ctx, a.TextExpression);
                textitems[id] = a;
                return a;
            }
        }

        public AuraImage GetImage(string id)
        {
            if (imageitems.ContainsKey(id) == true)
            {
                return imageitems[id];
            }
            return null;
        }

        public AuraText GetText(string id)
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

        public void ManagerThread()
        {
            int numTicks = 0;
            List<Aura> auraCollection = new List<Aura>();
            DateTime prevTick = DateTime.Now, tickTime;
            double msSince, lag = 0.0;
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
                        auraCollection.Clear();
                        ExecuteItemActions();
                        UpdateImages(numTicks, auraCollection);
                        UpdateText(numTicks, auraCollection);
                    }
                    if (auraCollection.Count > 0)
                    {
                        Render(auraCollection);
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void UpdateAura(int numTicks, Aura a, List<Aura> ac, List<string> toRem)
        {
            try
            {
                if (a.Logic(numTicks) == false)
                {
                    toRem.Add(a.Name);
                }
                else
                {
                    if (a.Changed == true)
                    {
                        a.Changed = false;
                    }
                    ac.Add(a);
                }
            }
            catch (Exception ex)
            {
                /* tododoo
                if (a.ctx != null && a.ctx.trig != null)
                {
                    messages.Add(new DeferredMessage()
                    {
                        ctx = a.ctx,
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
                }*/
                toRem.Add(a.Name);
            }
        }

        private void UpdateImages(int numTicks, List<Aura> ac)
        {
            /* tododoo
            List<string> toRem = new List<string>();
            List<DeferredMessage> messages = new List<DeferredMessage>();
            toRem.Clear();
            foreach (KeyValuePair<string, AuraImage> kp in imageitems)
            {
                UpdateAura(numTicks, kp.Value, ac, toRem);
            }
            if (toRem.Count > 0)
            {
                foreach (string si in toRem)
                {
                    Aura a = imageitems[si];
                    if (a.ctx != null && a.ctx.trig != null)
                    {
                        messages.Add(new DeferredMessage()
                        {
                            ctx = a.ctx,
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
                    a.Dispose();
                }
            }
            ProcessMessages(messages);*/
        }

        private void UpdateText(int numTicks, List<Aura> ac)
        {
            /* tododoo
            List<string> toRem = new List<string>();
            List<DeferredMessage> messages = new List<DeferredMessage>();
            toRem.Clear();
            foreach (KeyValuePair<string, AuraText> kp in textitems)
            {
                UpdateAura(numTicks, kp.Value, ac, toRem);
            }
            if (toRem.Count > 0)
            {
                foreach (string si in toRem)
                {
                    Aura a = textitems[si];
                    if (a.ctx != null && a.ctx.trig != null)
                    {
                        messages.Add(new DeferredMessage()
                        {
                            ctx = a.ctx,
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
                    a.Dispose();
                }
            }
            ProcessMessages(messages);*/
        }

        private void UpdateAuras(int numTicks, List<Aura> ac)
        {
            UpdateImages(numTicks, ac);
            UpdateText(numTicks, ac);
        }

        private void Render(IEnumerable<Aura> ac)
        {
            foreach (Aura a in ac)
            {
                a.Render();
            }
        }

    }

}
