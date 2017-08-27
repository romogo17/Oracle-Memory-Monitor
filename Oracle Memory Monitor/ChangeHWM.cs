using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oracle_Memory_Monitor
{
    public partial class ChangeHWM : Form
    {
        public ChangeHWM(Application application, decimal current)
        {
            InitializeComponent();
            app = application;
            curr = current*100;

            this.numericUpDown1.Value = current*100;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal pct = this.numericUpDown1.Value;
            if (pct > 0 && pct < 100)
            {
                app.RedrawHWM(Convert.ToDouble(pct /100));
                this.Close();
                app.Show();
            }
            else
            {
                System.Media.SystemSounds.Exclamation.Play();
                this.numericUpDown1.Value = curr;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            app.Show();
        }
    }
}
