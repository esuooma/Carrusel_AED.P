using Carrusel_AED.P.Modelos;
using Carrusel_AED.P.TDAs;
using System;
using System.Text;
using System.Web;

namespace Carrusel_AED.P.Logica
{
    internal class StoryBuilder
    {
        public Bicola<Pagina> BicolaPaginas { get; private set; }
        public string AudioGlobal { get; private set; }

        public StoryBuilder()
        {
            BicolaPaginas = new Bicola<Pagina>();
            AudioGlobal = "";

        }

        public void ConstruirHistoria(ColaConBicola<Registro> colaGuardado)
        {
            string imagenes = ""; // Conserva la última imagen decodificada
            string audioBase64 = "";    // Pista de fondo
            int numeroPagina = 1;
            string base64ImagenActual = "";

            while (!colaGuardado.vacia())
            {
                Registro reg = colaGuardado.DesEncolar();
                string op = reg.Operacion != null ? reg.Operacion : "";

                if (op.Contains("AUDIO"))
                {
                    AudioGlobal = reg.Payload; // Solo actualiza la pista de audio
                }
                else if (op.Contains("IMAGEN"))
                {
                    base64ImagenActual = reg.Payload; // Solo actualiza la imagen actual
                }
                else if (op.Contains("TEXTO"))
                {

                    // 1. Desencriptar el texto con la Pila
                    PilaConBicola<char> pilaTexto = new PilaConBicola<char>();
                    string textoDesencriptado = "";

                    foreach (char letra in reg.Payload) pilaTexto.Apilar(letra);
                    while (!pilaTexto.vacia()) textoDesencriptado += pilaTexto.DesApilar();

                    if (string.IsNullOrEmpty(base64ImagenActual))
                    {
                        string muestra = base64ImagenActual.Length > 50 ? base64ImagenActual.Substring(0, 50) : base64ImagenActual;
                    }


                    // 2. Crear la nueva página con la imagen que se venía guardando y el texto
                    Pagina nuevaPagina = new Pagina();
                    nuevaPagina.Numero = numeroPagina;
                    nuevaPagina.Texto = textoDesencriptado;

                    nuevaPagina.CargarImagenDesdeBase64(base64ImagenActual);

                    // 3. Insertar la página en la Bicola
                    BicolaPaginas.InsertarFinal(nuevaPagina);

                    numeroPagina++;
                    base64ImagenActual = ""; // Limpiamos para la siguiente página
                }
            }
        }
    }
}




