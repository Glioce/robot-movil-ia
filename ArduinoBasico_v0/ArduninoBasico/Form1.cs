using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduninoBasico
{
    public partial class Form1 : Form
    {
        Arduino arduino;
        public Form1()
        {
            InitializeComponent();
            arduino = new Arduino("COM24");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            arduino.Escribir("1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            arduino.Escribir("2");
        }
    }
}
