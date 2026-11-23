using System;
using System.Text;
using Proyecto_Carrusel.TDAS;
using Proyecto_Carrusel.Modelos;

namespace Proyecto_Carrusel.Logica
{
    public class Extractor
    {
        public Registro ExtraerRegistro(string linea)
        {
            string textoId = "";
            string textoCanal = "";
            string textoOperacion = "";
            string textoPayload = "";

            // Usamos la Pila para el balanceo y StringBuilder para armar el texto
            PilaConBicola<char> pila = new PilaConBicola<char>();
            StringBuilder sb = new StringBuilder();

            // Variable para saber qué estamos leyendo en este momento
            char enBloque = ' ';

            foreach (char p in linea)
            {
                // 1. Si es un símbolo de apertura, lo apilamos y marcamos el bloque
                if (p == '[' || p == '(' || p == '{')
                {
                    pila.Apilar(p);
                    enBloque = p;
                    sb.Clear(); // Empezamos a guardar texto limpio
                }
                // 2. Si es un símbolo de cierre, desapilamos y guardamos lo extraído
                else if (p == ']' || p == ')' || p == '}')
                {
                    char apertura = pila.DesApilar(); // Aquí validas que haga match

                    string textoLimpio = sb.ToString().Trim();

                    // Dependiendo del bloque del que salimos, asignamos los datos
                    if (enBloque == '[')
                    {
                        // Aquí viene el ID, canal y operacion separados por comas
                        // Ejemplo: id:001, canal:1, operacion:AUDIO
                        // (Para simplificar, separamos por comas)
                        string[] partes = textoLimpio.Split(',');
                        foreach (string parte in partes)
                        {
                            if (parte.Contains("id:")) textoId = parte.Replace("id:", "").Trim();
                            if (parte.Contains("canal:")) textoCanal = parte.Replace("canal:", "").Trim();
                            if (parte.Contains("operacion:")) textoOperacion = parte.Replace("operacion:", "").Trim();
                        }
                    }
                    else if (enBloque == '{')
                    {
                        textoPayload = textoLimpio; // El texto del mensaje
                    }

                    enBloque = ' '; // Terminó el bloque
                }
                // 3. Si no es un delimitador, guardamos el texto interno
                else
                {
                    if (enBloque != ' ')
                    {
                        sb.Append(p);
                    }
                }
            }

            // Convertimos el canal a entero para el Registro
            int canalFinal = int.TryParse(textoCanal, out int c) ? c : 1;

            return new Registro(textoId, canalFinal, textoOperacion, textoPayload);
        }
    }
}

