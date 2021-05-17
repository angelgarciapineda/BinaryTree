using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Nodo
    {
        private object pEleme;
        public Nodo Liga;

        public object Elemento
        {
            set { pEleme = value; }
            get { return pEleme; }
        }

        public Nodo()
        {
            pEleme = null;
            Liga = null;
        }

        public Nodo(object ElElemento)
        {
            pEleme = ElElemento;
            Liga = null;
        }
    }
}
