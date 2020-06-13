using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug
{
    class Nodo
    {
        // Esta clase crea nodos fijos
        // Se conectan a otros nodos con la lista de vecinos

        public double x; //coordenadas
        public double y;
        public double dist = -1; //distancia recorrida, por ahora no está calculada
        public bool visto = false; //este nodo no ha sido visto (o visitado)

        public Circulo c; //se usa para dibujar el nodo

        public List<Nodo> vecino; //lista de nodos vecinos, asignados después de la triangulación
        public Nodo padre; //indica el nodo precedente en la ruta más corta

        //------------------------------------------------------------------------------
        public Nodo(double _x, double _y, Circulo _c)
        {
            // constructor
            this.x = _x; //asignar coordenadas
            this.y = _y;
            this.c = _c;
            vecino = new List<Nodo>(); //crear lista de vecinos
        }
        //------------------------------------------------------------------------------
        public double Distancia_a_nodo(Nodo nd)
        {
            // distancia euclidiana
            return Math.Sqrt((nd.x - x) * (nd.x - x) + (nd.y - y) * (nd.y - y));
        }
        //------------------------------------------------------------------------------
        public void Agregar_vecino(Nodo nd)
        {
            if (nd == null) return; //no agregar si es null

            if (vecino.Contains(nd) == false) //si todavía no está agregado
            {
                vecino.Add(nd); //agregar a la lista dinámica
            }

            if (nd.vecino.Contains(this) == false)
            {
                nd.vecino.Add(this);
            }
        }
        //------------------------------------------------------------------------------
    }
}
