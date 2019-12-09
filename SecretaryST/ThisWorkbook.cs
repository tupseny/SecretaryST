using SecretaryST.SheetGenerators;
using System.Collections.Generic;

namespace SecretaryST
{
    public partial class ThisWorkbook
    {
        private void ThisWorkbook_Startup(object sender, System.EventArgs e)
        {
        }

        private void ThisWorkbook_Shutdown(object sender, System.EventArgs e)
        {
        }

        #region Код, созданный конструктором VSTO

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InternalStartup()
        {
            this.Startup += new System.EventHandler(ThisWorkbook_Startup);
            this.Shutdown += new System.EventHandler(ThisWorkbook_Shutdown);
        }

        #endregion

        public static void StartProtocol1()
        {
            List<Dictionary<string, object>> tempList = new List<Dictionary<string, object>>()
            {
                new Dictionary<string, object>{ { "asd", "asd" } }
            };

            StartProtocolGenerator generator = new StartProtocolGenerator(Enums.DistanceGroupAmount.One);
            generator.Create(tempList);
        }
    }
}
