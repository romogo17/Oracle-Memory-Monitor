using Newtonsoft.Json;
using System;
using System.Data;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Oracle_Memory_Monitor
{
    partial class AlertasHWM
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
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.opcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirAlertaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarComoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(301, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Alertas al Sobrepasar el High Water Mark";
            this.label1.UseMnemonic = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 57);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(885, 326);
            this.dataGridView1.TabIndex = 4;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.opcionesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(909, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // opcionesToolStripMenuItem
            // 
            this.opcionesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirAlertaToolStripMenuItem,
            this.agregarToolStripMenuItem,
            this.guardarComoToolStripMenuItem});
            this.opcionesToolStripMenuItem.Name = "opcionesToolStripMenuItem";
            this.opcionesToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.opcionesToolStripMenuItem.Text = "Opciones";
            // 
            // abrirAlertaToolStripMenuItem
            // 
            this.abrirAlertaToolStripMenuItem.Name = "abrirAlertaToolStripMenuItem";
            this.abrirAlertaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.abrirAlertaToolStripMenuItem.Text = "Abrir";
            this.abrirAlertaToolStripMenuItem.Click += new System.EventHandler(this.abrirAlertaToolStripMenuItem_Click);
            // 
            // agregarToolStripMenuItem
            // 
            this.agregarToolStripMenuItem.Name = "agregarToolStripMenuItem";
            this.agregarToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.agregarToolStripMenuItem.Text = "Agregar";
            this.agregarToolStripMenuItem.Click += new System.EventHandler(this.agregarToolStripMenuItem_Click);
            // 
            // guardarComoToolStripMenuItem
            // 
            this.guardarComoToolStripMenuItem.Name = "guardarComoToolStripMenuItem";
            this.guardarComoToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.guardarComoToolStripMenuItem.Text = "Guardar como";
            this.guardarComoToolStripMenuItem.Click += new System.EventHandler(this.guardarComoToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // AlertasHWM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(27)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(909, 395);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AlertasHWM";
            this.Opacity = 0.9D;
            this.Text = "Alertas de HWM";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private void abrirAlertaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create an instance of the open file dialog box.
            openFileDialog1 = new OpenFileDialog();

            // Set and ensure the initial directory
            string exeRuntimeDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string subDirectory = System.IO.Path.Combine(exeRuntimeDirectory, "alertas");
            if (!System.IO.Directory.Exists(subDirectory))
            {
                System.IO.Directory.CreateDirectory(subDirectory);
            }

            // Set filter options and filter index.
            openFileDialog1.Filter = "XML (.xml)|*.xml";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;
            openFileDialog1.InitialDirectory = subDirectory;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                data = new DataSet();
                data.ReadXml(openFileDialog1.FileName);

                dataGridView1.DataSource = data.Tables[0];

                //System.IO.StreamReader sr = new   System.IO.StreamReader(openFileDialog1.FileName);
                //MessageBox.Show(sr.ReadToEnd());
                //sr.Close();
            }
        }

        private void agregarToolStripMenuItem_Click(object sender, EventArgs e)

        {
            // Create an instance of the open file dialog box.
            openFileDialog1 = new OpenFileDialog();

            // Set and ensure the initial directory
            string exeRuntimeDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string subDirectory = System.IO.Path.Combine(exeRuntimeDirectory, "alertas");
            if (!System.IO.Directory.Exists(subDirectory))
            {
                System.IO.Directory.CreateDirectory(subDirectory);
            }

            // Set filter options and filter index.
            openFileDialog1.Filter = "XML (.xml)|*.xml";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;
            openFileDialog1.InitialDirectory = subDirectory;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                data.ReadXml(openFileDialog1.FileName);
                dataGridView1.DataSource = data.Tables[0];

                //System.IO.StreamReader sr = new   System.IO.StreamReader(openFileDialog1.FileName);
                //MessageBox.Show(sr.ReadToEnd());
                //sr.Close();
            }
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Si no hay datos por guardar, avisar
            bool flag = false;
            if (data.Tables.Count == 0) flag = true;
            else if (!(data.Tables[0].Rows.Count > 0)) flag = true;
            if(flag)
            {
                MessageBox.Show("No hay datos por guardar en la tabla. Seleccione el menu Opciones para abrir o agregar un archivo", 
                    "Advertencia", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation);
                return;
            }




            saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "XML (.xml)|*.xml|JSON|*.json";
            saveFileDialog1.FilterIndex = 1;

            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.  
            if (saveFileDialog1.FileName != "")
            { 
                // NOTE that the FilterIndex property is one-based.  
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1: // XML format
                        data.WriteXml(saveFileDialog1.FileName);
                        break;

                    case 2: // JSON format

                        string JSONresult;
                        JSONresult = JsonConvert.SerializeObject(data.Tables[0]);
                        System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();

                        byte[] info = new UTF8Encoding(true).GetBytes(JSONresult);
                        fs.Write(info, 0, info.Length);
                        fs.Close();

                        break;
                }
            }
        }

        private System.Windows.Forms.Label label1;
        private Application app;
        private DataSet data;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem opcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirAlertaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarComoToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private ToolStripMenuItem agregarToolStripMenuItem;
    }
}