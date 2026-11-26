namespace Carrusel_AED.P
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
            PictureBox1 = new PictureBox();
            label1 = new Label();
            Anterior = new Button();
            Siguiente = new Button();
            ((System.ComponentModel.ISupportInitialize)PictureBox1).BeginInit();
            SuspendLayout();
            // 
            // PictureBox1
            // 
            PictureBox1.BorderStyle = BorderStyle.FixedSingle;
            PictureBox1.Location = new Point(229, 109);
            PictureBox1.Name = "PictureBox1";
            PictureBox1.Size = new Size(384, 284);
            PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            PictureBox1.TabIndex = 0;
            PictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.Font = new Font("Courier New", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Lime;
            label1.Location = new Point(24, 412);
            label1.MaximumSize = new Size(800, 150);
            label1.Name = "label1";
            label1.Size = new Size(788, 150);
            label1.TabIndex = 1;
            label1.Text = "<Texto>\r\n";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Anterior
            // 
            Anterior.BackColor = Color.FromArgb(103, 103, 103);
            Anterior.FlatStyle = FlatStyle.Flat;
            Anterior.ForeColor = SystemColors.ButtonHighlight;
            Anterior.Location = new Point(86, 257);
            Anterior.Name = "Anterior";
            Anterior.Size = new Size(75, 23);
            Anterior.TabIndex = 3;
            Anterior.Text = "←";
            Anterior.UseVisualStyleBackColor = false;
            Anterior.Click += button2_Click;
            // 
            // Siguiente
            // 
            Siguiente.BackColor = Color.FromArgb(95, 95, 95);
            Siguiente.FlatStyle = FlatStyle.Flat;
            Siguiente.ForeColor = Color.White;
            Siguiente.Location = new Point(649, 257);
            Siguiente.Name = "Siguiente";
            Siguiente.Size = new Size(75, 23);
            Siguiente.TabIndex = 2;
            Siguiente.Text = "→";
            Siguiente.UseVisualStyleBackColor = false;
            Siguiente.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(68, 68, 68);
            ClientSize = new Size(849, 571);
            Controls.Add(Anterior);
            Controls.Add(Siguiente);
            Controls.Add(label1);
            Controls.Add(PictureBox1);
            Name = "Form1";
            Text = "Form1";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)PictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox PictureBox1;
        private Label label1;
        private Button Anterior;
        private Button Siguiente;
    }
}