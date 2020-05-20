using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace AStar
{
    class AStar
    {
        public Nodo inicio = null;
        public Nodo meta = null;
        DataGridView tablero;

        List<Nodo> Open, Closed;

        //Constructor
        public AStar(DataGridView Tablero)
        {
            inicio = new Nodo();
            meta = new Nodo();
            tablero = Tablero;
            Open = new List<Nodo>();
            Closed = new List<Nodo>();
        }
        //------------------------------------------------

        public int EjecutarAlgoritmo()
        {
            // Ejecutar algoritmo A*
            // Pueden existir varios casos de error. Se devuleve un valor por cada tipo de error.

            // Propiedades
            Nodo actual; // es el nodo que se está evanluando dentro del ciclo
            //Nodo hj; //hijo del nodo actual
            double gTemp; //costo g temportal (tentativo)

            // Asignar costos a nodo inicio
            inicio.g = 0; //llegar a esta posición no tiene costo
            inicio.calcular_h(meta); //costo si avanza en línea recta

            // Agregar nodo inicio al conjunto abierto
            Open.Add(inicio);
            //también se podrían asignar lo hijos/vecinos

            // Ciclo del algoritmo
            while (Open.Count > 0) //mientras el conjunto abierto contiene nodos
            {
                actual = Open[0]; //extraer el primer nodo (el conjunto debe estar ordenado)
                Open.RemoveAt(0); //borrar del conjunto

                if (actual == meta) //si llegamos a la meta, terminar ciclo
                {
                    Console.WriteLine("Algoritmo completado");
                    return 1;
                }
                else //si no hemos llegado a la meta, continuar
                {
                    foreach (Nodo hj in actual.hijo) //revisar todos los hijos del nodo actual
                    {
                        if (hj != null) //si es un nodo valido
                        {
                            gTemp = actual.g + 1; //costo tentativo
                            // si ese costo es menor al que se haya evaluado por otro camino
                            // o el hijo no tiene costo todavía
                            if (gTemp < hj.g || hj.g == -1)
                            {
                                hj.padre = actual; //el nodo actual se convierte en padre
                                hj.g = gTemp; //asignar o actualizar costo g
                                hj.calcular_h(meta); //calcular costo h

                                if (Open.Contains(hj) == false) //si el conjunto abierto no contiene el nodo hijo evaluado
                                {
                                    //agregar nodo al conjunto ordenando por el costo f
                                    bool agregado = false;
                                    for (int i = 0; i < Open.Count; i++) //recorrer conjunto abierto
                                    {
                                        if (Open[i].f() > hj.f()) //si el valor f de un elemento en el conjunto es mayor al valor del hijo que se está evaluando
                                        {
                                            Open.Insert(i, hj); //insertar para ocupar su posición
                                            agregado = true; //ya está agregado
                                            break; //terminar for
                                        }

                                    }
                                    //si no se agregó en el for anterior, es porque el conjunto está vacío o no hay un nodo con f mayor
                                    //agregar en la última posición
                                    if (agregado == false) Open.Add(hj);
                                }
                            }
                        }
                    }
                }
            }
            // Si no se encontró una solución devolver el siguiente valor
            Console.WriteLine("No hay solución");
            return 0;
        }
    }
}
