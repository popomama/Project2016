using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2016.SortingSeraching
{
    class CodeCrack_SortingSearching
    {

        //Search In Rotaed Array: Given a sorted array of n integers that has been rotated an unknown number of times,
        //write code to find an elemennt in the array. You may assume that array was originally sorted in increasing order.
        // Input find 5 in {15,16,19,20,25,1,3,4,5,7,10,14}
        //Output 8(index of 5)
        int searchRotatedSortedArray(int[] arr, int value)
        {
            //key point: (1) binary search, (2) half and only half of the array are in normal order
            return searchRotatedSortedArray(arr, value, 0, arr.Length - 1);
        }

        private int searchRotatedSortedArray(int[] arr, int value, int left, int right)
        {
            if (left > right)
                return -1;

            int mid = (left + right) / 2;

            if (arr[mid] == value)
                return mid;

            if (arr[left] < arr[mid]) // the left half is normal
            {
                if (value >= arr[left] && value < arr[mid])
                    return searchRotatedSortedArray(arr, value, left, mid-1);
                else
                    return searchRotatedSortedArray(arr, value, mid + 1, right);
            }
            else if(arr[mid]<arr[left]) // right half is normal
            {
                if (value > arr[mid] && value < arr[right])
                    return searchRotatedSortedArray(arr, value, mid + 1, right);
                else
                    return searchRotatedSortedArray(arr, value, left, mid - 1);
            }
            else// if(arr[left]==arr[mid])
            {
                if(arr[right]==arr[mid]) // we have to search both sides 2,2,2,2,5,1,2
                {
                    int leftHit = searchRotatedSortedArray(arr, value, left + 1, mid - 1);
                    if (leftHit == -1)
                        return searchRotatedSortedArray(arr, value, mid + 1, right - 1);
                    else
                        return leftHit;
                }
                else// left hand side are all repeats
                {
                    return searchRotatedSortedArray(arr, value, mid + 1, right);
                }


            }
        }

        //Sorted searc, no sizes: You are given an array-like data structure Listy which lacks a size
        //method,. It does have an elementAt(i) method that returns the element at indext i in O(1)
        //time. If is beyond the bounds of the data structure it returns -1. For this reason, the data
        //structure only supports positive integers. Given a Listy which contains sorted, positive integers,
        // find the index at which an element x occurs. If x occurs multiple times, you may return any index.
    }
}
