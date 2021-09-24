using System;
using System.Collections.Generic;

namespace Voraz
{
    class Program
    {
        /*
        * VARIABLES PARA USO DEL ALGORITMO DE MONEDA UNICAMENTE        
        */
        static int[] deno = { 1, 2, 5, 10, 20 };
        static int n = deno.Length;

        static void Main()
        {
            /*
             * AQUI COMIENZA EL PROGRAMA
             * Se puede ejecutar el algoritmo 1 y el algorimot 3 o comentarias alguno para ver algo en especifico
             * 
             * 
             */
            EjecucionAlgoritmo1();
            EjecucionAlgoritmo3();
        }

        static void EjecucionAlgoritmo1()
        {
            /*             
             * Se define el valor que se usara en monedas
             * Ademas se define la salida y ejecución del algoritmo             
             */

            int n = 36;
            Console.Write("\n ***** ALGORITMO EJEMPLO 1 *****");
            Console.Write(" -- Las monedas para el valor " + n + " es: ");
            BuscarCambioMoneda(n);
            Console.Write("\n");
        }

        static void EjecucionAlgoritmo3()
        {
            /*             
             * Se define el valor que se usara en el algoritmo de letras
             * Ademas se define la salida y ejecución del algoritmo        
             */

            string texto = "ABAABCB";
            Console.Write("\n ***** ALGORITMO EJEMPLO 3 *****");            
            Console.Write(" -- El texto lexograficamente mayor para " + texto + " es: ");            
            BuscarLetras(texto.ToUpper());
            Console.Write("\n");
        }

        public static void BuscarCambioMoneda(int V)
        {
            /*             
             * Codigo para ejecutar las monedas que se usaran dependiendo del valor que se ingrese
             */
            
            List<int> resp = new List<int>();//Se crea la lista que se va a actualizar para mostrar

            for (int i = n - 1; i >= 0; i--)//Se recorre las posibles monedas, con el fin de mirar de mayor a menor si aplica para dar el cambio
            {                
                while (V >= deno[i])//Valida si el valor actual es mayor o igual que la moneda actual para asignar la moneda al cambio
                {
                    V -= deno[i];//Como la moneda aplica al cambio se le resta el valor de la moneda al valor actual del valor solicitado, asi se va modificando el valor
                    resp.Add(deno[i]);//Se agrega a la lista de monedas de cambio
                }
            }

            //Codigo que muestra la lista ya con el cambio total
            for (int i = 0; i < resp.Count; i++)
            {
                Console.Write(" " + resp[i]);
            }
        }

        public static void BuscarLetras(string texto)
        {

            List<string> resp = new List<string>();//Lista que se muestra al final ya que convierte los numeros en letras
            List<int> textoNum = new List<int>();//Lista que va a tener el texto original en numeros
            List<int> textNumOrdenada = new List<int>();//Lista que se va a ordenar en el proceso, queda en numeros
            
            textoNum = ConvertirToNumero(texto);//Se transforma el texto en una lista de numeros

            while (textoNum.Count != textNumOrdenada.Count)//Valida que la lista original no sea igual a la lista que se esta ordenando, así termina el ciclo cuando la lista este completamente ordenada
            {
                for (int i = 0; i < textoNum.Count; i++)//Recorre la lista de numeros
                {
                    if (i != 0)//Valida que no sea el primer ciclo, ya que si lo es solamente agrega el valor actual a la lista sin validar nada 
                    {
                        var menorLista = textNumOrdenada[0];//Obtiene el valor de la izquierda de la lista para asi poder compararlo con los otros

                        if (textoNum[i] >= menorLista)//Valida que el numero actual no sea mayor o igual que el valor de la izquierda, esto valida si el numero se tiene que agregar a la derecha o la izquierda de la lista
                        {
                            for (int j = textNumOrdenada.Count - 1; j  != -1; j--)//Esto se utiliza para correr toda la lista a la derecha y así asignar el valor actual a la parte izquierda de la lista
                            {
                                //j = 0
                                if (j == textNumOrdenada.Count - 1)
                                {
                                    textNumOrdenada.Add(textNumOrdenada[j]);
                                }
                                else
                                {
                                    textNumOrdenada[j + 1] = textNumOrdenada[j];
                                }                                
                            }
                            textNumOrdenada[0] = textoNum[i];//Aca se agrega a la parte izquierda
                        }
                        else
                        {
                            textNumOrdenada.Add(textoNum[i]);
                        }
                    }
                    else
                    {
                        textNumOrdenada.Add(textoNum[i]);
                    }
                }
            }

            resp = ConvertirToLetra(textNumOrdenada);//Acá vuelve y convierte la lista a letras para poder mostrarla
            
            for (int i = 0; i < resp.Count; i++)//Luego solo la imprime
            {
                Console.Write(resp[i]);
            }
        }

        public static List<int> ConvertirToNumero(string texto)
        {
            List<int> resp = new List<int>();
            for (int i = 0; i < texto.Length; i++)
            {
                if (Char.IsLetter(Convert.ToChar(texto[i])))
                {
                    switch (texto[i])
                    {
                        case 'A':
                            resp.Add(1);
                            break;
                        case 'B':
                            resp.Add(2);
                            break;
                        case 'C':
                            resp.Add(3);
                            break;
                        case 'D':
                            resp.Add(4);
                            break;
                    }
                }
            }
            return resp;
        }

        public static List<string> ConvertirToLetra(List<int> num)
        {
            List<string> resp = new List<string>();

            for (int i = 0; i < num.Count; i++)
            {
                switch (num[i])
                {
                    case 1:
                        resp.Add("A");
                        break;
                    case 2:
                        resp.Add("B");
                        break;
                    case 3:
                        resp.Add("C");
                        break;
                    case 4:
                        resp.Add("D");
                        break;
                }
            }
            return resp;
        }
    }
}
