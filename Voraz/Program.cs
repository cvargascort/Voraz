using System;
using System.Collections.Generic;

namespace Voraz
{
    class Program
    {
        static int[] deno = { 1, 2, 5, 10, 20 };
        static int n = deno.Length;

        static void Main()
        {
            /*
             * AQUI COMIENZA EL PROGRAMA
             * Se puede ejecutar el algoritmo 1 o el algoritmo 3 dependiendo cual se descomentaree
             * 
             * 
             */

            EjecucionAlgoritmo1();
            EjecucionAlgoritmo3();
        }

        static void EjecucionAlgoritmo1()
        {
            int n = 36;
            Console.Write("\n ***** ALGORITMO EJEMPLO 1 *****");
            Console.Write(" -- Las monedas para el valor " + n + " es: ");            
            BuscarCambioMoneda(n);
            Console.Write("\n");
        }

        static void EjecucionAlgoritmo3()
        {
            string texto = "ABAABCB";
            Console.Write("\n ***** ALGORITMO EJEMPLO 3 *****");            
            Console.Write(" -- El texto lexograficamente mayor para " + texto + " es: ");            
            BuscarLetras(texto.ToUpper());
            Console.Write("\n");
        }

        public static void BuscarCambioMoneda(int V)
        {
            List<int> resp = new List<int>();

            // Traverse through all denomination
            for (int i = n - 1; i >= 0; i--)
            {
                // Find denominations
                while (V >= deno[i])
                {
                    V -= deno[i];
                    resp.Add(deno[i]);
                }                
            }

            // Print result
            for (int i = 0; i < resp.Count; i++)
            {
                Console.Write(" " + resp[i]);
            }
        }

        public static void BuscarLetras(string texto)
        {
            List<string> resp = new List<string>();
            List<int> textoNum = new List<int>();
            List<int> textNumOrdenada = new List<int>();
            
            textoNum = ConvertirToNumero(texto);

            while (textoNum.Count != textNumOrdenada.Count)
            {
                for (int i = 0; i < textoNum.Count; i++)
                {
                    if (i != 0)
                    {
                        var menorLista = textNumOrdenada[0];

                        if (textoNum[i] >= menorLista)
                        {
                            for (int j = textNumOrdenada.Count - 1; j  != -1; j--)
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
                            textNumOrdenada[0] = textoNum[i];
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

            resp = ConvertirToLetra(textNumOrdenada);

            // Print result
            for (int i = 0; i < resp.Count; i++)
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
