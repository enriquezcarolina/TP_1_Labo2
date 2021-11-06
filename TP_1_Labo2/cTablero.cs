using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Summary description for Class1
/// </summary>
namespace TP_1_Labo2
{
    public class Tablero
    {

        public bool[,] colores = new bool[8, 8]; //color de los casilleros
        public bool[,] atacadas = new bool[8, 8]; //que casilleros estan siendo atacados
        public bool[,] tipo_ataque = new bool[8, 8]; //ataque fuerte o leve
        public List<Pieza> piezas = new List<Pieza>(); //listado de piezas
       
      //  public List<int[]> Atacadas_Fatalmente = new List<int[]>(); //listado de casillas atacadas fatalmente


        //constructor que solo crea el tablero pero no setea las piezas
        public Tablero()
        {
            for (int n = 0; n < constantes.TAM; n++)
            {
                for (int m = 0; m < constantes.TAM; m++)
                {
                    if (n % 2 != 0 && m % 2 != 0 || n % 2 == 0 && m % 2 == 0) // n y m impar o n y m par
                        colores[n, m] = constantes.BLANCO;
                    if (n % 2 != 0 && m % 2 == 0 || n % 2 == 0 && m % 2 != 0) //n impar y m par o n par y m impar
                        colores[n, m] = constantes.NEGRO;
                }
            }
            for (int n = 0; n < constantes.TAM; n++)
            {
                for (int m = 0; m < constantes.TAM; m++)
                {
                    atacadas[n, m] = constantes.NO_ATACADA;
                    tipo_ataque[n, m] = false;
                }
            }
        }

        //constructor que setea las piezas de forma inicial random
        public Tablero(bool setear)
        {
            for (int n = 0; n < constantes.TAM; n++)
            {
                for (int m = 0; m < constantes.TAM; m++)
                {
                    if (n % 2 != 0 && m % 2 != 0 || n % 2 == 0 && m % 2 == 0) // n y m impar o n y m par
                        colores[n, m] = constantes.BLANCO;
                    if (n % 2 != 0 && m % 2 == 0 || n % 2 == 0 && m % 2 != 0) //n impar y m par o n par y m impar
                        colores[n, m] = constantes.NEGRO;
                }
            }
            for (int n = 0; n < constantes.TAM; n++)
            {

                for (int m = 0; m < constantes.TAM; m++)
                {
                    atacadas[n, m] = constantes.NO_ATACADA;
                    tipo_ataque[n, m] = false;
                }
            }

            Random rand = new Random();
            int[] pos = new int[2];

            pos[0] = rand.Next(0, 2) * 7; //o 0 o 7, que este en una de las puntas
            pos[1] = rand.Next(0, 2) * 7;
            setear_pieza(new Torre(pos));
            // la otra torre tiene que estar en la punta opuesta
            if (pos[0] == 7)
                pos[0] = 0;
            else pos[0] = 7;
            if (pos[1] == 7)
                pos[1] = 0;
            else pos[1] = 7;
           setear_pieza(new Torre(pos));

            pos[0] = rand.Next(3, 5);//solo en el centro
            pos[1] = rand.Next(3, 5);
            setear_pieza(new Reina(pos));
           
            do
            {
                pos[0] = rand.Next(1, 7); //en cualquier lugar menos el borde
                pos[1] = rand.Next(1, 7);
            } while (pos_ocupada(pos)==true);//que pruebe hasta una posicion libre
            setear_pieza(new Rey(pos));

            do
            {
                pos[0] = rand.Next(0, 8);//en cualquier lugar 
                pos[1] = rand.Next(0, 8);
            } while (pos_ocupada(pos)==true);
            setear_pieza(new Alfil(pos));

            do
            {
                pos[0] = rand.Next(0, 8);//en cualquier lugar 
                pos[1] = rand.Next(0, 8);

            } while (pos_ocupada(pos)==true && this.color_pos(piezas[4].get_pos()) != this.color_pos(pos));
            //que los alfiles esten en casilleros de distinto color
            setear_pieza(new Alfil(pos));

            do
            {
                pos[0] = rand.Next(2, 6);//solo en el centro 4x4
                pos[1] = rand.Next(2, 6);
            } while (pos_ocupada(pos)==true);
            setear_pieza(new Caballo(pos));

            do
            {
                pos[0] = rand.Next(2, 6);//solo en el centro 4x4
                pos[1] = rand.Next(2, 6);
            } while (pos_ocupada(pos)==true);
            setear_pieza(new Caballo(pos));

        }

