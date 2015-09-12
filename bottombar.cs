using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Superhandy.Tools
{
    public enum BottomBarButtons { OK, OKCancel, Close, UserDefined };

    public class BottomBar : UserControl
    {
        // Button4.....Button3.....Button2.....Button1
        //                                          OK
        //                              OK   Abbrechen
        //                                   Schließen
           
        Label label_error;
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
            Button1.Text = "Button1";
            Button1.Click += Button1_Click;
            Button1.TabIndex = 1;
            Controls.Add(Button1);

            Button2 = new Button();
            Button2.Text = "Button2";
            Button2.Click += Button2_Click;
            Button2.TabIndex = 2;
            Controls.Add(Button2);

            Button3 = new Button();
            Button3.Text = "Button3";
            Button3.Click += Button3_Click;
            Button3.TabIndex = 3;
            Controls.Add(Button3);

            Button4 = new Button();
            Button4.Text = "Button4";
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
                        Button2.Visible = false;
                        Button3.Visible = false;
                        Button4.Visible = false;
                        break;
                    case BottomBarButtons.OKCancel:
                        Button1.Text = "Abbrechen";
                        Button2.Text = "OK";
                        Button2.Visible = true;
                        Button3.Visible = false;
                        Button4.Visible = false;
                        break;
                    case BottomBarButtons.Close:
                        Button1.Text = "Schließen";
                        Button2.Visible = false;
                        Button3.Visible = false;
                        Button4.Visible = false;
                        break;
                    case BottomBarButtons.UserDefined:
                        //Button1.Visible = true;
                        //Button2.Visible = true;
                        //Button3.Visible = true;
                        //Button4.Visible = true;
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

        
        public string Button1Text { set { Button1.Text = value; } get { return Button1.Text; }}
        public string Button2Text { set { Button2.Text = value; } get { return Button2.Text; } }
        public string Button3Text { set { Button3.Text = value; } get { return Button3.Text; } }
        public string Button4Text { set { Button4.Text = value; } get { return Button4.Text; } }

        public bool Button1Visible { set { Button1.Visible = value; } get { return Button1.Visible; } }
        public bool Button2Visible { set { Button2.Visible = value; } get { return Button2.Visible; } }
        public bool Button3Visible { set { Button3.Visible = value; } get { return Button3.Visible; } }
        public bool Button4Visible { set { Button4.Visible = value; } get { return Button4.Visible; } }



    }
    // TODO Umswitchung von Button1....Button3 aus Button_OK, Button_cancel .......
    // TODO Verschiedene Farbschemata definieren
    // TODO Errorlabel implementieren
    // TODO Wenn ButtonText oder ButtonVisible geändert wird, muß BottomBarButtons auf Userdefined umgeschaltet werden, sonst Datenverlust       

                         
}