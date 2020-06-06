using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;


namespace Bug
{
    class Circulo
    {
        // Esta clase se usará para dibujar los nodos y para
        // animar el recorrido desde el nodo inicial hasta la meta
        int radio;
        public int x;
        public int y;
        int xold;
        int yold;
        Bitmap b;
        Graphics mapa;
        PictureBox pictureBox;
        Color color;

        //--------------------------------
        public Circulo(PictureBox _pictureBox, Bitmap _b, int _radio, int _x, int _y, Color _color)
        {
            radio = _radio;
            x = _x;
            y = _y;
            b = _b;
            mapa = Graphics.FromImage(b);
            pictureBox = _pictureBox;
            color = _color;
            //Console.WriteLine(Color.Black.ToArgb());
        }
        //--------------------------------
        public void Dibujar(bool borrar = true)
        {
            SolidBrush _brocha = new SolidBrush(color);
            mapa.FillEllipse(_brocha, x - radio, y - radio, radio * 2, radio * 2);
            pictureBox.Image = (Image)b;
            pictureBox.Refresh(); //esto podría llamarse fuera de la función para ahorrar tiempo
            xold = x;
            yold = y;
            if (borrar) Borrar();
        }
        //--------------------------------
        public void DibujarLinea(float x1, float y1, float x2, float y2, Color c)
        {
            Pen lapiz = new Pen(c);
            mapa.DrawLine(lapiz, x1, y1, x2, y2);
            pictureBox.Refresh(); //esto podría llamarse fuera de la función para ahorrar tiempo
        }
        //--------------------------------
        public bool PuedeVerA(Circulo otro)
        {
            // checa los pixels en una línea, 
            // si encuentra negro significa que no puede ver al otro circulo

            // El punto inicial es this.x. this.y
            // El punto final es other.x, other.y

            double vx = otro.x - x; // vector
            double vy = otro.y - y;
            double d = Math.Sqrt((vx * vx) + (vy * vy)); //distancia

            double pasos = Math.Ceiling(d);

            double px, py; //posición del pixel
            int pc; //color del pixel

            for (double i = 1; i < pasos; i++)
            {
                px = x + (vx * i / pasos);
                py = y + (vy * i / pasos);
                pc = b.GetPixel((int)px, (int)py).ToArgb();
                //Console.WriteLine(pc.ToArgb());

                if (pc == Color.Black.ToArgb())
                {
                    //Console.WriteLine("No puede ver!");
                    return false; //no puede ver
                }
            }
            return true; //si puede ver
        }
        //--------------------------------
        void Borrar()
        {
            Thread.Sleep(10);
            SolidBrush _brocha = new SolidBrush(Color.White);
            mapa.FillEllipse(_brocha, xold - radio, yold - radio, radio * 2, radio * 2);
            pictureBox.Image = (Image)b;
        }

        //-----------------------------------
        public void moverA(int xf, int yf)
        {
            if (xf != x || yf != y)
            {
                int xi = x;
                int yi = y;
                if (Math.Abs(xf - x) > Math.Abs(yf - y))
                {
                    for (int n = 1; n <= Math.Abs(xf - xi); n++)
                    {
                        x += Math.Sign(xf - xi);
                        y = yi + Convert.ToInt16((x - xi) / Convert.ToDouble(xf - xi) * (yf - yi));
                        Dibujar();
                    }
                }
                else
                {
                    for (int n = 1; n <= Math.Abs(yf - yi); n++)
                    {
                        y += Math.Sign(yf - yi);
                        x = xi + Convert.ToInt16((y - yi) / Convert.ToDouble(yf - yi) * (xf - xi));
                        Dibujar();
                    }

                }
            }
            Dibujar(false);
        }
        //-----------------------------------------
    }
}
