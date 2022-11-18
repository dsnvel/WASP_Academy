namespace Exec1
{
   class Programm
    {
        public static void Main(string[] args)
        {
            int count = 0;
            string str = "";

            for (int digit = 4210-1; digit < 9876;)
            {
                digit += 1;
                str = $"{digit}";

                while (!((str[0] > str[1]) & (str[1] > str[2]) & (str[2] > str[3])))
                {
                    digit += 1;
                    str = $"{digit}";
                }
                count += 1;
                Console.WriteLine(digit);
                continue;
            }
            Console.WriteLine("Количество комбинаций: " + count);
        }
    }
}
