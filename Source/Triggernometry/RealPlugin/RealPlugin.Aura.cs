using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Triggernometry.CustomControls;
using Triggernometry.Utilities;

namespace Triggernometry
{

    public partial class RealPlugin
    {
        internal Scarborough.Scarborough sc = null;
        private bool _usingScarborough = false;

        internal Dictionary<string, Forms.AuraContainerForm> imageauras = new Dictionary<string, Forms.AuraContainerForm>();
        internal Dictionary<string, Forms.AuraContainerForm> textauras = new Dictionary<string, Forms.AuraContainerForm>();

        internal Thread AuraUpdateThread = null;

        private void InitAura()
        {
            AuraUpdateThread = new Thread(new ThreadStart(AuraUpdateThreadProc));
            AuraUpdateThread.Name = "AuraUpdateThread";
            AuraUpdateThread.Start();

            if (cfg.UseScarborough == true)
            {
                sc = new Scarborough.Scarborough();
                sc.plug = this;
                _usingScarborough = true;
            }
        }

        private void DeInitAura()
        {
            if (AuraUpdateThread != null)
            {
                if (AuraUpdateThread.Join(5000) == false)
                {
                    AuraUpdateThread.Abort();
                }
                AuraUpdateThread = null;
            }
            if (sc != null)
            {
                sc.Shutdown();
                sc.Dispose();
                sc = null;
            }
        }

        private bool _HideAllAuras = false;
        internal bool HideAllAuras
        {
            get
            {
                return _HideAllAuras;
            }
            set
            {
                if (value != _HideAllAuras)
                {
                    _HideAllAuras = value;
                    if (_HideAllAuras == true)
                    {
                        ProcessAuraControl(true);
                    }
                    else
                    {
                        ProcessAuraControl(false);
                    }
                }
            }
        }

        private void ProcessAuraControl(bool hideAuras)
        {
            if (hideAuras == true)
            {
                if (sc != null)
                {
                    sc.HideAllItems();
                }
                else
                {
                    foreach (KeyValuePair<string, Forms.AuraContainerForm> kp in textauras)
                    {
                        kp.Value.Hide();
                    }
                    foreach (KeyValuePair<string, Forms.AuraContainerForm> kp in imageauras)
                    {
                        kp.Value.Hide();
                    }
                }
            }
            else
            {
                if (sc != null)
                {
                    sc.ShowAllItems();
                }
                else
                {
                    foreach (KeyValuePair<string, Forms.AuraContainerForm> kp in textauras)
                    {
                        kp.Value.Show();
                    }
                    foreach (KeyValuePair<string, Forms.AuraContainerForm> kp in imageauras)
                    {
                        kp.Value.Show();
                    }
                }
            }
        }

        private void AuraUpdateThreadProc()
        {
            WaitHandle[] wh = new WaitHandle[1];
            wh[0] = ExitEvent;
            int numTicks = 0, procticks = 0;
            DateTime prevTick, tickTime;
            if (mainform.IsHandleCreated == false)
            {
                do
                {
                    Thread.Sleep(100);
                } while (mainform.IsHandleCreated == false);
            }
            prevTick = DateTime.Now;
            double msSince, lag = 0.0;
            while (true)
            {
                if (ExitEvent.WaitOne(20) == true)
                {
                    return;
                }
                if (procticks >= 10)
                {
                    VerifyProcessWindow();
                    procticks = 0;
                }
                tickTime = DateTime.Now;
                msSince = (tickTime - prevTick).TotalMilliseconds + lag;
                numTicks = (int)Math.Floor(msSince / 20.0);
                //System.Diagnostics.Debug.WriteLine(String.Format("{0}.{1} -> {2}.{3} = {4}+{5} = {6}x", prevTick, prevTick.Millisecond, tickTime, tickTime.Millisecond, msSince - lag, lag, numTicks));
                lag = msSince - (numTicks * 20);
                prevTick = tickTime;
                UpdateAuras(numTicks);
                procticks++;
            }
        }

        private void VerifyProcessWindow()
        {
            if (string.IsNullOrWhiteSpace(cfg.WindowToMonitor))
            {
                HideAllAuras = (WindowsUtils.IsInFocus(cfg.WindowToMonitor) == false);
            }
            else
            {
                HideAllAuras = false;
            }
        }

