using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Project2016.Helpers;


namespace Project2016.Array
{
    public class EPI_Array 
    {
        // 6.1 Write a function that takes an array A and an index i into A, and
        // rearranges the elements such that all elements less than A[i] appear first,
        // followed by element equal to A[i], followed by elements greater than A[i].
        // Your algorithm should have O(1) space complexity and O(|A|) time complexity.
        // Research the counting sort
        void  EPI_61_DutchFlagPartition(int[] arr, int pvtIndex)
        {
            //create 4 pointers
            //bottom: stored in arr[0:smaller-1]
            //middle; stored in arr[smaller:equal-1]
            //unclassigied: stored in arr[equal:larger]
            //top: stored in a[larger+1: length-1]

            int pivot =arr[pvtIndex];
            int smaller=0, equal=0,  larger =arr.Length-1;// initialize the pointer
            //arr[equal] represents the incoming unclassied element in the arrary
            // 17, 25, 6, 33, 19, 29, 19,44, 33, 5,8,19, 65
            // pivot = 19
            while(equal<=larger)
            {
                if(arr[equal]<pivot)
                {
                    Helper.swap(arr, equal, smaller);
                    smaller++;
                    equal++;
                    
                }
                else if (arr[equal] == pivot)
                {
                    equal++;
                    
                }
                else
                {
                    Helper.swap(arr, equal, larger);
                    larger--;
                    //equal++;
                }
                    
            }


        }

        void EPI_61_CountingSort(int[] arr)
        {

        }

        // 6.2 Design a deterministic scheme by which reads and writes to an uninitialized 
        // array can be made in O(1) time. You may use O(n) additional storage; reads to 
        // unilitialized entry should return false.
        void EPI_62_LazyInitialization()
        {

        }

        // 6.18 Implement run-length encoding and decoding functions. Assume the string to be 
        // encoded consits of letters of the alphabe, with no digits, and the string to be 
        // decoded is a valid encoding.
        string PEC_618_decoding(string s)
        {
            string ret = "";
            int count=0;
            foreach (char a in s)
            {
                if (a >= '0' && a <= '9')
                {
                    count = a - '0' + count * 10;
                }
                else
                {
                    ret += new string(a, count);
                    count = 0;
                }
            }

            return ret;
        }

        string EPI_618_encoding(string s)
        {
            return "";
        }
    
    }
}