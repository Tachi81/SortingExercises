using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

            QuickSort(unsortedArray);

            Console.ReadKey();

        }

        private static void QuickSort(List<int> unsortedArray)
        {
            int startIndex = 0;
            int endIndex = unsortedArray.Count - 1;
            int lastIndexBeforePivot = endIndex - 1;
            int pivot = new Random().Next(0, endIndex);
            var tempArray = unsortedArray;
            int temp;

            

            temp = unsortedArray[pivot];
            unsortedArray[pivot] = unsortedArray[endIndex];
            unsortedArray[endIndex] = temp;

            CompareLeftAndRight(tempArray, ref startIndex, endIndex, ref lastIndexBeforePivot);

        }

        private static void CompareLeftAndRight(List<int> unsortedArray, ref int startIndex, int endIndex, ref int lastIndexBeforePivot)
        {
            int left, right;
            for (int i = startIndex; i < endIndex; i++)
            {
                if (unsortedArray[i] > unsortedArray[endIndex])
                {
                    left = unsortedArray[i];
                    startIndex = i;
                }
            }

            for (int j = lastIndexBeforePivot; j > startIndex; j--)
            {
                if (unsortedArray[j] < unsortedArray[endIndex])
                {
                    right = unsortedArray[j];
                    lastIndexBeforePivot = j;
                }
            }

            if (startIndex < lastIndexBeforePivot)
            {

            }
            else
            {

            }
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
            var a = true;
            int j = unsortedArray.Count;
            while (a)
            {
                a = false;

                for (int i = 0; i < j - 1; i++)
                {
                    if (unsortedArray[i] > unsortedArray[i + 1])
                    {
                        int temp = unsortedArray[i];
                        unsortedArray[i] = unsortedArray[i + 1];
                        unsortedArray[i + 1] = temp;
                        a = true;
                    }
                }
                j--;
                PrintArray(unsortedArray);
            }
        }
    }
}