        internal void UpdateAuras(int numTicks)
        {
            lock (imageauras)
            {
                List<string> toRem = new List<string>();
                foreach (KeyValuePair<string, Forms.AuraContainerForm> kp in imageauras)
                {
                    if (kp.Value.UpdateAura(numTicks) == false)
                    {
                        toRem.Add(kp.Key);
                    }
                }
                foreach (string rem in toRem)
                {
                    imageauras.Remove(rem);
                }
            }
            lock (textauras)
            {
                List<string> toRem = new List<string>();
                foreach (KeyValuePair<string, Forms.AuraContainerForm> kp in textauras)
                {
                    if (kp.Value.UpdateAura(numTicks) == false)
                    {
                        toRem.Add(kp.Key);
                    }
                }
                foreach (string rem in toRem)
                {
                    textauras.Remove(rem);
                }
            }
        }

        internal void ImageAuraManagement(Context ctx, Action a)
        {
            if (_usingScarborough == true)
            {
                SbImageAuraManagement(ctx, a);
            }
            else
            {
                LegacyImageAuraManagement(ctx, a);
            }
        }

        internal void TextAuraManagement(Context ctx, Action a)
        {
            if (_usingScarborough == true)
            {
                SbTextAuraManagement(ctx, a);
            }
            else
            {
                LegacyTextAuraManagement(ctx, a);
            }
        }

        internal void SbImageAuraManagement(Context ctx, Action a)
        {
            switch (a._AuraOp)
            {
                case Action.AuraOpEnum.ActivateAura:
                    {
                        string ax = ctx.EvaluateStringExpression(a.ActionContextLogger, ctx, a._AuraName);
                        FilteredAddToLog(DebugLevelEnum.Info, I18n.Translate("internal/Plugin/actimageaura", "Activating image aura '{0}'", ax));
                        try
                        {
                            Scarborough.ScarboroughImage si = new Scarborough.ScarboroughImage(sc);
                            si.ImageExpression = a._AuraImage;
                            si.InitXExpression = a._AuraXIniExpression;
                            si.InitYExpression = a._AuraYIniExpression;
                            si.InitWExpression = a._AuraWIniExpression;
                            si.InitHExpression = a._AuraHIniExpression;
                            si.InitOExpression = a._AuraOIniExpression;
                            si.UpdateXExpression = a._AuraXTickExpression;
                            si.UpdateYExpression = a._AuraYTickExpression;
                            si.UpdateWExpression = a._AuraWTickExpression;
                            si.UpdateHExpression = a._AuraHTickExpression;
                            si.UpdateOExpression = a._AuraOTickExpression;
                            si.TTLExpression = a._AuraTTLTickExpression;
                            si.Display = a._AuraImageMode;
                            si.ctx = ctx;
                            sc.Activate(ax, si);
                        }
                        catch (Exception ex)
                        {
                            FilteredAddToLog(DebugLevelEnum.Error, I18n.Translate("internal/Plugin/exactimageaura", "Exception '{0}' when activating image aura '{1}'", ex.Message, ax));
                        }
                    }
                    break;
                case Action.AuraOpEnum.DeactivateAura:
                    {
                        string ax = ctx.EvaluateStringExpression(a.ActionContextLogger, ctx, a._AuraName);
                        FilteredAddToLog(DebugLevelEnum.Info, I18n.Translate("internal/Plugin/deactimageaura", "Deactivating image aura '{0}'", ax));
                        sc.Deactivate(ax, Scarborough.Scarborough.ItemAction.ItemTypeEnum.Image);
                    }
                    break;
                case Action.AuraOpEnum.DeactivateAllAura:
                    {
                        FilteredAddToLog(DebugLevelEnum.Info, I18n.Translate("internal/Plugin/deactallimageaura", "Deactivating all image auras"));
                        sc.DeactivateAllImages();
                    }
                    break;
                case Action.AuraOpEnum.DeactivateAuraRegex:
                    {
                        string ax = a._AuraName;
                        FilteredAddToLog(DebugLevelEnum.Info, I18n.Translate("internal/Plugin/deactimageaurarex", "Deactivating image auras matching '{0}'", ax));
                        sc.DeactivateRegex(ax, Scarborough.Scarborough.ItemAction.ItemTypeEnum.Image);
                    }
                    break;
                case Action.AuraOpEnum.DeactivateAuraTrigger:
                    {
                        FilteredAddToLog(DebugLevelEnum.Info, I18n.Translate("internal/Plugin/deactimageauratrig", "Deactivating image auras from trigger '{0}' ({1})", ctx.trig.LogName, ctx.trig.Id));
                        sc.DeactivateTrigger(ctx.trig, Scarborough.Scarborough.ItemAction.ItemTypeEnum.Image);
                    }
                    break;
            }
        }

