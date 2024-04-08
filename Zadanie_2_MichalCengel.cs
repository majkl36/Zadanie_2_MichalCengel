using System;

namespace Zadanie_2_MichalCengel
{
    public class NespravnyVstupException : Exception
    {
        public NespravnyVstupException() : base() { }
        public NespravnyVstupException(string message) : base(message) { }
        public NespravnyVstupException(string message, Exception innerException) : base(message, innerException) { }
    }
    public class Matica
    {
        public const uint MAX_ROZMER = 10;
        private int[,] data;

        private uint velkostMatice;
        private int minCisloMatice = 0, maxCisloMatice = 10; //Predvolené hodnoty čísel v matici
        public Matica()
        {
            NacitajVstup();
            this.data = new int[velkostMatice, velkostMatice];
            NaplnMaticu(minCisloMatice, maxCisloMatice);
        }
        private void NacitajVstup()
        {
            while (true)
            {
                Console.Write("Zadajte veľkosť n generovanej matice n*n (od 1 do 10): ");
                try
                {
                    if (!uint.TryParse(Console.ReadLine(), out velkostMatice))
                        throw new NespravnyVstupException("Nesprávny formát zadávaného čísla!");
                    if (!(0 < velkostMatice && velkostMatice <= MAX_ROZMER))
                        throw new NespravnyVstupException("Zadané číslo nie je z povoleného rozsahu!");
                }
                catch (NespravnyVstupException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                break;
            }
            string odpoved;
            while (true)
            {
                Console.Write("Predvolené rozsah čísel v matici je od 0 do 10, želáte si to zmeniť? (áno/nie) : ");
                try
                {
                    odpoved = Console.ReadLine();
                    odpoved = odpoved.ToLower();
                    if (!(odpoved.Equals("áno") || odpoved.Equals("nie")))
                        throw new NespravnyVstupException("Odpoveď nerozpoznaná.");
                }
                catch (NespravnyVstupException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                break;
            }
            while (odpoved.Equals("áno"))
            {
                Console.Write("Zadajte spodnú inkluzívnu hranicu (od {0} do {1}: ", int.MinValue, int.MaxValue);
                try
                {
                    if (!int.TryParse(Console.ReadLine(), out minCisloMatice))
                        throw new NespravnyVstupException("Nesprávny formát zadávaného čísla!");
                    if (!(int.MinValue <= minCisloMatice && minCisloMatice <= int.MaxValue))
                        throw new NespravnyVstupException("Zadané číslo nie je z povoleného rozsahu!");
                }
                catch (NespravnyVstupException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                break;
            }
            while (odpoved.Equals("áno"))
            {
                Console.Write("Zadajte hornú inkluzívnu hranicu (od {0} do {1}: ", minCisloMatice, int.MaxValue);
                try
                {
                    if (!int.TryParse(Console.ReadLine(), out maxCisloMatice))
                        throw new NespravnyVstupException("Nesprávny formát zadávaného čísla!");
                    if (!(minCisloMatice <= maxCisloMatice && maxCisloMatice <= int.MaxValue))
                        throw new NespravnyVstupException("Zadané číslo nie je z povoleného rozsahu!");
                }
                catch (NespravnyVstupException ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
                break;
            }
        }
        private void NaplnMaticu(int min, int max)
        {
            Random rand = new Random();
            for (int i = 0; i < this.data.GetLength(0); i++)
                for (int j = 0; j < this.data.GetLength(1); j++)
                    data[i, j] = rand.Next(min, max);
        }
        private long HlavnaDiagonalaSuma()
        {
            long suma = 0;
            for (int i = 0; i < this.data.GetLength(0); i++)
                suma += this.data[i, i];
            return suma;
        }
        private int[,] RotaciaMatice(int[,] aMatica)
        {
            int n = aMatica.GetLength(0);
            int[,] rotovanaMatica = new int[n, n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    rotovanaMatica[j, n - 1 - i] = aMatica[i, j];
            return rotovanaMatica;
        }
        private long VedlajsiaDiagonalaSuma()
        {
            long suma = 0;
            int[,] data = RotaciaMatice(this.data);
            for (int i = 0; i < data.GetLength(0); i++)
                suma += data[i, i];
            return suma;
        }
        public void Vypis()
        {
            Console.WriteLine("Vygenerovaná matica:");
            for (int i = 0; i < this.data.GetLength(0); i++)
            {
                for (int j = 0; j < this.data.GetLength(1); j++)
                {
                    Console.Write(this.data[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine("Suma hlavnej diagonály:" + HlavnaDiagonalaSuma());
            Console.WriteLine("Suma vedľajšej diagonály:" + VedlajsiaDiagonalaSuma());
        }
    }
    internal class Zadanie_2_MichalCengel
    {
        static void Main(string[] args)
        {
            Matica mat = new Matica();

            mat.Vypis();

            Console.ReadKey();
        }
    }
}
