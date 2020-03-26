using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triggernometry.Aura
{

    abstract class Aura : IDisposable
    {

        internal Int64 Ordinal { get; set; }

        internal Renderer.RendererBase Renderer { get; set; }

        internal string Name { get; set; }
        internal string InitXExpression { get; set; }
        internal string InitYExpression { get; set; }
        internal string InitWExpression { get; set; }
        internal string InitHExpression { get; set; }
        internal string InitOExpression { get; set; }
        internal string UpdateXExpression { get; set; }
        internal string UpdateYExpression { get; set; }
        internal string UpdateWExpression { get; set; }
        internal string UpdateHExpression { get; set; }
        internal string UpdateOExpression { get; set; }
        internal string TTLExpression { get; set; }
        internal Triggernometry.Context ctx { get; set; }
        internal Triggernometry.RealPlugin plug { get; set; }

        internal bool Changed { get; set; }

        private int _Left;
        internal int Left
        {
            get
            {
                return _Left;
            }
            set
            {
                if (value != _Left)
                {
                    Changed = true;
                    _Left = value;
                }
            }
        }

        private int _Top;
        internal int Top
        {
            get
            {
                return _Top;
            }
            set
            {
                if (value != _Top)
                {
                    Changed = true;
                    _Top = value;
                }
            }
        }

        private int _Width;
        internal int Width
        {
            get
            {
                return _Width;
            }
            set
            {
                if (value != _Width)
                {
                    Changed = true;
                    _Width = value;
                }
            }
        }

        private int _Height;
        internal int Height
        {
            get
            {
                return _Height;
            }
            set
            {
                if (value != _Height)
                {
                    Changed = true;
                    _Height = value;
                }
            }
        }

        private int _Opacity;
        internal int Opacity
        {
            get
            {
                return _Opacity;
            }
            set
            {
                if (value != _Opacity)
                {
                    Changed = true;
                    _Opacity = value;
                }
            }
        }

        virtual public void Dispose()
        {
            if (Renderer != null)
            {
                Renderer.Dispose();
                Renderer = null;
            }
        }

        private string PreprocessExpression(string exp)
        {
            exp = exp.Replace("${_x}", Left.ToString());
            exp = exp.Replace("${_y}", Top.ToString());
            exp = exp.Replace("${_width}", Width.ToString());
            exp = exp.Replace("${_height}", Height.ToString());
            exp = exp.Replace("${_opacity}", Opacity.ToString());
            return exp;
        }

        internal int EvaluateNumericExpression(Triggernometry.Context c, string exp)
        {
            return (int)c.EvaluateNumericExpression((c.trig != null) ? c.trig.TriggerContextLogger : (Triggernometry.Context.LoggerDelegate)null, c.plug, PreprocessExpression(exp));
        }

        internal string EvaluateStringExpression(Triggernometry.Context c, string exp)
        {
            return c.EvaluateStringExpression((c.trig != null) ? c.trig.TriggerContextLogger : (Triggernometry.Context.LoggerDelegate)null, c.plug, PreprocessExpression(exp));
        }

        internal void Render()
        {
            if (Renderer != null)
            {
                Renderer.Render(this);
            }
        }

        public bool GenericLogic()
        {
            if (UpdateXExpression != null && UpdateXExpression.Length > 0)
            {
                Left = EvaluateNumericExpression(ctx, UpdateXExpression);
            }
            if (UpdateYExpression != null && UpdateYExpression.Length > 0)
            {
                Top = EvaluateNumericExpression(ctx, UpdateYExpression);
            }
            if (UpdateWExpression != null && UpdateWExpression.Length > 0)
            {
                int newval = EvaluateNumericExpression(ctx, UpdateWExpression);
                if (newval < 0)
                {
                    newval = 0;
                }
                Width = newval;
            }
            if (UpdateHExpression != null && UpdateHExpression.Length > 0)
            {
                int newval = EvaluateNumericExpression(ctx, UpdateHExpression);
                if (newval < 0)
                {
                    newval = 0;
                }
                Height = newval;
            }
            if (UpdateOExpression != null && UpdateOExpression.Length > 0)
            {
                int newval = EvaluateNumericExpression(ctx, UpdateOExpression);
                if (newval < 0)
                {
                    newval = 0;
                }
                if (newval > 100)
                {
                    newval = 100;
                }
                Opacity = newval;
            }
            if (TTLExpression != null && TTLExpression.Length > 0)
            {
                if (EvaluateNumericExpression(ctx, TTLExpression) < 0)
                {
                    if (ctx.trig != null)
                    {
                        ctx.trig.AddToLog(plug, Triggernometry.RealPlugin.DebugLevelEnum.Verbose, Triggernometry.I18n.Translate("internal/AuraContainer/deactaurattl", "Deactivating aura due to TTL expression"));
                    }
                    else
                    {
                        plug.FilteredAddToLog(Triggernometry.RealPlugin.DebugLevelEnum.Verbose, Triggernometry.I18n.Translate("internal/AuraContainer/deactaurattl", "Deactivating aura due to TTL expression"));
                    }
                    return false;
                }
            }
            return true;
        }

        public bool Logic(int numTicks)
        {
            try
            {
                return InternalLogic(numTicks);
            }
            catch (Exception ex)
            {
                if (ctx.trig != null)
                {
                    ctx.trig.AddToLog(plug, Triggernometry.RealPlugin.DebugLevelEnum.Error, Triggernometry.I18n.Translate("internal/AuraContainer/updateerror", String.Format("Deactivating aura '{0}' from trigger '{1}' due to update exception: {2}", Name, ctx.trig.LogName, ex.Message)));
                }
                else
                {
                    plug.FilteredAddToLog(Triggernometry.RealPlugin.DebugLevelEnum.Error, Triggernometry.I18n.Translate("internal/AuraContainer/updateerror", String.Format("Deactivating aura '{0}' due to update exception: {1}", Name, ex.Message)));
                }
                return false;
            }
        }

        virtual internal bool InternalLogic(int numTicks)
        {
            while (numTicks > 0)
            {
                if (GenericLogic() == false)
                {
                    return false;
                }
                numTicks--;
            }
            return true;
        }

    }

}
