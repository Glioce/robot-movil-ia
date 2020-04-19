using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing; //para dibujar
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports; //para usar serial

namespace ArduninoBasico
{
    public partial class Form1 : Form
    {
        Arduino arduino;
        //conteo de pulsos
        int pulsos_i0 = 0;  //inicial izquierda
        int pulsos_i1; //actualizado derecha
        int pulsos_d0 = 0;
        int pulsos_d1;
        double x = 0; //posición del robot
        double y = 0;
        double gama = 0; //posición angula en radianes
        Graphics mapa;
        Bitmap bm;
        Pen lapiz = new Pen(Color.Red);
        Random rnd = new Random();

        public Form1()
        {
            InitializeComponent();
            //textEncoder1.Text = "lololo";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // Leer posición de encoders para calcular posición del robot
            // También leer posición del servo y distancia del sensor para dibujar las líneas de visión
            string l = arduino.LeerLinea();
            //textDistSharp.Text = x;
            string[] separatingStrings = { "," };
            string[] arr = l.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);

            const double t = 0.1; //periodo de muestreo
            const double r = 3.0; //radio de las llantas
            const double b = 14.5; //base (distancia entre ruedas)
            const int ppv = 40; //pulsos por vuelta
            double v_i; //velocidad de rueda izquierda
            double v_d; //velocidad de rueda derecha
            double v; //velocidad instantánea en el centro del robot
            double w; //velocidad angular del robot
            double a; //posición angular en grados
            double pos; //posición del servo (ángulo)
            double dist; //lectura de distancia
            double linea_x; //componentes de la línea de visión
            double linea_y;

            // Si se recibieron 4 valores separados por comas, entonces la cadena no estaba cortada
            if (arr.Length == 4)
            {
                textEncoder1.Text = arr[0];
                textEncoder2.Text = arr[1];
                textAngSharp.Text = arr[2];
                textDistSharp.Text = arr[3];

                // guardar pulsos actualizados
                pulsos_i1 = Convert.ToInt16(arr[0]);
                pulsos_d1 = Convert.ToInt16(arr[1]);

                // calcular velocidades (cm/s)
                v_i = (pulsos_i1 - pulsos_i0) * 2 * Math.PI * r / (t * ppv);
                v_d = (pulsos_d1 - pulsos_d0) * 2 * Math.PI * r / (t * ppv);
                v = (v_i + v_d) / 2; // cm/s
                w = (v_i + v_d) / b; // rad/s

                // actualizar contadores previos
                pulsos_i0 = pulsos_i1;
                pulsos_d0 = pulsos_d1;

                // caclular nueva posición
                x += v * Math.Cos(gama) * t;
                y += v * Math.Sin(gama) * t;
                gama += w * t;
                if (gama < 0) gama += (2 * Math.PI);
                if (gama > 2 * Math.PI) gama -= (2 * Math.PI);
                a = gama * 180 / Math.PI; //obtener ángulo en grados

                // mostrar resultado
                textX.Text = x.ToString("0.00");
                textY.Text = y.ToString("0.00");
                textGama.Text = a.ToString("0.00");

                //Dibujar líneas de distancia
                bm = new Bitmap(pictureBox1.Image); //extraer la imagen como bitmap
                mapa = Graphics.FromImage(bm); //pasar los datos del bitmap al objeto Graphics
                //mapa.DrawLine(lapiz, rnd.Next(0,500), rnd.Next(0, 500), rnd.Next(0, 500), rnd.Next(0, 500)); //dibujar en el objeto Graphics
                // El robot se dibuja en el centro del bitmap (offset 250,250)
                pos = Convert.ToDouble(arr[2]);
                dist = Convert.ToDouble(arr[3]);
                // Obtener coordenadas cartesianas a partir del ángulo y distancia anteriores
                linea_x = dist * Math.Cos(pos * Math.PI / 180.0);
                linea_y = -dist * Math.Sin(pos * Math.PI / 180.0);
                mapa.DrawLine(lapiz, 250, 250, 250 + (float)linea_x, 250 + (float)linea_y);
                pictureBox1.Image = (Image)bm; //guardar nueva imagen en pictureBox
                pictureBox1.Refresh(); //redibujar en pantalla
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Inicia la comunicación
            if (buttonConectar.Text == "Conectar")
            {
                arduino = new Arduino(comboPuerto.SelectedItem.ToString());
                timer1.Enabled = true;
                buttonConectar.Text = "Desconectar";
            }
            else //tal vez esto no se debe hacer
            {
                arduino = null;
                timer1.Enabled = false;
                buttonConectar.Text = "Conectar";
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Cuando la forma inicia, se obtine la lista de puertos disponibles
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                //Console.WriteLine(port);
                // Agregar lista de puertos al comboBox
                comboPuerto.Items.Add(port);
                // Seleccionar automáticamente el primer elemento
                comboPuerto.SelectedIndex = 0;
            }
        }

