namespace WFcarro
{
    partial class Form1
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
            btnEncender = new Button();
            btnAcelerar = new Button();
            kph = new Label();
            SuspendLayout();
            // 
            // btnEncender
            // 
            btnEncender.Location = new Point(161, 109);
            btnEncender.Name = "btnEncender";
            btnEncender.Size = new Size(196, 34);
            btnEncender.TabIndex = 0;
            btnEncender.Text = "ENCENDER CARRO";
            btnEncender.UseVisualStyleBackColor = true;
            btnEncender.Click += btnEncender_Click;
            // 
            // btnAcelerar
            // 
            btnAcelerar.Location = new Point(161, 211);
            btnAcelerar.Name = "btnAcelerar";
            btnAcelerar.Size = new Size(196, 34);
            btnAcelerar.TabIndex = 1;
            btnAcelerar.Text = "ACELERAR";
            btnAcelerar.UseVisualStyleBackColor = true;
            btnAcelerar.Visible = false;
            btnAcelerar.Click += btnAcelerar_Click;
            // 
            // kph
            // 
            kph.AutoSize = true;
            kph.Location = new Point(499, 162);
            kph.Name = "kph";
            kph.Size = new Size(45, 25);
            kph.TabIndex = 2;
            kph.Text = "KPH";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(kph);
            Controls.Add(btnAcelerar);
            Controls.Add(btnEncender);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnEncender;
        private Button btnAcelerar;
        private Label kph;
    }
}