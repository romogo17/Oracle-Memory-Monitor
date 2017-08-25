namespace Oracle_Memory_Monitor
{
    using System;
    using System.Windows.Forms;
    using LiveCharts;
    using LiveCharts.Configurations;
    using LiveCharts.Wpf;

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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarHWMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bitacoraDeErroresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pruebasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exigirMemoriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.myChart = new LiveCharts.WinForms.CartesianChart();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionesToolStripMenuItem,
            this.pruebasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(764, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
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
            // myChart
            // 
            this.myChart.Location = new System.Drawing.Point(12, 27);
            this.myChart.Name = "myChart";
            this.myChart.Size = new System.Drawing.Size(740, 365);
            this.myChart.TabIndex = 1;
            this.myChart.Text = "cartesianChart1";
            // 
            // Application
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 404);
            this.Controls.Add(this.myChart);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Application";
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
                    Title  = "Carga de Memoria",
                    Values = ChartValues,
                    PointGeometrySize = 9,
                    StrokeThickness = 3
                }
            };
            myChart.AxisX.Add(new Axis
            {
                Title = "Hora",
                DisableAnimations = true,
                LabelFormatter = value => new System.DateTime((long)value).ToString("mm:ss"),
                Separator = new Separator
                {
                    Step = TimeSpan.FromSeconds(1).Ticks
                }
            });
            myChart.AxisY.Add(new Axis
            {
                Title = "Consumo de Memoria",
                DisableAnimations = true,
            });

            SetAxisLimits(System.DateTime.Now);

            //The next code simulates data changes every 500 ms
            Timer = new Timer
            {
                Interval = 1000
            };
            Timer.Tick += TimerOnTick;
            R = new Random();
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
                Value = R.Next(0, 10)
            });

            SetAxisLimits(now);

            //lets only use the last 30 values
            if (ChartValues.Count > 30) ChartValues.RemoveAt(0);
        }






        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cambiarHWMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bitacoraDeErroresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pruebasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exigirMemoriaToolStripMenuItem;

        private LiveCharts.WinForms.CartesianChart myChart;
        public ChartValues<MeasureModel> ChartValues { get; set; }
        public Timer Timer { get; set; }
        public Random R { get; set; }

    }
}

