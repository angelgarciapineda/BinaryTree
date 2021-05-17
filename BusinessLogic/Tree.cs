using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace BusinessLogic
{
    public class Tree
    {
        public NodoA raiz;
        List<int> inOrder = new List<int>();
        List<int> preOrder = new List<int>();
        List<int> postOrder = new List<int>();
        //CONSTRUCTORES
        public Tree()
        {
            raiz = null;
        }

        public Tree(int dato)
        {
            NodoA nuevo = new NodoA(dato);
            raiz = nuevo;
        }

        public String Insertar(int dato)
        {
            string msj = "";
            raiz = Insertar(dato, raiz, ref msj);
            return msj;
        }

        private NodoA Insertar(int dato, NodoA rz, ref string msj)
        {
            if (rz == null)
            {
                NodoA nuevo = new NodoA(dato);
                rz = nuevo;
                raiz = nuevo;
            }
            else
            {
                NodoA actual = rz;
                if (actual.Dato > dato)
                {
                    actual.Izq = Insertar(dato, actual.Izq, ref msj);
                    actual.Izq.Padre = actual;
                }
                if (actual.Dato < dato)
                {
                    actual.Der = Insertar(dato, actual.Der, ref msj);
                    actual.Der.Padre = actual;
                }
                if (actual.Dato == dato)
                {
                    msj = "No se puede insertar datos duplicados";
                }
            }
            return rz;
        }

        public List<int> enOrden()
        {
            return enOrden(raiz);
        }

        private List<int> enOrden(NodoA rz)
        {

            if (rz.Izq != null)
            {
                enOrden(rz.Izq);
            }
            //MessageBox.Show(rz.Dato + " ");
            inOrder.Add(rz.Dato);
            if (rz.Der != null)
            {
                enOrden(rz.Der);
            }
            return inOrder;
        }

        public List<int> preOrden()
        {
            return PreOrden(raiz);
        }

        private List<int> PreOrden(NodoA rz)
        {
            //MessageBox.Show(rz.Dato + " ");
            preOrder.Add(rz.Dato);
            if (rz.Izq != null)
            {
                PreOrden(rz.Izq);
            }

            if (rz.Der != null)
            {
                PreOrden(rz.Der);
            }
            return preOrder;
        }

        public List<int> postOrden()
        {
            return PostOrden(raiz);
        }

        private List<int> PostOrden(NodoA rz)
        {
            if (rz.Izq != null)
            {
                PostOrden(rz.Izq);
            }

            if (rz.Der != null)
            {
                PostOrden(rz.Der);
            }
            //MessageBox.Show(rz.Dato + " ");
            postOrder.Add(rz.Dato);
            return postOrder;
        }

        public int Search(int dato)
        {
            int e = -1;
            if (Busca(dato, raiz) != null) e = Busca(dato, raiz).Dato;
            else e = -1;
            return e;
        }

        public NodoA Busca(int dato)
        {
            NodoA aux = Busca(dato, raiz);
            return aux;
        }

        public NodoA Busca(int dato, NodoA rz)
        {
            NodoA aux = null;
            if (rz != null)
            {
                if (rz.Dato > dato)
                {
                    aux = Busca(dato, rz.Izq);
                }

                else if (rz.Dato < dato)
                {
                    aux = Busca(dato, rz.Der);
                }
                else if (rz.Dato == dato)
                {
                    aux = rz;
                }
            }
            else
            {
                aux = null;
            }
            return aux;
        }

        public Pila alaPila(NodoA nodo, Pila lapila)
        {
            if (nodo != null)
            {
                lapila.Push(nodo.Dato);
            }
            if (nodo.Izq != null)
            {
                alaPila(nodo.Izq, lapila);
            }
            if (nodo.Der != null)
            {
                alaPila(nodo.Der, lapila);
            }
            return lapila;
        }

        public void Borrar(int dato)
        {
            NodoA nodo = Busca(dato);
            if (nodo == raiz)
            {
                if ((nodo.Izq == null) && (nodo.Der == null))
                    raiz = null;
                else if ((nodo.Izq != null) && (nodo.Der == null))
                    raiz = nodo.Izq;
                else if ((nodo.Izq == null) && (nodo.Der != null))
                    raiz = nodo.Der;
                else if ((nodo.Izq != null) && (nodo.Der != null))
                {
                    Pila miPila = new Pila();
                    miPila = alaPila(nodo, miPila);
                    raiz = null;

                    while (!miPila.PilaVacia())
                    {
                        int n;
                        if ((n = (Convert.ToInt32(miPila.Pop()))) != dato)
                            Insertar(n);
                    }
                }

            }

            else if (nodo != raiz)
            {
                if (nodo.Izq == null && (nodo.Der == null))
                {
                    if (nodo.Padre.Izq == nodo)
                    {
                        nodo.Padre.Izq = null;
                    }
                    else
                    {
                        nodo.Padre.Der = null;
                        nodo.Padre = null;
                    }

                }
                else if ((nodo.Izq != null && (nodo.Der == null)))
                {
                    nodo.Izq.Padre = nodo.Padre;
                    if (nodo.Padre.Izq == nodo)
                    {
                        nodo.Padre.Izq = nodo.Izq;
                    }
                    else
                    {
                        nodo.Padre.Der = nodo.Izq;
                    }
                }
                else
                {
                    if ((nodo.Izq == null) && (nodo.Der != null))
                    {
                        nodo.Der.Padre = nodo.Padre;
                        if ((nodo.Padre.Izq) == nodo)
                        {
                            nodo.Padre.Izq = nodo.Der;
                        }
                        else
                        {
                            nodo.Padre.Der = nodo.Der;
                        }
                    }
                    else
                    {
                        if ((nodo.Izq != null) && nodo.Der != null)
                        {
                            Pila miPila = new Pila();
                            miPila = alaPila(nodo, miPila);

                            if (nodo.Padre.Izq == nodo)
                            {
                                nodo.Padre.Izq = null;
                            }
                            else
                            {
                                nodo.Padre.Der = null;
                            }

                            while (!miPila.PilaVacia())
                            {
                                int n;
                                if ((n = Int32.Parse(miPila.Pop().ToString())) != dato)
                                {
                                    Insertar(n);
                                }
                            }
                        }
                    }
                }
            }
            //MessageBox.Show("Borrado exitoso");
        }
    }
}
