﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
//using System.Windows.Forms;

namespace Bug
{
    class Dijkstra
    {
        // En esta clase se implementa el algoritmo de Dijkstra
        // Esta clase recibe una lista de nodos
        // Cada nodo tiene una lista de vecinos, con la que se forma el grafo

        List<Nodo> nodos; // lista de todos los nodos
        List<Nodo> cola; // cola de prioridad

        Nodo inicio;
        Nodo meta;

        private double cx, cy, cr; //variables para calcular circunferencia que pasa por 3 puntos

        //Bitmap b;
        //Graphics mapa;
        //PictureBox pictureBox;

        //------------------------------------------------------------------------------
        public Dijkstra(List<Nodo> nodos)
        {
            // constructor - recibir lista de nodos
            this.nodos = nodos;
        }

        //------------------------------------------------------------------------------
        public void Triangular()
        {
            // Asignar vecinos a los nodos usando Triangulación de Delaunay
            // Algoritmo de fuerza bruta

            int n = nodos.Count(); //número de nodos

            // revisar todas las combinaciones de 3 nodos
            for (int i = 0; i < (n - 2); i++)
            {
                for (int j = (i + 1); j < (n - 1); j++)
                {
                    for (int k = (j + 1); k < n; k++)
                    {
                        // calcular circunferencia que pasa por los 3 nodos actuales
                        // luego revisar que no hay otro nodo en la circunferencia
                        if (Circunferencia3Nodos(nodos[i], nodos[j], nodos[k]))
                        {
                            if (ComprobarDelaunay(i, j , k) == 1)
                            {
                                // Los 3 nodos son  pueden ser vecinos
                                // revisar que la líneas de conexión no cruzan pixeles negros

                                if (nodos[i].c.PuedeVerA( nodos[j].c))
                                {
                                    nodos[i].Agregar_vecino( nodos[j]);
                                }
                                if (nodos[i].c.PuedeVerA( nodos[k].c))
                                {
                                    nodos[i].Agregar_vecino(nodos[k]);
                                }
                                if (nodos[j].c.PuedeVerA( nodos[k].c))
                                {
                                    nodos[j].Agregar_vecino(nodos[k]);
                                }
                            }
                        }
                        // si no hay circunferencia, entonces los 3 nodos son colineales
                        else
                        {
                            // No agregamos vecinos por ahora
                        }
                    }
                }
            }

            // Dibujar conexiones con los vecinos
            for (int i = 0; i < nodos.Count(); i++)
            {
                Nodo _n = nodos[i];
                for (int j = 0; j < _n.vecino.Count(); j++)
                {
                    nodos[0].c.DibujarLinea(
                        (float)_n.x,
                        (float)_n.y,
                        (float)_n.vecino[j].x,
                        (float)_n.vecino[j].y,
                        Color.Blue);
                }
            }
                
        }
        //------------------------------------------------------------------------------
        public bool Circunferencia3Nodos(Nodo n1, Nodo n2, Nodo n3)
        {
            // Encontrar circunferencia que pasa por 3 puntos (3 nodos en este caso)
            // Usa método de mediatrices
            // Si se encuentra una circunferencia, se asignan las variables cx, cy, cr

            // Ecuación de la primera mediatriz: ax + by = c
            double a = 2 * (n2.x - n1.x);
            double b = 2 * (n2.y - n1.y);
            double c = (n2.x * n2.x) - (n1.x * n1.x) + (n2.y * n2.y) - (n1.y * n1.y);

            // Ecuación de la segunda mediatriz: dx + ey = f
            double d = 2 * (n3.x - n1.x);
            double e = 2 * (n3.y - n1.y);
            double f = (n3.x * n3.x) - (n1.x * n1.x) + (n3.y * n3.y) - (n1.y * n1.y);

            // Determinante principal
            double D = (a * e) - (b * d);

            if (D != 0) //si el determinante es diferente de cero, existe una circunferencia
            {
                cx = ((c * e) - (f * b)) / D; //centro de la circunferencia
                cy = ((f * a) - (c * d)) / D;
                cr = Math.Sqrt((n1.x - cx) * (n1.x - cx) + (n1.y - cy) * (n1.y - cy)); //radio
                return true; //se encontró circunferencia
            }

            // si el determinante es cero, no existe la circunferencia
            return false;
        }
        //------------------------------------------------------------------------------
        public int ComprobarDelaunay(int a, int b, int c)
        {
            // Comprobar que la circunferencia con centro en cx, cy
            // y radio cr, no contiene nodos en su interior
            // Se recorre toda la lista de nodos.
            // Los índices a, b, c no se revisan porque forman parte de la circunferencia.

            // hay 3 posibles situaciones
            // 0: hay nodos en el interior
            // 1: no hay nodos en el interior
            // 2: hay nodos en la circunferencia

            for (int i = 0; i < nodos.Count; i++)
            {
                if ((i == a) || (i == b) || (i == c)) continue;

                Nodo _n = nodos[i]; // nodo a revisar
                //distancia al centro de la circunferencia
                double _d = Math.Sqrt((_n.x - cx) * (_n.x - cx) + (_n.y - cy) * (_n.y - cy));

                if (_d > cr) continue; // está fuera, revisar siguiente nodo

                if (_d < cr) return 0; // hay nodos en el interior

                //if (_d == cr) ¿qué hacer?
            }

            return 1; // no contiene otros nodos
        }
    }
}
