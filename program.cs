/* Tools      Kleine Helferlein vom Superhandy
 * -------------------------------------------
 * Anwendung: Testanwendung
 * Datei:     program.cs
 * Version:   29.01.2013
 * Besitzer:  Mathias Rentsch (rentsch@online.de)
 * Lizenz:    GPL
 *
 * Die Anwendung und die Quelltextdateien sind freie Software und stehen unter der
 * GNU General Public License. Der Originaltext dieser Lizenz kann eingesehen werden
 * unter http://www.gnu.org/licenses/gpl.html.
 */

using System;
using System.Windows.Forms;
using Superhandy.Tools;

public class TestForm : Form
{
    private InputLine inputLine1;
    private InputLine inputLine2;
    private InputLine inputLine3;
    private InputLine inputLine4;
    private InputLine inputLine5;

    public TestForm()
    {
        inputLine1 = new InputLine();
        inputLine2 = new InputLine();
        inputLine3 = new InputLine();
        inputLine4 = new InputLine();
        inputLine5 = new InputLine();
    
        inputLine1.Line = 1;
        inputLine1.LabelText = "Vorname";
        inputLine1.TextBoxSize = 200;

        inputLine2.Line = 2;
        inputLine2.LabelText = "Nachname";
        inputLine2.TextBoxSize = 200;

        inputLine3.Line = 3;
        inputLine3.LabelText = "Strasse";
        inputLine3.TextBoxSize = 300;

        inputLine4.Line = 4;
        inputLine4.LabelText = "PLZ";
        inputLine4.TextBoxSize = 100;

        inputLine5.Line = 5;
        inputLine5.LabelText = "Ort";
        inputLine5.TextBoxSize = 300;

        Controls.Add(inputLine1);
        Controls.Add(inputLine2);
        Controls.Add(inputLine3);
        Controls.Add(inputLine4);
        Controls.Add(inputLine5);

        Height = 250;
        Width = 550;
    }
    
    [STAThread]
    static void Main()
    {
        Application.Run(new TestForm());
    }
}

    

