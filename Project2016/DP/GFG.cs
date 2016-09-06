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

        int CoinCount(int[] denominations, int total)
        {
            int numberOfDenominations = denominations.Count();
            int[] countArray = new int[total+1];

            countArray[0] = 0;
            for(int i =1;i<=total;i++)
            {
                int tempMax = 0;
                for(int j=0;j<numberOfDenominations && denominations[j]<=i;j++)
                {
                    if (tempMax <= countArray[i - denominations[j]])
                        tempMax = countArray[i - denominations[j]] + 1;
                }

                countArray[i] = tempMax;
            }
            return countArray[total];
        }

    }
}
