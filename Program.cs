using System;
using System.Collections.Generic;

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
            var number = new Random();
            for (int i = 0; i < 654; i++)
            {
                unsortedArray.Add(number.Next(1, 2000));
            }
            PrintArray(unsortedArray);

            //  BubbleSort(unsortedArray);

            QuickSort(unsortedArray);

            PrintArray(unsortedArray);

            Console.ReadKey();

        }

        private static void QuickSort(List<int> unsortedArray)
        {
            int InitialstartIndex = 0;
            int endIndex = unsortedArray.Count - 1;

            List<int> indexesOfIntegersInCorrectPosition = new List<int>();
            int indexesLength = indexesOfIntegersInCorrectPosition.Count;

            SortGivenArray(unsortedArray, InitialstartIndex, InitialstartIndex, endIndex - 1, endIndex, indexesOfIntegersInCorrectPosition, indexesLength);
        }

        private static void SortGivenArray(List<int> unsortedArray, int initialStartIndex, int startIndex, int lastIndexBeforePivot, int endIndex, List<int> indexesOfIntegersInPosition, int indexesLength)
        {
            ChooseRandomPivotAndMoveItToEndIndex(unsortedArray, startIndex, endIndex);

            Console.WriteLine($"pivot ={unsortedArray[endIndex]}, start index = {startIndex}, last Index = {endIndex}");
     //       PrintArray(unsortedArray);

            if (endIndex > startIndex)
            {
                CompareLeftAndRight(unsortedArray, initialStartIndex, startIndex, lastIndexBeforePivot, endIndex, indexesOfIntegersInPosition, indexesLength);
            }
        }

        private static void CompareLeftAndRight(List<int> unsortedArray, int initialStartIndex, int startIndex, int lastIndexBeforePivot, int endIndex, List<int> indexesOfIntegersInPosition, int indexesLength)
        {
            int leftIndex = FindIndexOfFirstDigitFromTheLeftSideThatIsBiggerThanPivot(unsortedArray, startIndex, endIndex);

            int rightIndex = FindIndexOfFirstDigitFromTheRightSideThatIsSmallerThanPivot(unsortedArray, initialStartIndex, lastIndexBeforePivot, endIndex);
            Console.WriteLine($"leftindex = {leftIndex}, rightindex = {rightIndex}");
            if (leftIndex == -1)
            //biggest number is on right side
            {
                endIndex--;
                if (endIndex > startIndex)
                {
                    SortGivenArray(unsortedArray, initialStartIndex, startIndex, endIndex - 1, endIndex, indexesOfIntegersInPosition, indexesLength);
                }
                else
                {
                    FinishIt(unsortedArray, indexesOfIntegersInPosition, indexesLength, initialStartIndex);
                }
            }
            else if (rightIndex == -1)
            //smallest number is on right side
            {
                MovePivotToCorrectPosition(unsortedArray, endIndex, startIndex);
                Console.WriteLine($"after moving pivot to correct position");
       //         PrintArray(unsortedArray);

                startIndex++;
                initialStartIndex++;
                if (endIndex > startIndex)
                {
                    SortGivenArray(unsortedArray, initialStartIndex, startIndex, lastIndexBeforePivot, endIndex, indexesOfIntegersInPosition, indexesLength);
                }
                else
                {
                    FinishIt(unsortedArray, indexesOfIntegersInPosition, indexesLength, initialStartIndex);
                }

            }
            else if (leftIndex < rightIndex)
            //number from mid is on right side
            {
                SwapLeftAndRight(unsortedArray, leftIndex, rightIndex);
                Console.WriteLine($"after swap");
        //        PrintArray(unsortedArray);

                CompareLeftAndRight(unsortedArray, initialStartIndex, leftIndex + 1, rightIndex - 1, endIndex, indexesOfIntegersInPosition, indexesLength);
            }
            else
            // smaller and bigger numbers are sorted on left and right
            {
                MovePivotToCorrectPosition(unsortedArray, endIndex, leftIndex);
                Console.WriteLine($"after moving pivot to correct position");
          //      PrintArray(unsortedArray);

                indexesOfIntegersInPosition.Add(leftIndex);
                indexesLength++;

                endIndex = leftIndex - 1;
                startIndex = initialStartIndex;

                if (endIndex > startIndex)
                {
                    SortGivenArray(unsortedArray, initialStartIndex, startIndex, endIndex - 1, endIndex, indexesOfIntegersInPosition, indexesLength);
                }
                else
                {
                    FinishIt(unsortedArray, indexesOfIntegersInPosition, indexesLength, initialStartIndex);
                }
            }
        }

        private static void FinishIt(List<int> unsortedArray, List<int> indexesOfIntegersInPosition, int indexesLength, int initialStartIndex)
        {
            if (indexesLength > 1)
            {
                int startIndex = indexesOfIntegersInPosition[indexesLength - 1] + 1;
                initialStartIndex = startIndex;
                int endIndex = indexesOfIntegersInPosition[indexesLength - 2] - 1;

                if (endIndex - startIndex > 2)
                {
                    RemoveLastNumberFromIndexes(indexesOfIntegersInPosition, ref indexesLength);
                    CompareLeftAndRight(unsortedArray, initialStartIndex, startIndex, endIndex - 1, endIndex, indexesOfIntegersInPosition, indexesLength);
                }
                else
                {
                    RemoveLastNumberFromIndexes(indexesOfIntegersInPosition, ref indexesLength);

                    FinishIt(unsortedArray, indexesOfIntegersInPosition, indexesLength, initialStartIndex);
                }

            }
            else if (indexesLength == 1)
            {
                int startIndex = indexesOfIntegersInPosition[0] + 1;
                initialStartIndex = startIndex;
                int endIndex = unsortedArray.Count - 1;
                RemoveLastNumberFromIndexes(indexesOfIntegersInPosition, ref indexesLength);

                SortGivenArray(unsortedArray, initialStartIndex, startIndex, endIndex - 1, endIndex, indexesOfIntegersInPosition, indexesLength);

            }
        }

        private static void RemoveLastNumberFromIndexes(List<int> indexesOfIntegersInPosition, ref int indexesLength)
        {
            indexesOfIntegersInPosition.RemoveAt(indexesLength - 1);
            indexesLength--;
        }

        private static int FindIndexOfFirstDigitFromTheRightSideThatIsSmallerThanPivot(List<int> unsortedArray, int startIndex, int lastIndexBeforePivot, int endIndex)
        {
            int rightIndex = -1;

            for (int j = lastIndexBeforePivot; j >= startIndex; j--)
            {
                if (unsortedArray[j] < unsortedArray[endIndex])
                {
                    rightIndex = j;
                    break;
                }
            }

            return rightIndex;
        }

        private static int FindIndexOfFirstDigitFromTheLeftSideThatIsBiggerThanPivot(List<int> unsortedArray, int startIndex, int endIndex)
        {
            int leftIndex = -1;
            for (int i = startIndex; i < endIndex; i++)
            {
                if (unsortedArray[i] > unsortedArray[endIndex])
                {
                    leftIndex = i;
                    break;
                }
            }
            return leftIndex;
        }

        private static void ChooseRandomPivotAndMoveItToEndIndex(List<int> unsortedArray, int startIndex, int endIndex)
        {
            int pivot = new Random().Next(startIndex, endIndex);
            int temp;

            temp = unsortedArray[pivot];
            unsortedArray[pivot] = unsortedArray[endIndex];
            unsortedArray[endIndex] = temp;
        }

        private static void MovePivotToCorrectPosition(List<int> unsortedArray, int endIndex, int correctPositionOfPivot)
        {
            int temp = unsortedArray[correctPositionOfPivot];
            unsortedArray[correctPositionOfPivot] = unsortedArray[endIndex];
            unsortedArray[endIndex] = temp;

        }

        private static void SwapLeftAndRight(List<int> unsortedArray, int leftIndex, int rightIndex)
        {
            int temp = unsortedArray[leftIndex];
            unsortedArray[leftIndex] = unsortedArray[rightIndex];
            unsortedArray[rightIndex] = temp;

        }

        private static void PrintArray(List<int> unsortedArray)
        {
            foreach (var integer in unsortedArray)
            {
                Console.Write(integer + ", ");
            }

            Console.WriteLine();
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
