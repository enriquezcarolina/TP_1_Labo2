using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TP_1_Labo2
{

    public class Pieza
    {
        public string nombre;
        public int[] Pos = new int[2];
        public List<int[]> Pos_Atacadas = new List<int[]>(); //listado de casillas atacadas por la pieza
        List<int[]> Posiciones_Ya_Probadas = new List<int[]>(); // lista con las posiciones que tuvo esta ficha, ya probe y no me funcionaron

        /* public virtual List<int[]> Ataque_Fatal(List<int[]> Pos_Con_Fichas)
          {

              // pasa por parametro una lista posiciones donde se sabe que hay piezas
              // para fijarme uee  ninguna se entrometa en el camino del ataque  (en caso de que lo haga es un ataque leve)
            List<int[]> ataques_fatales[0]=-1;
            List<int[]> ataques_fatales[1]=-1;

        }*/
        public Pieza()
        {
            Pos[0] = -1;
            Pos[1] = -1;

        }

        public Pieza(Pieza otra)
        {
            this.nombre = otra.nombre;
            Pos[0] = otra.Pos[0];
            Pos[1] = otra.Pos[1];
            for (int i = 0; i < otra.Pos_Atacadas.Count(); i++)
                this.Pos_Atacadas.Add(otra.Pos_Atacadas.ElementAt(i));
        }

        public Pieza(int[] pos)
        {
            Pos[0] = pos[0];
            Pos[1] = pos[1];
        }
       
        public virtual void Atacar(Tablero tablero)
        {

        }
        public void set_pos(int[] xy)
        {
            Pos[0] = xy[0];
            Pos[1] = xy[1];
        }

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
        public Torre(int[] pos)
        {
            nombre = constantes.TORRE;
            Pos[0] = pos[0];
            Pos[1] = pos[1];
        }

        public Torre()
        {
            nombre = constantes.TORRE;
            Pos[0] = -1;
            Pos[1] = -1;

        }

        public Torre(Pieza otra)
        {
            this.nombre = otra.nombre;
            Pos[0] = otra.Pos[0];
            Pos[1] = otra.Pos[1];
          /*  for (int i = 0; i < otra.Pos_Atacadas.Count(); i++)
                this.Pos_Atacadas.Add(otra.Pos_Atacadas.ElementAt(i));*/
        }


        /*   
           public override List<int[]> Ataque_Fatal(List<int[]> Pos_Con_Fichas)
           {




               return ataques_fatales;
            }
           */
        public override void Atacar(Tablero tablero)
        {

            int[] auxpos = new int[2];
            for (int i = 0; i < constantes.TAM; i++) //ataca toda la fila
            {
                if (i != Pos[0]) //que no ataque su posicion
                {   tablero.atacadas[i, Pos[1]] = constantes.ATACADA;
                    /*auxpos[0]=i;
                    auxpos[1]=Pos[1];

                    Pos_Atacadas.Add(auxpos);*/
                 }
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

        public Caballo(int[] pos)
        {
            nombre = constantes.CABALLO;
            Pos[0] = pos[0];
            Pos[1] = pos[1];
        }

        public Caballo()
        {
            nombre = constantes.CABALLO;
            Pos[0] = -1;
            Pos[1] = -1;

        }

        public Caballo(Pieza otra)
        {
            this.nombre = otra.nombre;
            Pos[0] = otra.Pos[0];
            Pos[1] = otra.Pos[1];
            for (int i = 0; i < otra.Pos_Atacadas.Count(); i++)
                this.Pos_Atacadas.Add(otra.Pos_Atacadas.ElementAt(i));
        }

        /*
           public override List<int[]> Ataque_Fatal(List<int[]> Pos_Con_Fichas)
        {

            // pasa por parametro una lista posiciones donde se sabe que hay piezas
            // para fijarme uee  ninguna se entrometa en el camino del ataque  (en caso de que lo haga es un ataque leve)
      List<int[]> ataques_fatales=0;

            
          
            
            return ataques_fatales;
            
                
         }*/
        public override void Atacar (Tablero tablero)
        {

            int[] auxpos = new int[2];
            //no se como hacerlo con un for entonces puse que casilleros ataca uno por uno
            tablero.atacadas[Pos[0] + 2, Pos[1] + 1] = constantes.ATACADA;
            /*auxpos[0]=Pos[0] + 2;
            auxpos[1]= Pos[1] + 1;
            Pos_Atacadas.Add(auxpos);*/
            tablero.atacadas[Pos[0] + 2, Pos[1] - 1] = constantes.ATACADA;
            /*auxpos[0]=Pos[0] + 2;
            auxpos[1]= Pos[1] - 1;
            Pos_Atacadas.Add(auxpos);*/
            tablero.atacadas[Pos[0] - 2, Pos[1] + 1] = constantes.ATACADA;
            /*auxpos[0]=Pos[0] - 2;
            auxpos[1]=  Pos[1] + 1;
            Pos_Atacadas.Add(auxpos);*/
            tablero.atacadas[Pos[0] - 2, Pos[1] - 1] = constantes.ATACADA;
           /* auxpos[0]=Pos[0] - 2;
            auxpos[1]= Pos[1] - 1;
            Pos_Atacadas.Add(auxpos);*/
            tablero.atacadas[Pos[0] + 1, Pos[1] + 2] = constantes.ATACADA;
            /*auxpos[0]=Pos[0] + 1;
            auxpos[1]=  Pos[1] + 2;
            Pos_Atacadas.Add(auxpos);*/
            tablero.atacadas[Pos[0] - 1, Pos[1] + 2] = constantes.ATACADA;
           /*auxpos[0]=Pos[0] - 1;
            auxpos[1]= Pos[1] + 2;
            Pos_Atacadas.Add(auxpos);*/
            tablero.atacadas[Pos[0] + 1, Pos[1] - 2] = constantes.ATACADA;
            /*auxpos[0]=Pos[0] + 1;
            auxpos[1]= Pos[1] - 2;
            Pos_Atacadas.Add(auxpos);*/
            tablero.atacadas[Pos[0] - 1, Pos[1] - 2] = constantes.ATACADA;
            /*auxpos[0]=Pos[0] - 1;
            auxpos[1]= Pos[1] - 2;
            Pos_Atacadas.Add(auxpos);*/
           
        }
    }

    public class Alfil : Pieza
    {
        public Alfil(int[] pos)
        {
            nombre = constantes.ALFIL;
            Pos[0] = pos[0];
            Pos[1] = pos[1];
        }

        public Alfil()
        {
            nombre = constantes.ALFIL;
            Pos[0] = -1;
            Pos[1] = -1;

        }

        public Alfil(Pieza otra)
        {
            this.nombre = constantes.ALFIL;
            Pos[0] = otra.Pos[0];
            Pos[1] = otra.Pos[1];
            for (int i = 0; i < otra.Pos_Atacadas.Count(); i++)
                this.Pos_Atacadas.Add(otra.Pos_Atacadas.ElementAt(i));
        }

        /* public override List<int[]> Ataque_Fatal(List<int[]> Pos_Con_Fichas)
        {

            // pasa por parametro una lista posiciones donde se sabe que hay piezas
            // para fijarme uee  ninguna se entrometa en el camino del ataque  (en caso de que lo haga es un ataque leve)
            List<int[]> ataques_fatales[0]=-1;
            List<int[]> ataques_fatales[1]=-1;
            
          
            
            return ataques_fatales;
            
                
         }*/
        public override void Atacar(Tablero tablero)
        {
             int[] auxpos = new int[2];
            for(int i = 1; i < constantes.TAM; i++)//desde 1 porque con 0 atacaria su posicion
            { 
                //el alfil ataca en diagonal entonces sumo o resto lo mismo a la fila y la columa

                if (Pos[0] + i < constantes.TAM && Pos[1] - i >= 0) //chequeo que no se pase del tablero
                {   
                    tablero.atacadas[Pos[0] + i, Pos[1] - i] = constantes.ATACADA;
                    /*auxpos[0]=Pos[0] + i;
                    auxpos[1]= Pos[1] - i;
                    Pos_Atacadas.Add(auxpos);*/
                }
               
                if (Pos[0] - i >=0 && Pos[1] + i < constantes.TAM) 
                {   
                    tablero.atacadas[Pos[0] - i, Pos[1] + i] = constantes.ATACADA;
                    /*auxpos[0]=Pos[0] - i;
                    auxpos[1]= Pos[1] + i;
                    Pos_Atacadas.Add(auxpos);*/
                }
               
                if(Pos[0] + i < constantes.TAM && Pos[1] + i < constantes.TAM)
                { 
                    tablero.atacadas[Pos[0] + i, Pos[1] + i] = constantes.ATACADA;
                   /* auxpos[0]=Pos[0] + i;
                    auxpos[1]=  Pos[1] + i;
                    Pos_Atacadas.Add(auxpos);      */         
                }
               
                if (Pos[0] - i >= 0 && Pos[1] - i >= 0)
                {
                    tablero.atacadas[Pos[0] - i, Pos[1] - i] = constantes.ATACADA;
                   /* auxpos[0]=Pos[0] - i;
                    auxpos[1]= Pos[1] - i;
                    Pos_Atacadas.Add(auxpos);*/
                }
            }
        }
    }

    public class Rey : Pieza
    {
        public Rey(int[] pos)
        {
            nombre = constantes.REY;
            Pos[0] = pos[0];
            Pos[1] = pos[1];
        }

        public Rey()
        {
            nombre = constantes.REY;
            Pos[0] = -1;
            Pos[1] = -1;

        }

        public Rey(Pieza otra)
        {
            this.nombre = otra.nombre;
            Pos[0] = otra.Pos[0];
            Pos[1] = otra.Pos[1];
            for (int i = 0; i < otra.Pos_Atacadas.Count(); i++)
                this.Pos_Atacadas.Add(otra.Pos_Atacadas.ElementAt(i));
        }

        /*
           public override List<int[]> Ataque_Fatal(List<int[]> Pos_Con_Fichas)
        {

            // pasa por parametro una lista posiciones donde se sabe que hay piezas
            // para fijarme uee  ninguna se entrometa en el camino del ataque  (en caso de que lo haga es un ataque leve)
           List<int[]> ataques_fatales=0;

            
          
            
            return ataques_fatales;
            
                
         }*/
        public override void Atacar(Tablero tablero)
        {  int[] auxpos = new int[2];
            for(int i=-1; i<2; i++)
            {
                for(int j=-1; j<2; j++)
                {
                    if(!(i==0 && j==0))//que no ataque su posicion
                    {
                        tablero.atacadas[Pos[0] + i, Pos[1] + j] = constantes.ATACADA;
                        /* auxpos[0]=Pos[0] + i;
                         auxpos[1]= Pos[1] + j;
                         Pos_Atacadas.Add(auxpos);*/
                    }
                }
            }
        }
    }

    public class Reina : Pieza
    {
        public Reina(int[] pos)
        {
            nombre = constantes.REINA;
            Pos[0] = pos[0];
            Pos[1] = pos[1];
        }
        public Reina()
        {
            nombre = constantes.REINA;
            Pos[0] = -1;
            Pos[1] = -1;

        }

        public Reina(Pieza otra)
        {
            this.nombre = otra.nombre;
            Pos[0] = otra.Pos[0];
            Pos[1] = otra.Pos[1];
            for (int i = 0; i < otra.Pos_Atacadas.Count(); i++)
                this.Pos_Atacadas.Add(otra.Pos_Atacadas.ElementAt(i));
        }

        /*
         public override List<int[]> Ataque_Fatal(List<int[]> Pos_Con_Fichas)
         {
             List<int[]> ataques_fatales=0;



             return ataques_fatales;




          }*/
        public override void Atacar(Tablero tablero)
        {   int[] auxpos = new int[2];
            //ataque alfil + ataque torre

            //ALFIL
            for (int i = 1; i < constantes.TAM; i++)//desde 1 porque con 0 atacaria su posicion
            {
                //el alfil ataca en diagonal entonces sumo o resto lo mismo a la fila y la columa

                if (Pos[0] + i < constantes.TAM && Pos[1] - i >= 0) //chequeo que no se pase del tablero
                {   tablero.atacadas[Pos[0] + i, Pos[1] - i] = constantes.ATACADA;
                    /*auxpos[0]=Pos[0] + i;
                    auxpos[1]= Pos[1] - i;
                    Pos_Atacadas.Add(auxpos);*/
                }
               
                if (Pos[0] - i >=0 && Pos[1] + i < constantes.TAM) 
                {   
                    tablero.atacadas[Pos[0] - i, Pos[1] + i] = constantes.ATACADA;
                    /*auxpos[0]=Pos[0] - i;
                    auxpos[1]= Pos[1] + i;
                    Pos_Atacadas.Add(auxpos);*/

                }
               
                if(Pos[0] + i < constantes.TAM && Pos[1] + i < constantes.TAM)
                   { 
                    tablero.atacadas[Pos[0] + i, Pos[1] + i] = constantes.ATACADA;
                    /*auxpos[0]=Pos[0] + i;
                    auxpos[1]=  Pos[1] + i;
                    Pos_Atacadas.Add(auxpos);*/
                
                }
               
                if (Pos[0] - i >= 0 && Pos[1] - i >= 0)
                    {tablero.atacadas[Pos[0] - i, Pos[1] - i] = constantes.ATACADA;
                    /*auxpos[0]=Pos[0] - i;
                    auxpos[1]= Pos[1] - i;
                    Pos_Atacadas.Add(auxpos);*/
                    }
            }

            //TORRE
            for (int i = 0; i < constantes.TAM; i++) //ataca toda la fila
            {
                if (i != Pos[0]) //que no ataque su posicion
               {     tablero.atacadas[i, Pos[1]] = constantes.ATACADA;
                 /* auxpos[0]=i;
                    auxpos[1]= Pos[1];
                    Pos_Atacadas.Add(auxpos); */}
            }
            for (int j = 0; j < constantes.TAM; j++) //ataca toda la columna
            {
                if (j != Pos[1]) //que no ataque su posicion
                   { tablero.atacadas[Pos[0], j] = constantes.ATACADA;
                    /*auxpos[0]=Pos[0];
                    auxpos[1]= j;
                    Pos_Atacadas.Add(auxpos);*/ }
            }
        }
    }

}