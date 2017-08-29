using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Threading;

namespace Oracle_Memory_Monitor
{
    public partial class Application : Form
    {
        public Application()
        {
            sgaSize = GetSgaSize();
            enAlerta = false;
            hwm = Decimal.Parse(ConfigurationManager.AppSettings["highWaterMark"])/100;
            InitializeComponent();
            InitChart();
            Thread.Sleep(2000);
        }

    }
}
