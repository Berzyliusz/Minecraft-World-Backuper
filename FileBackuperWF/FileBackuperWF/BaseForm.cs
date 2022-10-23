using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FileBackuperWF
{
    public partial class BaseForm : Form
    {
        public BaseForm()
        {
            InitializeComponent();
        }

        public ButtonAndBox AddWorldsToRestoreElements()
        {
            AddWorldsLabel("Choose World to restore", new Point(500, 29), new Size(150, 21));
            var box =  AddWorldsComboBox(Data.BACKUP_PATH, new Point(500, 54), new Size(150, 21));
            var button = AddButton("Restore World", new Point(500, 80), new Size(150, 21));
            return new ButtonAndBox(button, box);
        }

        public ButtonAndBox AddWorldsToBackupElements()
        {
            AddWorldsLabel("Choose World to backup", new Point(50, 29), new Size(150, 21));
            var box = AddWorldsComboBox(Data.WORLD_PATH, new Point(50, 54), new Size(150, 21));
            var button = AddButton("Backup World", new Point(50, 80), new Size(150, 21));
            return new ButtonAndBox(button, box);
        }

        Button AddButton(string buttonText, Point location, Size size)
        {
            Button button = new Button();
            button.Location = location;
            button.Size = size;
            button.Text = buttonText;
            this.Controls.Add(button);

            return button;
        }

        void AddWorldsLabel(string labelText, Point location, Size size)
        {
            Label worldsLabel = new Label();
            worldsLabel.Text = labelText;
            worldsLabel.Location = location;
            worldsLabel.Size = size;
            this.Controls.Add(worldsLabel);
        }

        ComboBox AddWorldsComboBox(string path, Point location, Size size)
        {
            ComboBox box = new ComboBox();
            box.Location = location;
            box.Size = size;
            box.Name = "World_choice_combo_box";

            var di = new DirectoryInfo(path);
            var directoryInfos = di.GetDirectories();

            foreach (var directory in directoryInfos)
            {
                box.Items.Add(directory.Name);
            }

            box.SelectedIndex = 0;
            this.Controls.Add(box);
            return box;
        }
    }
}
