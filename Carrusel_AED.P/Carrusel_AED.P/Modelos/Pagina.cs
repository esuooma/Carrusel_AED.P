using System.Drawing;
using System.IO;

namespace Carrusel_AED.P.Modelos
{
    public class Pagina
    {
        public int Numero { get; set; }
        public string Texto { get; set; }
        public Image ImagenActual { get; set; }

        public Pagina()
        {
            Numero = 0;
            Texto = "";
            ImagenActual = null;
        }

        // Código del profesor para decodificar
        public void CargarImagenDesdeBase64(string base64)
        {
            if (string.IsNullOrEmpty(base64)) return;

            try
            {
                byte[] bytes = System.Convert.FromBase64String(base64);
                using (var ms = new MemoryStream(bytes))
                {
                    // Usamos el truco del profesor: clonar la imagen para cerrar el stream
                    using (var imgTemporal = Image.FromStream(ms))
                    {
                        ImagenActual = new Bitmap(imgTemporal);
                    }
                }
            }
            catch { ImagenActual = null; }
        }
    }
}