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
    public partial class Ataques_fatales : Form
    {
        private Tablero tablero = new Tablero();
        Form llamado;

        public Ataques_fatales(Form llamado_, Tablero solucion)
        {
            tablero = solucion;
            llamado = llamado_;
            InitializeComponent();
            DataGrid_Ataques.RowCount = constantes.TAM; //grid del tamaño del tablero (8x8)
            DataGrid_Ataques.ColumnCount = constantes.TAM;
            tablero.Ataques_Fatales();
            imprimir_ataques();
        }

        private void DataGrid_Ataques_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //formato de la celdas para que sea un tablero
            //cuadros intercalados blanco y negro
           /* if (e.RowIndex % 2 == 0 && e.ColumnIndex % 2 == 0)
            {
                e.CellStyle.BackColor = Color.Black;
                e.CellStyle.ForeColor = Color.White;

            }
            else if (e.RowIndex % 2 == 1 && e.ColumnIndex % 2 == 1)
            {
                e.CellStyle.BackColor = Color.Black;
                e.CellStyle.ForeColor = Color.White;
            }*/

            DataGridView dgv = sender as DataGridView;
            for (int i = 0; i < DataGrid_Ataques.ColumnCount; i++)
            {
                dgv.Columns[i].Width = 50; //tamaño de las columnas para que sea un cuadrado
            }

        }

        void imprimir_ataques()
        {
            int[] pos = new int[2];
            for(int i = 0; i < tablero.piezas.Count(); i++)
            {
                for (int j = 0; j < tablero.piezas.ElementAt(i).Ataques_Fatales.Count(); j++)
                {
                    pos[0] = tablero.piezas.ElementAt(i).Ataques_Fatales.ElementAt(j)[0];
                    pos[1] = tablero.piezas.ElementAt(i).Ataques_Fatales.ElementAt(j)[1];
                    DataGrid_Ataques[pos[0], pos[1]].Style.BackColor = Color.Orange;

                }
                
            }
            
            for (int i = 0; i < constantes.CANT_PIEZAS; i++)
            {    //voy pieza por pieza(i) en la solucion que estoy(cont-1) y las posiciono en la datagrid
                pos = tablero.piezas[i].Pos;
                if (DataGrid_Ataques[pos[0], pos[1]].Value != null)
                    DataGrid_Ataques[pos[0], pos[1]].Value = DataGrid_Ataques[pos[0], pos[1]].Value + "/" + tablero.piezas.ElementAt(i).nombre;
                else DataGrid_Ataques[pos[0], pos[1]].Value = tablero.piezas.ElementAt(i).nombre;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            llamado.Show();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string titulo = "PIEZAS QUE PRODUCEN EL BLOQUEO";
            string texto="";
            int cont_caballo = 0;
            int cont_alfil = 0;
            int cont_rey = 0;
            int cont_reina = 0;
            int cont_torre = 0;
            for (int i=0;i<tablero.piezas.Count;i++)
            {
               
                for (int j = 0; j < tablero.piezas.ElementAt(i).Bloqueo_Fatal.Count; j++)
                { 
                    if(tablero.piezas.ElementAt(i).Bloqueo_Fatal.ElementAt(j)== "Reina" && cont_reina<1)
                    {
                        texto = texto + "-" + tablero.piezas.ElementAt(i).Bloqueo_Fatal.ElementAt(j) + "\n";
                        cont_reina++;
                    }
                    if (tablero.piezas.ElementAt(i).Bloqueo_Fatal.ElementAt(j) == "Alfil" && cont_alfil < 2)
                    {
                        texto = texto + "-" + tablero.piezas.ElementAt(i).Bloqueo_Fatal.ElementAt(j) + "\n";
                        cont_alfil++;
                    }
                    if (tablero.piezas.ElementAt(i).Bloqueo_Fatal.ElementAt(j) == "Caballo" && cont_caballo < 2)
                    {
                        texto = texto + "-" + tablero.piezas.ElementAt(i).Bloqueo_Fatal.ElementAt(j) + "\n";
                        cont_caballo++;
                    }

                    if (tablero.piezas.ElementAt(i).Bloqueo_Fatal.ElementAt(j) == "Rey" && cont_rey < 1)
                    {
                        texto = texto + "-" + tablero.piezas.ElementAt(i).Bloqueo_Fatal.ElementAt(j) + "\n";
                        cont_rey++;
                    }
                    if (tablero.piezas.ElementAt(i).Bloqueo_Fatal.ElementAt(j) == "Torre" && cont_torre < 2)
                    {
                        texto = texto + "-" + tablero.piezas.ElementAt(i).Bloqueo_Fatal.ElementAt(j) + "\n";
                        cont_torre++;
                    }

                }

            }
           
            MessageBox.Show(texto, titulo, MessageBoxButtons.OK);
        }
    }
}
