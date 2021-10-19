using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TP_1_Labo2
{
    static class constantes
    {
        public const bool NEGRO = true;
        public const bool BLANCO = false;
        public const int TAM = 8;
        public const bool ATACADA = true;
        public const bool NO_ATACADA = false; 
        
    }
    // prueba

    public class Pieza
    {
        public int[] Pos = new int[2];
        public virtual void Atacar(tablero tablero)
        {

        }
    }
   
    public class Torre : Pieza
    {
        public override void Atacar(tablero tablero)
        {
            for (int i = 0; i < constantes.TAM; i++) //ataca toda la fila
            {
                if(i!=Pos[0]) //que no ataque su posicion
                    tablero.atacadas[i, Pos[1]] = constantes.ATACADA;
            }
            for(int j=0; j<constantes.TAM; j++) //ataca toda la columna
            {
                if (j != Pos[1]) //que no ataque su posicion
                    tablero.atacadas[Pos[0], j] = constantes.ATACADA;
            }
        }
    }

    public class Caballo : Pieza
    {
        public override void Atacar (tablero tablero)
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
        }
    }

    public class Alfil : Pieza
    {

        public override void Atacar(tablero tablero)
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

        public override void Atacar(tablero tablero)
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

        public override void Atacar(tablero tablero)
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

    public class tablero
    {
        
        public bool[,] colores = new bool[8, 8];
        public bool[,] atacadas = new bool[8, 8];
        public bool[,] tipo_ataque = new bool[8, 8];
        public Pieza[,] posiciones = new Pieza[8, 8];

        public tablero()
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
                    posiciones[n,  m] = null;
                    tipo_ataque[n,  m]  = false;
                }
            }


        }
     }


}