        public Tablero(Tablero otro)
        {

            for (int i = 0; i < otro.piezas.Count; i++)
            {
                if(otro.piezas.ElementAt(i) is Torre)
                    this.piezas.Add(new Torre(otro.piezas.ElementAt(i)));
                else if (otro.piezas.ElementAt(i) is Reina)
                    this.piezas.Add(new Reina(otro.piezas.ElementAt(i)));
                else if (otro.piezas.ElementAt(i) is Rey)
                    this.piezas.Add(new Rey(otro.piezas.ElementAt(i)));
                else if (otro.piezas.ElementAt(i) is Caballo)
                    this.piezas.Add(new Caballo(otro.piezas.ElementAt(i)));
                else if (otro.piezas.ElementAt(i) is Alfil)
                    this.piezas.Add(new Alfil(otro.piezas.ElementAt(i)));
            }

            for (int i = 0; i < piezas.Count; i++)
                piezas.ElementAt(i).Atacar(this);

            for(int i = 0; i < constantes.TAM; i++)
            {
                for (int j = 0; j < constantes.TAM; j++)
                {
                    atacadas[i, j] = otro.atacadas[i, j];
                    colores[i, j] = otro.colores[i, j];
                    tipo_ataque[i, j] = otro.tipo_ataque[i, j];
                }

            }
        }

        //devuelve la pieza en esa posicion
        public Pieza Pieza_en_pos(int[] pos)
        {

            for (int i = 0; i < piezas.Count; i++)
            {
                if (piezas.ElementAt(i).Pos == pos)
                    return piezas.ElementAt(i);

            }
            return null;
        }

        //verifica si todas las posiciones estan siendo atacadas
        public bool atacadas_todas()
        {
            for (int i = 0; i < constantes.TAM; i++)
            {
                for (int j = 0; j < constantes.TAM; j++)
                {
                    if (atacadas[i, j] == false)
                        return false;
                }
            }
            return true;
        }

        // ver si la posicion esta ocupada
        public bool pos_ocupada(int[] pos)
        {
            for (int i = 0; i < piezas.Count; i++)
            {
                if (piezas.ElementAt(i).Pos == pos)
                    return true; //esta ocupada
            }

            return false; //no esta ocupada
        }

        //devuelve el color del casillero
        public bool color_pos(int[] pos)
        {
            return colores[pos[0], pos[1]];
        }

        public Pieza pieza_rnd()
        {
            Random rand = new Random();
            int num;
            do
            {
                num = rand.Next(0, piezas.Count());
                //pieza random de la lista, posicion entre 0 y 7
            } while (piezas.ElementAt(num) is Torre); //no cambio las torres de posicion

            return piezas.ElementAt(num);
        }

        //agrega la pieza a la lista y ataca al tablero
        public void setear_pieza(Pieza p)
        {
            piezas.Add(p); //agrego la pieza a la lista
            p.Atacar(this); //ataca
        }

        //devuelve una nueva pos random a donde se podria mover la pieza
        public int[] posible_mover(Pieza pieza_mover)
        {
            // despues en el main hay que chequear si se atacan mas espacios que en la posicion anterior

            int[] new_pos = new int[2];
            new_pos[0] = -1;
            new_pos[1] = -1;
            Random rand = new Random();

            if (pieza_mover is Reina)
            {
                do
                {   //next(min, max) incluye el minimo pero no se incluye el maximo
                    new_pos[0] = rand.Next(3, 5);//solo en el centro
                    new_pos[1] = rand.Next(3, 5);

                } while (pos_ocupada(new_pos) == true); // que siga probanbdo hasta una pos libre

                return new_pos;
            }

            else if (pieza_mover is Caballo)
            {
                do
                {
                    new_pos[0] = rand.Next(2, 6);//solo en el centro 4x4
                    new_pos[1] = rand.Next(2, 6);
                    if (pos_ocupada(new_pos) == false || Pieza_en_pos(new_pos) is Rey)
                        break;

                } while (pos_ocupada(new_pos) == true);// que siga probanbdo hasta una pos libre o que la pieza que hay sea un rey

                return new_pos;
            }

            else if (pieza_mover is Alfil)
            {
                bool color = color_pos(pieza_mover.Pos);
                do
                {
                    new_pos[0] = rand.Next(0, 8);//en cualquier lugar 
                    new_pos[1] = rand.Next(0, 8);

                } while (pos_ocupada(new_pos) == true && color != color_pos(new_pos) );
                // que siga probanbdo hasta una pos libre y se respete el color donde tiene que estar el alfil

                return new_pos;
            }

            else if (pieza_mover is Rey)
            {
                do
                {
                    new_pos[0] = rand.Next(1, 7); //en cualquier lugar menos el borde
                    new_pos[1] = rand.Next(1, 7);
                    if (pos_ocupada(new_pos) == false || Pieza_en_pos(new_pos) is Caballo)
                        break;
                } while (pos_ocupada(new_pos) == true);
                // que siga probanbdo hasta una pos libre

                return new_pos;
            }
            return null;
        }

