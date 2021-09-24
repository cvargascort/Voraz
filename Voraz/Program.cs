using System;
using System.Collections.Generic;

namespace Voraz
{
    class Program
    {
        static int[] deno = { 20, 10, 5, 2, 1 };

        static int n = deno.Length;

        static void Main()
        {
            int n = 36;
            Console.Write("La menor cantidad de monedas para el valor " + n + " es: ");

            BuscarCambio(n);
        }

        public static void BuscarCambio(int valor)
        {
            int valorTemp = valor;
            List<int> resp = new List<int>();            
            int indiceInicio = n - 1;
            int contador = 0;
            int i = 0;
            while (contador != 3)
            {
                List<int> respTemp = new List<int>();
                valor = valorTemp;
                for (i = contador; i <= indiceInicio; i++)
                {                    
                    // Buscar denominacion
                    while (valor >= deno[i])
                    {
                        valor -= deno[i];
                        respTemp.Add(deno[i]);
                    }
                }

                indiceInicio = indiceInicio - 1;
                contador = contador + 1;

                if (resp.Count == 0)
                {
                    resp = respTemp;
                }
                else if (resp.Count > respTemp.Count && respTemp.Count != 0)
                {
                    resp = respTemp;
                }
                /*
                for (int respT = 0; respT < respTemp.Count; respT++)
                {
                    respTemp.RemoveAt(respT);
                }*/
                
            }
            
            // Print result
            for (i = 0; i < resp.Count; i++)
            {
                Console.Write(" " + resp[i]);
            }

        }

    }
}
