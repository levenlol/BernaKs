using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BernaKs.Utils;

namespace BernaKs
{
    public partial class QueryMemoryForm : Form
    {
        public QueryMemoryForm()
        {
            InitializeComponent();

            FillDataPicker();
            FillRoundPicker();
        }

        private void FillDataPicker()
        {
            foreach (MemoryDataType memoryType in (MemoryDataType[]) Enum.GetValues(typeof(MemoryDataType)))
            {
                string memoryTypeStr = FlagsUtility.MemoryDataTypeToStr(memoryType);
                dataPickerBox.Items.Add(memoryTypeStr);
            }

            dataPickerBox.SelectedIndex = 4;
        }

        private void FillRoundPicker()
        {
            foreach(string s in Enum.GetNames(typeof(RoundType)))
            {
                roundComboBox.Items.Add(s);
            }

            roundComboBox.SelectedIndex = 0;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if(valueToQueryTextBox.Text.Length == 0)
            {
                MessageBox.Show("Missing value to query", "Value missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MainForm form = (MainForm)Application.OpenForms[0];

            MemoryDataType memoryType = ((MemoryDataType[])Enum.GetValues(typeof(MemoryDataType)))[dataPickerBox.SelectedIndex];
            RoundType roundType = ((RoundType[])Enum.GetValues(typeof(RoundType)))[roundComboBox.SelectedIndex];

            try
            {
                form.SetMemoryDataType(memoryType, roundType, BitConverter.GetBytes(int.Parse(valueToQueryTextBox.Text)));
                Close();
            }
            catch
            {
                MessageBox.Show("Invalid value", "Invalid value", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
