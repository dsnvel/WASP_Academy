using System;

namespace Exec1
{
    class Programm
    {
        public static string binary_convert(int get_n)
        {
            int n = get_n;
            string new_n = "";
            int digit;
            while (n != 0)
            {
                digit = n % 2;
                new_n = digit + new_n;
                n /= 2;
            }
            return new_n;
        }

        public static void Main(string[] args)
        {
          int n = Convert.ToInt32(Console.ReadLine());
            int m = Convert.ToInt32(Console.ReadLine());
            int summ = n + m;

            string bin_n = binary_convert(n);
            string bin_m = binary_convert(m);
            string bin_summ = binary_convert(summ);

            while (bin_n.Length != bin_summ.Length)
            {
                bin_n = "0" + bin_n;
            }

            while (bin_m.Length != bin_summ.Length)
            {
                bin_m = "0" + bin_m;
            }

            Console.WriteLine(bin_n);
            Console.WriteLine(bin_m);

            Console.WriteLine(".........");

            Console.WriteLine(bin_summ);
        }
    }
}
