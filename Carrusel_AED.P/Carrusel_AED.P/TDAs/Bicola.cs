using System;

namespace Carrusel_AED.P.TDAs
{
    public class Bicola<T>
    {
        public Nodo<T> Frente { get; private set; }
        public Nodo<T> Final { get; private set; }
        public int contador { get; private set; }

        public Bicola()
        {
            Frente = null;
            Final = null;
            contador = 0;
        }

        public bool vacia()
        {
            return Frente == null;
        }
        // insertar por el final 
        public void InsertarFinal(T dato)
        {
            Nodo<T> nuevo = new Nodo<T>(dato);
            if (vacia())
            {
                Frente = nuevo;
                Final = nuevo;
            }
            else
            {
                Final.siguiente = nuevo;
                nuevo.anterior = Final;
                Final = nuevo;
            }
            contador++;
        }

        // insertar frente (para la pila)

        public void InsertarFrente(T dato)
        {
            Nodo<T> nuevo = new Nodo<T>(dato);
            if (vacia())
            {
                Frente = nuevo;
                Final = nuevo;
            }
            else
            {
                nuevo.siguiente = Frente;
                Frente.anterior = nuevo;
                Frente = nuevo;
            }
            contador++;
        }
        //extraer por el frente (pila y cola)
        public T ExtraerFrente()
        {
            if (vacia()) return default(T);

            T dato = Frente.dato;
            if (Frente == Final) //queda un elemento
            {
                Frente = null;
                Final = null;
            }
            else
            {
                Frente = Frente.siguiente;
                Frente.anterior = null;
            }
            contador--;
            return dato;
        }

        //insertar por el final (para la cola)
        public T ExtraerFinal()
        {
            if (vacia()) return default(T);

            T dato = Final.dato;
            if (Frente == Final)
            {
                Frente = null;
                Final = null;
            }
            else
            {
                Final = Final.anterior;
                Final.siguiente = null;
            }
            contador--;
            return dato;
        }
    }
}