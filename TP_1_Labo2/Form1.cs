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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Correr();
        }
        
        // criterios de poda que utilizamos 
        // las piezas las ubicamos en los lugares que mas posiciones atacan
        // cuando genero una posicion random chequea si esa pieza no habia probado estar ahi antes para que no se repita
        // todo el programa con la misma posicion
      
        public static void Correr()
        {
            List<Tablero> soluciones = new List<Tablero>();

            do
            {
                Tablero solucion = new Tablero(true);
                buscar_solucion(solucion); // la funcion que recibe el tablero y hace todo el random para encontrar una solucion

                if (! soluciones.Contains(solucion))//chequear que no este ya en la lista para que no se repitan
                {
                    soluciones.Add(solucion);
                }

            } while (soluciones.Count() < 10);

            for(int i=0; i<soluciones.Count(); i++)
            {
                Form form_datagrid = new Form();
                form_datagrid.Show();
                Console.Write("Tablero: ");
                Console.WriteLine(i);
                
            }

        }

        public static void buscar_solucion(Tablero tablero)
        {
            Pieza pieza_mover;
            int[] nueva_pos = new int[2];
            do
            {
                pieza_mover = tablero.pieza_rnd(); //elijo una pieza aleatoria

                do
                {
                    nueva_pos = tablero.posible_mover(pieza_mover); //devuelve una pos random donde podria moverse la pieza

                } while (pieza_mover.bool_pos_ya_probada(nueva_pos) == true); // que siga buscando randoms si esta en la lista de ya probada
                
                
                if (cant_atacadas(tablero, pieza_mover, pieza_mover.Pos) < cant_atacadas(tablero, pieza_mover, nueva_pos))
                { //si en la nueva posicion quedan menos casillas sin atacar cambio la posicion
                    tablero.mover(pieza_mover, nueva_pos);
                }

                else
                {
                    pieza_mover.set_pos_ya_probada(nueva_pos);
                }

            } while (!tablero.atacadas_todas());
 
        }

        //Calcula la cantidad de posiciones que ataca una pieza, que no estan siendo atacadas por otras
        public static int cant_atacadas(Tablero tablero, Pieza pieza, int[] pos)
        {
            //necesitamos un tablero con todas las piezas menos esta.
            int cont_sin = 0; //contador si la pieza no estuviera
            int cont_con = 0; //contador con la pieza

            Pieza pieza_temp = pieza;
            pieza_temp.Pos=pos; //pieza_temp esta en la nueva posicion posible
            Tablero tab_sinPieza=tablero;
            tab_sinPieza.sacar(pieza); //creo un tablero como el anterior pero sin esa pieza
            Tablero tab_nuevaPos = tab_sinPieza;
            tab_nuevaPos.setear_pieza(pieza_temp); //tablero con la pieza en la nueva posicion

            for(int i=0; i< constantes.TAM; i++)
            {
                for(int k=0; k< constantes.TAM; k++)
                {
                    if (tab_sinPieza.atacadas[i,k]==constantes.NO_ATACADA)
                        cont_sin++; //cuento las casillas que no estan siendo atacadas si la pieza no estuviera
                     if (tab_nuevaPos.atacadas[i,k]==constantes.NO_ATACADA)
                        cont_con++; //cuento cuantas quedan sin atacar con la pieza en esa posicion
                }
            }

            return cont_sin-cont_con;
        }

    }
}



