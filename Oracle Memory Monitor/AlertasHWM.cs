﻿using System;
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
    public partial class AlertasHWM : Form
    {
        public AlertasHWM(Application application)
        {
            InitializeComponent();
            app = application;
            data = new DataSet();
        }
    }
}
