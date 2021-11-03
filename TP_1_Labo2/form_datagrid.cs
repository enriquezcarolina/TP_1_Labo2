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

        private Pieza[,] Solucion = new Pieza[constantes.TAM, constantes.TAM];
        private List<Tablero> Soluciones_ = new List<Tablero>();

        public form_datagrid(List<Tablero> soluciones)
        {
            Soluciones_ = soluciones;

            InitializeComponent();
            DataGridView.RowCount = constantes.TAM;
            DataGridView.ColumnCount = constantes.TAM;
            next();
        }

        private void DataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {

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
                dgv.Columns[i].Width = 50;
            }

        }

        private int cont = 0;
        private void buttonNext_Click_1(object sender, EventArgs e)
        {   
            if (cont == Soluciones_.Count()-1)
                this.Close();
            next();
            
          
        }

        public void next()
        {
            textBox1.Text = "Solucion : " + (cont + 1);
            for (int i = 0; i < constantes.TAM; i++)
            {
                for (int j = 0; i < constantes.TAM; i++)
                {
                    Solucion[i, j] = null;
                }
            }

            int[] pos;
            for (int i = 0; i < constantes.CANT_PIEZAS; i++)
            {
                pos = Soluciones_[cont].piezas[i].Pos;
                Solucion[pos[0], pos[1]] = Soluciones_[cont].piezas[i];
            }

            for (int i = 0; i < DataGridView.RowCount; i++)
            {
                for (int j = 0; i < DataGridView.ColumnCount; i++)
                {
                    if (Solucion[i, j] != null)
                    {
                        DataGridView[i, j].Value = Solucion[i, j].nombre;

                    }
                }
            }
            cont++;
        }


        //IGNORAR

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
