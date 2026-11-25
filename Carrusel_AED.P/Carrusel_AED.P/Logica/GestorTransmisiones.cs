using Carrusel_AED.P.Modelos;
using Carrusel_AED.P.TDAs;
using System;
using System.Linq.Expressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Carrusel_AED.P.Logica
{
    public class GestorTransmisiones
    {
        // Estas son las 3 colas para los canalaes 
        public ColaConBicola<Registro> Canal1 { get; private set; }
        public ColaConBicola<Registro> Canal2 { get; private set; }
        public ColaConBicola<Registro> Canal3 { get; private set; }

        public GestorTransmisiones()
        {
            Canal1 = new ColaConBicola<Registro>();
            Canal2 = new ColaConBicola<Registro>();
            Canal3 = new ColaConBicola<Registro>();
        }

        public void ProcesarTexto(string contenidoArchivo)
        {
            // Limpiamos por si se procesa dos veces
            Canal1 = new ColaConBicola<Registro>();
            Canal2 = new ColaConBicola<Registro>();
            Canal3 = new ColaConBicola<Registro>();

            Extractor extractor = new Extractor();
            string[] lineas = contenidoArchivo.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            int error = 0; 
            

            foreach (string linea in lineas)
            {
                try
                {
                    Registro reg = extractor.ExtraerRegistro(linea);
                    if (reg.Canal == 1) Canal1.Encolar(reg);
                    else if (reg.Canal == 2) Canal2.Encolar(reg);
                    else Canal3.Encolar(reg);
                }
                catch (Exception)
                {
                    error++;
                }
                
            }
            if (error > 0)
            {
                System.Windows.Forms.MessageBox.Show("Hubo " + error + " errores al procesar líneas. Revisa el formato del TXT.");
            }
        }
       
    }
   
}

