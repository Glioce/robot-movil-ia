using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AStar
{
    public partial class Form1 : Form
    {
        // Declarar variables globales
        int sizeTablero; // tamaño del tablero
        AStar a; // objeto de tipo AStar
        public Form1()
        {
            InitializeComponent(); // generado automáticamente
            a = new AStar(tablero); // iniciar objeto AStar usando un objeto DataGridView de Form1
            sizeTablero = 20; // definir tamaño
            tablero.ColumnCount = sizeTablero + 1;
            tablero.RowCount = sizeTablero + 1;      //Agrega uno para los indices

            for (int i = 1; i <= sizeTablero; i++)
                for (int j = 1; j <= sizeTablero; j++)
                    tablero[j, i].Value = ""; // Limpia las celdas (:o DataGridView se puede manejar como array!)

            tablero.RowHeadersWidth = 25;
            tablero.ColumnHeadersHeight = 25;     // Fija dimensiones de los indices

            for (int i = 1; i <= sizeTablero; i++)
            {
                tablero[0, i].Value = i;
                tablero[i, 0].Value = i;  //Escribe índices
                tablero.Columns[i].Width = 20;   // Fija dimensiones de las celdas
                tablero.Rows[i].Height = 20;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Clic en botón ejecutar inicia la evaluación
            a.EjecutarAlgoritmo();
        }

        private void tablero_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (radioButtonInicio.Checked)
            {
                tablero.CurrentCell.Style.BackColor = Color.Red;
                tablero.CurrentCell.Value = "I";
                a.inicio.X = tablero.CurrentCell.ColumnIndex;
                a.inicio.Y = tablero.CurrentCell.RowIndex;
                labelInicio.Text = "(" + a.inicio.X + "," + a.inicio.Y + ")";

            }
            if (radioButtonMeta.Checked)
            {
                tablero.CurrentCell.Style.BackColor = Color.Green;
                tablero.CurrentCell.Value = "M";
                a.meta.X = tablero.CurrentCell.ColumnIndex;
                a.meta.Y = tablero.CurrentCell.RowIndex;
                labelMeta.Text = "(" + a.meta.X + "," + a.meta.Y + ")";
            }
            if (radioButtonObstaculo.Checked)
            {
                tablero.CurrentCell.Style.BackColor = Color.Black;
                // no guarda otra info en el objeto a (AStar)
            }
            if (radioButtonNinguno.Checked)
            {
                tablero.CurrentCell.Style.BackColor = Color.White;
            }

            int j = tablero.CurrentCell.ColumnIndex;
            int i = tablero.CurrentCell.RowIndex;
            label5.Text = "Celda(" + j.ToString() + "," + i.ToString() + ")";
            //label4.Text = "h(n)="+a.h[j, i].ToString("F2");

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // parece que este botón tampoco existe en Form1
        }
    }
}
