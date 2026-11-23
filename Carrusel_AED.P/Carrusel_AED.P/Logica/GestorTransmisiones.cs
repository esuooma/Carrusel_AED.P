using System;
using Carrusel_AED.P.Modelos;
using Carrusel_AED.P.TDAs;

namespace Carrusel_AED.P.Logica
{
    public class GestorTransmisiones
    {
        // Estas son las 3 colas que el Frontend podrá consultar
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

            int contadorCanal1 = 0;
            int contadorCanal2 = 0;
            int contadorCanal3 = 0;

            foreach (string linea in lineas)
            {
                Registro reg = extractor.ExtraerRegistro(linea);

                if (reg.Canal == 1)
                {
                    Canal1.Encolar(reg);
                    contadorCanal1++;
                }
                else if (reg.Canal == 2)
                {
                    Canal2.Encolar(reg);
                    contadorCanal2++;
                }
                else
                {
                    Canal3.Encolar(reg);
                    contadorCanal3++;
                }
            }
        }
    }
}