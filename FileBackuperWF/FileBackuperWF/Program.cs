using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileBackuperWF
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var baseForm = new BaseForm();
            var backupElements = baseForm.AddWorldsToBackupElements();
            var restoreElements = baseForm.AddWorldsToRestoreElements();
            ButtonHandler handler = new ButtonHandler(backupElements, restoreElements);

            Application.Run(baseForm);            
        }
    }
}
