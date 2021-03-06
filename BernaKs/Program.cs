﻿using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace BernaKs
{
    class TutorialProgramHandler
    {
        private Process m_tutorialProcess;

        public TutorialProgramHandler()
        {
            m_tutorialProcess = new Process();
            m_tutorialProcess.StartInfo.CreateNoWindow = true;
            m_tutorialProcess.StartInfo.UseShellExecute = false;
            m_tutorialProcess.StartInfo.RedirectStandardOutput = true;

            m_tutorialProcess.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            m_tutorialProcess.StartInfo.Arguments = "--test"; // dont create window
            m_tutorialProcess.StartInfo.FileName = System.IO.Directory.GetCurrentDirectory() + @"\..\..\..\..\Debug\TutorialApp.exe";

            m_tutorialProcess.Start();
        }

        ~TutorialProgramHandler()
        {
            try
            {
                m_tutorialProcess.Kill();
            }
            catch { Console.WriteLine("Cannot kill tutorial process. might already be dead."); }
        }
    }

    static class Program
    {
        [STAThread]
        static void Main()
        {
            // TutorialProgramHandler tutorial = new TutorialProgramHandler();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
