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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            PictureBox1 = new PictureBox();
            label1 = new Label();
            Anterior = new Button();
            Siguiente = new Button();
            ((System.ComponentModel.ISupportInitialize)PictureBox1).BeginInit();
            SuspendLayout();
            // 
            // PictureBox1
            // 
            PictureBox1.Location = new Point(239, 97);
            PictureBox1.Name = "PictureBox1";
            PictureBox1.Size = new Size(384, 284);
            PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            PictureBox1.TabIndex = 0;
            PictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ActiveCaptionText;
            label1.Location = new Point(36, 384);
            label1.MaximumSize = new Size(800, 150);
            label1.Name = "label1";
            label1.Size = new Size(788, 150);
            label1.TabIndex = 1;
            label1.Text = "<Texto>\r\n";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Anterior
            // 
            Anterior.BackColor = Color.Transparent;
            Anterior.FlatStyle = FlatStyle.Flat;
            Anterior.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Anterior.ForeColor = Color.White;
            Anterior.Location = new Point(87, 244);
            Anterior.Name = "Anterior";
            Anterior.Size = new Size(86, 31);
            Anterior.TabIndex = 3;
            Anterior.Text = "◀";
            Anterior.UseVisualStyleBackColor = false;
            Anterior.Click += button2_Click;
            // 
            // Siguiente
            // 
            Siguiente.BackColor = Color.Transparent;
            Siguiente.FlatStyle = FlatStyle.Flat;
            Siguiente.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Siguiente.ForeColor = Color.White;
            Siguiente.Location = new Point(673, 235);
            Siguiente.Name = "Siguiente";
            Siguiente.Size = new Size(86, 31);
            Siguiente.TabIndex = 2;
            Siguiente.Text = "▶";
            Siguiente.UseVisualStyleBackColor = false;
            Siguiente.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(847, 571);
            Controls.Add(Anterior);
            Controls.Add(Siguiente);
            Controls.Add(label1);
            Controls.Add(PictureBox1);
            Name = "Form1";
            Text = "Carrusel_AED_III";
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