using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cabability2
{
    class Program
    {
        static void Main(string[] args)
        {
            int flag = 1;
            while (flag == 1)
            {
                Console.WriteLine("press 1 to get non repeating elements");
                Console.WriteLine("press 2 to get soted string ");
                Console.WriteLine("press 3 to exit");
                Console.WriteLine("enter the choice ");
                int n = int.Parse(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        nonrep();
                        break;
                    case 2:
                        sortstr();
                        break;
                    case 3:
                        flag = 0;
                        break;
                    default:
                        Console.WriteLine("invalid input");
                        break;

                }
            }
            Console.ReadKey();
        }

        public static void sortstr()
        {
            Console.WriteLine("enter the string ");
            string s = Console.ReadLine();
            string s1 = "";
            char temp = new char();
            char[] chararr = new char[s.Length];
            for (int i = 0; i < s.Length; i++)
            {
                chararr[i] = s[i];
            }

            for (int k = 0; k < s.Length; k++)
            {
                for (int j = 0; j < s.Length - 1; j++)
                {
                    if (chararr[j].CompareTo(chararr[j + 1]) > 0)
                    {
                        temp = chararr[j];
                        chararr[j] = chararr[j + 1];
                        chararr[j + 1] = temp;
                    }


                }
            }
            for (int i = 0; i < s.Length; i++)
            {
                s1 = s1 + chararr[i];
            }
            Console.WriteLine(s1);





        }



        public static void nonrep()
        {
            Console.WriteLine("enter the size of array");
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            for (int j = 0; j < arr.Length; j++)
            {
                for (int k = 0; k < arr.Length; k++)
                {
                    if (arr[j] == arr[k])
                    {
                        count++;
                    }
                }
                if (count == 1)
                {
                  

                    Console.WriteLine("required output:"+arr[j]);
                   
                }
                count = 0;
                Console.ReadKey();
            }
        }
    }
}





