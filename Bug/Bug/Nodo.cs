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
        // No se utilizan objetos para las aristas

        public double x; //coordenadas
        public double y;
        //public double f; //costo total f = g  h
        //public double g; //costo para llegar a este nodo
        //public double h; //costo heurística
        public double dist = -1; //distancia recorrida, por ahora no está calculada
        public bool visto = false; //este nodo no ha sido visto (o visitado)

        public Circulo c; //se usa para dibujar el nodo

        List<Nodo> vecino; //lista de nodos vecinos, asignados después de la triangulación
        Nodo padre; //indica el nodo precedente en la ruta más corta

        //------------------------------------------------------------------------------
        public Nodo(double x, double y, Circulo c)
        {
            // constructor
            this.x = x; //asignar coordenadas
            this.y = y;
            this.c = c;
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
            vecino.Add(nd);
        }
    }
}
