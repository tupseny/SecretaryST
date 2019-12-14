using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static SecretaryST.Settings.StartProtOptions;
using static System.Windows.Forms.CheckedListBox;

namespace SecretaryST.Forms
{
    public partial class StartProtocolOptions : Form
    {
        public StartProtocolOptions()
        {
            InitializeComponent();
            InitData();

            butSave.Click += ButSave_Click;
        }

        private void ButSave_Click(object sender, EventArgs e)
        {
            CheckedItemCollection checkedItems1 = HeadersCheckedListGroup1.CheckedItems;
            CheckedItemCollection checkedItems2 = HeadersCheckedListGroup2.CheckedItems;
            CheckedItemCollection checkedItems4 = HeadersCheckedListGroup4.CheckedItems;

            Settings.StartProtOptions.StartProtGroup1.ChoosedHeaders = saveStartProtHeaders(checkedItems1);
            Settings.StartProtOptions.StartProtGroup2.ChoosedHeaders = saveStartProtHeaders(checkedItems2);
            Settings.StartProtOptions.StartProtGroup4.ChoosedHeaders = saveStartProtHeaders(checkedItems4);

            Settings.StartProtOptions.save();

            this.Close();

            List<string> saveStartProtHeaders(CheckedItemCollection checkedItemCollection)
            {
                List<string> choosedHeaders = new List<string>();

                foreach (object item in checkedItemCollection)
                {
                    if (Settings.StartProtOptions.TryGetHeader((string)item, out Header header))
                    {
                        choosedHeaders.Add(header.ShortName);
                    }
                }

                return choosedHeaders;
            }
        }

        private void InitData()
        {
            HeadersCheckedListGroup1.Items.AddRange(Settings.StartProtOptions.StartProtGroup1.ReadableHeadersArray());
            HeadersCheckedListGroup2.Items.AddRange(Settings.StartProtOptions.StartProtGroup2.ReadableHeadersArray());
            HeadersCheckedListGroup4.Items.AddRange(Settings.StartProtOptions.StartProtGroup4.ReadableHeadersArray());

            setChecked(HeadersCheckedListGroup1, Settings.StartProtOptions.StartProtGroup1.ReadableChoosedHeadersList());
            setChecked(HeadersCheckedListGroup2, Settings.StartProtOptions.StartProtGroup2.ReadableChoosedHeadersList());
            setChecked(HeadersCheckedListGroup4, Settings.StartProtOptions.StartProtGroup4.ReadableChoosedHeadersList());

            void setChecked(CheckedListBox box, List<string> toCheck)
            {
                int count = box.Items.Count;
                for (int i = 0; i < count; i++)
                {
                    string val = (string)box.Items[i];
                    if (toCheck.Contains(val))
                    {
                        box.SetItemChecked(i, true);
                    }
                    else
                    {
                        box.SetItemChecked(i, false);
                    }
                }
            }
        }

        protected override void OnDeactivate(EventArgs e)
        {
            base.OnDeactivate(e);

            this.Activate();
        }
    }
}
