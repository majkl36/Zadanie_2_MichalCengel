using System;

namespace Zadanie_2_MichalCengel
{
    public class Matica
    {
        public const uint MAX_ROZMER = 10;
        private int[,] data;
        public Matica(uint size = MAX_ROZMER)
        {
            this.data = new int[size, size];
            NaplnMaticu();
        }
        public Matica(uint size, int min, int max)
        {
            this.data = new int[size, size];
            NaplnMaticu(min, max);
        }
        private void NaplnMaticu(int min = 0, int max = 10)
        {
            Random rand = new Random();
            for (int i = 0; i < this.data.GetLength(0); i++)
                for (int j = 0; j < this.data.GetLength(1); j++)
                    data[i, j] = rand.Next(min, max);
        }
        private int HlavnaDiagonalaSuma()
        {
            int suma = 0;
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
        private int VedlajsiaDiagonalaSuma()
        {
            int suma = 0;
            int[,] data = RotaciaMatice(this.data);
            for (int i = 0; i < data.GetLength(0); i++)
                suma += data[i, i];
            return 0;
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
    internal class Zadanie_2_MC
    {
        static void Main(string[] args)
        {
            Matica xxx = new Matica(3);

            
            xxx.Vypis();

            Console.WriteLine("Vygenerovaná matica:");

            Console.ReadKey();
        }
    }
}
