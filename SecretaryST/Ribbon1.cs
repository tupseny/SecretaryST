using Microsoft.Office.Tools.Ribbon;

namespace SecretaryST
{
    public partial class SecretaryRibbon
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
            this.importBut.Click += (s, ev) => Заявка.ImportToBase();
        }
    }

   
}