        public void mover(Pieza pieza, int[] pos)
        {
        
            sacar(pieza); //saca la pieza del tablero y deja de atacar las posiciones que atacaba antes

            pieza.set_pos(pos); //cambio la posicion de la pieza
            setear_pieza(pieza); //la agrego al tablero con la nueva posicion
        }

        //saca la pieza del tablero 
        public void sacar(Pieza p)
        {    
            Tablero tablero_prueba = new Tablero(); //tablero vacio
            tablero_prueba.setear_pieza(p);

            for (int i = 0; i < constantes.TAM; i++)
            {
                for (int j = 0; j < constantes.TAM; j++)
                {
                    if (tablero_prueba.atacadas[i, j] == true)
                        this.atacadas[i, j] = false;

                }
            }

            for(int i = 0; i < piezas.Count; i++)
            {
                if (piezas.ElementAt(i).nombre == p.nombre)
                {
                    piezas.Remove(piezas.ElementAt(i));
                    break;
                }
            }

            for (int i = 0; i < piezas.Count(); i++)
            {
                piezas.ElementAt(i).Atacar(this); // volver a atacar por si alguna otra pieza atacaba una posicion que dejamos de atacar
            }

            return;
        }

        public Tablero Intercambio(string Alfil_Caballo) // prueba si encuentro solucion intercambiando las piezas puede ser un alfil o un caballo (criterio de poda)
        {
            int Caballo_Alfil = -1;
            int Reina_ = -1;
            Tablero t_prueba = new Tablero(this);

            int[] pos_reina;
            int[] pos_alfil_caballo;
            for (int j = 0; j < piezas.Count; j++)
            {
                if (Alfil_Caballo == constantes.CABALLO && t_prueba.piezas.ElementAt(j) is Caballo && Caballo_Alfil == -1)
                    Caballo_Alfil = j; // guardamos el indice de la pieza que buscamos y que se encuentra en la lista
                if (Alfil_Caballo == constantes.ALFIL && t_prueba.piezas.ElementAt(j) is Alfil && Caballo_Alfil == -1)
                    Caballo_Alfil = j;
                if (t_prueba.piezas.ElementAt(j) is Reina)
                    Reina_ = j;
            }

            pos_reina = t_prueba.piezas.ElementAt(Reina_).Pos;
            pos_alfil_caballo = t_prueba.piezas.ElementAt(Caballo_Alfil).Pos;
            t_prueba.mover(t_prueba.piezas.ElementAt(Reina_), pos_alfil_caballo);
            t_prueba.mover(t_prueba.piezas.ElementAt(Caballo_Alfil), pos_reina);
            
            if (atacadas_todas() == true)
                return t_prueba;

            else
                return null;
        }

       /* public void Ataques_Fatales() // añade en una lista las casillas que poseen ataques letales
        {

           List<int[]> Pos_Con_Fichas = new List<int[]>(); // guardare las posiciones en donde se con seguridad que hay una ficha
           for (int i=0; i<piezas.Count;i++)
           {
                Pos_Con_Fichas.Add(piezas.ElementAt(i).Pos);
           }

           for (int i=0; i<piezas.Count;i++)
           {
             //  Atacadas_Fatalmente.Add (piezas.ElementAt(i).Ataque_Fatal(Pos_Con_Fichas));//s agrego a la lista de ataadas fatalemte
           }          

          // verificar que me elimine los repetidos
           for(int j=0; j<Atacadas_Fatalmente.Count;j++)
            {
                for(int i=0; i<Atacadas_Fatalmente.Count;i++)
                {

                    if(Atacadas_Fatalmente.ElementAt(i)==Atacadas_Fatalmente.ElementAt(j))
                        Atacadas_Fatalmente.RemoveAt(j);
                }


            }
        }*/
    }
}
