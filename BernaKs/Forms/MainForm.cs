using BernaKs.Memory;
using BernaKs.Utils;
using System;
using System.Collections.Generic;
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
            // keep locally for now
            //int dataSize = FlagsUtility.GetMemoryDataSize(memoryType);

            // #todo use params

            Dictionary<IntPtr, byte[]> dictionary;

            m_memory.ReadMemory(out dictionary);

            byte[] buffer;
            if(m_memory.ReadMemoryAt(0x00007FF739160000, 4, out buffer))
            {
                int val = BitConverter.ToInt32(buffer, 0);
            }

            m_MemoryNavigator = new MemoryNavigator(dictionary);
            var l = m_MemoryNavigator.GetAddressOfValue(12345);
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
