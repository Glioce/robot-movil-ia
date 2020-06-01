﻿using System;
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
        Circulo c,cfinal;
        Bitmap b;
        public Form1()
        {
            InitializeComponent();
            panel1.Enabled = false;
           
        }
//---------------------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
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
            c.Dibujar();
            cfinal.Dibujar(false);
            c.moverA(cfinal.x, cfinal.y);
        }
//----------------------------------------------------------------------
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs me = (MouseEventArgs)e;
            Point coordinates = me.Location;
            if (radioButton1.Checked)
            {
                if (c != null) c.Dibujar();
                if (cfinal != null) cfinal.Dibujar(false);
                c = new Circulo(pictureBox1,b, 8, coordinates.X, coordinates.Y,Color.Red);
                c.Dibujar(false);
            }
            else
            {
                if (c != null) c.Dibujar(false);
                if (cfinal!= null) cfinal.Dibujar();
                cfinal = new Circulo(pictureBox1,b, 8, coordinates.X, coordinates.Y,Color.Green);
                cfinal.Dibujar(false);
            }
        }
//----------------------------------------------------------------------------------
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (c != null) c.Dibujar(false);
        }
//----------------------------------------------------------------------------------
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (cfinal != null) cfinal.Dibujar(false);
        }
//-----------------------------------------------------------------------------------

    }
}
