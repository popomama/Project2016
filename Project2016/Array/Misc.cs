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
        bool Find3Sum(int[] arr, int sum)
        {
            bool bFound = false;

            System.Array.Sort(arr); //sort the array in ascending order {1,3,4,6,9,12}

            int left = 0;
            int right;
            int mid;

            //overalll performance is O(N^2)
            for (left = 0; left < arr.Length - 2; left++) // we will loop through the left from 0 to N-2;
            {
                mid = left + 1;
                right = arr.Length - 1;

                while (mid < right)
                {
                    if (arr[left] + arr[mid] + arr[right] == sum) //found the triplet
                    {
                        Console.Write(arr[left] + " " + arr[mid] + " " + arr[right] + "=" + sum);
                        bFound = true;
                    }
                    else if (arr[left] + arr[mid] + arr[right] < sum) // if the sum is smaller than the target, move the mid to the right
                        mid++;
                    else //if the sum is bigger than target, move the right to the left
                        right--;
                }
            }

            return bFound;


        }

        //There are two sorted arrays A and B of size m and n respectively. Find the median of the two sorted arrays. 
        //The overall run time complexity should be O(log (m+n)).
        public int findMedianSortedArrays(int[] a, int[] b)
        {
            int lenA = a.Length;
            int lenB = b.Length;

            int total = lenA + lenB;

            if (total % 2 == 0)//there are even number of elements, take the avg of the middle two;
                return (FindKthFromTwo(a, 0, a.Length - 1, b, 0, b.Length - 1, total / 2) +
                    FindKthFromTwo(a, 0, a.Length - 1, b, 0, b.Length - 1, total / 2 + 1) / 2);
            else
                return FindKthFromTwo(a, 0, a.Length - 1, b, 0, b.Length - 1, total / 2 + 1);

        }

        private int FindKthFromTwo(int[] a, int startA, int endA, int[] b, int startB, int endB, int position)
        {
            if (position < startA || position > endA)
                return b[startB + position - 1];
            if (position < startB || position > endB)
                return a[startA + position - 1];

            int halfA = position / 2;
            int halfB = position - halfA;

            if(a[startA+ halfA]<b[startB + halfB])// the elements between startA and startA+halfA must in the first position
            {
                return FindKthFromTwo(a, startA + halfA + 1, endA, b, startB, endB, position - halfA);
            }

            if(a[startA + halfA] > b[startB + halfB])// the elements between startB and startB+halfB must in the first position
            {
                return FindKthFromTwo(a, startA, endA, b, startB + halfB, endB, position - halfB);
            }

            //if a[startA+ halfA]==b[startB + halfB], return it;
            return a[startA + halfA];

        }
    }
}
