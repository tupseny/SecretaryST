using Microsoft.Office.Tools.Ribbon;

namespace SecretaryST
{
    public partial class SecretaryRibbon
    {
        private void Ribbon1_Load(object sender, RibbonUIEventArgs e)
        {
            this.importBut.Click += (s, ev) =>
            {
                Заявка.ImportToBase();
                this.numOfPersons.Label = База.NumEntries.ToString();
                if (База.NumEntries > 0)
                {
                    StartProtSetEnabled(true);
                }
            };

            //start protocol management
            this.startProt1.Click += (s, ev) => ThisWorkbook.StartProtocol1Generate();
            this.startProt2.Click += (s, ev) => ThisWorkbook.StartProtocol2Generate();
            this.startProt4.Click += (s, ev) => ThisWorkbook.StartProtocol4Generate();

            StartProtSetEnabled(false);
            this.numOfPersons.Label = "База пустая!";
            this.numOfPersons.ScreenTip = "Кол-во значений в базе";

            //main management
            this.removeOtherSheets.Click += (s, ev) => ThisWorkbook.RemoveOtherSheets();
            this.visualEffectsToggle.Click += (s, ev) => EnableVisualEffects(this.visualEffectsToggle.Checked);
            this.butOptions.Click += (s, ev) => new Forms.StartProtocolOptions().ShowDialog();


        }

        private void StartProtSetEnabled(bool visible)
        {
            this.startProt1.Enabled = visible;
            this.startProt2.Enabled = visible;
            this.startProt4.Enabled = visible;
        }

        private void EnableVisualEffects(bool isEnable = true)
        {
            Globals.Options.enableVisualEffects = isEnable;
        }
    }


}
