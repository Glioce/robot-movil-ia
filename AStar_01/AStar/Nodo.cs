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

        // valor obtenido con la heurística, es la distancia a la meta
        // tal vez no es necesario conservar este valor
        public double h { get; set; }

        // costo para llegar a este nodo
        public double g { get; set; }

        // costo total estimado
        public double f { get; set; }

        public Nodo[] hijo; // esto se puede llamar "vecino"?
        public int numhijos = 0;
        public Nodo padre; // este el nodo anterior en el camino?
        public bool es_obstaculo = false;

        //--------------------------------------------------------------
        public Nodo(int xx, int yy)
        {
            hijo = new Nodo[4]; //8];
            // inicia con 8 hijos, 
            // eso significa que el camino puede ser en diagonal (agrega un poco de dificultad)

            this.g = -1; //este valor indica que el costo no ha sido evaluado
            this.X = xx; //posición x
            this.Y = yy; //posición y
        }
        //--------------------------------------------------------------
        public void Calcular_f()
        {
            // el costo total es la suma de los costos anteriores
            f = h + g;
        }
        //--------------------------------------------------------------
        public void Calcular_h(Nodo meta)
        {
            // distancia euclidiana
            h = Math.Sqrt((meta.X - X) * (meta.X - X) + (meta.Y - Y) * (meta.Y - Y));
        }
        //--------------------------------------------------------------
        public double Distancia_a_nodo(Nodo nd)
        {
            // distancia euclidiana
            return Math.Sqrt((nd.X - X) * (nd.X - X) + (nd.Y - Y) * (nd.Y - Y));
        }
        //--------------------------------------------------------------
        public void Agregar_hijo(Nodo nd)
        {
            if (nd != null)
                if (nd.es_obstaculo == false)
                {
                    hijo[numhijos] = nd;
                    numhijos++;
                }
        }
    }
}
