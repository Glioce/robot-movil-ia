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

          private void timer1_Tick(object sender, EventArgs e)
        {
            int valor = arduino.LeerInt();
            valor = valor/4;
            if (valor > 100) valor = 100;   
            progressBar1.Value = 100-valor;
              
         }

         private void button1_Click(object sender, EventArgs e)
         {
             timer1.Enabled = true;
         }

        
    }
}
