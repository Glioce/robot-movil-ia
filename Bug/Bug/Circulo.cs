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
        }
        //--------------------------------
        public void Dibujar(bool borrar = true)
        {
            SolidBrush _brocha = new SolidBrush(color);
            mapa.FillEllipse(_brocha, x - radio, y - radio, radio * 2, radio * 2);
            pictureBox.Image = (Image)b;
            pictureBox.Refresh();
            xold = x;
            yold = y;
            if (borrar) Borrar();
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
