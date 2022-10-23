using System.Windows.Forms;

namespace FileBackuperWF
{
    public struct ButtonAndBox
    {
        public Button Button;
        public ComboBox Box;

        public ButtonAndBox(Button button, ComboBox box)
        {
            this.Button = button;
            this.Box = box;
        }
    }
}
