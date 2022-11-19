using System;

namespace Exec1
{
    class Programm
    {
        public static void Main(string[] args)
        {
          int n = Convert.ToInt32(Console.ReadLine());
            int n_convert = 0;
            int counter = 1;
            int digit;
            while (n != 0)
            {
                digit = n % 2;
                n_convert += digit * counter;
                counter *= 10;
                n /= 2;
            }
            Console.WriteLine(n_convert);
        }
    }
}
