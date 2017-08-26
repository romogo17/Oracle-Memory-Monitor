namespace Oracle_Memory_Monitor
{
    using System;
    using System.Windows.Forms;
    using LiveCharts;
    using LiveCharts.Configurations;
    using LiveCharts.Wpf;
    //using System.Data.OracleClient;
    using Oracle.DataAccess.Client;
    using Oracle.DataAccess.Types;
    using System.Data;
    using System.Configuration;
    using System.Windows.Media;

    partial class Application
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Application));
            this.myChart = new LiveCharts.WinForms.CartesianChart();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarHWMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bitacoraDeErroresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pruebasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exigirMemoriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // myChart
            // 
            this.myChart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.myChart.Location = new System.Drawing.Point(12, 27);
            this.myChart.Name = "myChart";
            this.myChart.Size = new System.Drawing.Size(751, 373);
            this.myChart.TabIndex = 1;
            this.myChart.Text = "cartesianChart1";
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cambiarHWMToolStripMenuItem,
            this.bitacoraDeErroresToolStripMenuItem});
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // cambiarHWMToolStripMenuItem
            // 
            this.cambiarHWMToolStripMenuItem.Name = "cambiarHWMToolStripMenuItem";
            this.cambiarHWMToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.cambiarHWMToolStripMenuItem.Text = "Cambiar HWM";
            // 
            // bitacoraDeErroresToolStripMenuItem
            // 
            this.bitacoraDeErroresToolStripMenuItem.Name = "bitacoraDeErroresToolStripMenuItem";
            this.bitacoraDeErroresToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.bitacoraDeErroresToolStripMenuItem.Text = "Bitacora de Errores";
            // 
            // pruebasToolStripMenuItem
            // 
            this.pruebasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exigirMemoriaToolStripMenuItem});
            this.pruebasToolStripMenuItem.Name = "pruebasToolStripMenuItem";
            this.pruebasToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.pruebasToolStripMenuItem.Text = "Pruebas";
            // 
            // exigirMemoriaToolStripMenuItem
            // 
            this.exigirMemoriaToolStripMenuItem.Name = "exigirMemoriaToolStripMenuItem";
            this.exigirMemoriaToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.exigirMemoriaToolStripMenuItem.Text = "Exigir Memoria";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionesToolStripMenuItem,
            this.pruebasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(775, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Application
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(775, 412);
            this.Controls.Add(this.myChart);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Application";
            this.Opacity = 0.9D;
            this.Text = "Monitor de Memoria";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private void InitChart()
        {
            var mapper = Mappers.Xy<MeasureModel>()
                .X(model => model.DateTime.Ticks)   //use DateTime.Ticks as X
                .Y(model => model.Value);           //use the value property as Y

            //lets save the mapper globally.
            Charting.For<MeasureModel>(mapper);

            //the ChartValues property will store our values array
            ChartValues = new ChartValues<MeasureModel>();
            myChart.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title  = "Carga de Memoria (MB)",
                    Values = ChartValues,
                    PointGeometrySize = 9,
                    StrokeThickness = 3,
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(28, 142, 196)),
                }
            };
            myChart.AxisX.Add(new Axis
            {
                IsMerged = true,
                Separator = new Separator
                {
                    StrokeThickness = 1,
                    StrokeDashArray = new System.Windows.Media.DoubleCollection(2),
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(27,27,27)),
                    Step = TimeSpan.FromSeconds(1).Ticks
                },

                Title = "Hora",
                DisableAnimations = true,
                LabelFormatter = value => new System.DateTime((long)value).ToString("mm:ss"),
            });

            myChart.AxisY.Add(new Axis
            {
                IsMerged = true,
                Separator = new Separator
                {
                    StrokeThickness = 1,
                    StrokeDashArray = new System.Windows.Media.DoubleCollection(2),
                    Stroke = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromRgb(27,27,27)),
                },
                Sections = new SectionsCollection
                {
                    new AxisSection
                    {
                        Value = Convert.ToDouble(sgaSize * Decimal.Parse(ConfigurationManager.AppSettings["highWaterMark"])),
                        Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(248, 213, 72)),
                        StrokeThickness = 3
                    }
                },
                Title = "Consumo de Memoria (MB)",
                DisableAnimations = true
            });

            myChart.AxisY[0].MinValue = 0;
            myChart.AxisY[0].MaxValue = Convert.ToDouble(sgaSize);

            SetAxisLimits(System.DateTime.Now);

            //The next code simulates data changes every 500 ms
            Timer = new Timer
            {
                Interval = 1000
            };
            Timer.Tick += TimerOnTick;
            Timer.Start();


        }

        private void SetAxisLimits(System.DateTime now)
        {
            myChart.AxisX[0].MaxValue = now.Ticks + TimeSpan.FromSeconds(0).Ticks; // lets force the axis to be 100ms ahead
            myChart.AxisX[0].MinValue = now.Ticks - TimeSpan.FromSeconds(8).Ticks; //we only care about the last 8 seconds
        }

        private void TimerOnTick(object sender, EventArgs eventArgs)
        {
            var now = System.DateTime.Now;

            ChartValues.Add(new MeasureModel
            {
                DateTime = now,
                Value = Convert.ToDouble(GetUsedMemory())
            });

            SetAxisLimits(now);

            //lets only use the last 30 values
            if (ChartValues.Count > 30) ChartValues.RemoveAt(0);
        }

        private decimal GetSgaSize()
        {
            using (OracleConnection objConn = new OracleConnection(ConfigurationManager.AppSettings["connectionString"]))
            {
                decimal sgaSize = 0;

                // Create and execute the command
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = objConn;
                objCmd.CommandText = "get_sga_size";
                objCmd.CommandType = CommandType.StoredProcedure;

                // Set parameters
                OracleParameter retParam = objCmd.Parameters.Add("return_value", OracleDbType.Decimal, ParameterDirection.ReturnValue);
                //objCmd.Parameters.Add("return_value", OracleDbType.Int32, sgaSize, System.Data.ParameterDirection.Input);

                try
                {
                    objConn.Open();
                    objCmd.ExecuteNonQuery();
                    sgaSize = (decimal)((OracleDecimal)retParam.Value);
                    //System.Console.WriteLine("Size of the SGA is {0}", retParam.Value);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Exception: {0}", ex.ToString());
                }

                objConn.Close();
                objConn.Dispose();
                return sgaSize;
            }
        }

        private decimal GetUsedMemory()
        {
            using (OracleConnection objConn = new OracleConnection(ConfigurationManager.AppSettings["connectionString"]))
            {
                decimal usedMem = 0;

                // Create and execute the command
                OracleCommand objCmd = new OracleCommand();
                objCmd.Connection = objConn;
                objCmd.CommandText = "get_used_memory";
                objCmd.CommandType = CommandType.StoredProcedure;

                // Set parameters
                OracleParameter retParam = objCmd.Parameters.Add("return_value", OracleDbType.Decimal, ParameterDirection.ReturnValue);
                //objCmd.Parameters.Add("return_value", OracleDbType.Int32, sgaSize, System.Data.ParameterDirection.Input);

                try
                {
                    objConn.Open();
                    objCmd.ExecuteNonQuery();
                    usedMem = (decimal)((OracleDecimal)retParam.Value);
                    //System.Console.WriteLine("Memory Usage is {0}", retParam.Value);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Exception: {0}", ex.ToString());
                }

                objConn.Close();
                objConn.Dispose();
                return usedMem;
            }
        }

        private LiveCharts.WinForms.CartesianChart myChart;
        private ToolStripMenuItem opcionesToolStripMenuItem;
        private ToolStripMenuItem cambiarHWMToolStripMenuItem;
        private ToolStripMenuItem bitacoraDeErroresToolStripMenuItem;
        private ToolStripMenuItem pruebasToolStripMenuItem;
        private ToolStripMenuItem exigirMemoriaToolStripMenuItem;
        private MenuStrip menuStrip1;

        public ChartValues<MeasureModel> ChartValues { get; set; }
        public Timer Timer { get; set; }
        private decimal sgaSize;


    }

}

