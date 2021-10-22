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

        public Pieza(int[] pos)
        {
            Pos[0]= pos[0];
            Pos[1]=pos[1];
        }
   
        public virtual void Atacar(Tablero tablero)
        {

        }
        public void set_pos(int[] xy)
        {
            Pos[0] = xy[0];
            Pos[1] = xy[1];
        }

        public int[] get_pos()
        {
            return Pos;
        }


    }
   
    public class Torre : Pieza
    {
        public string nombre = 'Torre';
        public Torre(int[] pos)
        {
            Pos[0] = pos[0];
            Pos[1] = pos[1];
        }
   
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
        public string nombre = 'Caballo';
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
        public string nombre = 'Alfil';

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
        
        public bool[,] colores = new bool[8, 8]; //color de los casilleros
        public bool[,] atacadas = new bool[8, 8]; //que casilleros estan siendo atacados
        public bool[,] tipo_ataque = new bool[8, 8]; //ataque fuerte o leve
        List<Pieza> piezas = new List<Pieza>(8); //listado de piezas

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

            Random rand= new Random();
            int[] pos = new int[2];

            pos[0] = rand.Next(0,1)*7; //o 0 o 7, que este en una de las puntas
            pos[1] = rand.Next(0,1)*7;
            piezas[0] = new Torre(pos);

           // la otra torre tiene que estar en la punta opuesta
            if(pos[0]==7)
                pos[0]=0;
            else pos[0]=7;            
            if(pos[1]==7)
                pos[1]=0;
            else pos[1]=7;
            piezas[1] = new Torre(pos);

            pos[0]=rand.Next(3,4);//solo en el centro
            pos[1]=rand.Next(3,4);
            piezas[2] = new Reina(pos);

           do
           {
              pos[0]=rand.Next(1,6); //en cualquier lugar menos el borde
              pos[1]=rand.Next(1,6);
           }while(pos_ocupada(pos));//que pruebe hasta una posicion libre
            piezas[3] = new Rey();

            do { 
               pos[0]=rand.Next(0,7);//en cualquier lugar 
               pos[1]=rand.Next(0,7);
            }while(pos_ocupada(pos))
            piezas[4] = new Alfil();

            do { 
               pos[0]=rand.Next(0,7);//en cualquier lugar 
               pos[1]=rand.Next(0,7);

            }while(pos_ocupada(pos) && this.color_pos(piezas[4].get_pos()) != this.color_pos(pos)) 
            //que los alfiles esten en casilleros de distinto color
            piezas[5] = new Alfil();
           
            do { 
            new_pos[0]=rand.Next(2,5);//solo en el centro 4x4
            new_pos[1]=rand.Next(2,5);
            }while(pos_ocupada(pos))
            piezas[6] = new Caballo();

            do { 
            new_pos[0]=rand.Next(2,5);//solo en el centro 4x4
            new_pos[1]=rand.Next(2,5);
            }while(pos_ocupada(pos))
            piezas[7] = new Caballo();

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

        // ver si la posicion esta ocupada
        public bool pos_ocupada(int[] pos) 
        {
            for(int i = 0; i < constantes.CANT_PIEZAS; i++){
                if (piezas[i].Pos==pos)
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

            return piezas[rand.Next(0,constantes.CANT_PIEZAS-1)]; //pieza random de la lista, posicion entre 0 y 7
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
        
        public void mover(Pieza pieza, int[] pos)
        { 
            sacar(pieza); //saca la pieza del tablero y deja de atacar las posiciones que atacaba antes

            for (int i=0;i<piezas.Count();i++)
            {

                piezas.ElementAt(i).Atacar(this); // volver a atacar por si alguna otra pieza atacaba una posicion que dejamos de atacar
            }

            pieza.set_pos(pos); //cambio la posicion de la pieza
            setear_pieza(pieza); //la agrego al tablero con la nueva posicion
        }
        
        //saca la pieza del tablero 
        public void sacar(Pieza p) 
        {
            Tablero tablero_prueba = new Tablero();
            tablero_prueba.setear_pieza(p);
           
            for (int i = 0; i < constantes.TAM; i++)
            {
                for (int j = 0; j < constantes.TAM; j++)
                {
                    if (tablero_prueba.atacadas[i, j] == true)
                        this.atacadas[i, j] = false;

                }
            }
            
            piezas.Remove(p);

            return;
        }
        
    }
  
    

}