        private void buttonActualizar_Click(object sender, EventArgs e)
        {
            // Quitar elementos anteriores
            comboPuerto.Items.Clear();

            // Y agregar nuevs elementos
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                // Agregar lista de puertos al comboBox
                //Console.WriteLine(port);
                comboPuerto.Items.Add(port);
                // Seleccionar automáticamente el primer elemento
                comboPuerto.SelectedIndex = 0;
            }
        }

        private void buttonLin_Click(object sender, EventArgs e)
        {
            // Calcular número de pulsos para avanzar la distancia indicada en línea recta
            double d = double.Parse(textLin.Text); //distancia en cm
            const int ppv = 40; //pulsos por vuelta
            const double r = 3.0; //radio de las llantas
            double pulsos = (d * ppv) / (2 * Math.PI * r); //calcular número de pulsos
            string p = Math.Round(pulsos).ToString(); //valor redondeado y convertido a string

            // las dos llantas deben generear el mismo número de pulsos y moverse a la misma velocidad
            arduino.Escribir(p + "," + p + "," + textPwmLin.Text + "," + textPwmLin.Text + "\n");

            //textX.Text = p.ToString();
            // Probar envío de cadenas que se interpretan en Arduino
            //string s = textLin.Text;
            //arduino.Escribir(textLin.Text + "," + textRot.Text + "," + textPwmLin.Text + "," + textPwmRot.Text + "\n");
        }

        private void buttonRot_Click(object sender, EventArgs e)
        {
            // Calcular número de pulsos para rotar el ángulo indicado
            // si el ángulo es negativo, gira en sentido de las manecillas del reloj
            // si el ángulo es positivo, gira en sentido contrario
            double a = double.Parse(textRot.Text); //ángulo en grados
            a = a * Math.PI / 180; //convertir a radianes
            const double R = 7.25; //radio del robot en cm
            const int ppv = 40; //pulsos por vuelta
            const double r = 3.0; //radio de las llantas
            double pulsos = (a * R * ppv) / (2 * Math.PI * r); //calcular número de pulsos

            // las llantas deben girar en direcciones contrarias y ala misma velocidad
            double p_d = Math.Round(pulsos); //valor redondeado
            double p_i = -p_d; //valor * -1
            arduino.Escribir(p_i.ToString() + "," + p_d.ToString() + "," + textPwmRot.Text + "," + textPwmRot.Text + "\n");

            //textY.Text = p_d.ToString();
            //textGama.Text = p_i.ToString();
        }

        private void buttonReiniciar_Click(object sender, EventArgs e)
        {
            pulsos_i0 = 0;  //inicial izquierda
            pulsos_i1 = 0; //actualizado derecha
            pulsos_d0 = 0;
            pulsos_d1 = 0;
            x = 0; //posición del robot
            y = 0;
            gama = 0; //posición angula en radianes
        }
    }
}
