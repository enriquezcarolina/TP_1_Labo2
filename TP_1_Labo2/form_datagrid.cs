using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_1_Labo2
{
    public partial class form_datagrid : Form
    {

        private Pieza[,] Solucion = new Pieza[constantes.TAM, constantes.TAM]; //matriz de piezas para posicionarlas donde van en la solucion
        private List<Tablero> Soluciones_ = new List<Tablero>(); //se guarda la lista de soluciones

        public form_datagrid(List<Tablero> soluciones)
        {
            Soluciones_ = soluciones;

            InitializeComponent();
            DataGridView.RowCount = constantes.TAM; //grid del tamaño del tablero (8x8)
            DataGridView.ColumnCount = constantes.TAM;
            next(); //imprimo la primera solucion
        }

        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {   //formato de la celdas para que sea un tablero
            //cuadros intercalados blanco y negro
            if (e.RowIndex % 2 == 0 && e.ColumnIndex % 2 == 0)
            {
                e.CellStyle.BackColor = Color.Black;
                e.CellStyle.ForeColor = Color.White;

            }
            else if (e.RowIndex % 2 == 1 && e.ColumnIndex % 2 == 1)
            {
                e.CellStyle.BackColor = Color.Black;
                e.CellStyle.ForeColor = Color.White;
            }

            DataGridView dgv = sender as DataGridView;
            for (int i = 0; i < DataGridView.ColumnCount; i++)
            {
                dgv.Columns[i].Width = 50; //tamaño de las columnas para que sea un cuadrado
            }

        }

        private int cont = 0; //contador para ir imprimiendo las soluciones
        
        private void buttonNext_Click_1(object sender, EventArgs e)
        {   
            if (cont == Soluciones_.Count()-1) //ver si ya llego a la ultima
                this.Close();
            next(); //imprimo la solucion             
        }

        public void next()
        {
            textBox1.Text = "Solucion : " + (cont + 1); //que numero de solucion va
          
            for (int i = 0; i < constantes.TAM; i++)
            {
                for (int j = 0; i < constantes.TAM; i++)
                {
                    Solucion[i, j] = null; //reseteo la matriz de piezas a null para posicionar las de la solucion que quiero mostrar
                }
            }

            int[] pos;
            for (int i = 0; i < constantes.CANT_PIEZAS; i++)
            {    //voy pieza por pieza(i) en la solucion que estoy(cont) y las posiciono en la matriz solucion en su posicion
                pos = Soluciones_[cont].piezas[i].Pos; 
                Solucion[pos[0], pos[1]] = Soluciones_[cont].piezas[i];
            }

            for (int i = 0; i < DataGridView.RowCount; i++)
            {
                for (int j = 0; i < DataGridView.ColumnCount; i++)
                {
                    if (Solucion[i, j] != null)
                    { //recorro toda la matriz solucion y en las posiciones en las que hay una pieza imprimo el nombre en el DataGrid
                        DataGridView[i, j].Value = Solucion[i, j].nombre;

                    }
                }
            }
            cont++; //paso a la siguiente
        }


        // IGNORAR

        private void buttonNext_Click(object sender, EventArgs e)
        {
        }

        private void form_datagrid_Load(object sender, EventArgs e)
        {           
        }

        private void tableroDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void tableroBindingSource_CurrentChanged(object sender, EventArgs e)
        {
        }

        private void form_datagrid_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
    }
}
