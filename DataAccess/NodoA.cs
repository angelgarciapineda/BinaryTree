using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class NodoA
    {
        int dato;
        NodoA izq;
        NodoA der;
        NodoA padre;

        //CONSTRUCTORES
        public NodoA(int d)
        {
            dato = d;
            izq = null;
            der = null;
            padre = null;
        }
        //PROPIEDADES
        public int Dato
        {
            get { return dato; }
        }
        public NodoA Izq
        {
            set { izq = value; }
            get { return izq; }
        }
        public NodoA Der
        {
            set { der = value; }
            get { return der; }
        }

        public NodoA Padre
        {
            set { padre = value; }
            get { return padre; }
        }
    }
}
