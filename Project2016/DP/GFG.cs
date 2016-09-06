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
            int[] countArray = new int[total+1];

            countArray[0] = 0;
            for(int i =1;i<=total;i++)
            {
                int tempMax = 0;

                //count[n] = max(count[n-s[j]])+1  when 1<=j<=numberOfDenominations && n>=s[j]
                for (int j=0;j<numberOfDenominations && denominations[j]<=i;j++)
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
            denom =new int[] { 1,2,3};
            total = 4;
            count = CoinCount(denom, total);
            return 0;
        }

    }
}
