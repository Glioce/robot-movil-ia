using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Drawing;
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

        //Bitmap b;
        //Graphics mapa;
        //PictureBox pictureBox;

        //------------------------------------------------------------------------------
        public Dijkstra(List<Nodo> lista)
        {
            // constructor - recibir lista de nodos
            this.nodos = lista;
        }
    }
}
