using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triggernometry.Aura.Renderer
{

    sealed internal class WinformsRenderer : RendererBase
    {

        internal class WinformsState : RendererState
        {

            Forms.AuraContainerForm acf = null;

            public override void Dispose()
            {
                CloseForm();
            }

            private void CloseForm()
            {
                if (acf != null)
                {
                    acf.Close();
                    acf.Dispose();
                    acf = null;
                }
            }

            internal void Initialize(Aura a)
            {
                if (a is AuraImage)
                {
                    acf = new Forms.AuraContainerForm(Forms.AuraContainerForm.AuraTypeEnum.Image);
                }
                if (a is AuraText)
                {
                    acf = new Forms.AuraContainerForm(Forms.AuraContainerForm.AuraTypeEnum.Text);
                }
                acf.plug = a.ctx.plug;
                acf.AuraName = a.Name;
                acf.AuraPrepare();
                acf.ctx = a.ctx;
            }

        }

        public WinformsRenderer()
        {
        }

        public override void Dispose()
        {
        }

        internal override void Initialize(Aura a)
        {
            if (a.State != null)
            {
                a.State.Dispose();
                a.State = null;
            }
            WinformsState s = new WinformsState();
            s.Initialize(a);
            a.State = s;
        }

        internal override void RenderImage(AuraImage a)
        {
        }

        internal override void RenderText(AuraText a)
        {
        }

    }

}
