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
            // seteo la primer solucion ¿mediante una funcion?

            bool[,] atacadas_= new bool[8, 8];
            for (int n = 0; n < constantes.TAM; n++)
            {
                for (int m = 0; m < constantes.TAM; m++)
                {
                    atacadas_[n, m] = constantes.ATACADA;
             
                }
            }
            List<Pieza> piezas_= new List<Pieza>(); ;
            int[] Pos = new int[2];
            Rey rey0= new Rey();
            Pos[0]=5;
            Pos[1]=6;
            rey0.set_pos(Pos);
            piezas_.Add(rey0);
            Caballo caballo0= new Caballo();
            Pos[0]=3;
            Pos[1]=1;
            caballo0.set_pos(Pos);
            piezas_.Add(caballo0);
            Caballo caballo01= new Caballo();
            Pos[0]=3;
            Pos[1]=2;
            caballo01.set_pos(Pos);
            piezas_.Add(caballo01);
            Alfil alfil0= new Alfil();
            Pos[0]=4;
            Pos[1]=1;
            alfil0.set_pos(Pos);
            piezas_.Add(alfil0);
            Alfil alfil01= new Alfil();
            Pos[0]=1;
            Pos[1]=5;
            alfil01.set_pos(Pos);
            piezas_.Add(alfil01);
            Torre torre0= new Torre();
            Pos[0]=7;
            Pos[1]=1;
            torre0.set_pos(Pos);
            piezas_.Add(torre0);
            Torre torre01= new Torre();
            Pos[0]=0;
            Pos[1]=4;
            torre01.set_pos(Pos);
            piezas_.Add(torre01);
            Reina reina0= new Reina();
            Pos[0]=2;
            Pos[1]=6;
            reina0.set_pos(Pos);
            piezas_.Add(reina0);

            Tablero Solucion_cero = new Tablero(atacadas_, piezas_);

            soluciones.Add(Solucion_cero);
            if (soluciones.Count() < cant_solucionesUpDown.Value)
            {
                    soluciones.Add(Espejar_x(Solucion_cero));
            }
            if (soluciones.Count() < cant_solucionesUpDown.Value)
            {
                    soluciones.Add(Espejar_y(Solucion_cero));
            }
            if (soluciones.Count() < cant_solucionesUpDown.Value)
            {
                    soluciones.Add(Espejar_y(Espejar_x(Solucion_cero)));
            }
            if (soluciones.Count() < cant_solucionesUpDown.Value)
            {
                soluciones.Add(Espejar_diagonal1(Solucion_cero));
            }
            
            if (soluciones.Count() < cant_solucionesUpDown.Value)
            {
                soluciones.Add(Espejar_diagonal2(Solucion_cero));
            }

            while (soluciones.Count() < cant_solucionesUpDown.Value)
            {
                Tablero solucion = new Tablero(true);
                buscar_solucion(solucion); // la funcion que recibe el tablero y hace todo el random para encontrar una solucion
                
                if (!soluciones.Contains(solucion) && !Solucion_Ya_Creada(soluciones, solucion))//chequear que no este ya en la lista para que no se repitan
                {
                    soluciones.Add(solucion);
                    
                    //si encuentra una solucion que agregue la solucion espejada para reducir el tiempo
                    if (soluciones.Count() < cant_solucionesUpDown.Value)
                    {
                        soluciones.Add(Espejar_x(solucion));
                    }
                    if (soluciones.Count() < cant_solucionesUpDown.Value)
                    {
                        soluciones.Add(Espejar_y(solucion));
                    }
                    if (soluciones.Count() < cant_solucionesUpDown.Value)
                    {
                        soluciones.Add(Espejar_y(Espejar_x(solucion)));
                    }
                    if (soluciones.Count() < cant_solucionesUpDown.Value)
                    {
                        soluciones.Add(Espejar_diagonal1(solucion));
                    }
                    if (soluciones.Count() < cant_solucionesUpDown.Value)
                    {
                        soluciones.Add(Espejar_diagonal2(solucion));
                    }

                }           

            }
            
            Form form_datagrid = new form_datagrid(soluciones);
            form_datagrid.Show();                            
            
        }

        public void buscar_solucion(Tablero tablero)
        {
            Pieza pieza_mover;
            int[] nueva_pos;
            do
            {
                pieza_mover = tablero.pieza_rnd(); //elijo una pieza aleatoria
                nueva_pos = tablero.posible_mover(pieza_mover); //devuelve una pos random donde podria moverse la pieza
                       
                if (cant_atacadas(tablero, pieza_mover, pieza_mover.Pos) <= cant_atacadas(tablero, pieza_mover, nueva_pos))
                { //si en la nueva posicion quedan menos casillas sin atacar cambio la posicion
                    tablero.mover(pieza_mover, nueva_pos);                 
                }                

            } while (!tablero.atacadas_todas());


        }


        // cantidad de atacadas por ficha compara el contador de atacadas de la ficha y de la ficha en otra posi
        // devuelve true si ataca mas y false si ataca menos

        public bool atacadas_por_ficha(Pieza pieza, int[] nueva_pos)
        {

            Tablero tablero_aux = new Tablero(); // tablero con piezas sin seteat

            if (pieza is Caballo)
            {    
                Caballo pieza_aux= new Caballo();
                tablero_aux.setear_pieza(pieza_aux);
                tablero_aux.mover(pieza_aux, nueva_pos);
                if(pieza_aux.contador_atacadas>pieza.contador_atacadas)
                    return true;
            }
            if(pieza is Reina )
            { 
                Reina pieza_aux= new Reina();
                 tablero_aux.setear_pieza(pieza_aux);
            tablero_aux.mover(pieza_aux, nueva_pos);
                 if(pieza_aux.contador_atacadas>pieza.contador_atacadas)
                return true;
            
            
            }
            if(pieza is Alfil)
               { Alfil pieza_aux= new Alfil();
            
             tablero_aux.setear_pieza(pieza_aux);
            tablero_aux.mover(pieza_aux, nueva_pos);
                 if(pieza_aux.contador_atacadas>pieza.contador_atacadas)
                return true;
            }
           if(pieza is Rey)
            {    Rey pieza_aux= new Rey();
                 tablero_aux.setear_pieza(pieza_aux);
            tablero_aux.mover(pieza_aux, nueva_pos);
                 if(pieza_aux.contador_atacadas>pieza.contador_atacadas)
                return true;
                }
           

            return false;
        }

        //Calcula la cantidad de posiciones que ataca una pieza, que no estan siendo atacadas por otras
        public static int cant_atacadas(Tablero tablero, Pieza pieza, int[] pos)
        {//necesitamos un tablero con todas las piezas menos esta.
            int cont_sin = 0; //contador si la pieza no estuviera
            int cont_con = 0; //contador con la pieza

            Pieza pieza_temp = null;
            if (pieza is Torre)
                pieza_temp = new Torre(pos);
            else if (pieza is Alfil)
                pieza_temp = new Alfil(pos);
            else if (pieza is Caballo)
                pieza_temp = new Caballo(pos);
            else if (pieza is Reina)
                pieza_temp = new Reina(pos);
            else if (pieza is Rey)
                pieza_temp = new Rey(pos);
            //pieza_temp esta en la nueva posicion posible

            Tablero tab_sinPieza = new Tablero(tablero);
            tab_sinPieza.sacar(pieza); //creo un tablero como el anterior pero sin esa pieza
            Tablero tab_nuevaPos = new Tablero(tab_sinPieza);
            tab_nuevaPos.setear_pieza(pieza_temp); //tablero con la pieza en la nueva posicion           

            for (int i = 0; i < constantes.TAM; i++)
            {
                for (int k = 0; k < constantes.TAM; k++)
                {
                    if (tab_sinPieza.atacadas[i, k] == constantes.NO_ATACADA)
                        cont_sin++; //cuento las casillas que no estan siendo atacadas si la pieza no estuviera
                    if (tab_nuevaPos.atacadas[i, k] == constantes.NO_ATACADA)
                        cont_con++; //cuento cuantas quedan sin atacar con la pieza en esa posicion
                }
            }

            return cont_sin - cont_con;
        }
        public bool Solucion_Ya_Creada(List<Tablero> soluciones, Tablero solucion) // prueba si la solucion que encontro ya estaba creada pero con torres y alfiles distintos
        {
             Tablero solucion_Alfiles_cambiados = new Tablero(solucion); //que no sea la misma solucion cambiando solo las torres 
             Tablero solucion_Torres_Cambiadas = new Tablero(solucion);  // que no sea la misma solucion cambiando solo alfiles
             Tablero solucion_Torres_Alfiles = new Tablero(solucion);

             int torre1 = -1;
             int torre2 = -1;
             int alfil1 = -1;
             int alfil2 = -1;
            int[] pos = new int[2];
            int[] pos2 = new int[2];

            for (int j = 0; j < solucion.piezas.Count; j++)
             {
                 if (solucion.piezas.ElementAt(j) is Torre && torre1 ==-1)
                     torre1 = j; // guardamos el indice de la pieza que buscamos y que se encuentra en la lista

                 if (solucion.piezas.ElementAt(j) is Torre && torre1 != j)
                     torre2 = j; // guardamos la segunda torre

                 if (solucion.piezas.ElementAt(j) is Alfil && alfil1 == -1)
                     alfil1 = j; // guardamos el indice de la pieza que buscamos y que se encuentra en la lista

                 if (solucion.piezas.ElementAt(j) is Alfil && alfil1 != j)
                     alfil2 = j; // guardamos el segundo alfil que se encuentra en otra posicion

             }
             // las voy a invertir para chequear con la lista de soluciones que no haya sido creada previamente

            // el ataque no se modifica pq es la misma pieza solo se modifica la posicion

            // cambio solo las torres 
            pos[0] = solucion_Torres_Cambiadas.piezas.ElementAt(torre1).Pos[0]; // guardo posicion de torre1 
            pos[1] = solucion_Torres_Cambiadas.piezas.ElementAt(torre1).Pos[1];
            pos2[0] = solucion_Torres_Cambiadas.piezas.ElementAt(torre2).Pos[0]; // guardo posicion de torre1 
            pos2[1] = solucion_Torres_Cambiadas.piezas.ElementAt(torre2).Pos[1];
            solucion_Torres_Cambiadas.mover(solucion_Torres_Cambiadas.piezas.ElementAt(torre1), pos2);
            solucion_Torres_Cambiadas.mover(solucion_Torres_Cambiadas.piezas.ElementAt(torre2), pos);

            if (soluciones.Contains(solucion_Torres_Cambiadas))
                return true; // si la soluccion esta contenida retorna true 

            // cambio solo alfiles
            pos[0] = solucion_Alfiles_cambiados.piezas.ElementAt(alfil1).Pos[0]; // guardo posicion de torre1 
            pos[1] = solucion_Alfiles_cambiados.piezas.ElementAt(alfil1).Pos[1];
           pos2[0] = solucion_Alfiles_cambiados.piezas.ElementAt(alfil2).Pos[0]; // guardo posicion de torre1 
            pos2[1] = solucion_Alfiles_cambiados.piezas.ElementAt(alfil2).Pos[1];
            solucion_Alfiles_cambiados.mover(solucion_Alfiles_cambiados.piezas.ElementAt(alfil1),pos2);
            solucion_Alfiles_cambiados.mover(solucion_Alfiles_cambiados.piezas.ElementAt(alfil2), pos);

            if (soluciones.Contains(solucion_Alfiles_cambiados) == true)
                return true; // si la soluccion esta contenida retorna true 

            //cambio en la solucion ambos alfiles y ambas torres
             pos[0] = solucion_Torres_Alfiles.piezas.ElementAt(torre1).Pos[0]; // guardo posicion de torre1 
             pos[1] = solucion_Torres_Alfiles.piezas.ElementAt(torre1).Pos[1];
            pos2[0] = solucion_Torres_Alfiles.piezas.ElementAt(torre2).Pos[0]; // guardo posicion de torre1 
            pos2[1] = solucion_Torres_Alfiles.piezas.ElementAt(torre2).Pos[1];
            solucion_Torres_Alfiles.mover(solucion_Torres_Alfiles.piezas.ElementAt(torre1), pos2);
             solucion_Torres_Alfiles.mover(solucion_Torres_Alfiles.piezas.ElementAt(torre2), pos);
           
             pos[0] = solucion_Torres_Alfiles.piezas.ElementAt(alfil1).Pos[0]; // guardo posicion de torre1 
             pos[1] = solucion_Torres_Alfiles.piezas.ElementAt(alfil1).Pos[1];
            pos2[0] = solucion_Torres_Alfiles.piezas.ElementAt(alfil2).Pos[0]; // guardo posicion de torre1 
            pos2[1] = solucion_Torres_Alfiles.piezas.ElementAt(alfil2).Pos[1];
            solucion_Torres_Alfiles.mover(solucion_Torres_Alfiles.piezas.ElementAt(alfil1),pos2);
            solucion_Torres_Alfiles.mover(solucion_Torres_Alfiles.piezas.ElementAt(alfil2), pos);


            if (soluciones.Contains(solucion) == true)
                 return true; // si la soluccion esta contenida retorna true 
             
             // no me interesa que la solucion original quede cambiada porque es lo mismo solamente invertimos las tores y alfiles 

             return false; // No esta contenida la solucion
        }

        public Tablero Espejar_x(Tablero original)
        {
            Tablero espejado = new Tablero(original);
            for(int i = 0; i < espejado.piezas.Count; i++)
            {
                espejado.piezas.ElementAt(i).Pos[0] = 7 - espejado.piezas.ElementAt(i).Pos[0];

            }

            return espejado;
        }

        public Tablero Espejar_y(Tablero original)
        {
            Tablero espejado = new Tablero(original);
            for (int i = 0; i < espejado.piezas.Count; i++)
            {
                espejado.piezas.ElementAt(i).Pos[1] = 7 - espejado.piezas.ElementAt(i).Pos[1];

            }

            return espejado;
        }

        public Tablero Espejar_diagonal1(Tablero original)
        {
            Tablero espejado = new Tablero(original);
            for (int i = 0; i < espejado.piezas.Count; i++)
            {
                int temp = 0;
                temp = espejado.piezas.ElementAt(i).Pos[0];
                espejado.piezas.ElementAt(i).Pos[0] = espejado.piezas.ElementAt(i).Pos[1];
                espejado.piezas.ElementAt(i).Pos[1] = temp;

            }

            return espejado;
        }

        public Tablero Espejar_diagonal2(Tablero original)
        {
            Tablero espejado = new Tablero(original);
            for (int i = 0; i < espejado.piezas.Count; i++)
            {
                int temp0 = espejado.piezas.ElementAt(i).Pos[0];
                int temp1 = espejado.piezas.ElementAt(i).Pos[1];
                 espejado.piezas.ElementAt(i).Pos[0] = 7-temp1;
                espejado.piezas.ElementAt(i).Pos[1] = 7 - temp0;

            }

            return espejado;
        }

        private void button_costo_Click(object sender, EventArgs e)
        {
            string titulo = "COSTO DEL ALGORITMO";
            string texto = "Además de depender claramente de  de la cantidad de soluciones que se quieran obtener, el tamaño de la entrada, el costo del argoritmo depende directamente del orden en que se posicionan las piezas aleatoriamente al comenzar el programa." +
                "\n El mejor caso seria que al posicionarse las piezas se encuentre inmediatamente con una solucion y no haga falta hacer ningun movimiento. \n" +
                "En ese caso la cota inferior seria una función constante ya que siempre se van a ejecutar la misma cantidad de instrucciones T(n) = c.1\n"+
                "En el peor de los casos seria necesario probar con todas las piezas en todas sus posiciones posibles hasta llegar a una solucion. \n " +
                "\nPor otro lado, con los criterios de poda que implementamos si se quieren encontrar 4 soluciones el costo seria muy similar al de encontrar una ya que luego de encontrar la primer solucion las siguientes 3 se encuentran espejando esta con un consto muy bajo que no se compara al de la busqueda de las soluciones.";
            MessageBox.Show(texto, titulo, MessageBoxButtons.OK);


        }

        private void poda_btn_Click(object sender, EventArgs e)
        {
            string titulo = "CRITERIOS DE PODA";
            string texto = "Los criterios de poda que aplicamos son los siguientes: \n" +
                "\n- Mantener algunas piezas en areas determinadas del tablero donde es mas posible que generen una solucion.\n" +
                "\n- Limitamos a las torres a puntas opuestas para que cubran todo el borde externo del tablero.\n" +
                "\n- Utilizando la sumetría del tablero, una vez que encuentra una solucion con el método de intercambio se refleja el tablero encontrado en varias direcciones, que se hace muy rapido, para reducir el tiempo del programa.\n " +
                "\n- Los ataques fatales se calculan y se muestran solo si se quiere, apretando el boton 'ataques fatales', una vez encontradas todas las soluciones para no agregarle tiempo en el momento que busca las soluciones";
            MessageBox.Show(texto, titulo, MessageBoxButtons.OK);
        }

        private void btn_1_Click(object sender, EventArgs e)
        {
            cant_solucionesUpDown.Value = 1;
        }

        private void btn_5_Click(object sender, EventArgs e)
        {
            cant_solucionesUpDown.Value = 5;
        }

        private void btn_10_Click(object sender, EventArgs e)
        {
            cant_solucionesUpDown.Value = 10;
        }
    }
}



