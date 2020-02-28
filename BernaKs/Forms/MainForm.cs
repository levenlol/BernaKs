using BernaKs.Utils;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace BernaKs
{
    public partial class MainForm : Form
    {
        private BMemory m_memory;

        public MainForm()
        {
            m_memory = null;

            InitializeComponent();
            ResetUI();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PickAProcessForm pickProcessForm = new PickAProcessForm();
            pickProcessForm.Show();
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

        public void SetMemoryDataType(MemoryDataType memoryType, RoundType roundType)
        {
            int dataSize = FlagsUtility.GetMemoryDataSize(memoryType);

            switch (memoryType)
            {
                case MemoryDataType.Byte_1:
                    break;
                case MemoryDataType.Byte_2:
                    break;
                case MemoryDataType.Byte_4:
                    break;
                case MemoryDataType.Byte_8:
                    break;
                case MemoryDataType.Integer:
                    break;
                case MemoryDataType.Float:
                    break;
                case MemoryDataType.Double:
                    break;
            }
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
            queryForm.Show();
        }
    }
}
