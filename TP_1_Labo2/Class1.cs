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
        List<Pieza> piezas = new List<Pieza>(8);

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

            piezas[0] = new Torre();
            piezas[1] = new Torre();
            piezas[2] = new Reina();
            piezas[3] = new Rey();
            piezas[4] = new Alfil();
            piezas[5] = new Alfil();
            piezas[6] = new Caballo();
            piezas[7] = new Caballo();

        }

        public void setear_pieza(Pieza p)
        {
            piezas.Add(p);
            p.Atacar();
        }

        //verifica si todas las posiciones estan siendo atacadas
        public bool atacadas_todas() 
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

        //devuelve un tablero nuevo sin esa pieza
        public Tablero sacar(Pieza p) 
        {
           int indx = piezas.FindIndex(p); //indice de la pieza que no quiero que este
           Tablero nuevo = new Tablero(); //tablero sin la pieza
           for(int i =0; i< constantes.CANT_PIEZAS; i++)
           {
                if(i!= indx) //agrega todas las piezas que estaban en la lista de piezas del tablero original menos la que recibe
                    nuevo.setear_pieza(piezas[i]);
           }
            return nuevo;
        }
        
        public int cant_atacadas(Pieza p)
        {
            Tablero temp = this;
            temp.sacar(p);
        }
         
        //devuelve una nueva pos random a donde se podria mover la pieza
        public int[] posible_mover(Pieza pieza_mover) 
        {    
            // despues en el main hay que chequear si se atacan mas espacios que en la posicion anterior

            int[] new_pos = new int[2];
            new_pos[0]=-1;
            new_pos[1]=-1;
            Random rand = new Random();

            if(pieza_mover is Torre)
            {
                return pieza_mover.Pos; //queda en el mismo lugar
            }
            
            else if(pieza_mover is Reina)
            {
                do
                {
                    new_pos[0]=rand.Next(3,4);//solo en el centro
                    new_pos[1]=rand.Next(3,4);

                }while(pos_ocupada(new_pos)==true); // que siga probanbdo hasta una pos libre
                
                return new_pos;
            }

            else if(pieza_mover is Caballo)
            {
                do
                {
                    new_pos[0]=rand.Next(2,5);//solo en el centro 4x4
                     new_pos[1]=rand.Next(2,5);

                }while(pos_ocupada(new_pos)==true); // que siga probanbdo hasta una pos libre
                
                return new_pos;
            }

            else if(pieza_mover is Alfil)
            {
                bool color = color_pos(pieza_mover.Pos);
                do
                {
                    new_pos[0]=rand.Next(0,7);//en cualquier lugar 
                    new_pos[1]=rand.Next(0,7);

                }while(pos_ocupada(new_pos)==true && color != color_pos(new_pos));
                // que siga probanbdo hasta una pos libre y se respete el color donde tiene que estar el alfil

                return new_pos;
            }

            else if(pieza_mover is Rey)
            {
                do
                {
                    new_pos[0]=rand.Next(1,6); //en cualquier lugar menos el borde
                    new_pos[1]=rand.Next(1,6);

                }while(pos_ocupada(new_pos)==true);
                // que siga probanbdo hasta una pos libre

                return new_pos;
            }
            return  null;
        }
        
        public bool pos_ocupada(int[] pos)
        {
            for(int i = 0; i < constantes.CANT_PIEZAS; i++{
                if (piezas[i].Pos==pos)
                    return true; //esta ocupada
            }

            return false; //no esta ocupada
        }
        
        public bool color_pos(int[] pos)
        {
            return colores[pos[0], pos[1]]; //devuelve el color de la posicion
        }

        public Pieza pieza_rnd()
        {
            Random rand = new Random();

            return piezas[rand.Next(0,constantes.CANT_PIEZAS-1)]; //pieza random de la lista, posicion entre 0 y 7
        }

        public void mover(Pieza pieza, int[] pos)
        {
            this=this.sacar(pieza); //devuelve un tablero nuevo sin esa pieza
            pieza.Pos=pos; //cambio la posicion de la pieza
            this.setear_pieza(pieza); //la agrego al tablero con la nueva posicion

        }
       
     }

}


