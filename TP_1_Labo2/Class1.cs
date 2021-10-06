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


    public class pieza
    { 

        public virtual void atacar(tablero tablero);  

    }
   
    public class reina : pieza
    {

        public override void atacar(tablero tablero)
        {

        }
    }

    public class tablero
    {
        
        public bool[,] colores = new bool[8, 8];
        public bool[,] atacadas = new bool[8, 8];
        public bool[,] tipo_ataque = new bool[8, 8];
        public pieza[,] posiciones = new pieza[8, 8];

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

            
         


