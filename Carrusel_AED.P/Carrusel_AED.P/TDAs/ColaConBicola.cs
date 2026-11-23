using System;

namespace Proyecto_Carrusel.TDAS
{
    public class ColaConBicola<T>
    {
        private Bicola<T> bicolaInterna;
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