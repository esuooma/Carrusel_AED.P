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

            // Le pasamos el texto a tu Cerebro (GestorTransmisiones)
            Gestor.ProcesarTexto(contenidoArchivoCompleto);

            // Mostramos el resultado (Así se concatenan strings sin errores)
            string mensaje = "Procesamiento completo:\n" +
                             "Canal 1: " + Gestor.Canal1.Contador + " registros.\n" +
                             "Canal 2: " + Gestor.Canal2.Contador + " registros.\n" +
                             "Canal 3: " + Gestor.Canal3.Contador + " registros.";

            MessageBox.Show(mensaje, "Resumen");


        }

        private void EjecutarRoundRobin()
        {
            // 1. Limpiamos todo y llenamos de nuevo
            Gestor = new GestorTransmisiones();
            Gestor.ProcesarTexto(contenidoArchivoCompleto);

            MessageBox.Show("Canales listos. C1: " + Gestor.Canal1.Contador + ", C2: " + Gestor.Canal2.Contador);

            // 2. Ejecutamos
            RoundRobin simulador = new RoundRobin();
            simulador.EjecutarSimulacion(Gestor.Canal1, Gestor.Canal2, Gestor.Canal3);

            // 3. Resultado
            MessageBox.Show("Guardados: " + simulador.ColaGuardado.Contador + " | Eliminados: " + simulador.ColaEliminados.Contador);
        }
    }
}
