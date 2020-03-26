using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Triggernometry.Aura.Renderer
{

    sealed internal class Winforms : RendererBase
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

        internal override void Initialize(Aura a)
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

        internal override void Render(Aura a)
        {
        }

    }

}
