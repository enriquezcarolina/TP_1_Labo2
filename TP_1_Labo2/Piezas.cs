using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TP_1_Labo2
{

    public class Pieza
    {
        public int[] Pos = new int[2];
   
        public virtual void Atacar(Tablero tablero)
        {

        }
        public void set_pos(int[] xy)
        {
            Pos[0] = xy[0];
            Pos[1] = xy[1];
        }

        List<int[]> Posiciones_Ya_Probadas = new List<int[]>(); // lista con las posiciones que tuvo esta ficha, ya probe y no me funcionaron

        public void set_pos_ya_probada(int[] Pos)
        {
            Posiciones_Ya_Probadas.Add(Pos); // agrega la posicion ya probada a la lista
        }
        public bool bool_pos_ya_probada(int[] Pos) // retorna true o false si ya se probo esa posicion 
        {
            return Posiciones_Ya_Probadas.Contains(Pos); // retorna true si la contiene en la lista y false si no esta
        }

        public int[] get_pos()
        {
            return Pos;
        }


    }

    public class Torre : Pieza
    {
        public string nombre = "Torre";
        public Torre(int[] pos)
        {
            Pos[0] = pos[0];
            Pos[1] = pos[1];
        }

        public override void Atacar(Tablero tablero)
        {
            for (int i = 0; i < constantes.TAM; i++) //ataca toda la fila
            {
                if (i != Pos[0]) //que no ataque su posicion
                    tablero.atacadas[i, Pos[1]] = constantes.ATACADA;
            }

            for (int j = 0; j < constantes.TAM; j++) //ataca toda la columna
            {
                if (j != Pos[1]) //que no ataque su posicion
                    tablero.atacadas[Pos[0], j] = constantes.ATACADA;
            }
            //return tablero;
        }
    }

    public class Caballo : Pieza
    {
        public string nombre = "Caballo";

        public Caballo(int[] pos)
        {
            Pos[0] = pos[0];
            Pos[1] = pos[1];
        }
        public override void Atacar (Tablero tablero)
        {
            //no se como hacerlo con un for entonces puse que casilleros ataca uno por uno
            tablero.atacadas[Pos[0] + 2, Pos[1] + 1] = constantes.ATACADA;
            tablero.atacadas[Pos[0] + 2, Pos[1] - 1] = constantes.ATACADA;
            tablero.atacadas[Pos[0] - 2, Pos[1] + 1] = constantes.ATACADA;
            tablero.atacadas[Pos[0] - 2, Pos[1] - 1] = constantes.ATACADA;
            tablero.atacadas[Pos[0] + 1, Pos[1] + 2] = constantes.ATACADA;
            tablero.atacadas[Pos[0] - 1, Pos[1] + 2] = constantes.ATACADA;
            tablero.atacadas[Pos[0] + 1, Pos[1] - 2] = constantes.ATACADA;
            tablero.atacadas[Pos[0] - 1, Pos[1] - 2] = constantes.ATACADA;
           // return tablero;
        }
    }

    public class Alfil : Pieza
    {
        public string nombre = "Alfil";
        public Alfil(int[] pos)
        {
            Pos[0] = pos[0];
            Pos[1] = pos[1];
        }
        public override void Atacar(Tablero tablero)
        {
            for(int i = 1; i < constantes.TAM; i++)//desde 1 porque con 0 atacaria su posicion
            { 
                //el alfil ataca en diagonal entonces sumo o resto lo mismo a la fila y la columa

                if (Pos[0] + i < constantes.TAM && Pos[1] - i >= 0) //chequeo que no se pase del tablero
                    tablero.atacadas[Pos[0] + i, Pos[1] - i] = constantes.ATACADA;
               
                if (Pos[0] - i >=0 && Pos[1] + i < constantes.TAM) 
                    tablero.atacadas[Pos[0] - i, Pos[1] + i] = constantes.ATACADA;
               
               
                if(Pos[0] + i < constantes.TAM && Pos[1] + i < constantes.TAM)
                    tablero.atacadas[Pos[0] + i, Pos[1] + i] = constantes.ATACADA;
               
                if (Pos[0] - i >= 0 && Pos[1] - i >= 0)
                    tablero.atacadas[Pos[0] - i, Pos[1] - i] = constantes.ATACADA;
            }
        }
    }

    public class Rey : Pieza
    {
        public string nombre = "Rey";
        public Rey(int[] pos)
        {
            Pos[0] = pos[0];
            Pos[1] = pos[1];
        }
        public override void Atacar(Tablero tablero)
        {
            for(int i=-1; i<2; i++)
            {
                for(int j=-1; j<2; j++)
                {
                    if(!(i==0 && j==0))//que no ataque su posicion
                    {
                        tablero.atacadas[Pos[0] + i, Pos[1] + j] = constantes.ATACADA;
                    }
                }
            }
        }
    }

    public class Reina : Pieza
    {
        public string nombre = "Reina";
        public Reina(int[] pos)
        {
            Pos[0] = pos[0];
            Pos[1] = pos[1];
        }
        public override void Atacar(Tablero tablero)
        {
            //ataque alfil + ataque torre

            //ALFIL
            for (int i = 1; i < constantes.TAM; i++)//desde 1 porque con 0 atacaria su posicion
            {
                //el alfil ataca en diagonal entonces sumo o resto lo mismo a la fila y la columa

                if (Pos[0] + i < constantes.TAM && Pos[1] - i >= 0) //chequeo que no se pase del tablero
                    tablero.atacadas[Pos[0] + i, Pos[1] - i] = constantes.ATACADA;

                if (Pos[0] - i >= 0 && Pos[1] + i < constantes.TAM)
                    tablero.atacadas[Pos[0] - i, Pos[1] + i] = constantes.ATACADA;


                if (Pos[0] + i < constantes.TAM && Pos[1] + i < constantes.TAM)
                    tablero.atacadas[Pos[0] + i, Pos[1] + i] = constantes.ATACADA;

                if (Pos[0] - i >= 0 && Pos[1] - i >= 0)
                    tablero.atacadas[Pos[0] - i, Pos[1] - i] = constantes.ATACADA;
            }

            //TORRE
            for (int i = 0; i < constantes.TAM; i++) //ataca toda la fila
            {
                if (i != Pos[0]) //que no ataque su posicion
                    tablero.atacadas[i, Pos[1]] = constantes.ATACADA;
            }
            for (int j = 0; j < constantes.TAM; j++) //ataca toda la columna
            {
                if (j != Pos[1]) //que no ataque su posicion
                    tablero.atacadas[Pos[0], j] = constantes.ATACADA;
            }
        }
    }

}