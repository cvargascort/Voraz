using System;
using System.Collections.Generic;

namespace Voraz
{
    class Program
    {
        static int[] deno = { 5, 10, 20, 25 };

        static int n = deno.Length;

        static void Main()
        {
            int n = 40;
            Console.Write("La menor cantidad de monedas para el valor " + n + " es: ");

            BuscarCambio(n);
        }

        public static void BuscarCambio(int V)
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

    }
}
