using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2016.DP
{
    class GFG
    {
        //Coin Change
        //Given a value N, if we want to make change for N cents, and we have infinite supply of each of 
        //S = { S1, S2, .. , Sm} valued coins, how many ways can we make the change? The order of coins doesn’t matter.
        // For example, for N = 4 and S = { 1, 2, 3 }, there are four solutions: {1,1,1,1},{1,1,2},{2,2},{1,3}. 
        //So output should be 4. For N = 10 and S = { 2, 5, 3, 6 }, there are five solutions: {2,2,2,2,2}, {2,2,3,3}, 
        // {2,2,6}, {2,3,5} and {5,5}. So the output should be 5.

        //count[n] = max(count[n-s[j]])+1  when 1<=j<=numberOfDenominations && n>=s[j]
        //the complexity is O(nm) n = total, m = numberOfDenominations
        int CoinCount(int[] denominations, int total)
        {
            int numberOfDenominations = denominations.Count();
            int[] countArray = new int[total + 1];

            countArray[0] = 0;
            for (int i = 1; i <= total; i++)
            {
                int tempMax = 0;

                //count[n] = max(count[n-s[j]])+1  when 1<=j<=numberOfDenominations && n>=s[j]
                for (int j = 0; j < numberOfDenominations && denominations[j] <= i; j++)
                {
                    if (tempMax <= countArray[i - denominations[j]])
                        tempMax = countArray[i - denominations[j]] + 1;
                }

                countArray[i] = tempMax;
            }
            return countArray[total];
        }


        //int count(int S[], int m, int n)
        //{
        //    // table[i] will be storing the number of solutions for
        //    // value i. We need n+1 rows as the table is consturcted
        //    // in bottom up manner using the base case (n = 0)
        //    int table[n + 1];

        //    // Initialize all table values as 0
        //    memset(table, 0, sizeof(table));

        //    // Base case (If given value is 0)
        //    table[0] = 1;

        //    // Pick all coins one by one and update the table[] values
        //    // after the index greater than or equal to the value of the
        //    // picked coin
        //    for (int i = 0; i < m; i++)
        //        for (int j = S[i]; j <= n; j++)
        //            table[j] += table[j - S[i]];

        //    return table[n];
        //}

        //int count(int S[], int m, int n)
        //{
        //    // table[i] will be storing the number of solutions for
        //    // value i. We need n+1 rows as the table is consturcted
        //    // in bottom up manner using the base case (n = 0)
        //    int table[n + 1];

        //    // Initialize all table values as 0
        //    memset(table, 0, sizeof(table));

        //    // Base case (If given value is 0)
        //    table[0] = 1;

        //    // Pick all coins one by one and update the table[] values
        //    // after the index greater than or equal to the value of the
        //    // picked coin
        //    for (int i = 0; i < m; i++)
        //        for (int j = S[i]; j <= n; j++)
        //            table[j] += table[j - S[i]];

        //    return table[n];
        //}

        public int TestCoinCount()
        {
            //For N = 10 and S = { 2, 5, 3, 6 }, there
            int[] denom = { 2, 5, 3, 6 };
            int total = 10;
            int count = CoinCount(denom, total);
            denom = new int[] { 1, 2, 3 };
            total = 4;
            count = CoinCount(denom, total);
            return 0;
        }

        //Find the sub set of a collection whose sum is half of the total
        //e. The input is a collection, C, of integers, and we are interested in a subset whose sum
        //exactly half of the total sum of C. The problem is NP­hard
        //this may be generalized to be the sum of a specifc value




        //Partition problem is to determine whether a given set can be partitioned into two subsets 
        //such that the sum of elements in both subsets is same.
        //below we assume the array has n elements, the partition will be sum/2 . We need to find out
        //if there exists a subset of the arr of which the sum of the sub arrary equals sum/2 
        //this can also be used to find the minimum difference of the two subsets
        bool FindPartition(int[] arr, int n)
        {
            int sum = 0;
            for (int i = 0; i < n; i++)
                sum += arr[i];

            sum /= 2;

            //now we create a 2-dim array to record the result from bottom to up.
            //each row has the same sum, while each column stands for individual elememnt in the original array
            //so the 2-dim array is (sum+1)x(n+1); and the overall complexity is O(sum*n)
            bool[,] result = new bool[sum + 1, n + 1];

            //initialize the first row, set each to true, since there is always subset of the array whose sum is 0
            for (int i = 0; i < n + 1; i++)
                result[0, i] = true;

            //initialize the first column, set each to false(except (0,0)), since 
            for (int i = 1; i < sum + 1; i++)
                result[i, 0] = false;

            //basically result[value, K] = result[value, K-1] or result[value-arr[k-1], k-1]
            //                         case1 doesn't include kth element
            //                         case2 does inlcude kth element(only if the kth element is smaller/equal to value)
            //we only deal with positive number here. Also notice the index shift as index starts from 0 from the original array
            for (int value = 1; value < sum + 1; value++)
                for (int col = 1; col < n + 1; col++)
                {
                    if (arr[col - 1] > value)
                        result[value, col] = result[value, col - 1];
                    else
                        result[value, col] = result[value, col - 1] || result[value - arr[col - 1], col - 1];
                }

            //print out the matrix
            for (int value = 0; value < sum + 1; value++)
            {
                for (int col = 0; col < n + 1; col++)
                {
                    Console.Write(result[value, col] + " ");

                }
                Console.WriteLine();
            }

            return result[sum, n];

            //noticed, if we want to partition the set into two subsets to minimize the difference of the sum of the two sets
            //we only need to loop through result[k, n] (k=sum, sum-1, sum-2, ...0). the biggest k(the 1st K) we find is the one
            //the difference will be 2*(sum-k).
        }

        //Largest Sum Contiguous Subarray
        //Write an efficient C program to find the sum of contiguous subarray within a one-dimensional array of numbers 
        // which has the largest sum.
        int maxSubArraySum(int[] a)
        {
            //O(N), //assuming at least one item in the array is positive
            int maxSum = 0, currentSum = 0;
            //int size = a.Length;

            //for(int i=1;i<a.Length;i++) // this is not good, as we should take care if the array only has one element.
            for (int i = 0; i < a.Length; i++)
            {
                currentSum += a[i];
                if (currentSum < 0) //
                {
                    currentSum = 0;

                }
                else
                {
                    if (maxSum < currentSum)
                        maxSum = currentSum;
                }
            }

            return maxSum;

        }


        //Given a sequence of matrices, find the most efficient way to multiply these matrices together. The problem is 
        //not actually to perform the multiplications, but merely to decide in which order to perform the multiplications.
        int MatrixChainOrder(int[] p)
        {
            int matrixNumber = p.Length;
            if (matrixNumber <= 1)
                return 0;
            if (matrixNumber == 2)
                return p[0] * p[1] * p[2];

            int[,] matrixComplexity = new int[matrixNumber, matrixNumber];


            //create the base
            for (int i = 1; i < matrixNumber; i++)
            {
                matrixComplexity[i, i] = 0;  // only the current matrix
                matrixComplexity[i, i + 1] = p[i - 1] * p[i] * p[i + 1];

            }

            int currentComplextity = int.MaxValue;
            int minComplexity = int.MaxValue;
            //the matrix number now is at least 3, as otherwise it's already taken care of above
            for (int gap = 2; gap < matrixNumber - 1; gap++)
            {
                for (int startMatrix = 1; startMatrix < matrixNumber - gap; startMatrix++)
                {
                    for (int movingIndex = startMatrix; movingIndex < startMatrix + gap; movingIndex++)
                    {
                        currentComplextity = matrixComplexity[startMatrix, movingIndex]
                            + matrixComplexity[movingIndex + 1, startMatrix + gap]
                            + p[startMatrix - 1] * p[movingIndex] * p[startMatrix + gap];
                        if (currentComplextity < minComplexity)
                            minComplexity = currentComplextity;
                    }
                }
            }

            return minComplexity;
        }
    }
    }
