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

       // private Pieza[,] Solucion = new Pieza[constantes.TAM, constantes.TAM];//matriz de piezas para posicionarlas donde van en la solucion
        private List<Tablero> Soluciones_ = new List<Tablero>(); //se guarda la lista de soluciones
        private int cont = 1; //contador para ir imprimiendo las soluciones

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
        
        private void buttonNext_Click_1(object sender, EventArgs e)
        {
            if (cont > Soluciones_.Count()) //ver si ya llego a la ultima
            {
                this.Close();
                return;
            }
            next(); //imprimo la solucion             
        }

        public void next()
        {
            textBox1.Text = "Solucion : " + cont ; //que numero de solucion va
          
            for (int i = 0; i < constantes.TAM; i++)
            {
                for (int j = 0; j < constantes.TAM; j++)
                { //reseteo a null para posicionar las de la solucion que quiero mostrar
                    DataGridView[i, j].Value = null;
                }
            }

            int[] pos;
            for (int i = 0; i < constantes.CANT_PIEZAS; i++)
            {    //voy pieza por pieza(i) en la solucion que estoy(cont-1) y las posiciono en la datagrid
                pos = Soluciones_[cont-1].piezas[i].Pos;
                if (DataGridView[pos[0], pos[1]].Value != null)
                    DataGridView[pos[0], pos[1]].Value = DataGridView[pos[0], pos[1]].Value + "/"+ Soluciones_[cont - 1].piezas.ElementAt(i).nombre;
                else DataGridView[pos[0], pos[1]].Value = Soluciones_[cont - 1].piezas.ElementAt(i).nombre;
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
