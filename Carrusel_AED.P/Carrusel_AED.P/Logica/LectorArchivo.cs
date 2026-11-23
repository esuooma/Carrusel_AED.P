using System;
using System.IO;

namespace Carrusel_AED.P.Logica
{
    public class LectorArchivo
    {
        public string Leer(string nombreArchivo)
        {
            // Usa la ruta del ejecutable de forma segura
            string ruta = Path.Combine(AppContext.BaseDirectory, nombreArchivo);

            if (!File.Exists(ruta))
            {
                // Si no lo encuentra en la raíz del ejecutable, busca en la carpeta Resources
                ruta = Path.Combine(AppContext.BaseDirectory, "Resources", nombreArchivo);
            }

            if (File.Exists(ruta))
            {
                return File.ReadAllText(ruta);
            }

            throw new FileNotFoundException("No se encontró el archivo en: " + ruta);
        }
    }
}