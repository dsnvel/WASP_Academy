using System;

namespace Exec1
{
    class Programm
    {
        public static void Main(string[] args)
        {
          int n = Convert.ToInt32(Console.ReadLine());
            string new_n = "";
            int digit;
            while (n != 0)
            {
                digit = n % 2;
                new_n = digit + new_n;
                n /= 2;
            }
            Console.WriteLine(new_n);
        }
    }
}
