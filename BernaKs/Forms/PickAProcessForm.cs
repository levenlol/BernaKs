using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BernaKs
{
    public partial class PickAProcessForm : Form
    {
        public PickAProcessForm()
        {
            InitializeComponent();

            FillList();
        }

        private void FillList()
        {
            List<Process> processes = BMemory.GetAllProcresses(true);

            foreach (Process process in processes)
            {
                string name = process.ProcessName;
                string id   = process.Id.ToString();

                ListViewItem lvi = new ListViewItem(name);
                lvi.SubItems.Add(id);

                listView1.Items.Add(lvi);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListViewItem Selected = listView1.SelectedItems[0];
            int processID = int.Parse(Selected.SubItems[1].Text);

            MainForm mainForm = (MainForm)Application.OpenForms[0];
            mainForm.RequestBindToProcess(this, processID);

            Close();
        }
    }
}
