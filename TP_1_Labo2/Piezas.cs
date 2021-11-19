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
        public List<int[]> Posiciones_Ya_Probadas = new List<int[]>(); // lista con las posiciones que tuvo esta ficha, ya probe y no me funcionaron
        public List<int[]>  Ataques_Fatales = new List<int[]>();
        public int contador_atacadas;

        

        public virtual void Ataque_Fatal(List<Pieza> Lista_Fichas)
          {

              // pasa por parametro una lista de piezas
              // para fijarme uee  ninguna se entrometa en el camino del ataque  (en caso de que lo haga es un ataque leve)
             // seteara los ataques fatales ques produce la ficha 
             // podemos hacer que retorne la lista d elementos que impiden el ataque fatal 
             // carga la lista ataques fatales de la pieza 

        }
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
            {
                this.Pos_Atacadas.Add(otra.Pos_Atacadas.ElementAt(i));
            }
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
            contador_atacadas=0;
        }

        public Torre()
        {
            nombre = constantes.TORRE;
            Pos[0] = -1;
            Pos[1] = -1;
            contador_atacadas=0;

        }

        public Torre(Pieza otra)
        {
            this.nombre = otra.nombre;
            Pos[0] = otra.Pos[0];
            Pos[1] = otra.Pos[1];
            contador_atacadas=0;

        }

     
        public override void Ataque_Fatal(List<Pieza> Lista_Fichas)
        { 
            
            int[] Pos = this.Pos;
            int[] Pos_pieza = new int[2];
            Pos_pieza[0]=8;
            Pos_pieza[1]=8;
            int[] Pos_ataque_fatal = new int[2];
            bool hay_pieza = false;
            // primero desde la pos de la torre a la derecha 

            for (int i = Pos[0]+1; i < 8 ; i++) //ataca toda la fila fijarse si [0] es fila o columna 
            {

                for (int j=0; j<Lista_Fichas.Count; j++)
                {
                    if (Lista_Fichas.ElementAt(j).Pos[0] == i && Lista_Fichas.ElementAt(j).Pos[1] != Pos[1] && Lista_Fichas.ElementAt(j).Pos[1]<Pos_pieza[1])
                    {
                        Pos_pieza[0] = Lista_Fichas.ElementAt(j).Pos[0];
                        Pos_pieza[1] = Lista_Fichas.ElementAt(j).Pos[1];
                        hay_pieza = true;
                        break;
                    }
                }
            }
            if (hay_pieza)
            {
                for (int i = Pos[0] + 1; i < Pos_pieza[0]; i++)
                {
                    Pos_ataque_fatal[0] = i;
                    Pos_ataque_fatal[1] = Pos[1];
                    Ataques_Fatales.Add(Pos_ataque_fatal);
                }
            }
            else 
            {
                for (int i = Pos[0] + 1; i < 8; i++)
                {
                    Pos_ataque_fatal[0] = i;
                    Pos_ataque_fatal[1] = Pos[1];
                    Ataques_Fatales.Add(Pos_ataque_fatal);
                }

            }

            // ahora hacemos desde la posicion de la torre a la izquierda
            Pos_pieza[0]=-1;
            Pos_pieza[1]=-1;
            hay_pieza = false;
            for (int i = Pos[0]-1; i > -1 ; i--) //ataca toda la fila fijarse si [0] es fila o columna 
            {

                for (int j=0; j<Lista_Fichas.Count; j++)
                {

                    
                    if (Lista_Fichas.ElementAt(j).Pos[0] == Pos[0] && Lista_Fichas.ElementAt(j).Pos[1] != Pos[1] && Lista_Fichas.ElementAt(j).Pos[1]>Pos_pieza[1])
                    {
                        Pos_pieza[0] = Lista_Fichas.ElementAt(j).Pos[0];
                        Pos_pieza[1] = Lista_Fichas.ElementAt(j).Pos[1];
                        hay_pieza = true;
                           break;
                    }
                }
            }

           

            if (hay_pieza)
            {
                for (int i = Pos[0] - 1; i > Pos_pieza[0]; i--)
                {
                        Pos_ataque_fatal[0] = i;
                        Pos_ataque_fatal[1] = Pos_pieza[1];
                        Ataques_Fatales.Add(Pos_ataque_fatal);
                }
            }
            else
            {
                for (int i = Pos[0] - 1; i > -1; i--)
                {
                        Pos_ataque_fatal[0] = i;
                        Pos_ataque_fatal[1] = Pos[1];
                        Ataques_Fatales.Add(Pos_ataque_fatal);


                }

            }

            ////////////////////////////////////////////////////////
            // ahora las columnas
            Pos_pieza[0]=Pos[0];
            Pos_pieza[1] = Pos[1];
            hay_pieza = false;
            for (int i = Pos[1]+1; i < 8 ; i++) //ataca toda la fila fijarse si [0] es fila o columna 
            {

                 for (int j=0; j<Lista_Fichas.Count; j++)
                 {

                    
                    if (Lista_Fichas.ElementAt(j).Pos[0] == Pos[1] && Lista_Fichas.ElementAt(j).Pos[0]<Pos_pieza[0])
                    {
                        hay_pieza =true;
                        Pos_pieza[0] = Lista_Fichas.ElementAt(j).Pos[0];
                        Pos_pieza[1] = Lista_Fichas.ElementAt(j).Pos[1];
                        break;
                    }
                   }
            }
            if (hay_pieza)
            {
                for (int i = Pos[1] + 1; i < Pos_pieza[1]; i++)
                {
                    Pos_ataque_fatal[1] = i;
                    Pos_ataque_fatal[0] = Pos[0];
                    Ataques_Fatales.Add(Pos_ataque_fatal);
                }
            }
            else
            {
                for (int i = Pos[1] + 1; i < 8; i++)
                {
                    Pos_ataque_fatal[1] = i;
                    Pos_ataque_fatal[0] = Pos[0];
                    Ataques_Fatales.Add(Pos_ataque_fatal);
                }
            }

            // ahora hacemos desde la posicion de la torre para abajo
            Pos_pieza[0]=Pos[0];
            Pos_pieza[1]=Pos[1];
            hay_pieza = false;
            for (int i = Pos[1]-1; i > -1 ; i--) //ataca toda la fila fijarse si [0] es fila o columna 
            {

                 for (int j=0; j<Lista_Fichas.Count; j++)
                 {

                    Pos_pieza = Lista_Fichas.ElementAt(j).Pos;
                    if (Pos_pieza[1] == Pos[1])
                    {
                        hay_pieza = true;
                        break;
                    }
                 }
            }
            if (hay_pieza)
            {
                for (int i = Pos[1] - 1; i > Pos_pieza[1]; i--)
                {
                    if (i > -1)
                    {
                        Pos_ataque_fatal[1] = i;
                        Pos_ataque_fatal[0] = Pos[0];
                        Ataques_Fatales.Add(Pos_ataque_fatal);

                    }

                }
            }
            else
            {
                for (int i = Pos[1] - 1; i >-1; i--)
                {
                    if (i > -1)
                    {
                        Pos_ataque_fatal[1] = i;
                        Pos_ataque_fatal[0] = Pos[0];
                        Ataques_Fatales.Add(Pos_ataque_fatal);

                    }

                }
            }
            // podemos hacer que retorne la lista d elementos que impiden el ataque fatal 
        }
           
     
        public override void Atacar(Tablero tablero)
        {
            contador_atacadas=0;

            int[] auxpos = new int[2];

            for (int i =0; i < constantes.TAM; i++) //ataca toda la fila
            {
                if (i != Pos[0]) //que no ataque su posicion
                {   
                    tablero.atacadas[i, Pos[1]] = constantes.ATACADA;
                    contador_atacadas= contador_atacadas+1;
                 }
            }

            for (int j = 0; j < constantes.TAM; j++) //ataca toda la columna
            {
                if (j != Pos[1]) //que no ataque su posicion
                  {  tablero.atacadas[Pos[0], j] = constantes.ATACADA;
                    contador_atacadas= contador_atacadas+1;
            } }
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
            contador_atacadas= 0;
        }
        
        public Caballo()
        {
            nombre = constantes.CABALLO;
            Pos[0] = -1;
            Pos[1] = -1;
            contador_atacadas= 0;
        }

        public Caballo(Pieza otra)
        {
            this.nombre = otra.nombre;
            Pos[0] = otra.Pos[0];
            Pos[1] = otra.Pos[1];
            for (int i = 0; i < otra.Pos_Atacadas.Count(); i++)
                this.Pos_Atacadas.Add(otra.Pos_Atacadas.ElementAt(i));
        }

        public override void Ataque_Fatal(List<Pieza> Lista_Fichas)
        {
            // pasa por parametro una lista posiciones donde se sabe que hay piezas
            // para fijarme uee  ninguna se entrometa en el camino del ataque  (en caso de que lo haga es un ataque leve)
            // todos los ataques del caballo son fatales
            int[] auxpos = new int[2];

            if (Pos[0] + 2 < constantes.TAM && Pos[1] + 1 < constantes.TAM)
            {
                auxpos[0] = Pos[0] + 2;
                auxpos[1] = Pos[1] + 1;
                Ataques_Fatales.Add(auxpos);
            }

            if (Pos[0] + 2 < constantes.TAM && Pos[1] - 1 > 0)
            {
               
                auxpos[0] = Pos[0] + 2;
                auxpos[1] = Pos[1] - 1;
                Ataques_Fatales.Add(auxpos);
            }

            if (Pos[0] - 2 > 0 && Pos[1] + 1 < constantes.TAM)
            {
  
                auxpos[0] = Pos[0] - 2;
                auxpos[1] = Pos[1] + 1;
                Ataques_Fatales.Add(auxpos);
            }

            if (Pos[0] - 2 > 0 && Pos[1] - 1 > 0)
            {
                auxpos[0] = Pos[0] - 2;
                auxpos[1] = Pos[1] - 1;
                Ataques_Fatales.Add(auxpos);
            }
            if (Pos[0] + 1 < constantes.TAM && Pos[1] + 2 < constantes.TAM)
            {
                auxpos[0] = Pos[0] + 1;
                auxpos[1] = Pos[1] + 2;
                Ataques_Fatales.Add(auxpos);
            }
            if (Pos[0] - 1 > 0 && Pos[1] + 2 < constantes.TAM)
            {
                auxpos[0] = Pos[0] - 1;
                auxpos[1] = Pos[1] + 2;
                Ataques_Fatales.Add(auxpos);
            }
            if (Pos[0] + 1 < constantes.TAM && Pos[1] - 2 > 0)
            {
             
                auxpos[0] = Pos[0] + 1;
                auxpos[1] = Pos[1] - 2;
                Ataques_Fatales.Add(auxpos);
            }
            if (Pos[0] - 1 > 0 && Pos[1] - 2 > 0)
            {
                auxpos[0] = Pos[0] - 1;
                auxpos[1] = Pos[1] - 2;
                Ataques_Fatales.Add(auxpos);
            }


            return;           
                
         }
        public override void Atacar (Tablero tablero)
        {
            contador_atacadas=0;
            int[] auxpos = new int[2];
  
            if(Pos[0] + 2 < constantes.TAM && Pos[1] + 1 < constantes.TAM )
            {
                tablero.atacadas[Pos[0] + 2, Pos[1] + 1] = constantes.ATACADA;
                contador_atacadas= contador_atacadas+1;
                auxpos[0]=Pos[0] + 2;
                auxpos[1]=Pos[1] + 1;
                Ataques_Fatales.Add(auxpos);
             }

            if (Pos[0] + 2 < constantes.TAM && Pos[1] - 1 > 0)
            { 
                tablero.atacadas[Pos[0] + 2, Pos[1] - 1] = constantes.ATACADA;
                contador_atacadas= contador_atacadas+1;
                auxpos[0]=Pos[0] + 2;
                auxpos[1]=Pos[1] - 1;
                Ataques_Fatales.Add(auxpos);
            }
            
            if (Pos[0] - 2 >0 && Pos[1] + 1 < constantes.TAM)
            {    tablero.atacadas[Pos[0] - 2, Pos[1] + 1] = constantes.ATACADA;
                contador_atacadas= contador_atacadas+1;
                auxpos[0]=Pos[0] - 2;
                auxpos[1]=Pos[1] + 1;
                Ataques_Fatales.Add(auxpos);
            }            
           
            if(Pos[0] - 2 >0 && Pos[1] - 1 >0)
            {
                tablero.atacadas[Pos[0] - 2, Pos[1] - 1] = constantes.ATACADA;
                contador_atacadas= contador_atacadas+1;
                auxpos[0]=Pos[0] - 2;
                auxpos[1]=Pos[1] - 1;
                Ataques_Fatales.Add(auxpos);
            }
            if (Pos[0] + 1 < constantes.TAM && Pos[1] + 2 < constantes.TAM)
            {   
                tablero.atacadas[Pos[0] + 1, Pos[1] + 2] = constantes.ATACADA;
                contador_atacadas= contador_atacadas+1;
                auxpos[0]=Pos[0] + 1;
                auxpos[1]=Pos[1] + 2;
                Ataques_Fatales.Add(auxpos);
            }
            if (Pos[0] - 1 >0 && Pos[1] + 2 < constantes.TAM )
            {
                tablero.atacadas[Pos[0] - 1, Pos[1] + 2] = constantes.ATACADA;
                contador_atacadas= contador_atacadas+1;
                auxpos[0]=Pos[0] -1 ;
                auxpos[1]=Pos[1] + 2;
                Ataques_Fatales.Add(auxpos);
            }
            if (Pos[0] + 1 < constantes.TAM && Pos[1] - 2 > 0)
            {
                tablero.atacadas[Pos[0] + 1, Pos[1] - 2] = constantes.ATACADA;
                contador_atacadas= contador_atacadas+1;
                auxpos[0]=Pos[0] + 1;
                auxpos[1]=Pos[1] -2;
                Ataques_Fatales.Add(auxpos);
            }
            if (Pos[0] - 1 >0 && Pos[1] - 2 >0 )
            {
                tablero.atacadas[Pos[0] - 1, Pos[1] - 2] = constantes.ATACADA;
                contador_atacadas= contador_atacadas+1;
                auxpos[0]=Pos[0] - 1;
                auxpos[1]=Pos[1] -2;
                Ataques_Fatales.Add(auxpos);
            }
           
        }
    }

    public class Alfil : Pieza
    {
        public Alfil(int[] pos)
        {
            nombre = constantes.ALFIL;
            Pos[0] = pos[0];
            Pos[1] = pos[1];
             contador_atacadas= 0;
        }
        
        public Alfil()
        {
            nombre = constantes.ALFIL;
            Pos[0] = -1;
            Pos[1] = -1;
            contador_atacadas=0;
        }

        public Alfil(Pieza otra)
        {
            this.nombre = constantes.ALFIL;
            Pos[0] = otra.Pos[0];
            Pos[1] = otra.Pos[1];
            for (int i = 0; i < otra.Pos_Atacadas.Count(); i++)
                this.Pos_Atacadas.Add(otra.Pos_Atacadas.ElementAt(i));

            contador_atacadas=0;
        }
        public override void Ataque_Fatal(List<Pieza> Lista_Fichas)
        { 
        }
    /*
         public override List<int[]> Ataque_Fatal(List<int[]> Lista_Fichas)
        {

            // pasa por parametro una lista posiciones donde se sabe que hay piezas
            // para fijarme uee  ninguna se entrometa en el camino del ataque  (en caso de que lo haga es un ataque leve)
            int[] pos_Alfil = this.Pos;
            int[] ataque;
            int[]  auxpos;
           
               return ataques_fatales;
        
            }*/


        public override void Atacar(Tablero tablero)
        {    contador_atacadas=0;
             int[] auxpos = new int[2];
            for(int i = 1; i < constantes.TAM; i++)//desde 1 porque con 0 atacaria su posicion
            { 
                //el alfil ataca en diagonal entonces sumo o resto lo mismo a la fila y la columa

                if (Pos[0] + i < constantes.TAM && Pos[1] - i >= 0) //chequeo que no se pase del tablero
                {   
                    if(Pos[0] + i < 8 && Pos[1] - i > 0)
                   { tablero.atacadas[Pos[0] + i, Pos[1] - i] = constantes.ATACADA;
                    contador_atacadas= contador_atacadas+1;
                        }/*auxpos[0]=Pos[0] + i;
                    auxpos[1]= Pos[1] - i;
                    Pos_Atacadas.Add(auxpos);*/
                }
               
                if (Pos[0] - i >=0 && Pos[1] + i < constantes.TAM) 
                {   
                    if(Pos[0] - i>0 && Pos[1] + i < 8)
                    { tablero.atacadas[Pos[0] - i, Pos[1] + i] = constantes.ATACADA;
                     contador_atacadas= contador_atacadas+1;
                    }/*auxpos[0]=Pos[0] - i;
                    auxpos[1]= Pos[1] + i;
                    Pos_Atacadas.Add(auxpos);*/
                }
               
                if(Pos[0] + i < constantes.TAM && Pos[1] + i < constantes.TAM)
                { 
                    if(Pos[0] + i<8 && Pos[1] + i<8)
                   { tablero.atacadas[Pos[0] + i, Pos[1] + i] = constantes.ATACADA;
                    contador_atacadas= contador_atacadas+1;
                    }/* auxpos[0]=Pos[0] + i;
                    auxpos[1]=  Pos[1] + i;
                    Pos_Atacadas.Add(auxpos);      */         
                }
               
                if (Pos[0] - i >= 0 && Pos[1] - i >= 0)
                {
                    if(Pos[0] - i>0 && Pos[1] - i>0)
                    {tablero.atacadas[Pos[0] - i, Pos[1] - i] = constantes.ATACADA;
                   contador_atacadas= contador_atacadas+1;
                        }/* auxpos[0]=Pos[0] - i;
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
            contador_atacadas=0;
        }
       
        public Rey()
        {
            nombre = constantes.REY;
            Pos[0] = -1;
            Pos[1] = -1;
            contador_atacadas=0;

        }

        public Rey(Pieza otra)
        {
            this.nombre = otra.nombre;
            Pos[0] = otra.Pos[0];
            Pos[1] = otra.Pos[1];
            for (int i = 0; i < otra.Pos_Atacadas.Count(); i++)
                this.Pos_Atacadas.Add(otra.Pos_Atacadas.ElementAt(i));

            contador_atacadas=0;
        }

        public override void Ataque_Fatal(List<Pieza> Lista_Fichas)
        {
        }
        /*   public override List<int[]> Ataque_Fatal(List<int[]> Lista_Fichas)
        {

            // pasa por parametro una lista posiciones donde se sabe que hay piezas
            // para fijarme uee  ninguna se entrometa en el camino del ataque  (en caso de que lo haga es un ataque leve)
            // todos los ataques del rey son fatales

            
          
            
            return ataques_fatales;
            
                
         }*/
        public override void Atacar(Tablero tablero)
        {  int[] auxpos = new int[2];
            for(int i=-1; i<2; i++)
            {
                for(int j=-1; j<2; j++)
                {
                    if(!(i==0 && j==0) && Pos[0]+i<8 && Pos[0]+i>=0 && Pos[1] + j < 8 && Pos[1] + j >= 0)//que no ataque su posicion
                    {
                        tablero.atacadas[Pos[0] + i, Pos[1] + j] = constantes.ATACADA;
                        contador_atacadas=contador_atacadas+1;
                      /*   auxpos[0]=Pos[0] + i;
                         auxpos[1]= Pos[1] + j;
                         
                         Ataques_Fatales.Add(auxpos);                   */
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
            contador_atacadas=0;
        }
       
        public Reina()
        {
            nombre = constantes.REINA;
            Pos[0] = -1;
            Pos[1] = -1;
            contador_atacadas=0;
        }

        public Reina(Pieza otra)
        {
            this.nombre = otra.nombre;
            Pos[0] = otra.Pos[0];
            Pos[1] = otra.Pos[1];
            for (int i = 0; i < otra.Pos_Atacadas.Count(); i++)
                this.Pos_Atacadas.Add(otra.Pos_Atacadas.ElementAt(i));
            contador_atacadas=0;
        }
        public override void Ataque_Fatal(List<Pieza> Lista_Fichas)
        { 
        }
        /*
         public override List<int[]> Ataque_Fatal(List<int[]> Lista_Fichas)
         {
             List<int[]> ataques_fatales=0;



             return ataques_fatales;




          }*/
        public override void Atacar(Tablero tablero)
        {   int[] auxpos = new int[2];
            //ataque alfil + ataque torre
            contador_atacadas=0;
            //ALFIL
            for (int i = 1; i < constantes.TAM; i++)//desde 1 porque con 0 atacaria su posicion
            {
                //el alfil ataca en diagonal entonces sumo o resto lo mismo a la fila y la columa

                if (Pos[0] + i < constantes.TAM && Pos[1] - i >= 0) //chequeo que no se pase del tablero
                {   tablero.atacadas[Pos[0] + i, Pos[1] - i] = constantes.ATACADA;
                    contador_atacadas=contador_atacadas+1;
                    /*auxpos[0]=Pos[0] + i;
                    auxpos[1]= Pos[1] - i;
                    Pos_Atacadas.Add(auxpos);*/
                }
               
                if (Pos[0] - i >=0 && Pos[1] + i < constantes.TAM) 
                {   
                    tablero.atacadas[Pos[0] - i, Pos[1] + i] = constantes.ATACADA;
                    contador_atacadas= contador_atacadas+1;
                    /*auxpos[0]=Pos[0] - i;
                    auxpos[1]= Pos[1] + i;
                    Pos_Atacadas.Add(auxpos);*/

                }
               
                if(Pos[0] + i < constantes.TAM && Pos[1] + i < constantes.TAM)
                   { 
                    tablero.atacadas[Pos[0] + i, Pos[1] + i] = constantes.ATACADA;
                    contador_atacadas= contador_atacadas+1;
                    /*auxpos[0]=Pos[0] + i;
                    auxpos[1]=  Pos[1] + i;
                    Pos_Atacadas.Add(auxpos);*/
                
                }
               
                if (Pos[0] - i >= 0 && Pos[1] - i >= 0)
                    {tablero.atacadas[Pos[0] - i, Pos[1] - i] = constantes.ATACADA;
                    contador_atacadas= contador_atacadas+1;
                    /*auxpos[0]=Pos[0] - i;
                    auxpos[1]= Pos[1] - i;
                    Pos_Atacadas.Add(auxpos);*/
                    }
            }

            //TORRE
            for (int i = 0; i < constantes.TAM; i++) //ataca toda la fila
            {
                if (i != Pos[0] && Pos[0]<8 && Pos[0]>=0) //que no ataque su posicion
               {     tablero.atacadas[i, Pos[1]] = constantes.ATACADA;
                    contador_atacadas=contador_atacadas+1;
                 /* auxpos[0]=i;
                    auxpos[1]= Pos[1];
                    Pos_Atacadas.Add(auxpos); */}
            }
            for (int j = 0; j < constantes.TAM; j++) //ataca toda la columna
            {
                if (j != Pos[1] && Pos[1]<8 && Pos[1]>=0) //que no ataque su posicion
                   { tablero.atacadas[Pos[0], j] = constantes.ATACADA;
                    contador_atacadas=contador_atacadas+1;
                    /*auxpos[0]=Pos[0];
                    auxpos[1]= j;
                    Pos_Atacadas.Add(auxpos);*/ }
            }
        }
    }

}