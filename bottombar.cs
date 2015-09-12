/* Tools      Kleine Helferlein vom Superhandy
 * -------------------------------------------
 * Anwendung: Testanwendung
 * Datei:     bottombar.cs
 * Version:   12.09.2015
 * Besitzer:  Mathias Rentsch (rentsch@online.de)
 * Lizenz:    GPL
 *
 * Die Anwendung und die Quelltextdateien sind freie Software und stehen unter der
 * GNU General Public License. Der Originaltext dieser Lizenz kann eingesehen werden
 * unter http://www.gnu.org/licenses/gpl.html.
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace Superhandy.Tools
{
    public enum BottomBarButtons { OK, OKCancel, YesNo, Close, UserDefined };

    public class BottomBar : UserControl
    {
        // Button4.....Button3.....Button2.....Button1
        //                                          OK
        //                              OK   Abbrechen
        //                              Ja        Nein
        //                                   Schließen

        public Button Button1;
        public Button Button2;
        public Button Button3;
        public Button Button4;

        public Button Button_Ok;
        public Button Button_Cancel;
        public Button Button_Close;

        public BottomBar()
        {
            Button1 = new Button();
            Button1.Click += Button1_Click;
            Button1.TabIndex = 1;
            Controls.Add(Button1);

            Button2 = new Button();
            Button2.Click += Button2_Click;
            Button2.TabIndex = 2;
            Controls.Add(Button2);

            Button3 = new Button();
            Button3.Click += Button3_Click;
            Button3.TabIndex = 3;
            Controls.Add(Button3);

            Button4 = new Button();
            Button4.Click += Button4_Click;
            Button4.TabIndex = 4;
            Controls.Add(Button4);

            SizeChanged += OnSizeChanged;
            MarginChanged += OnMarginChanged;
            Dock = DockStyle.Bottom;
            BackColor = Color.AliceBlue;
            Margin = new Padding(10);
            Font = new Font("Verdana", 9F, FontStyle.Regular);
            ButtonBarButtons = BottomBarButtons.UserDefined;
            ButtonWidth = 90;
            ButtonHeight = 25;
        }

        public int ButtonWidth
        {
            set
            {
                Button1.Width = value;
                Button2.Width = value;
                Button3.Width = value;
                Button4.Width = value;
                setButtonPos();
            }
            get
            {
                return Button1.Width;
            }
        }

        public int ButtonHeight
        {
            set
            {
                Button1.Height = value;
                Button2.Height = value;
                Button3.Height = value;
                Button4.Height = value;
                setButtonPos();
            }
            get
            {
                return Button1.Height;
            }
        }

        private BottomBarButtons buttonBarButtons;
        public BottomBarButtons ButtonBarButtons
        {
            set
            {
                switch (value)
                {
                    case BottomBarButtons.OK:
                        Button1.Text = "OK";
                        Button1.Visible = true;
                        Button2.Visible = false;
                        Button3.Visible = false;
                        Button4.Visible = false;
                        break;
                    case BottomBarButtons.OKCancel:
                        Button1.Text = "Abbrechen";
                        Button1.Visible = true;
                        Button2.Text = "OK";
                        Button2.Visible = true;
                        Button3.Visible = false;
                        Button4.Visible = false;
                        break;
                    case BottomBarButtons.YesNo:
                        Button1.Text = "Nein";
                        Button1.Visible = true;
                        Button2.Text = "Ja";
                        Button2.Visible = true;
                        Button3.Visible = false;
                        Button4.Visible = false;
                        break;
                    case BottomBarButtons.Close:
                        Button1.Text = "Schließen";
                        Button1.Visible = true;
                        Button2.Visible = false;
                        Button3.Visible = false;
                        Button4.Visible = false;
                        break;
                    case BottomBarButtons.UserDefined:
                        Button1.Visible = false;
                        Button2.Visible = false;
                        Button3.Visible = false;
                        Button4.Visible = false;
                        break;
                }
                buttonBarButtons = value;
            }
            get
            {
                return buttonBarButtons;
            }
        }

        private void setButtonPos()
        {
            Button1.Left = Width - Button1.Width - Margin.All;
            Button2.Left = Width - Button1.Width - Margin.All - Button2.Width - Margin.All;
            Button3.Left = Width - Button1.Width - Margin.All - Button2.Width - Margin.All - Button3.Width - Margin.All;
            Button4.Left = Width - Button1.Width - Margin.All - Button2.Width - Margin.All - Button3.Width - Margin.All - Button4.Width - Margin.All;

            Button1.Top = Margin.All;
            Button2.Top = Margin.All;
            Button3.Top = Margin.All;
            Button4.Top = Margin.All;

            Height = Button1.Height + 2 * Margin.All;
        }

        private void OnSizeChanged(object sender, EventArgs e)
        {
            setButtonPos();
        }

        private void OnMarginChanged(object sender, EventArgs e)
        {
            setButtonPos();
        }

        public event EventHandler Button1Click;
        public event EventHandler Button2Click;
        public event EventHandler Button3Click;
        public event EventHandler Button4Click;

        private void Button1_Click(object sender, EventArgs e) { if (Button1Click != null) Button1Click(this, e); }
        private void Button2_Click(object sender, EventArgs e) { if (Button2Click != null) Button2Click(this, e); }
        private void Button3_Click(object sender, EventArgs e) { if (Button3Click != null) Button3Click(this, e); }
        private void Button4_Click(object sender, EventArgs e) { if (Button4Click != null) Button4Click(this, e); }

        public string Button1Text { set { Button1.Text = value; } get { return Button1.Text; } }
        public string Button2Text { set { Button2.Text = value; } get { return Button2.Text; } }
        public string Button3Text { set { Button3.Text = value; } get { return Button3.Text; } }
        public string Button4Text { set { Button4.Text = value; } get { return Button4.Text; } }

        public bool Button1Visible { set { Button1.Visible = value; } get { return Button1.Visible; } }
        public bool Button2Visible { set { Button2.Visible = value; } get { return Button2.Visible; } }
        public bool Button3Visible { set { Button3.Visible = value; } get { return Button3.Visible; } }
        public bool Button4Visible { set { Button4.Visible = value; } get { return Button4.Visible; } }
    }
}