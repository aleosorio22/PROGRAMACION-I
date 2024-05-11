namespace WFP1.Formularios
{
    partial class FrmIngreso
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.n1 = new System.Windows.Forms.TextBox();
            this.n2 = new System.Windows.Forms.TextBox();
            this.resultado = new System.Windows.Forms.TextBox();
            this.sumar = new System.Windows.Forms.Button();
            this.comboBoxFacultades = new System.Windows.Forms.ComboBox();
            this.btnsuma = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(310, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese numero 1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(310, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ingrese numero 2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(310, 225);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Resultado";
            // 
            // n1
            // 
            this.n1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.n1.Location = new System.Drawing.Point(501, 86);
            this.n1.Name = "n1";
            this.n1.Size = new System.Drawing.Size(176, 39);
            this.n1.TabIndex = 3;
            // 
            // n2
            // 
            this.n2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.n2.Location = new System.Drawing.Point(501, 151);
            this.n2.Name = "n2";
            this.n2.Size = new System.Drawing.Size(176, 39);
            this.n2.TabIndex = 4;
            // 
            // resultado
            // 
            this.resultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultado.Location = new System.Drawing.Point(501, 219);
            this.resultado.Name = "resultado";
            this.resultado.Size = new System.Drawing.Size(176, 39);
            this.resultado.TabIndex = 5;
            this.resultado.TextChanged += new System.EventHandler(this.resultado_TextChanged);
            // 
            // sumar
            // 
            this.sumar.Location = new System.Drawing.Point(275, 414);
            this.sumar.Name = "sumar";
            this.sumar.Size = new System.Drawing.Size(276, 48);
            this.sumar.TabIndex = 6;
            this.sumar.Text = "MOSTRAR CARRERAS";
            this.sumar.UseVisualStyleBackColor = true;
            this.sumar.Click += new System.EventHandler(this.sumar_Click);
            // 
            // comboBoxFacultades
            // 
            this.comboBoxFacultades.FormattingEnabled = true;
            this.comboBoxFacultades.Location = new System.Drawing.Point(590, 425);
            this.comboBoxFacultades.Name = "comboBoxFacultades";
            this.comboBoxFacultades.Size = new System.Drawing.Size(121, 28);
            this.comboBoxFacultades.TabIndex = 7;
            this.comboBoxFacultades.SelectedIndexChanged += new System.EventHandler(this.comboBoxFacultades_SelectedIndexChanged);
            // 
            // btnsuma
            // 
            this.btnsuma.Location = new System.Drawing.Point(452, 298);
            this.btnsuma.Name = "btnsuma";
            this.btnsuma.Size = new System.Drawing.Size(144, 54);
            this.btnsuma.TabIndex = 8;
            this.btnsuma.Text = "SUMAR";
            this.btnsuma.UseVisualStyleBackColor = true;
            this.btnsuma.Click += new System.EventHandler(this.btnsuma_Click);
            // 
            // FrmIngreso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.ClientSize = new System.Drawing.Size(1005, 563);
            this.Controls.Add(this.btnsuma);
            this.Controls.Add(this.comboBoxFacultades);
            this.Controls.Add(this.sumar);
            this.Controls.Add(this.resultado);
            this.Controls.Add(this.n2);
            this.Controls.Add(this.n1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmIngreso";
            this.Text = "FrmIngreso";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox n1;
        private System.Windows.Forms.TextBox n2;
        private System.Windows.Forms.TextBox resultado;
        private System.Windows.Forms.Button sumar;
        private System.Windows.Forms.ComboBox comboBoxFacultades;
        private System.Windows.Forms.Button btnsuma;
    }
}