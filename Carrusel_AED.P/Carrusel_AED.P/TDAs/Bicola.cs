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
                Final.Siguiente = nuevo;
                nuevo.Anterior = Final;
                Final = nuevo;
            }
            contador++;
        }

        // insertar frente 

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
                nuevo.Siguiente = Frente;
                Frente.Anterior = nuevo;
                Frente = nuevo;
            }
            contador++;
        }
        //extraer por el frente (pila y cola)
        public T ExtraerFrente()
        {
            if (vacia()) return default(T);

            // 1. Guardamos el dato del nodo que está al frente
            T dato = Frente.Dato;

            if (Frente == Final) // Si solo queda un elemento
            {
                Frente = null;
                Final = null;
            }
            else
            {
                // 2. Movemos el frente al siguiente nodo
                Frente = Frente.Siguiente;
                Frente.Anterior = null;
            }

            contador--;

            // 3. Retornamos el dato que guardamos al principio
            return dato;
        }

        //insertar por el final (para la cola)
        public T ExtraerFinal()
        {
            if (vacia()) return default(T);

            T dato = Final.Dato;
            if (Frente == Final)
            {
                Frente = null;
                Final = null;
            }
            else
            {
                Final = Final.Anterior;
                Final.Siguiente = null;
            }
            contador--;
            return dato;
        }
    }
}