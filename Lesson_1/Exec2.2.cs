using System;

namespace Exec1
{
    class Programm
    {
        public static int binary_convert(int n)
        {
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
            return n_convert;
        }

        public static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());
            int m = Convert.ToInt32(Console.ReadLine());
            int summ = n + m;

            int bin_n = binary_convert(n);
            string n_res = $"{bin_n}";
            int bin_m = binary_convert(m);
            string m_res = $"{bin_m}";
            /*int bin_summ = binary_convert(summ);*/

            int counter = 1;
            int digit;
            int max = Math.Max(bin_n, bin_m);
            int check = 0;
            int bin_sum = 0;
            while (max != 0)
            {
                digit = bin_n%10 + bin_m%10;
                if (digit > 1)
                {   
                    if (check == 1)
                    {
                        bin_sum += check * counter;
                        check = 1;
                    }
                    else
                    {
                        bin_sum += 0;
                        check = 1;
                    }
                }

                else if (digit == 1)
                {
                    if (check == 1)
                    {
                        bin_sum += 0;
                    }
                    else
                    {
                        bin_sum += digit * counter;
                        check = 0;
                    }
                }

                else
                {
                    if (check == 1)
                    {
                        bin_sum += check * counter;
                        check = 0;
                    }
                    else
                    {
                        bin_sum += 0;
                    }
                }
                counter *= 10;
                max /= 10;
                bin_m /= 10;
                bin_n /= 10;
/*                Console.WriteLine("--------------");
                Console.WriteLine(bin_n);
                Console.WriteLine(bin_m);
                Console.WriteLine(digit);
                Console.WriteLine(bin_sum);
                Console.WriteLine(counter);
                Console.WriteLine("--------------");*/
            }
            if (check == 1)
            {
                bin_sum += check * counter;
            }

            string sum_res = $"{bin_sum}";

            while (n_res.Length != sum_res.Length)
            {
                n_res = "0" + n_res;
            }

            while (m_res.Length != sum_res.Length)
            {
                m_res = "0" + m_res;
            }

            Console.WriteLine(n_res);
            Console.WriteLine(m_res);

            Console.WriteLine(".........");

            Console.WriteLine(bin_sum);
        }
    }
}
