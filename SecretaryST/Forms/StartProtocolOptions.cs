using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static SecretaryST.Settings.StartProtOptions;
using static SecretaryST.Settings.StartProtOptions.StartProt;
using static System.Windows.Forms.CheckedListBox;

namespace SecretaryST.Forms
{
    public partial class StartProtocolOptions : Form
    {
        public StartProtocolOptions()
        {
            InitializeComponent();
            initData();

            butSave.Click += ButSave_Click;
        }

        private void ButSave_Click(object sender, EventArgs e)
        {
            //group 1
            CheckedItemCollection checkedItems = HeadersCheckedList.CheckedItems;

            Settings.StartProtOptions.StartProtGroup1.Headers = saveStartProtHeaders(checkedItems, Settings.StartProtOptions.StartProtMain);

            List<Header> saveStartProtHeaders(CheckedItemCollection checkedItemCollection, StartProt startProt)
            {
                List<Header> choosedHeaders = new List<Header>();
                foreach (object item in checkedItemCollection)
                {
                    if (startProt.TryGetHeader((string)item, out Header header, false))
                    {
                        choosedHeaders.Add(header);
                    }
                }

                return choosedHeaders;
            }
        }

        private void initData()
        {
            List<object> lData = new List<object>();
            foreach (Header item in Settings.StartProtOptions.StartProtMain.Headers)
            {
                lData.Add(item.ReadableName);
            }

            object[] aData = new object[lData.Count];
            lData.CopyTo(aData);
            HeadersCheckedList.Items.AddRange(aData);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
