using System;

namespace Carrusel_AED.P.TDAs
{
    public class ColaConBicola<T>
    {
        private Bicola<T> bicolaInterna;

        public int Contador
        {
            get { return bicolaInterna.contador; }
        }

        public ColaConBicola()
        {
            bicolaInterna = new Bicola<T>();
        }
        public void Encolar(T dato)
        {
            bicolaInterna.InsertarFinal(dato);
        }
        public T DesEncolar()
        {
            return bicolaInterna.ExtraerFrente();
        }
        public bool vacia()
        {
            return bicolaInterna.vacia();
        }
    }
}