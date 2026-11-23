using System;
// TDA espejo de la pila implementada con una bicola.

namespace Proyecto_Carrusel.TDAS
{
    public class PilaConBicola<T>
    {
        private Bicola<T> bicolaInterna;

        public PilaConBicola()
        {
            bicolaInterna = new Bicola<T>();
        }

        public void Apilar(T dato)
        {
            bicolaInterna.InsertarFrente(dato);
        }

        public T DesApilar()
        {
            return bicolaInterna.ExtraerFrente();
        }

        public bool vacia()
        {
            return bicolaInterna.vacia();
        }
    }
}

