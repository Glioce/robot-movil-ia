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
        string name; //
        string message; //
        StringComparer stringComparer = StringComparer.OrdinalIgnoreCase;
        Thread readThread = new Thread(Read);

        // Create a new SerialPort object with default settings.
        //_serialPort = new SerialPort();

        public Form1()
        {
            InitializeComponent();

            // Inicializar puerto serial
            _serialPort = new SerialPort();
            _serialPort.PortName = "COM7";
            _serialPort.BaudRate = 9600;
            _serialPort.Parity = Parity.None;
            _serialPort.DataBits = 8;
            _serialPort.StopBits = StopBits.One;
            _serialPort.Handshake = Handshake.None;

            // Set the read/write timeouts
            _serialPort.ReadTimeout = 500;
            _serialPort.WriteTimeout = 500;

            _serialPort.Open();
            _continue = true;
            readThread.Start();

            Console.Write("Name: ");
            name = Console.ReadLine();

            Console.WriteLine("Type QUIT to exit");
        }

        public static void Read()
        {
            while (_continue)
            {
                try
                {
                    string message = _serialPort.ReadLine();
                    Console.WriteLine(message);
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
            }
            if (e.KeyCode == Keys.Up)
            {
                s2 = "Flecha arriba";
                _serialPort.Write("A");
            }
            if (e.KeyCode == Keys.Down)
            {
                s2 = "Flecha abajo";
                _serialPort.Write("B");
            }
            if (e.KeyCode == Keys.Left)
            {
                s2 = "Flecha izquierda";
                _serialPort.Write("C");
            }
            if (e.KeyCode == Keys.Right)
            {
                s2 = "Flecha derecha";
                _serialPort.Write("D");
            }
            label1.Text = s1 + s2;
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            label1.Text = "Presiona una flecha,  o una flecha + shift";
        }
       
    }
}
