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

        public void Correr()
        {
            
            List<Tablero> soluciones = new List<Tablero>();
            
            do
            {
                Tablero solucion = new Tablero(true);
                buscar_solucion(solucion); // la funcion que recibe el tablero y hace todo el random para encontrar una solucion
              
                
               
                if (! soluciones.Contains(solucion)&& Solucion_Ya_Creada(soluciones,solucion)== false)//chequear que no este ya en la lista para que no se repitan
                {
                  
                    soluciones.Add(solucion);
                    
                }
                Tablero prueba1 = solucion; // dos tableros de prueba pq quiero probar cambiando el alfil y el caballo con la reina pero no quiero alterar cuando hago cada cosa
                Tablero prueba2 = solucion;
                if (prueba1.Intercambio("Alfil") == true && !soluciones.Contains(prueba1))
                    soluciones.Add(prueba1);
                if (prueba2.Intercambio("Caballo") == true && !soluciones.Contains(prueba2))
                    soluciones.Add(prueba2);

            } while (soluciones.Count() < cant_solucionesUpDown.Value);

            for(int i=0; i<soluciones.Count(); i++)
            {
                Form form_datagrid = new Form();
                form_datagrid.Show();
         
                
            }

        }

        public void buscar_solucion(Tablero tablero)
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
        public bool Solucion_Ya_Creada(List<Tablero> soluciones, Tablero solucion) // prueba si la solucion que encontro ya estaba creada pero con torres y alfiles distintos
        {
            Tablero solucion_Alfiles_cambiados;
            Tablero solucion_Torres_Cambiadas;
            
            int torre1 = -1;
            int torre2 =-1;
            int alfil1 = -1;
            int alfil2 = -1;
            int[] pos;
            for (int j = 0; j < solucion.piezas.Count; j++)
            {
                if (solucion.piezas.ElementAt(j) is Torre)
                    torre1 = j; // guardamos el indice de la pieza que buscamos y que se encuentra en la lista

                if (solucion.piezas.ElementAt(j) is Torre && torre1 != j)
                    torre2 = j; // guardamos la segunda torre
                if (solucion.piezas.ElementAt(j) is Alfil)
                    alfil1 = j; // guardamos el indice de la pieza que buscamos y que se encuentra en la lista

                if (solucion.piezas.ElementAt(j) is Alfil && alfil1 != j)
                    alfil2 = j; // guardamos el segundo alfil que se encuentra en otra posicion

            }
            // las voy a invertir para chequear con la lista de soluciones que no haya sido creada previamente
            solucion_Alfiles_cambiados = solucion; //que no sea la misma solucion cambiando solo las torres 
            solucion_Torres_Cambiadas= solucion; // que no sea la misma solucion cambiando solo alfiles


            // primero cambio en la solucion ambos alfiles y ambas torres
            pos = solucion.piezas.ElementAt(torre1).Pos; // guardo posicion de torre1 
            solucion.mover(solucion.piezas.ElementAt(torre1), solucion.piezas.ElementAt(torre2).Pos);
            solucion.mover(solucion.piezas.ElementAt(torre2), pos); // pongo la torre2 donde estaba la 1

            pos = solucion.piezas.ElementAt(alfil1).Pos; // guardo posicion de torre1 
            solucion.mover(solucion.piezas.ElementAt(alfil1), solucion.piezas.ElementAt(alfil2).Pos);
            solucion.mover(solucion.piezas.ElementAt(alfil2), pos); // pongo la alfil2 donde estaba la 1
            if (soluciones.Contains(solucion) == true)
                return true; // si la soluccion esta contenida retorna true 



            // cambio solo las torres 
            pos = solucion_Torres_Cambiadas.piezas.ElementAt(torre1).Pos; // guardo posicion de torre1 
            solucion_Torres_Cambiadas.mover(solucion_Torres_Cambiadas.piezas.ElementAt(torre1), solucion_Torres_Cambiadas.piezas.ElementAt(torre2).Pos);
            solucion_Torres_Cambiadas.mover(solucion_Torres_Cambiadas.piezas.ElementAt(torre2), pos);
            
            if (soluciones.Contains(solucion_Torres_Cambiadas) == true)
                return true; // si la soluccion esta contenida retorna true 


            // cambio solo alfiles
            pos = solucion_Alfiles_cambiados.piezas.ElementAt(alfil1).Pos; // guardo posicion de torre1 
            solucion_Alfiles_cambiados.mover(solucion_Alfiles_cambiados.piezas.ElementAt(alfil1), solucion_Alfiles_cambiados.piezas.ElementAt(alfil2).Pos);
            solucion_Alfiles_cambiados.mover(solucion_Alfiles_cambiados.piezas.ElementAt(alfil2), pos);

               if (soluciones.Contains(solucion_Alfiles_cambiados) == true)
                return true; // si la soluccion esta contenida retorna true 


            // no me interesa que la solucion original quede cambiada porque es lo mismo solamente invertimos las tores y alfiles 

            return false; // No esta contenida la solucion
        }
    }
}



