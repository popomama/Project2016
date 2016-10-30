﻿using System;
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


        //Find a triplet that sum to a given value
        //Given an array and a value, find if there is a triplet in array whose sum is equal to the given value.
        //If there is such a triplet present in array, then print the triplet and return true. Else return false. 
        //For example, if the given array is {12, 3, 4, 1, 6, 9} and given sum is 24, then there is a triplet(12, 3 and 9) 
        //present in array whose sum is 24.


        //Find 
        //e. The input is a collection, C, of integers, and we are interested in a subset whose sum
        //exactly half of the total sum of C. The problem is NP­hard
    }
}
