using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar
{
    class Nodo
    {
        public int X { get; set; }
        public int Y { get; set; }
        public double h { get; set; }
        // valor obtenido con la heurística, es la distancia a la meta
        // tal vez no es necesario conservar este valor
        public double g { get; set; }
        // costo para llegar a este nodo

        public Nodo[] hijo; // esto se puede llamar "vecino"?
        public int numhijos;
        public Nodo padre; // este el nodo anterior en el camino?

        //--------------------------------------------------------------
        public Nodo()
        {
            hijo = new Nodo[4]; //8];
            // inicia con 8 hijos, 
            // eso significa que el camino puede ser en diagonal (agrega un poco de dificultad)
            g = -1; //este valor indica que el costo no ha sido evaluado
        }
        //--------------------------------------------------------------
        public double f() { return h + g; } // el costo total es la suma de los costos anteriores
        //--------------------------------------------------------------
        public void calcular_h(Nodo meta)
        {
            // distancia euclidiana
            h = Math.Sqrt((meta.X - X) * (meta.X - X) + (meta.Y - Y) * (meta.Y - Y));
        }
        //--------------------------------------------------------------
    }
}
