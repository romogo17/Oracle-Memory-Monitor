using Oracle_Memory_Monitor.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Oracle_Memory_Monitor
{
    public partial class SplashForm : Form
    {
        private Bitmap loadingImage;
        private PictureBox spashPictureBox;

        public SplashForm()
        {
            InitializeComponent();

            string exeRuntimeDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            loadingImage = new Bitmap(exeRuntimeDirectory+ "\\OraMemMonitorLoading.png");

            spashPictureBox = new PictureBox
            {
                Image = (Image) loadingImage,
                SizeMode = PictureBoxSizeMode.StretchImage,
                Dock = DockStyle.Fill
            };
            this.Controls.Add(spashPictureBox);
        }
    }
}
