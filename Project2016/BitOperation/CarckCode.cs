using System;
using System.Collections.Generic;
using System.Text;

namespace Project2016.BitOperation
{
    class CarckCode
    {


        //example:
        //Input: N=100000000000, M=10011, i=2, j=6
        //Output:N=100001001100
        int CC_5_1_updateBits(int n, int m, int i, int j)
        {
            //first step is to set bits (between i and j) to 0 in n
            //1. set left
            int left = ~0 << (j+1);     // 11111100000
            int right = (1 << i) - 1; // 00000000011
            int mask = left | right; //11111100011
            int cleared = n & mask; 
            int value = m << i; // left shift m by i-1 bits
            return value | mask;

        }
    }
}
