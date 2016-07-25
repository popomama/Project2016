using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2016.Generalquestions
{
    class Google1
    {


        // Matching Nuts and Bolts Optimally
        // Given a set of n nuts of different sizes and n bolts of different sizes. There is a one-one mapping between nuts and bolts. 
        // Match nuts and bolts efficiently.
        // Constraint: Comparison of a nut to another nut or a bolt to another bolt is not allowed.It means nut can only be compared with 
        // bolt and bolt can only be compared with nut to see which one is bigger/smaller. Other way of asking this problem is, given a box 
        // with locks and keys where one lock can be opened by one key in the box. We need to match the pair.
        public static void NutsAndBoltsMatch(int[] bolts, int[] nuts)
        {
            // the solution : use the randomized quick sort
            // complextity is O(NlogN)
            int low = 0;
            int high = bolts.Length-1;

            NutsAndBoltsMatch(bolts, nuts, low, high);

            //print the sorted bolts and nuts


        }

    
        static void NutsAndBoltsMatch(int[] bolts, int[] nuts, int low, int high)
        {
            int pivotLocation;
            while(low<high)
            {    //  this is similar to the traditional quick sort
                pivotLocation = Partition(bolts, low, high, nuts[high]);
                pivotLocation = Partition(nuts, low, high, bolts[pivotLocation]);// the returned pivotLocation should be the same as passed in

                NutsAndBoltsMatch(bolts, nuts, low, pivotLocation - 1);
                NutsAndBoltsMatch(bolts, nuts, pivotLocation + 1, high);
            }
        }

        static void  swap(int[] arr, int i, int j)
        {
            int temp = arr[i];
            arr[j] = arr[i];
            arr[i] = temp;
        }

        //this is simiarl to partition menthod used in the regular quicksort, the difference is we pass in the pivat value instead of index
        static int Partition(int[] arr, int low, int high, int pivotValue)
        {
            int i = low;//record the next index of the elment whose value is (potentially) greater than pivot
            for(int j=low;j<high;j++) // j records the first index of the element whose value is greater than pivot
            {
                if (arr[j] < pivotValue)
                {
                    swap(arr, i, j);    //exchange, now arr[i] now records the last value that is smaller than pivot
                    i++; //move i to the next potential index
                }
                else if (arr[j] == pivotValue)
                {
                    swap(arr, j, high); // move the pivot value to the last
                    j--; // decrement j, so that we wil check new arr[j] (swap from high position)
                }
            }

            swap(arr, i, high); // make the element at index i to have the pivot value


            return i; // return the pivot index;
        }
    }
}
