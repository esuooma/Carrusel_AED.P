using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Carrusel_AED.P
{
    public partial class portada : Form
    {
        public portada()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide(); // Oculta la portada

            // Muestra el formulario principal (Form1)
            Form1 ventanaPrincipal = new Form1();
            ventanaPrincipal.ShowDialog();

            this.Close(); // Cuando cierres el Form1, se cierra el programa
        }
    }
}
