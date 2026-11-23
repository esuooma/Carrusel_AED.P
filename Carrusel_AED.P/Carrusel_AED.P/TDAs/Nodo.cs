using System;

namespace Proyecto_Carrusel.TDAS
{
    public class Nodo<T>
    {
        public T dato { get; set; }
        public Nodo<T> siguiente { get; set; }
        public Nodo<T> anterior { get; set; }

        public Nodo(T dato)
        {
            dato = dato;
            siguiente = null;
            anterior = null;
        }
    }
}
