using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bug
{
    public partial class Form1 : Form
    {
        //Circulo c, cfinal; // 2 círculos para probar
        Dijkstra grafo; // clase que contiene la lista de todos los nodos e implementa algoritmos
        Bitmap b;
        List<Nodo> listaNodos = new List<Nodo>();
        Nodo inicio, meta;

        public Form1()
        {
            InitializeComponent();
            panel1.Enabled = false;
           
        }
        //---------------------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            // Cargar imagen
            OpenFileDialog ofd = new OpenFileDialog();
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(ofd.FileName);
                    panel1.Enabled = true;
                    b = new Bitmap(pictureBox1.Image);
                }
            }
        }
        //-----------------------------------------------------------------------
        private void button2_Click(object sender, EventArgs e)
        {
            // Ejecutar algorimo
            if (grafo.EjecutarDijkstra(inicio, meta) == 1)
            {
                grafo.TrazarCamino(inicio, meta);
            }
            //c.Dibujar();
            //cfinal.Dibujar(false);
            //c.moverA(cfinal.x, cfinal.y);
        }
        //----------------------------------------------------------------------
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // Agregar inicio o meta
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;

            Circulo c;

            if (radioButton1.Checked)
            {
                //if (c != null) c.Dibujar();
                //if (cfinal != null) cfinal.Dibujar(false);
                c = new Circulo(pictureBox1, b, 4, coordinates.X, coordinates.Y, Color.Red); //crear circulo
                inicio = new Nodo(coordinates.X, coordinates.Y, c); //crear nodo inicio
                listaNodos.Add(inicio); //también agregar a la lista
                c.Dibujar(false);
                
            }
            else
            {
                //if (c != null) c.Dibujar(false);
                //if (cfinal!= null) cfinal.Dibujar();
                c = new Circulo(pictureBox1, b, 4, coordinates.X, coordinates.Y, Color.Green); //crear circulo
                meta = new Nodo(coordinates.X, coordinates.Y, c); //crear nodo meta
                listaNodos.Add(meta); //también agregar a la lista
                c.Dibujar(false);
            }
        }
        //----------------------------------------------------------------------------------
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //if (c != null) c.Dibujar(false);
        }
        //----------------------------------------------------------------------------------
        private void buttonCrearNodos_Click(object sender, EventArgs e)
        {
            // Crear varios nodos en posiciones aleatorias
            var _rand = new Random();
            int _n = Convert.ToInt32(textBoxN.Text);
            int _x;
            int _y;
            int _cont = 0; //contador de nodos creados

            //for (int i =0; i<_n; i++)
            while (_cont < _n)
            {
                _x = _rand.Next(500); //de 0 a 500
                _y = _rand.Next(500);
                
                Circulo _c = new Circulo(pictureBox1, b, 2, _x, _y, Color.Orange);

                int kolor = b.GetPixel(_x, _y).ToArgb();
                //Color kolor = b.GetPixel(_x, _y);
                //Console.WriteLine(kolor);
                if (kolor == Color.White.ToArgb())
                //if (kolor.Equals(Color.White))
                {
                    Console.WriteLine("Nodo creado");
                    listaNodos.Add(new Nodo(_x, _y, _c));
                    _c.Dibujar(false);
                    _cont++;
                }
                //
                //_c.DibujarLinea(_x, _y, _x + 20, _y, Color.Gray);
                //_c.DibujarLinea(0, 0, 200, 50, Color.Gray);
            }
        }

        private void buttonTriangular_Click(object sender, EventArgs e)
        {
            grafo = new Dijkstra(listaNodos);
            grafo.Triangular();
        }

        //----------------------------------------------------------------------------------
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //if (cfinal != null) cfinal.Dibujar(false);
        }
        //-----------------------------------------------------------------------------------

    }
}
