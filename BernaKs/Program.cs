using System;
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
            m_tutorialProcess.StartInfo.FileName = System.IO.Directory.GetCurrentDirectory() + @"\..\..\..\..\x64\Debug\TutorialApp.exe";

            m_tutorialProcess.Start();
        }

        ~TutorialProgramHandler()
        {
            if(!m_tutorialProcess.HasExited)
            {
                m_tutorialProcess.Kill();
            }
        }
    }

    static class Program
    {
        [STAThread]
        static void Main()
        {
            TutorialProgramHandler tutorial = new TutorialProgramHandler();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}
