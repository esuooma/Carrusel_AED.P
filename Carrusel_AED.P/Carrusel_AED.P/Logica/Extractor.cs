using Carrusel_AED.P.Modelos;
using Carrusel_AED.P.TDAs;
using System;
using System.Text;

namespace Carrusel_AED.P.Logica
{
    public class Extractor
    {
        public Registro ExtraerRegistro(string linea)
        {
            string id = "000";
            int canal = 1; // Por defecto
            string operacion = "DESCONOCIDA";
            string payload = "";

            // Usamos la Pila con Bicola como pide el PDF
            PilaConBicola<char> pila = new PilaConBicola<char>();
            StringBuilder sb = new StringBuilder();

            // Variable para saber qué estamos leyendo
            char enBloque = ' ';
            bool leyendoOperacion = false;

            foreach (char c in linea)
            {
                if (c == '[' || c == '(' || c == '{')
                {
                    pila.Apilar(c);
                    enBloque = c;
                    sb.Clear();
                }
                else if (c == ']' || c == ')' || c == '}')
                {
                    // Desapilamos de forma segura
                    if (!pila.vacia()) pila.DesApilar();

                    string texto = sb.ToString().Trim();

                    // Dependiendo de qué bloque cerramos, guardamos el dato
                    if (enBloque == '[')
                    {
                        // Asumimos que adentro del corchete viene el CANAL
                        int.TryParse(texto, out canal);
                    }
                    else if (enBloque == '(')
                    {
                        // Asumimos que adentro del paréntesis viene el ID
                        id = texto;
                    }
                    else if (enBloque == '{')
                    {
                        // Adentro de las llaves viene el PAYLOAD (Mensaje)
                        payload = texto;
                    }

                    enBloque = ' '; // Reiniciamos el bloque
                }
                else if (c == '<')
                {
                    // Si abre el símbolo de operación
                    leyendoOperacion = true;
                    sb.Clear();
                }
                else if (c == '>')
                {
                    // Si cierra el símbolo de operación
                    operacion = sb.ToString().Trim();
                    leyendoOperacion = false;
                }
                else
                {
                    // Si no es un delimitador, guardamos la letra
                    if (enBloque != ' ')
                    {
                        sb.Append(c);
                    }
                    else if (leyendoOperacion)
                    {
                        sb.Append(c);
                    }
                }
            }

            return new Registro(id, canal, operacion, payload);
        }
    }
}