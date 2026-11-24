using System;

namespace Carrusel_AED.P.TDAs
{
    public class Nodo<T>
    {
        public T Dato { get; set; }
        public Nodo<T> Siguiente { get; set; }
        public Nodo<T> Anterior { get; set; }

        public Nodo(T dato)
        {
            this.Dato = dato; 
            this.Siguiente = null;
            this.Anterior = null;
        }
    }
}