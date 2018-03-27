using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> unsortedArray = new List<int>()
            {
                9,
                13,
                7,
                14,
                5,
                19,
                6,
                2,
                11,
                1,
                8,
                18,
                12
            };
            PrintArray(unsortedArray);

            BubbleSort(unsortedArray);

            PrintArray(unsortedArray);

            Console.ReadKey();

        }

        private static void PrintArray(List<int> unsortedArray)
        {
            foreach (var integer in unsortedArray)
            {
                Console.Write(integer + ", ");
            }
            Console.WriteLine("----------------");
            Console.WriteLine("");
        }

        private static void BubbleSort(List<int> unsortedArray)
        {
            
        }
    }
}
