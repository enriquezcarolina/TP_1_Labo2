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
        public const int CANT_PIEZAS = 8;

    }

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
    }
   
    public class Torre : Pieza
    {
        public override void Atacar(Tablero tablero)
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
            //return tablero;
        }
    }

    public class Caballo : Pieza
    {
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

    public class Tablero
    {
        
        public bool[,] colores = new bool[8, 8];
        public bool[,] atacadas = new bool[8, 8];
        public bool[,] tipo_ataque = new bool[8, 8];
        public Pieza[] posiciones = new Pieza[8];

        public bool[,] get_atacadas()
        {
            return atacadas;
        }
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
                posiciones[n] = null;
                for (int m = 0; m < constantes.TAM; m++)
                {
                    atacadas[n, m] = constantes.NO_ATACADA;
                    tipo_ataque[n,  m]  = false;
                }
            }

        }

        public bool atacadas_todas() //verifica si todas las posiciones estan siendo atacadas
        {
            for(int i = 0; i < constantes.TAM; i++)
            {
                for(int j=0; j < constantes.TAM; j++)
                {
                    if (atacadas[i,j]==false)
                        return false;
                }
            }
            return true;
        }
           
        public int[] mover(Pieza pieza_mover) 
        {    //devuelve una nueva pos random a donde se podria mover la pieza
            // despues en el main hay que chequear si se atacan mas espacios que en la posicion anterior

          /*  torres primero enfrentadas en diagonal en las puntas. una se posiciona de forma aleatoria en una punta y la otra se pone en diagonal.
           reina aleatoriamente en una de las cuatro casillas del medio
          caballo aleatoriamente en el centro 4x4 (que no esté en las puntas)
            alfiles al azar en todo el tablero respetando que estén uno en blanco y otro en negro
            rey en posición aleatoria menos el borde 6x6
            */

            int[] new_pos = new int[2];
            Random rand = new Random();
            int pos1 = -1;
            int pos2 = -1;

            if(pieza_mover is Torre)
            {
                return pieza_mover.Pos;
            }
            
            else if(pieza_mover is Reina)
            {
                do
                {
                    pos1=rand.Next(3,4);//solo en el centro
                    pos2=rand.Next(3,4);

                }while(pos_ocupada(pos1, pos2)==true); // que siga probanbdo hasta una pos libre

                new_pos[0] = pos1;
                new_pos[1] = pos2;
                
                return new_pos;
            }
            else if(pieza_mover is Caballo)
            {
                do
                {
                    pos1=rand.Next(2,5);//solo en el centro 4x4
                    pos2=rand.Next(2,5);

                }while(pos_ocupada(pos1, pos2)==true); // que siga probanbdo hasta una pos libre

                new_pos[0]=pos1;
                new_pos[1] = pos2;
                
                return new_pos;

            }

            else if(pieza_mover is Alfil)
            {
                bool color = color_pos(pieza_mover.Pos[0], pieza_mover.Pos[1]);
                do
                {
                    pos1=rand.Next(0,7);//en cualquier lugar 
                    pos2=rand.Next(0,7);

                }while(pos_ocupada(pos1, pos2)==true && color != color_pos(pos1, pos2));
                // que siga probanbdo hasta una pos libre y se respete el color donde tiene que estar el alfil

                new_pos[0]=pos1;
                new_pos[1] = pos2;
                
                return new_pos;
            }

            else if(pieza_mover is Rey)
            {
                do
                {
                    pos1=rand.Next(1,6); //en cualquier lugar menos el borde
                    pos2=rand.Next(1,6);

                }while(pos_ocupada(pos1, pos2)==true);
                // que siga probanbdo hasta una pos libre

                new_pos[0] = pos1;
                new_pos[1] = pos2;
                
                return new_pos;
            }
            return  null;
        }
        
        public bool pos_ocupada(int x, int y)
        {
            if(posiciones[y] == null && posiciones[x]==null)
                return false;//no esta ocupada

            else return true;//esta ocupada
        }
        
        public bool color_pos(int x, int y)
        {
            return colores[x, y]; //devuelve el color de la posicion
        }

        
       
     }

    public class Test
    {
        public int cant_atacadas(Pieza pieza_prueba, int[] xy)
        { //devuelve la cantidad de posiciones que atacaria en una nueva posicion
          // podriamos probar con un nuevo tablero donde me pasen por parametro en que posicion estaria la ficha que quiero testear
          // contamos cuantas fichas esta atacndo y retornamos ese valor 
            int cont = 0;
            bool[,] atacadas=null;
            Tablero Tablero_Prueba = new Tablero();
            pieza_prueba.set_pos(xy); // pongo la pieza en la posicion deseada
            pieza_prueba.Atacar(Tablero_Prueba); // ataco el tablero de prueba

            for(int i=0; i< constantes.TAM; i++)
            {
                for(int k=0; k< constantes.TAM; k++)
                {

                    atacadas = Tablero_Prueba.get_atacadas();
                    if (atacadas[i,k]==true)
                        cont++; // aumento el contador cada vez que encuentro una casilla atacada 
                }
            }
           

            return cont;
        }
    }
}


