using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Numerics;
using System.Text;
using System.Windows.Forms;
using Carrusel_AED.P.Logica;
using Carrusel_AED.P.TDAs;

namespace Carrusel_AED.P
{
    public partial class Form1 : Form
    {
        private string contenidoArchivoCompleto;

        private RoundRobin SimuladorGlobal; 

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
            btnCargar.Location = new System.Drawing.Point(20, 20);
            btnCargar.Click += (s, e) => CargarArchivo();
            this.Controls.Add(btnCargar);

            // Botón 2: Procesar
            Button btnProcesar = new Button();
            btnProcesar.Text = "Fase.2";
            btnProcesar.Location = new System.Drawing.Point(150, 20);
            btnProcesar.Click += (s, e) => ProcesarYEncolar();
            this.Controls.Add(btnProcesar);

            // Botón 3: Round Robin
            Button btnRoundRobin = new Button();
            btnRoundRobin.Text = "Fase.3";
            btnRoundRobin.Location = new System.Drawing.Point(300, 20);
            btnRoundRobin.Click += (s, e) => EjecutarRoundRobin();
            this.Controls.Add(btnRoundRobin);

            // Botón 4: Destruir
            Button btnDestruir = new Button();
            btnDestruir.Text = "4. Destruir Eliminados";
            btnDestruir.Location = new System.Drawing.Point(450, 20); 
            btnDestruir.Click += (s, e) => {

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
            btnFase5.Location = new System.Drawing.Point(600, 20);
            btnFase5.Click += (s, e) =>
            {
                if (SimuladorGlobal == null)
                {
                    MessageBox.Show("Primero haz el RoundRobin.");
                    return;
                }

                StoryBuilder builder = new StoryBuilder();
                builder.ConstruirHistoria(SimuladorGlobal.ColaGuardado);

                MessageBox.Show("Se armaron " + builder.BicolaPaginas.contador + " páginas.", "Fase 5");
            };
            this.Controls.Add(btnFase5);
        }

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
    }
}
