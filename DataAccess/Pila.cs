using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Pila
    {
        Nodo topePila;

        public Pila()
        {
            topePila = null;
        }

        public void Push(object elemento)
        {
            if (topePila == null)
                topePila = new Nodo(elemento);
            else
            {
                Nodo nuevoElemento = new Nodo(elemento);
                nuevoElemento.Liga = topePila;
                topePila = nuevoElemento;
            }
        }

        public object Pop()
        {
            object dato;
            if (topePila == null)
            {
                dato = null;
            }
            else
            {
                dato = topePila.Elemento;
                topePila = topePila.Liga;
            }
            return dato;
        }

        public bool PilaVacia()
        {
            bool r = false;
            if (topePila == null)
            {
                r = true;
            }
            return r;
        }
    }
}
