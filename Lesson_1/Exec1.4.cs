using System;
/*
Основная проблема в том, что реализововать треугольник Паскаля через строки
получается, но криво. Я мог дальше доделать, но боюсь, что как я, так и ты оторвали бы
себе глаза после этого, так что максимальная высота моего треугольника равна 6, если 
нужно доделать полностью я сделаю, но при условии, что можно будет пользоваться масивами
*/
namespace Exec1
{
    class Programm
    {
        public static void Main(string[] args)
        {
           int height = Convert.ToInt32(Console.ReadLine());
            string result = "";
           for (int index = 0; index < height; index++)
            {
                if (index== 0)
                {
                    result += "1";
                }
                else if (index == 1){
                    result += "11";
                }
                else
                {
                    int a;
                    int b;

                    int check = 0;
                    for (int index2 = 0; index2 < index + 1; index2++)
                    {
                        if (index2 == 0 | index2 == index)
                        {
                            result += 1;
                        }
                        else
                        {
                            /*Console.WriteLine("\n");
                            Console.WriteLine("---------------");
                            Console.WriteLine(result);
                            Console.WriteLine("---------------");*/
                            a = Convert.ToInt32((result[result.Length - index - 1 - check]).ToString());
                            b = Convert.ToInt32((result[result.Length - index - 2 - check]).ToString());
                            if (a + b > 9)
                            {
                                check += 1;
                            }
                           /* Console.WriteLine(result.Length);
                            Console.WriteLine(index);
                            Console.WriteLine(index2);
                            Console.WriteLine("symbol 1 = " + b);
                            Console.WriteLine("symbol 2 = " + a);
                            Console.WriteLine("sum = " + (a + b));*/
                            result += (a + b);
                        }
                    }
                }
                
                result += "\n";
            }
           Console.WriteLine(result);
        }
    }
}
