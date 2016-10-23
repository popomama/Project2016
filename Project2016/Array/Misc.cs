using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2016.Array
{
    public class Misc
    {
        //There are N numbers, find all the combinations of K numbers from the N numbers
        public void FindPermutation(int total, int numToBeSelected)
        {
      
            if (total < numToBeSelected)
                return;

            int[] arr = new int[total];
            for (int i = 0; i < total; i++)
                arr[i] = 0;//initialize to 0;

            GenerateCombination(arr, total, numToBeSelected, 0, 0);
        }

        private void GenerateCombination(int[] arr, int total, int numToBeSelected, int numSelected, int currentLevel)
        {
            if (numSelected == numToBeSelected)
            {
                PrintoutPermutation(arr);
                return;
            }

            if (currentLevel == total)
                return; //we have reached all numbers;

            arr[currentLevel] = 1;
            GenerateCombination(arr, total, numToBeSelected, numSelected + 1, currentLevel + 1);

            arr[currentLevel] = 0;
            GenerateCombination(arr, total, numToBeSelected, numSelected, currentLevel + 1);

            return;


        }

        private void PrintoutPermutation(int[] arr)
        {
           for(int i=0;i<arr.Length;i++)
            {
                if (arr[i] == 1)
                    Console.Write(i+1);
            }

            Console.WriteLine();
        }
    }
}
