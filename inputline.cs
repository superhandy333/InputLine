/* Tools      Kleine Helferlein vom Superhandy
 * -------------------------------------------
 * Anwendung: Testanwendung
 * Datei:     inputline.cs
 * Version:   29.01.2013
 * Besitzer:  Mathias Rentsch (rentsch@online.de)
 * Lizenz:    GPL
 *
 * Die Anwendung und die Quelltextdateien sind freie Software und stehen unter der
 * GNU General Public License. Der Originaltext dieser Lizenz kann eingesehen werden
 * unter http://www.gnu.org/licenses/gpl.html.
 */

using System.Drawing;
using System.Windows.Forms;

namespace Superhandy.Tools
{
    public class InputLine : UserControl
    {
        const int TextBoxPadding = 4;
        Label label;
        Panel panel1;
        Panel panel2;
        public TextBox TextBox;

        public InputLine()
        {
            label = new Label();
            label.AutoSize = false;
            label.TabStop = false;
            label.Font = new Font("Verdana", 9, FontStyle.Regular);
            label.Location = new Point(10, 3);
            label.Size = new Size(180, 17);
            label.Text = "<labeltext>";
            Controls.Add(label);

            panel1 = new Panel();
            panel1.BackColor = Color.Silver;
            panel1.Location = new Point(10, 20);
            panel1.Size = new Size(180, 1);
            panel1.TabStop = false;
            Controls.Add(panel1);

            TextBox = new TextBox();
            TextBox.AutoSize = true;
            TextBox.Location = new Point(TextBoxPadding, TextBoxPadding);
            TextBox.Font = new Font("Verdana", 9, FontStyle.Regular);
            TextBox.BorderStyle = BorderStyle.None;
            TextBox.BackColor = Color.White;
            TextBox.TabStop = true;
            TextBox.TabIndex = line * 2;

            panel2 = new Panel();
            panel2.BackColor = Color.White;
            panel2.Location = new Point(200, 0);
            panel2.Height = TextBox.Height;
            TextBox.AutoSize = false;
            panel2.TabStop = false;
            panel2.Controls.Add(TextBox);
            Controls.Add(panel2);

            Height = panel2.Height;
        }

        private int line;
        public int Line
        {
            set
            {
                Location = new Point(10, value * (Height + 3));
                line = value;
            }
            get
            {
                return line;
            }
        }

        public string LabelText
        {
            set
            {
                label.Text = value;
            }
            get
            {
                return label.Text;
            }
        }

        public new string Text
        {
            set
            {
                TextBox.Text = value;
            }
            get
            {
                return TextBox.Text;
            }
        }

        public int TextBoxSize
        {
            set
            {
                TextBox.Width = value;
                panel2.Width = value + 2 * TextBoxPadding;
                Width = panel2.Location.X + TextBox.Width + 2 * TextBoxPadding;
            }
            get
            {
                return TextBox.Width;
            }
        }
    }
}

