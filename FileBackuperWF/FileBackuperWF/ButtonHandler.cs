using System;

namespace FileBackuperWF
{
    public class ButtonHandler
    {
        readonly ButtonAndBox backupElements;
        readonly ButtonAndBox restoreElements;

        public ButtonHandler(ButtonAndBox backupElements, ButtonAndBox restoreElements)
        {
            this.backupElements = backupElements;
            this.restoreElements = restoreElements;
            backupElements.Button.MouseClick += OnButtonBackupButtonClicked;
            restoreElements.Button.MouseClick += OnButtonRestoreButtonClicked;
        }

        public void OnButtonBackupButtonClicked(object sender, EventArgs e)
        {
            var chosenItem = backupElements.Box.SelectedItem.ToString();
            Saver.SaveBackup(chosenItem);
        }

        public void OnButtonRestoreButtonClicked(object sender, EventArgs e)
        {
            var chosenItem = restoreElements.Box.SelectedItem.ToString();
            Saver.RestoreBackup(chosenItem);
        }
    }
}
