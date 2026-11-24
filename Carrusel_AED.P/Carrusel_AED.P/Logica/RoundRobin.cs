using Carrusel_AED.P.Modelos;
using Carrusel_AED.P.TDAs;
using System;
using System.Windows.Forms;

namespace Carrusel_AED.P.Logica
{
    public class RoundRobin
    {
        public ColaConBicola<Registro> ColaGuardado { get; private set; }
        public ColaConBicola<Registro> ColaEliminados { get; private set; }

        public RoundRobin()
        {
            ColaGuardado = new ColaConBicola<Registro>();
            ColaEliminados = new ColaConBicola<Registro>();
        }

        // Ahora el método recibe las colas DIRECTAMENTE aquí
        public void EjecutarSimulacion(ColaConBicola<Registro> canal1, ColaConBicola<Registro> canal2, ColaConBicola<Registro> canal3)
        {
            int turno = 1;
            int procesados = 0;
            int vueltasSeguridad = 0; // Para evitar un bucle infinito

            // Bucle infinito controlado
            while (vueltasSeguridad < 500)
            {
                vueltasSeguridad++;
                Registro registroActual = null;

                // Intentamos sacar del canal 1
                if (turno == 1)
                {
                    registroActual = canal1.DesEncolar();
                }
                else if (turno == 2)
                {
                    registroActual = canal2.DesEncolar();
                }
                else if (turno == 3)
                {
                    registroActual = canal3.DesEncolar();
                }

                // Si sacamos un registro válido, lo procesamos
                if (registroActual != null)
                {
                    procesados++;
                    ProcesarRegistro(registroActual);
                }

                // Avanzamos el turno
                turno++;
                if (turno > 3) turno = 1;

                // CONDICIÓN DE SALIDA: Si los 3 canales están vacíos, salimos
                if (canal1.Contador == 0 && canal2.Contador == 0 && canal3.Contador == 0)
                {
                    break;
                }
            }

            System.Windows.Forms.MessageBox.Show("El bucle while sacó un total de: " + procesados + " registros de los canales.");
        }

        private void ProcesarRegistro(Registro reg)
        {
            // Si por alguna razon la operacion viene nula, la forzamos a vacio
            string op = reg.Operacion != null ? reg.Operacion : "";

            if (op.Contains("AUDIO") || op.Contains("IMAGEN") || op.Contains("TEXTO"))
            {
                ColaGuardado.Encolar(reg);
            }
            else if (op.Contains("DESTRUIR"))
            {
                ColaEliminados.Encolar(reg);
            }
            else if (op.Contains("INVERTIR"))
            {
                InvertirColaGuardado();
            }
            else
            {
                ColaGuardado.Encolar(reg); // Guardado por defecto
            }
        }

        private void InvertirColaGuardado()
        {
            PilaConBicola<Registro> pilaAux = new PilaConBicola<Registro>();
            while (ColaGuardado.Contador > 0)
            {
                pilaAux.Apilar(ColaGuardado.DesEncolar());
            }
            while (pilaAux.contador > 0)
            {
                ColaGuardado.Encolar(pilaAux.DesApilar());
            }
        }
    }
}