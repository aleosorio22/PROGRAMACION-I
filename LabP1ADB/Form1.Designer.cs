namespace LabP1ADB
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.test = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl5 = new System.Windows.Forms.Label();
            this.txtNombreConsola = new System.Windows.Forms.TextBox();
            this.lbl = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.comboBoxCompania = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePickerAnio = new System.Windows.Forms.DateTimePicker();
            this.lbl4 = new System.Windows.Forms.Label();
            this.txtGen = new System.Windows.Forms.NumericUpDown();
            this.btnCrear = new System.Windows.Forms.Button();
            this.dsa = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnObtenerTodos = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSiguiente = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // test
            // 
            this.test.Location = new System.Drawing.Point(1096, 36);
            this.test.Name = "test";
            this.test.Size = new System.Drawing.Size(75, 55);
            this.test.TabIndex = 0;
            this.test.Text = "test connection";
            this.test.UseVisualStyleBackColor = true;
            this.test.Click += new System.EventHandler(this.test_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Controls.Add(this.dsa);
            this.panel1.Controls.Add(this.btnCrear);
            this.panel1.Controls.Add(this.txtGen);
            this.panel1.Controls.Add(this.lbl4);
            this.panel1.Controls.Add(this.dateTimePickerAnio);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.comboBoxCompania);
            this.panel1.Controls.Add(this.lbl2);
            this.panel1.Controls.Add(this.lbl);
            this.panel1.Controls.Add(this.txtNombreConsola);
            this.panel1.Controls.Add(this.lbl5);
            this.panel1.Location = new System.Drawing.Point(38, 106);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(390, 478);
            this.panel1.TabIndex = 1;
            // 
            // lbl5
            // 
            this.lbl5.AutoSize = true;
            this.lbl5.Location = new System.Drawing.Point(122, 26);
            this.lbl5.Name = "lbl5";
            this.lbl5.Size = new System.Drawing.Size(154, 20);
            this.lbl5.TabIndex = 0;
            this.lbl5.Text = "CREAR O BUSCAR";
            // 
            // txtNombreConsola
            // 
            this.txtNombreConsola.Location = new System.Drawing.Point(113, 135);
            this.txtNombreConsola.Name = "txtNombreConsola";
            this.txtNombreConsola.Size = new System.Drawing.Size(224, 26);
            this.txtNombreConsola.TabIndex = 1;
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Location = new System.Drawing.Point(42, 141);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(65, 20);
            this.lbl.TabIndex = 2;
            this.lbl.Text = "Nombre";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(42, 214);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(81, 20);
            this.lbl2.TabIndex = 4;
            this.lbl2.Text = "Compania";
            // 
            // comboBoxCompania
            // 
            this.comboBoxCompania.FormattingEnabled = true;
            this.comboBoxCompania.Location = new System.Drawing.Point(129, 206);
            this.comboBoxCompania.Name = "comboBoxCompania";
            this.comboBoxCompania.Size = new System.Drawing.Size(212, 28);
            this.comboBoxCompania.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 286);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Compania";
            // 
            // dateTimePickerAnio
            // 
            this.dateTimePickerAnio.Location = new System.Drawing.Point(137, 286);
            this.dateTimePickerAnio.Name = "dateTimePickerAnio";
            this.dateTimePickerAnio.Size = new System.Drawing.Size(200, 26);
            this.dateTimePickerAnio.TabIndex = 7;
            // 
            // lbl4
            // 
            this.lbl4.AutoSize = true;
            this.lbl4.Location = new System.Drawing.Point(42, 354);
            this.lbl4.Name = "lbl4";
            this.lbl4.Size = new System.Drawing.Size(92, 20);
            this.lbl4.TabIndex = 8;
            this.lbl4.Text = "Generacion";
            // 
            // txtGen
            // 
            this.txtGen.Location = new System.Drawing.Point(140, 354);
            this.txtGen.Name = "txtGen";
            this.txtGen.Size = new System.Drawing.Size(197, 26);
            this.txtGen.TabIndex = 9;
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(129, 427);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(112, 38);
            this.btnCrear.TabIndex = 10;
            this.btnCrear.Text = "Crear";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // dsa
            // 
            this.dsa.AutoSize = true;
            this.dsa.Location = new System.Drawing.Point(42, 74);
            this.dsa.Name = "dsa";
            this.dsa.Size = new System.Drawing.Size(26, 20);
            this.dsa.TabIndex = 11;
            this.dsa.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(113, 71);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(163, 26);
            this.txtID.TabIndex = 12;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::LabP1ADB.Properties.Resources.icons8_buscar_contactos_80;
            this.pictureBox1.Location = new System.Drawing.Point(287, 57);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(54, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // btnObtenerTodos
            // 
            this.btnObtenerTodos.Location = new System.Drawing.Point(681, 409);
            this.btnObtenerTodos.Name = "btnObtenerTodos";
            this.btnObtenerTodos.Size = new System.Drawing.Size(112, 38);
            this.btnObtenerTodos.TabIndex = 14;
            this.btnObtenerTodos.Text = "ObtenerTodos";
            this.btnObtenerTodos.UseVisualStyleBackColor = true;
            this.btnObtenerTodos.Click += new System.EventHandler(this.btnObtenerTodos_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(466, 120);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(748, 283);
            this.dataGridView1.TabIndex = 15;
            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Location = new System.Drawing.Point(923, 409);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new System.Drawing.Size(112, 38);
            this.btnSiguiente.TabIndex = 16;
            this.btnSiguiente.Text = "Siguiente";
            this.btnSiguiente.UseVisualStyleBackColor = true;
            this.btnSiguiente.Click += new System.EventHandler(this.btnSiguiente_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(100, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(981, 46);
            this.label2.TabIndex = 17;
            this.label2.Text = "Rene Alejandro Osorio Gonzalez (0905-23-10736)";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 734);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSiguiente);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnObtenerTodos);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.test);
            this.Name = "Form1";
            this.Text = "x";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button test;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.TextBox txtNombreConsola;
        private System.Windows.Forms.Label lbl5;
        private System.Windows.Forms.ComboBox comboBoxCompania;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.NumericUpDown txtGen;
        private System.Windows.Forms.Label lbl4;
        private System.Windows.Forms.DateTimePicker dateTimePickerAnio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label dsa;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnObtenerTodos;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSiguiente;
        private System.Windows.Forms.Label label2;
    }
}