        internal void LegacyImageAuraManagement(Context ctx, Action a)
        {
            if (mainform.InvokeRequired == true)
            {
                string ax = ctx.EvaluateStringExpression(a.ActionContextLogger, ctx, a._AuraName);
                FilteredAddToLog(DebugLevelEnum.Verbose, I18n.Translate("internal/Plugin/invokeimageaura", "Invoke required for image aura '{0}'", ax));
                mainform.Invoke(new ActionExecutionHook(ImageAuraManagement), ctx, a);
                return;
            }
            switch (a._AuraOp)
            {
                case Action.AuraOpEnum.ActivateAura:
                    {
                        string ax = ctx.EvaluateStringExpression(a.ActionContextLogger, ctx, a._AuraName);
                        FilteredAddToLog(DebugLevelEnum.Info, I18n.Translate("internal/Plugin/actimageaura", "Activating image aura '{0}'", ax));
                        Forms.AuraContainerForm acf = null;
                        bool newAura = false;
                        try
                        {
                            lock (ctx.plug.imageauras)
                            {
                                if (ctx.plug.imageauras.ContainsKey(ax) == true)
                                {
                                    acf = ctx.plug.imageauras[ax];
                                }
                                else
                                {
                                    acf = new Forms.AuraContainerForm(Forms.AuraContainerForm.AuraTypeEnum.Image);
                                    acf.plug = this;
                                    acf.AuraName = ax;
                                    newAura = true;
                                }
                                acf.AuraPrepare();
                                acf.ctx = ctx;
                                acf.ImageExpression = a._AuraImage;
                                acf.Display = a._AuraImageMode;
                                acf.Left = acf.EvaluateNumericExpression(ctx, a._AuraXIniExpression);
                                acf.Top = acf.EvaluateNumericExpression(ctx, a._AuraYIniExpression);
                                int i = acf.EvaluateNumericExpression(ctx, a._AuraWIniExpression);
                                if (i < 0)
                                {
                                    i = 0;
                                }
                                acf.Width = i;
                                if (i < 0)
                                {
                                    i = 0;
                                }
                                i = acf.EvaluateNumericExpression(ctx, a._AuraHIniExpression);
                                if (i < 0)
                                {
                                    i = 0;
                                }
                                acf.Height = i;
                                i = acf.EvaluateNumericExpression(ctx, a._AuraOIniExpression);
                                if (i < 0)
                                {
                                    i = 0;
                                }
                                if (i > 100)
                                {
                                    i = 100;
                                }
                                acf.PresentableOpacity = i;
                                acf.XExpression = a._AuraXTickExpression;
                                acf.YExpression = a._AuraYTickExpression;
                                acf.WExpression = a._AuraWTickExpression;
                                acf.HExpression = a._AuraHTickExpression;
                                acf.OExpression = a._AuraOTickExpression;
                                acf.TTLExpression = a._AuraTTLTickExpression;
                                acf.AuraActivate();
                                if (newAura == true)
                                {
                                    ctx.plug.imageauras[ax] = acf;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            FilteredAddToLog(DebugLevelEnum.Error, I18n.Translate("internal/Plugin/exactimageaura", "Exception '{0}' when activating image aura '{1}'", ex.Message, ax));
                            if (acf != null)
                            {
                                if (newAura == true)
                                {
                                    acf.Dispose();
                                }
                                else
                                {
                                    acf.AuraDeactivate();
                                }
                            }
                        }
                    }
                    break;
                case Action.AuraOpEnum.DeactivateAura:
                    {
                        string ax = ctx.EvaluateStringExpression(a.ActionContextLogger, ctx, a._AuraName);
                        FilteredAddToLog(DebugLevelEnum.Info, I18n.Translate("internal/Plugin/deactimageaura", "Deactivating image aura '{0}'", ax));
                        lock (ctx.plug.imageauras)
                        {
                            if (ctx.plug.imageauras.ContainsKey(ax) == true)
                            {
                                Forms.AuraContainerForm acf = ctx.plug.imageauras[ax];
                                acf.AuraDeactivate();
                            }
                        }
                    }
                    break;
                case Action.AuraOpEnum.DeactivateAllAura:
                    {
                        FilteredAddToLog(DebugLevelEnum.Info, I18n.Translate("internal/Plugin/deactallimageaura", "Deactivating all image auras"));
                        while (true)
                        {
                            lock (ctx.plug.imageauras)
                            {
                                if (ctx.plug.imageauras.Count > 0)
                                {
                                    Forms.AuraContainerForm acf = ctx.plug.imageauras.ElementAt(0).Value;
                                    acf.AuraDeactivate();
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                    break;
                case Action.AuraOpEnum.DeactivateAuraRegex:
                    {
                        Regex rex = new Regex(a._AuraName);
                        FilteredAddToLog(DebugLevelEnum.Info, I18n.Translate("internal/Plugin/deactimageaurarex", "Deactivating image auras matching '{0}'", a._AuraName));
                        List<string> toRem = new List<string>();
                        lock (ctx.plug.imageauras)
                        {
                            toRem.AddRange(from sx in ctx.plug.imageauras where rex.IsMatch(sx.Key) select sx.Key);
                            foreach (string rem in toRem)
                            {
                                Forms.AuraContainerForm acf = ctx.plug.imageauras[rem];
                                acf.AuraDeactivate();
                            }
                        }
                    }
                    break;
                case Action.AuraOpEnum.DeactivateAuraTrigger:
                    {
                        FilteredAddToLog(DebugLevelEnum.Info, I18n.Translate("internal/Plugin/deactimageauratrig", "Deactivating image auras from trigger '{0}' ({1})", ctx.trig.LogName, ctx.trig.Id));
                        List<string> toRem = new List<string>();
                        lock (ctx.plug.imageauras)
                        {
                            toRem.AddRange(from sx in ctx.plug.imageauras where sx.Value.ctx.trig == ctx.trig select sx.Key);
                            foreach (string rem in toRem)
                            {
                                Forms.AuraContainerForm acf = ctx.plug.imageauras[rem];
                                acf.AuraDeactivate();
                            }
                        }
                    }
                    break;
            }
        }

        internal void SbTextAuraManagement(Context ctx, Action a)
        {
            if (mainform.InvokeRequired == true)
            {
                string ax = ctx.EvaluateStringExpression(a.ActionContextLogger, ctx, a._TextAuraName);
                FilteredAddToLog(DebugLevelEnum.Verbose, I18n.Translate("internal/Plugin/invoketextaura", "Invoke required for text aura '{0}'", ax));
                mainform.Invoke(new ActionExecutionHook(TextAuraManagement), ctx, a);
                return;
            }
            switch (a._TextAuraOp)
            {
                case Action.AuraOpEnum.ActivateAura:
                    {
                        string ax = ctx.EvaluateStringExpression(a.ActionContextLogger, ctx, a._TextAuraName);
                        FilteredAddToLog(DebugLevelEnum.Info, I18n.Translate("internal/Plugin/acttextaura", "Activating text aura '{0}'", ax));
                        try
                        {
                            Scarborough.ScarboroughText si = new Scarborough.ScarboroughText(sc);
                            si.InitXExpression = a._TextAuraXIniExpression;
                            si.InitYExpression = a._TextAuraYIniExpression;
                            si.InitWExpression = a._TextAuraWIniExpression;
                            si.InitHExpression = a._TextAuraHIniExpression;
                            si.InitOExpression = a._TextAuraOIniExpression;
                            si.UpdateXExpression = a._TextAuraXTickExpression;
                            si.UpdateYExpression = a._TextAuraYTickExpression;
                            si.UpdateWExpression = a._TextAuraWTickExpression;
                            si.UpdateHExpression = a._TextAuraHTickExpression;
                            si.UpdateOExpression = a._TextAuraOTickExpression;
                            si.TTLExpression = a._TextAuraTTLTickExpression;
                            FontStyle fs = FontStyle.Regular;
                            if ((a._TextAuraEffect & Action.TextAuraEffectEnum.Bold) != 0)
                            {
                                fs |= FontStyle.Bold;
                            }
                            if ((a._TextAuraEffect & Action.TextAuraEffectEnum.Italic) != 0)
                            {
                                fs |= FontStyle.Italic;
                            }
                            if ((a._TextAuraEffect & Action.TextAuraEffectEnum.Underline) != 0)
                            {
                                fs |= FontStyle.Underline;
                            }
                            if ((a._TextAuraEffect & Action.TextAuraEffectEnum.Strikeout) != 0)
                            {
                                fs |= FontStyle.Strikeout;
                            }
                            si.TextExpression = a._TextAuraExpression;
                            si.TextAlignment = a._TextAuraAlignment;
                            si.TextColor = ExpressionTextBox.ParseColor(
                                    ctx.EvaluateStringExpression(a.ActionContextLogger, ctx, a._TextAuraForegroundClInt),
                                    Color.Black);
                            si.OutlineColor = ExpressionTextBox.ParseColor(
                                    ctx.EvaluateStringExpression(a.ActionContextLogger, ctx, a._TextAuraOutlineClInt),
                                    Color.Empty);
                            si.UseOutline = si.OutlineColor != Color.Empty;
                            si.FontName = a._TextAuraFontName;
                            si.FontSize = a._TextAuraFontSize;
                            si.FontStyle = fs;
                            si.ctx = ctx;
                            si.BackgroundColor = ExpressionTextBox.ParseColor(
                                    ctx.EvaluateStringExpression(a.ActionContextLogger, ctx, a._TextAuraBackgroundClInt),
                                    Color.Transparent);
                            sc.Activate(ax, si);
                        }
                        catch (Exception ex)
                        {
                            FilteredAddToLog(DebugLevelEnum.Error, I18n.Translate("internal/Plugin/exacttextaura", "Exception '{0}' when activating text aura '{1}'", ex.Message, ax));
                        }
                    }
                    break;
                case Action.AuraOpEnum.DeactivateAura:
                    {
                        string ax = ctx.EvaluateStringExpression(a.ActionContextLogger, ctx, a._TextAuraName);
                        FilteredAddToLog(DebugLevelEnum.Info, I18n.Translate("internal/Plugin/deacttextaura", "Deactivating text aura '{0}'", ax));
                        sc.Deactivate(ax, Scarborough.Scarborough.ItemAction.ItemTypeEnum.Text);
                    }
                    break;
                case Action.AuraOpEnum.DeactivateAllAura:
                    {
                        FilteredAddToLog(DebugLevelEnum.Info, I18n.Translate("internal/Plugin/deactalltextaura", "Deactivating all text auras"));
                        sc.DeactivateAllText();
                    }
                    break;
                case Action.AuraOpEnum.DeactivateAuraRegex:
                    {
                        string ax = a._TextAuraName;
                        FilteredAddToLog(DebugLevelEnum.Info, I18n.Translate("internal/Plugin/deacttextaurarex", "Deactivating text auras matching '{0}'", ax));
                        sc.DeactivateRegex(ax, Scarborough.Scarborough.ItemAction.ItemTypeEnum.Text);
                    }
                    break;
                case Action.AuraOpEnum.DeactivateAuraTrigger:
                    {
                        FilteredAddToLog(DebugLevelEnum.Info, I18n.Translate("internal/Plugin/deacttextauratrig", "Deactivating text auras from trigger '{0}' ({1})", ctx.trig.LogName, ctx.trig.Id));
                        sc.DeactivateTrigger(ctx.trig, Scarborough.Scarborough.ItemAction.ItemTypeEnum.Text);
                    }
                    break;
            }
        }

        internal void LegacyTextAuraManagement(Context ctx, Action a)
        {
            if (mainform.InvokeRequired == true)
            {
                string ax = ctx.EvaluateStringExpression(a.ActionContextLogger, ctx, a._TextAuraName);
                FilteredAddToLog(DebugLevelEnum.Verbose, I18n.Translate("internal/Plugin/invoketextaura", "Invoke required for text aura '{0}'", ax));
                mainform.Invoke(new ActionExecutionHook(TextAuraManagement), ctx, a);
                return;
            }
            switch (a._TextAuraOp)
            {
                case Action.AuraOpEnum.ActivateAura:
                    {
                        string ax = ctx.EvaluateStringExpression(a.ActionContextLogger, ctx, a._TextAuraName);
                        FilteredAddToLog(DebugLevelEnum.Info, I18n.Translate("internal/Plugin/acttextaura", "Activating text aura '{0}'", ax));
                        Forms.AuraContainerForm acf = null;
                        bool newAura = false;
                        try
                        {
                            lock (ctx.plug.textauras)
                            {
                                if (ctx.plug.textauras.ContainsKey(ax) == true)
                                {
                                    acf = ctx.plug.textauras[ax];
                                }
                                else
                                {
                                    acf = new Forms.AuraContainerForm(Forms.AuraContainerForm.AuraTypeEnum.Text);
                                    acf.plug = this;
                                    acf.AuraName = ax;
                                    newAura = true;
                                }
                                acf.AuraPrepare();
                                acf.ctx = ctx;
                                acf.TextExpression = a._TextAuraExpression;
                                acf.TextAlignment = a._TextAuraAlignment;
                                acf.TextColor = ExpressionTextBox.ParseColor(
                                    ctx.EvaluateStringExpression(a.ActionContextLogger, ctx, a._TextAuraForegroundClInt),
                                    Color.Black);
                                acf.OutlineColor = ExpressionTextBox.ParseColor(
                                    ctx.EvaluateStringExpression(a.ActionContextLogger, ctx, a._TextAuraOutlineClInt),
                                    Color.Empty);
                                acf.UseOutline = acf.OutlineColor != Color.Empty;
                                if (acf.AuraFont != null)
                                {
                                    FontStyle fs = FontStyle.Regular;
                                    if ((a._TextAuraEffect & Action.TextAuraEffectEnum.Bold) != 0)
                                    {
                                        fs |= FontStyle.Bold;
                                    }
                                    if ((a._TextAuraEffect & Action.TextAuraEffectEnum.Italic) != 0)
                                    {
                                        fs |= FontStyle.Italic;
                                    }
                                    if ((a._TextAuraEffect & Action.TextAuraEffectEnum.Underline) != 0)
                                    {
                                        fs |= FontStyle.Underline;
                                    }
                                    if ((a._TextAuraEffect & Action.TextAuraEffectEnum.Strikeout) != 0)
                                    {
                                        fs |= FontStyle.Strikeout;
                                    }
                                    Font x = acf.AuraFont;
                                    if (x.Style != fs || x.Size != a._TextAuraFontSize || x.Name != a._TextAuraFontName)
                                    {
                                        x.Dispose();
                                        acf.AuraFont = null;
                                    }
                                }
                                if (acf.AuraFont == null)
                                {
                                    FontStyle fs = FontStyle.Regular;
                                    if ((a._TextAuraEffect & Action.TextAuraEffectEnum.Bold) != 0)
                                    {
                                        fs |= FontStyle.Bold;
                                    }
                                    if ((a._TextAuraEffect & Action.TextAuraEffectEnum.Italic) != 0)
                                    {
                                        fs |= FontStyle.Italic;
                                    }
                                    if ((a._TextAuraEffect & Action.TextAuraEffectEnum.Underline) != 0)
                                    {
                                        fs |= FontStyle.Underline;
                                    }
                                    if ((a._TextAuraEffect & Action.TextAuraEffectEnum.Strikeout) != 0)
                                    {
                                        fs |= FontStyle.Strikeout;
                                    }
                                    float ex = a._TextAuraFontSize;
                                    if (ex < 1)
                                    {
                                        ex = 1;
                                    }
                                    acf.AuraFont = new Font(a._TextAuraFontName, ex, fs, GraphicsUnit.Point);
                                }
                                acf.BackgroundColor = ExpressionTextBox.ParseColor(
                                    ctx.EvaluateStringExpression(a.ActionContextLogger, ctx, a._TextAuraBackgroundClInt),
                                    Color.Transparent);
                                if (acf.BackgroundColor == Color.Transparent)
                                {
                                    acf.BackColor = acf.TransparencyKey;
                                }
                                acf.Left = acf.EvaluateNumericExpression(ctx, a._TextAuraXIniExpression);
                                acf.Top = acf.EvaluateNumericExpression(ctx, a._TextAuraYIniExpression);
                                int i = acf.EvaluateNumericExpression(ctx, a._TextAuraWIniExpression);
                                if (i < 0)
                                {
                                    i = 0;
                                }
                                acf.Width = i;
                                if (i < 0)
                                {
                                    i = 0;
                                }
                                i = acf.EvaluateNumericExpression(ctx, a._TextAuraHIniExpression);
                                if (i < 0)
                                {
                                    i = 0;
                                }
                                acf.Height = i;
                                i = acf.EvaluateNumericExpression(ctx, a._TextAuraOIniExpression);
                                if (i < 0)
                                {
                                    i = 0;
                                }
                                if (i > 100)
                                {
                                    i = 100;
                                }
                                acf.PresentableOpacity = i;
                                acf.XExpression = a._TextAuraXTickExpression;
                                acf.YExpression = a._TextAuraYTickExpression;
                                acf.WExpression = a._TextAuraWTickExpression;
                                acf.HExpression = a._TextAuraHTickExpression;
                                acf.OExpression = a._TextAuraOTickExpression;
                                acf.TTLExpression = a._TextAuraTTLTickExpression;
                                acf.AuraActivate();
                                if (newAura == true)
                                {
                                    ctx.plug.textauras[ax] = acf;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            FilteredAddToLog(DebugLevelEnum.Error, I18n.Translate("internal/Plugin/exacttextaura", "Exception '{0}' when activating text aura '{1}'", ex.Message, ax));
                            if (acf != null)
                            {
                                if (newAura == true)
                                {
                                    acf.Dispose();
                                }
                                else
                                {
                                    acf.AuraDeactivate();
                                }
                            }
                        }
                    }
                    break;
                case Action.AuraOpEnum.DeactivateAura:
                    {
                        string ax = ctx.EvaluateStringExpression(a.ActionContextLogger, ctx, a._TextAuraName);
                        FilteredAddToLog(DebugLevelEnum.Info, I18n.Translate("internal/Plugin/deacttextaura", "Deactivating text aura '{0}'", ax));
                        lock (ctx.plug.textauras)
                        {
                            if (ctx.plug.textauras.ContainsKey(ax) == true)
                            {
                                Forms.AuraContainerForm acf = ctx.plug.textauras[ax];
                                acf.AuraDeactivate();
                            }
                        }
                    }
                    break;
                case Action.AuraOpEnum.DeactivateAllAura:
                    {
                        FilteredAddToLog(DebugLevelEnum.Info, I18n.Translate("internal/Plugin/deactalltextaura", "Deactivating all text auras"));
                        while (true)
                        {
                            lock (ctx.plug.textauras)
                            {
                                if (ctx.plug.textauras.Count > 0)
                                {
                                    Forms.AuraContainerForm acf = ctx.plug.textauras.ElementAt(0).Value;
                                    acf.AuraDeactivate();
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                    }
                    break;
                case Action.AuraOpEnum.DeactivateAuraRegex:
                    {
                        Regex rex = new Regex(a._TextAuraName);
                        FilteredAddToLog(DebugLevelEnum.Info, I18n.Translate("internal/Plugin/deacttextaurarex", "Deactivating text auras matching '{0}'", a._TextAuraName));
                        List<string> toRem = new List<string>();
                        lock (ctx.plug.textauras)
                        {
                            toRem.AddRange(from sx in ctx.plug.textauras where rex.IsMatch(sx.Key) select sx.Key);
                            foreach (string rem in toRem)
                            {
                                Forms.AuraContainerForm acf = ctx.plug.textauras[rem];
                                acf.AuraDeactivate();
                            }
                        }
                    }
                    break;
                case Action.AuraOpEnum.DeactivateAuraTrigger:
                    {
                        FilteredAddToLog(DebugLevelEnum.Info, I18n.Translate("internal/Plugin/deacttextauratrig", "Deactivating text auras from trigger '{0}' ({1})", ctx.trig.LogName, ctx.trig.Id));
                        List<string> toRem = new List<string>();
                        lock (ctx.plug.textauras)
                        {
                            toRem.AddRange(from sx in ctx.plug.textauras where sx.Value.ctx.trig == ctx.trig select sx.Key);
                            foreach (string rem in toRem)
                            {
                                Forms.AuraContainerForm acf = ctx.plug.textauras[rem];
                                acf.AuraDeactivate();
                            }
                        }
                    }
                    break;
            }
        }

        internal void RemoveAurasFromTrigger(Trigger t)
        {
            Context fakectx = new Context();
            fakectx.plug = this;
            fakectx.trig = t;
            Action a = new Action();
            a._AuraOp = Action.AuraOpEnum.DeactivateAuraTrigger;
            a._TextAuraOp = Action.AuraOpEnum.DeactivateAuraTrigger;
            ImageAuraManagement(fakectx, a);
            TextAuraManagement(fakectx, a);
        }
    }
}
