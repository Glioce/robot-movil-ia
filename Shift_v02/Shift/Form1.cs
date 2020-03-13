using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports; //para usar serial
using System.Threading;

namespace Shift
{
    public partial class Form1 : Form
    {
        // Variables de la clase Form1
        static bool _continue; //auxiliar
        static SerialPort _serialPort; //objeto serial
        //string name; //
        //string message; //
        //StringComparer stringComparer = StringComparer.OrdinalIgnoreCase;
        Thread readThread = new Thread(Read);
        bool shift_presionado = false;
        //Label ennn1 = Form1.label2;

        // Create a new SerialPort object with default settings.
        //_serialPort = new SerialPort();

        public Form1()
        {
            InitializeComponent();

            // Inicializar puerto serial
            _serialPort = new SerialPort
            {
                PortName = "COM7",
                BaudRate = 9600,
                Parity = Parity.None,
                DataBits = 8,
                StopBits = StopBits.One,
                Handshake = Handshake.None,
                ReadTimeout = 500,
                WriteTimeout = 500
            };

            _serialPort.Open();
            _continue = true;
            readThread.Start();

            //Console.Write("Name: ");
            //name = Console.ReadLine();
            //Console.WriteLine("Type QUIT to exit");
            label2.Text = "1234";
        }

        
        public static void Read()
        {
            while (_continue)
            {
                try
                {
                    string message = _serialPort.ReadLine();
                    Console.WriteLine(message);
                    //label2.Text = message;
                    //Form f = new Form1();
                    //f.Text = message;
                }
                catch (TimeoutException) { }
            }
        }
        

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            String s1 = "";
            String s2 = "";
            if (e.Shift)
            {
                s1 = "Shift + ";
                shift_presionado = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                s2 = "Flecha arriba";
                _serialPort.Write("A"); //avanza
            }
            if (e.KeyCode == Keys.Down)
            {
                s2 = "Flecha abajo";
                _serialPort.Write("P"); //para
            }
            if (e.KeyCode == Keys.Left)
            {
                s2 = "Flecha izquierda";
                if (shift_presionado) _serialPort.Write("1"); //servo a la izquierda
                else _serialPort.Write("I"); //robot a la izquierda
            }
            if (e.KeyCode == Keys.Right)
            {
                s2 = "Flecha derecha";
                if (shift_presionado) _serialPort.Write("2"); //servo a la derecha
                else _serialPort.Write("D"); //robot a la derecha
            }
            label1.Text = s1 + s2;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            label1.Text = "Presiona una flecha,  o una flecha + shift";
            if (e.Shift)
            {
                shift_presionado = false;
            }
        }
       
    }

    public class ControlManual
    {

    }
}
