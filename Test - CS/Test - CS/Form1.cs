using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test___CS
{
    public partial class Form1 : Form
    {
        bool konec = false, vysl = false;
        int prvni, druhy = 0;
        double vysledek;
        string operace;

        public Form1()
        {
            InitializeComponent();
        }

        private void Rovno_Click(object sender, EventArgs e)
        {
            if (display.Text != "")
            {
                switch (operace)
                {
                    case "+":
                        vysledek = prvni + druhy;
                        break;
                    case "-":
                        vysledek = prvni - druhy;
                        break;
                    case "*":
                        vysledek = prvni * druhy;
                        break;
                    case "/":
                        if (druhy != 0)
                        {
                            vysledek = (double)prvni / druhy;
                        }
                        else
                            vysledek = -1;
                        break;
                    case "%":
                        vysledek = (double)prvni % druhy;
                        break;
                }
                display.Text = (Math.Round(vysledek, 2)).ToString();
                vysl = true;
            }
        }

        private void Nm0_Click(object sender, EventArgs e)
        {
            if(vysl)
            {
                Del_Click(sender, e);
                vysl = false;
            }
            display.Text += ((Button)sender).Text;
            if(konec)
            {
                druhy *= 10;
                druhy += int.Parse((((Button)sender).Text));
            }
        }

        private void Del_Click(object sender, EventArgs e)
        {
            konec = false;
            prvni = 0;
            druhy = 0;
            vysledek = 0;
            display.Text = "";
        }

        private void Deleno_Click(object sender, EventArgs e)
        {
            if (!konec && display.Text != "")
            {
                konec = true;
                try
                {
                    prvni = int.Parse(display.Text);
                } catch
                {
                    MessageBox.Show("Něco se pokazilo!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                operace = ((Button)sender).Text;
                switch (((Button)sender).Text)
                {
                    case "+":
                        display.Text += "+";
                        break;
                    case "-":
                        display.Text += "-";
                        break;
                    case "*":
                        display.Text += "*";
                        break;
                    case "/":
                        display.Text += "/";
                        break;
                    case "%":
                        display.Text += "%";
                        break;
                }
            }
        }
    }
}
