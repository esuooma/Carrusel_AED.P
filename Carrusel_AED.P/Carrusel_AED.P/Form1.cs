using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Numerics;
using System.Text;
using System.Windows.Forms;
using Carrusel_AED.P.Logica;
using Carrusel_AED.P.TDAs;
using Carrusel_AED.P.Modelos;

namespace Carrusel_AED.P
{
    public partial class Form1 : Form
    {
        private string contenidoArchivoCompleto;

        private RoundRobin SimuladorGlobal;

        private StoryBuilder builderGlobal;

        private GestorTransmisiones Gestor = new GestorTransmisiones();

        public Form1()
        {
            InitializeComponent();
            ConfigurarBotonesDePrueba();
        }

        private void ConfigurarBotonesDePrueba()
        {
            // Botón 1: Leer
            Button btnCargar = new Button();
            btnCargar.Text = "1. Cargar TXT";
            btnCargar.Location = new System.Drawing.Point(135, 20);
            btnCargar.BackColor = System.Drawing.Color.FromArgb(50, 50, 50);
            btnCargar.ForeColor = System.Drawing.Color.White;
            btnCargar.FlatStyle = FlatStyle.Flat;
            btnCargar.Click += (s, e) => CargarArchivo();
            this.Controls.Add(btnCargar);

            // Botón 2: Procesar
            Button btnProcesar = new Button();
            btnProcesar.Text = "Fase.2";
            btnProcesar.Location = new System.Drawing.Point(255, 20);
            btnProcesar.BackColor = System.Drawing.Color.FromArgb(50, 50, 50);
            btnProcesar.ForeColor = System.Drawing.Color.White;
            btnProcesar.FlatStyle = FlatStyle.Flat;
            btnProcesar.Click += (s, e) => ProcesarYEncolar();
            this.Controls.Add(btnProcesar);

            // Botón 3: Round Robin
            Button btnRoundRobin = new Button();
            btnRoundRobin.Text = "Fase.3";
            btnRoundRobin.Location = new System.Drawing.Point(375, 20);
            btnRoundRobin.BackColor = System.Drawing.Color.FromArgb(50, 50, 50);
            btnRoundRobin.ForeColor = System.Drawing.Color.White;
            btnRoundRobin.FlatStyle = FlatStyle.Flat;
            btnRoundRobin.Click += (s, e) => EjecutarRoundRobin();
            this.Controls.Add(btnRoundRobin);

            // Botón 4: Destruir
            Button btnDestruir = new Button();
            btnDestruir.Text = "4. Destruir Eliminados";
            btnDestruir.Location = new System.Drawing.Point(495, 20);
            btnDestruir.BackColor = System.Drawing.Color.FromArgb(50, 50, 50);
            btnDestruir.ForeColor = System.Drawing.Color.White;
            btnDestruir.FlatStyle = FlatStyle.Flat;
            btnDestruir.Click += (s, e) =>
            {

                if (SimuladorGlobal == null)
                {
                    MessageBox.Show("Primero ejecuta el Round Robin (Botón 3).");
                    return;
                }

                // Mostramos la lista de eliminados
                string lista = SimuladorGlobal.ObtenerListaEliminados();

                // Pedimos confirmación
                DialogResult result = MessageBox.Show(lista + "\n\n¿Confirmas la destrucción de estos registros?", "Confirmación de Destrucción", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    SimuladorGlobal.ConfirmarDestruccion();
                    MessageBox.Show("Registros destruidos correctamente.");
                }
            };
            this.Controls.Add(btnDestruir);

            //fase 5 boton armar pagina
            Button btnFase5 = new Button();
            btnFase5.Text = "5. Armar Páginas";
            btnFase5.Location = new System.Drawing.Point(615, 20);
            btnFase5.BackColor = System.Drawing.Color.FromArgb(50, 50, 50);
            btnFase5.ForeColor = System.Drawing.Color.White;
            btnFase5.FlatStyle = FlatStyle.Flat;
            btnFase5.Click += (s, e) =>
            {
                if (SimuladorGlobal == null)
                {
                    MessageBox.Show("Primero haz el RoundRobin.");
                    return;
                }

                builderGlobal = new StoryBuilder();
                builderGlobal.ConstruirHistoria(SimuladorGlobal.ColaGuardado);

                MostrarImagenActual();

                if (!string.IsNullOrEmpty(builderGlobal.AudioGlobal))
                {
                    AudioPlayer.ReproducirBase64(builderGlobal.AudioGlobal);
                }

                MessageBox.Show("Se armaron " + builderGlobal.BicolaPaginas.contador + " páginas.", "Fase 5");

                Pagina primerapag = builderGlobal.BicolaPaginas.Frente.Dato;
                MessageBox.Show("la primera pagina tiene texto:" + (primerapag.Texto != "" ? "SI" : "NO") + "\n la primera pagina tiene iamgen " + (primerapag.ImagenActual != null ? "Si" : "NO"));

            };
            this.Controls.Add(btnFase5);
        }

