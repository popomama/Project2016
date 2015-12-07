using System;
using System.Collections.Generic;
using System.Text;

namespace Project2016.BitOperation
{
    class EPI
    {
        //compute the parity of a very large number o f64 bit non-negative integers.
        short EPI_5_1_Parity1(ulong x)
        {
            short result =0;
            //shift the bit one-by-one,  O(n) complexity
            while(x!=0)
            {
                //if( (x & (long)1) != (long)0)
                //{
                //    result ^= 1;
                //}

                result ^=(short) (x & ((ulong)1));
                x =x>> 1;
            }

            return result;
        }

        //compute the parity of a very large number o f64 bit non-negative integers.
        //use trick x&(x-1) reset the LSB
        //Complexity depends on the number of 1s in the long, and is good when it's sparse
        //not sure if left shift is much cheaper than x &= (x-1), if that's the case, then this
        //method will be in fact more expensive than the previous one.
        short EPI_5_1_Parity2(ulong x)
        {
            short result = 0;
            while(x!=0)
            {
                result ^= 1;
                x &= (x-1); // eliminate the 1 at LSB;
            }

            return result;
        }

        //now if we are doing a large number of the parity check on 64 bit,
        //we may considering cache of the small number for lookup(see commented part below)
        short EPI_5_1_Parity3( ulong x)
        {
            return 0;
            //return Precomputed_parity[x >> 48] ^
            //    (Precomputed_parity[x >> 32] && 0xffff) ^
            //    (Precomputed_parity[x >> 16] && 0xffff) ^
            //    (Precomputed_parity[x] && 0xffff);

        }

        long EPI_5_2_swap_bits(long x, int i, int j)
        {
            // regular way:
            // get the bits on i, j
            // set bit i, j to 0
            // reset i to j and j to i

            // below is new way
            //first check if bit i and bit j are the same;
            bool bSameValue = (x & (1 << i)) == (x & (1 << j));

            if (!bSameValue) //second, only need to swap if values are different
            {
                long mask = 1L << i | 1L << j;
                x ^= mask;
            }

            return x;
        }

        long EPI_5_3_reverse_bits(long x)
        {
            // use cache to revers3 16 bit speparately
            //return precomputed_reverse[(x >> 48) & 0xffff] |
            //    precomputed_reverse[((x >> 32) & 0xffff) << 16] |
            //    precomputed_reverse[((x >> 16) & 0xffff) << 32] |
            //    precomputed_reverse[(x & 0xffff) << 48];
            return 0L;
        }

        //closest integers with the same weight
        //weight = # of bits that have value one in an intger. s[i] denotes the set of integers with weight i
        //if x is of s[i], find y so that |y-x| is minimum and y is also of s[i]
        ulong EPI_5_4_closeset_int_same_bits(ulong x)
        {
            //1. loop from LSB to left to find the two consecutive bits that are different\
            int i = 1;
            while(i<63)
            {

                //if( (x & (1u<<i)) != (x & (1u<<(i+1))) )   wrong
                if( ((x>>i) & 1u) != ((x>>(i+1)) & 1u) )
                {
                    // now swap the bits between i and i+1
                    x ^= (1u << i | 1u << (i + 1));

                }

                i++;
 
            }

            return x;
        }
    }
}
