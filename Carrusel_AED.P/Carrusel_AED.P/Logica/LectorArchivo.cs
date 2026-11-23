using System.IO;

namespace Proyecto_Carrusel.Logica
{
    public class LectorArchivo
    {
        public string Leer(string ruta)
        {
            if (File.Exists(ruta))
            {
                return File.ReadAllText(ruta);
            }
            else
            {
                throw new FileNotFoundException($"El archivo en la ruta {ruta} no existe.");
            }
        }
    }
}