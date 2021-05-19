using System;

namespace Farneti.Michele._4H.Levenshtein
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Inserisci le stringhe\r\n");

            string str1 = Console.ReadLine();
            string str2 = Console.ReadLine();

            char[] s = str1.ToCharArray();
            char[] t = str2.ToCharArray();

            //Divstanza di Levenshtein
            int DL=0;

            int n = str1.Length;
            int m = str2.Length;

            //Creo la matrice
            int[,] D = new int[m + 1, n + 1];

            //Controllo i casi in cui una stringa vuota
            if (n == 0)
            {
                DL = m;
            }
            else
            {
                if (m == 0)
                {
                    DL = m;
                }
                else
                {
                    //Valorizzazione preliminare della matrice
                    for(int i = 0; i <= n; i++)
                    {
                        D[0, i] = i;
                    }
                    for (int j = 0; j <= m; j++)
                    {
                        D[j,0] = j;
                    }
                  
                    //Utilizzo l'algoritmo per completare la matrice
                    for (int j = 0; j < m; j++)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            int costo = 0;

                            if (t[j] != s[i])
                            {
                                costo = 1;
                            }

                            int a = D[j, i] + costo;
                            int b = D[j+1, i]+1;
                            int c = D[j, i+1] + 1;                      

                            D[j+1, i+1] = Math.Min(c, Math.Min(a, b));

                            //Stampo la matrice
                            for (int x = 0; x <= m; x++)
                            {
                                for (int y = 0; y <= n; y++)
                                {
                                    Console.Write($"  {D[x, y]}  ");
                                }
                                Console.WriteLine("\r\n");
                            }
                            Console.WriteLine("\r\n");
                            Console.WriteLine("\r\n");

                        }
                    }

                    DL = D[m, n];

                }
            }
    
            Console.WriteLine($"Distanza di Levenshtein: {DL}");
        }
    }
}
