using BernaKs.Memory;
using BernaKs.Utils;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace BernaKs
{
    public partial class MainForm : Form
    {
        private BMemory m_memory;
        private MemoryNavigator m_MemoryNavigator;

        public MainForm()
        {
            m_memory = null;

            InitializeComponent();
            ResetUI();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PickAProcessForm pickProcessForm = new PickAProcessForm();
            pickProcessForm.ShowDialog();
        }

        public void RequestBindToProcess(Object sender, int processID)
        {
            if(IsMemoryObjectValid())
            {
                m_memory.Release();
            }

            m_memory = new BMemory(processID);
            ResetUI();
        }

        private void BuildMemoryGridView(ref List<IntPtr> ValueAddresses, int value, byte[] rawData)
        {
            // #todo only int supported
            string[][] rows = new string[ValueAddresses.Count][];
            for (int i = 0; i < ValueAddresses.Count; i++)
            {
                rows[i] = new string[] { "0x" + ValueAddresses[i].ToInt64().ToString("X16"), value.ToString(), Encoding.Default.GetString(rawData) };
            }

            memoryDataGridView.Rows.Clear();

            foreach (string[] row in rows)
            {
                memoryDataGridView.Rows.Add(row);
            }
        }

        public void SetMemoryDataType(MemoryDataType memoryType, RoundType roundType, byte[] data)
        {
            // #todo we are just using byte data for now.

            Dictionary<IntPtr, byte[]> dictionary;
            m_memory.ReadMemory(out dictionary);

            List<IntPtr> ValueAddresses = new List<IntPtr>();
            m_MemoryNavigator = new MemoryNavigator(dictionary);
            ValueAddresses = m_MemoryNavigator.GetAddressOfValue(data);

            BuildMemoryGridView(ref ValueAddresses, BitConverter.ToInt32(data, 0), data);
        }

        private void ResetUI()
        {
            HandleProcessUtilisWidgets();

            ResetProcessName();
        }

        private void HandleProcessUtilisWidgets()
        {
            bool showWidgets = IsMemoryObjectValid();

            layoutProcessHandle.Visible = showWidgets;
            queryMemoryButton.Visible = showWidgets;
        }

        private void ResetProcessName()
        {
            if(!IsMemoryObjectValid())
            {
                textBox2.Text = "None";
                return;
            }

            textBox2.Text = m_memory.GetProcessName();
        }

        private bool IsMemoryObjectValid()
        {
            return m_memory != null && m_memory.IsBound();
        }

        private void queryMemoryButton_Click(object sender, EventArgs e)
        {
            if (!IsMemoryObjectValid())
                return;

            QueryMemoryForm queryForm = new QueryMemoryForm();
            queryForm.ShowDialog();
        }

        private void memoryDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int columnIndex = e.ColumnIndex;
            int rowIndex = e.RowIndex;

            string addressStr = memoryDataGridView.Rows[rowIndex].Cells["Address"].Value.ToString();
            IntPtr address = new IntPtr(Convert.ToInt64(addressStr, 16));

            try
            {
                string valueStr = memoryDataGridView.Rows[rowIndex].Cells["Value"].Value.ToString();
                int value = int.Parse(valueStr);

                if (m_memory.WriteMemory(address, BitConverter.GetBytes(value)))
                {
                    Console.WriteLine("Memory written.");
                }
            }
            catch
            {
                MessageBox.Show("Invalid data", "value type cannot be written", MessageBoxButtons.OK, MessageBoxIcon.Error);

                byte[] buffer;
                m_memory.ReadMemoryAt(address.ToInt64(), 4, out buffer);

                memoryDataGridView.Rows[rowIndex].Cells["Value"].Value = BitConverter.ToInt32(buffer, 0);
            }
        }
    }
}