        //fase 1
        private void CargarArchivo()
        {
            try
            {
                LectorArchivo lector = new LectorArchivo();
                contenidoArchivoCompleto = lector.Leer("transmisiones.txt");
                MessageBox.Show("Archivo cargado en memoria. Listo para procesar.", "Fase 1 completada");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error");
            }
        }

        //fase 2
        private void ProcesarYEncolar()
        {
            if (string.IsNullOrEmpty(contenidoArchivoCompleto))
            {
                MessageBox.Show("Primero carga el archivo.", "Aviso");
                return;
            }

            // Le pasamos el texto a (GestorTransmisiones)
            Gestor.ProcesarTexto(contenidoArchivoCompleto);

            // Mostramos el resultado 
            string mensaje = "Procesamiento completo:\n" +
                             "Canal 1: " + Gestor.Canal1.Contador + " registros.\n" +
                             "Canal 2: " + Gestor.Canal2.Contador + " registros.\n" +
                             "Canal 3: " + Gestor.Canal3.Contador + " registros.";

            MessageBox.Show(mensaje, "Resumen");


        }
        //fase 3
        private void EjecutarRoundRobin()
        {
            // Limpiamos todo y llenamos de nuevo
            Gestor = new GestorTransmisiones();
            Gestor.ProcesarTexto(contenidoArchivoCompleto);

            //Fase 4
            SimuladorGlobal = new RoundRobin();
            SimuladorGlobal.EjecutarSimulacion(Gestor.Canal1, Gestor.Canal2, Gestor.Canal3);

            MessageBox.Show("Guardados " + SimuladorGlobal.ColaGuardado.Contador + " | Eliminados: " + SimuladorGlobal.ColaEliminados.Contador, "completado! ");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (builderGlobal == null || builderGlobal.BicolaPaginas.contador <= 1) return;

            Pagina pag = builderGlobal.BicolaPaginas.ExtraerFinal();
            builderGlobal.BicolaPaginas.InsertarFrente(pag);

            MostrarImagenActual();
        }

        private void MostrarImagenActual()
        {
            if (builderGlobal == null || builderGlobal.BicolaPaginas.contador == 0) return;

            Pagina pag = builderGlobal.BicolaPaginas.Frente.Dato;

            if (pag != null)
            {
                label1.Text = pag.Texto;

                if (pag.ImagenActual == null)
                {
                    MessageBox.Show("la imagen es nula, el extractor no la guardo bien");
                    PictureBox1.Image = null;
                }
                else
                {
                    PictureBox1.Image = pag.ImagenActual;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (builderGlobal == null || builderGlobal.BicolaPaginas.contador <= 1) return;

            Pagina pag = builderGlobal.BicolaPaginas.ExtraerFrente();
            builderGlobal.BicolaPaginas.InsertarFinal(pag);

            MostrarImagenActual();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            AudioPlayer.Detener();
        }
    }

}
