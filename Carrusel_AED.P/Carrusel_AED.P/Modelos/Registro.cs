using System;

namespace Carrusel_AED.P.Modelos
{
    public class Registro
    {                 // constructor, con atributos de la clase registro 
        public string Id { get; set; }
        public int Canal { get; set; }
        public string Operacion { get; set; }
        public string Payload { get; set; }

        public Registro(string id, int canal, string operacion, string payload)
        {
            Id = id;
            Canal = canal;                // guarda el contenido del .txt en los atributos de la clase registro
            Operacion = operacion;
            Payload = payload;
        }
    }
}
