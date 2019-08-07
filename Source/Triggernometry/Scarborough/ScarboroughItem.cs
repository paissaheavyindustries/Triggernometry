using Scarborough.Drawing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scarborough
{

    abstract class ScarboroughItem : IDisposable
    {

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
        internal Triggernometry.Plugin plug { get; set; }

        internal int Left { get; set; }
        internal int Top { get; set; }
        internal int Width { get; set; }
        internal int Height { get; set; }
        internal int Opacity { get; set; }

        internal int FinalOffsetX
        {
            get
            {
                return Owner._offsetX;
            }
        }

        internal int FinalOffsetY
        {
            get
            {
                return Owner._offsetY;
            }
        }

        internal Scarborough Owner { get; set; }

        public abstract void Free();
        public abstract void Render(Graphics g);
        public abstract bool InternalLogic(int numTicks);

        public void Dispose()
        {
            Free();
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
                Width = EvaluateNumericExpression(ctx, UpdateWExpression);
                if (Width < 0)
                {
                    Width = 0;
                }
            }
            if (UpdateHExpression != null && UpdateHExpression.Length > 0)
            {
                Height = EvaluateNumericExpression(ctx, UpdateHExpression);
                if (Height < 0)
                {
                    Height = 0;
                }
            }
            if (UpdateOExpression != null && UpdateOExpression.Length > 0)
            {
                Opacity = EvaluateNumericExpression(ctx, UpdateOExpression);
                if (Opacity < 0)
                {
                    Opacity = 0;
                }
                if (Opacity > 100)
                {
                    Opacity = 100;
                }
            }
            if (TTLExpression != null && TTLExpression.Length > 0)
            {
                if (EvaluateNumericExpression(ctx, TTLExpression) < 0)
                {
                    if (ctx.trig != null)
                    {
                        ctx.trig.AddToLog(plug, Triggernometry.Plugin.DebugLevelEnum.Verbose, Triggernometry.I18n.Translate("internal/AuraContainer/deactaurattl", "Deactivating aura due to TTL expression"));
                    }
                    else
                    {
                        plug.FilteredAddToLog(Triggernometry.Plugin.DebugLevelEnum.Verbose, Triggernometry.I18n.Translate("internal/AuraContainer/deactaurattl", "Deactivating aura due to TTL expression"));
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
                    ctx.trig.AddToLog(plug, Triggernometry.Plugin.DebugLevelEnum.Error, Triggernometry.I18n.Translate("internal/AuraContainer/updateerror", String.Format("Deactivating aura due to update exception: {0}", ex.Message)));
                }
                else
                {
                    plug.FilteredAddToLog(Triggernometry.Plugin.DebugLevelEnum.Error, Triggernometry.I18n.Translate("internal/AuraContainer/updateerror", String.Format("Deactivating aura due to update exception: {0}", ex.Message)));
                }
                return false;
            }
        }

    }

}
