namespace Exec1
{
    class Programm
    {
        public static void Main(string[] args)
        {
            int size_of_matrix = Convert.ToInt32(Console.ReadLine());

            string result = "";
            for (int index1 = 0; index1 < size_of_matrix; index1++)
            {
                string str = "";
                int check_dig = size_of_matrix - index1;
                str += check_dig;
                int flag = 0;
                for (int index2 = 1; index2 < size_of_matrix; index2++)
                {
                    if (flag == 1)
                    {
                        check_dig -= 1;
                    }
                    else if (check_dig < size_of_matrix)
                    {
                        check_dig += 1;
                    }
                    else
                    {
                        check_dig -= 1;
                        flag = 1;
                    }
                    str += check_dig;
                }
                result += str + "\n";

            }
            Console.WriteLine(result);
        }
    }
}
