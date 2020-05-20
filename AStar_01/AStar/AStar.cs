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
            //inicio = new Nodo();
            //meta = new Nodo();
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
            Nodo hj; //hijo del nodo actual
            double gTemp; //costo g temportal (tentativo)
            Nodo[,] matriz = new Nodo[tablero.ColumnCount, tablero.RowCount]; // Declarar matriz de Nodos

            // Debug
            Console.WriteLine(tablero.ColumnCount);
            Console.WriteLine(tablero.RowCount);

            // Recorrer el tablero y revisar los colores de las celdas
            for (int j = 1; j <= 20; j++)
            {
                for (int i = 1; i <= 20; i++)
                {
                    matriz[i, j] = new Nodo(i, j); //crear instancia Nodo correspondiente a esta celda
                    Color k = tablero[i, j].Style.BackColor; //obtener color de la celda

                    if (Color.Equals(k, Color.Red))
                    {
                        Console.Write("I ");
                        inicio = matriz[i, j];
                    }
                    else if (Color.Equals(k, Color.Green))
                    {
                        Console.Write("M ");
                        meta = matriz[i, j];
                    }
                    else if (Color.Equals(k, Color.Black))
                    {
                        Console.Write("O ");
                        matriz[i, j].es_obstaculo = true;
                    }
                    else
                    {
                        Console.Write(". ");
                        tablero[i, j].Style.BackColor = Color.White;
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            // Ya se han creado todas las instancias de nodos
            // Ahora asignar los hijos a cada uno de los nodos
            for (int j = 1; j <= 20; j++)
            {
                for (int i = 1; i <= 20; i++)
                {
                    // Agregar hijos si las coordenadas están dentro de la matriz y no son obstáculos
                    actual = matriz[i, j];
                    if (actual.es_obstaculo == true)
                    {
                        Console.Write("  ");
                        continue;
                    }

                    // Derecha
                    if (actual.X < 20) actual.Agregar_hijo(matriz[i + 1, j]);
                    // Arriba
                    if (actual.Y > 1) actual.Agregar_hijo(matriz[i, j - 1]);
                    // Izquierda
                    if (actual.X > 1) actual.Agregar_hijo(matriz[i - 1, j]);
                    // Abajo
                    if (actual.Y < 20) actual.Agregar_hijo(matriz[i, j + 1]);

                    Console.Write(actual.numhijos.ToString() + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            // Errores iniciales
            if (inicio == null || meta == null)
            {
                Console.WriteLine("Falta Inicio y/o Meta!");
                return 0;
            }

            // Asignar costos al nodo inicio
            inicio.g = 0; //llegar a esta posición no tiene costo
            inicio.Calcular_h(meta); //costo si avanza en línea recta
            inicio.Calcular_f(); //parece que no es necesario para este nodo
            Open.Add(inicio); // Agregar nodo inicio al conjunto abierto
            Console.WriteLine("Inicio agregado a Open");

            // Ciclo del algoritmo
            while (Open.Count > 0) //mientras el conjunto abierto contiene nodos
            {
                actual = Open[0]; //extraer el primer nodo (el conjunto debe estar ordenado)
                Open.RemoveAt(0); //borrar del conjunto

                if (actual == meta) //si llegamos a la meta, terminar ciclo
                {
                    Console.WriteLine("Algoritmo completado");
                    Console.WriteLine("Trazando camino");
                    TrazarCamino(meta);
                    return 1;
                }

                //si no hemos llegado a la meta, continuar
                //foreach (Nodo hj in actual.hijo)
                for (int i = 0; i < actual.numhijos; i++) //revisar todos los hijos del nodo actual
                {
                    hj = actual.hijo[i];
                    //gTemp = actual.g + 1;
                    gTemp = actual.g + actual.Distancia_a_nodo(hj); //costo tentativo

                    // si ese costo es menor al que se ha evaluado por otro camino
                    // o el hijo no tiene costo calculado todavía
                    if (gTemp < hj.g || hj.g == -1)
                    {
                        hj.padre = actual; //el nodo actual se reconoce como padre
                        hj.g = gTemp; //asignar o actualizar costo g
                        hj.Calcular_h(meta); //calcular costo h
                        hj.Calcular_f(); //calcular suma de costos

                        if (Open.Contains(hj) == false) //si el conjunto abierto no contiene el nodo hijo evaluado
                        {
                            //agregar nodo al conjunto ordenando por el costo f
                            bool agregado = false;
                            for (int j = 0; j < Open.Count; j++) //recorrer conjunto abierto
                            {
                                if (Open[j].f > hj.f) //si el valor f de un elemento en el conjunto es mayor al valor del hijo que se está evaluando
                                {
                                    Open.Insert(j, hj); //insertar para ocupar su posición
                                    agregado = true; //ya está agregado
                                    break; //terminar for
                                }

                            }
                            //si no se agregó en el for anterior, es porque el conjunto está vacío o no hay un nodo con f mayor
                            //agregar en la última posición
                            if (agregado == false) Open.Add(hj);

                            // Imprimir valores f del conjunto abierto, para ver que están bien ordenados
                            Console.Write("Open: ");
                            for (int j = 0; j < Open.Count; j++)
                            {
                                Console.Write(Open[j].f.ToString("0.0") + ", ");
                            }
                            Console.WriteLine();
                        }
                    }
                }
            }
            // Si no se encontró una solución devolver el siguiente valor
            Console.WriteLine("No hay solución");
            return 0;
        }
        //------------------------------------------------

        public void TrazarCamino(Nodo mt)
        {
            // Cuando el argoritmo se ha terminado con éxito se ejecuta esta función
            // Inicia con el nodo meta
            Nodo nd = mt.padre; //se obtiene el padre
            while (nd != inicio)
            {
                tablero[nd.X, nd.Y].Style.BackColor = Color.Yellow;
                nd = nd.padre;
            }
        }
    }
}
