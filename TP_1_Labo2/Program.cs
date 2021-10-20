using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_1_Labo2
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            
        }

        public static void Correr()
        {
            Tablero[] soluciones = new Tablero[10];
            int cant_soluciones = 0;
            bool ya_existe = false;

            do
            {
                Tablero solucion = new Tablero();
                buscar_solucion(solucion); // la funcion que recibe el tablero y hace todo el random para encontrar una solucion

                for (int i = 0; i < cant_soluciones; i++)
                {
                    if (soluciones[i] == solucion)
                    { //hay que hacer una funcion para chequear esto supongo
                        ya_existe = true;
                        break;
                    }
                }

                if (!ya_existe)
                {
                    soluciones.agregar(solucion);
                    cant_soluciones++;
                }

            } while (cant_soluciones < 10);



        }

        public static void buscar_solucion(Tablero tablero)
        {

            do
            {

                Pieza pieza_mover = tablero.pieza_rnd(); //elijo una pieza aleatoria
                int[] nueva_pos = tablero.mover(pieza_mover); //devuelve una pos random donde podria moverse la pieza

                if (Test.cant_atacadas(pieza_mover, pieza_mover.Pos) < Test.cant_atacadas(pieza_mover, nueva_pos))
                {

                }

            } while (!tablero.atacadas_todas());



            
         }


    }

   


}
