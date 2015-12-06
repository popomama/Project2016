/*
Bit operations:

a^(~a) – all 1s
a & ~0 << n clears right most n bits
x^x =0
x&(x-1) -- drop the LSB of x
x^0=x;
x^(~0)=~x

*/

public class BitBasics
{

    bool getBit(int number, int i)
    {
        return (number & (1 << i))!=0;       
    }

    int setBit(int number, int i)
    {
        return number | (1 << i);
    }

    int clearBit(int number, int i)
    {
        return number & ~(1 << i);
    }

    //clear the bits through the most significant bit(i in inclusive)
    int clearBitsTMSB(int number, int i)
    {
        return number & ~((~0) << i);

        // the alternative is
        // return number & ~((1 << i) - 1);

    }

    //clear all bits from i through 0, i inclusive
    int clearAllBitsThrough0(int number, int i)
    {
        return number & ((~0) << (i + 1));
    }

    //update the bit i with value v
    int updateBit(int number, int i, int v)
    {
        number =  number & ~(1 << i); // first reset bit i to be 0;
        number = number | (v << i); // next, set the bit i to be value v

        return number;
    }


}