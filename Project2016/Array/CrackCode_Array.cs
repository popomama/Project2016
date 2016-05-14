using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2016.Array
{
    class CrackCode_Array
    {

        //1.4 v6 Palindrome Permutation: Given a string, write a function to check if it is a permutation of a
        //palindrome. A palindrome is a word or phase that is the same forwards and abckwards. A permutation is a 
        //rearrangement of letters. 
        //Example:
        //Input: Tact Coa
        //Otput:True (permutations: "taco cat", "atco cta", etc.) 
        //Idea: 1. use hashcode,
        //Idea: 2. use bit operation to save space
        public bool CCV6_IsPalindromePermutation(string org)
        {
            bool[] CharArrOdd = new bool[26];
            for (int i = 0; i < 26; i++)
                CharArrOdd[i] = false;


            for (int i = 0; i < org.Length; i++)
            {
                if ((org[i] <= 'z') && (org[i] >= 'a'))
                    CharArrOdd[org[i] - 'a'] = CharArrOdd[org[i] - 'a'] == false ? true : false;
                else if ((org[i] <= 'Z') && (org[i] >= 'A'))
                    CharArrOdd[org[i] - 'A'] = CharArrOdd[org[i] - 'A'] == false ? true : false;
                //if(org[i]!=' ')
                //    CharArrOdd[org[i]] = CharArrOdd[org[i]] == false ? true : false;

            }
            int oddNumber = 0;
            for (int i = 0; i < 26; i++)
            {
                if (CharArrOdd[i])
                    oddNumber++;
                if (oddNumber > 1)
                    return false;
            }

            return true;

        }


        public bool CCV6_IsPalindromePermutation_sol2(string org)
        {
            int index = 1;
            int bitVector = 0;
            for (int i = 0; i < org.Length; i++)
            {
                index = getCharNumber(org[i]);
                bitVector = toggle(bitVector, index);

            }

            //last step : check if there is at most ONE bit is set in the bitVestor;
            //if this is only 1 bit set,or 0 bit set, then bitVector & (bitVector - 1) ==0
            return (bitVector & (bitVector - 1)) == 0;
        }

        private int toggle(int bitVector, int index)
        {
            int mask = 1;
            if ((index >= 0) && (index < 26))
            {
                mask = 1 << index;
                if ((mask & bitVector) == 0)
                    bitVector |= mask;
                else
                    bitVector &= ~mask;
            }
            return bitVector;

        }

        int getCharNumber(char c)
        {
            if ((c <= 'z') && (c >= 'a'))
                return c - 'a';
            else if ((c <= 'Z') && (c >= 'A'))
                return c - 'A';
            else
                return -1;
        }


        //1.5 V6 One Away
        //There are three types of edits that can be performed on strings: insert,
        //remove a character, or replace a character. Given two strings, write a function 
        //to check if they are one edit(or zero edits) away.
        //Example:
        //pale, ple --> true   pales, pale --> true, pale, bale --> true, pale, bake --> false;
        public bool CCV6_OneEditAway(string s1, string s2)
        {
            int length1 = s1.Length, length2 = s2.Length;
            if (Math.Abs(length1 - length2) > 1)
                return false;

            if (length2 == length1)
                return isOneEditAway(s1, s2);

            bool bResult = false;
            if (length2 < length1)
            {
                return isOneInsertAway(s2, s1);
            }
            else
                return isOneInsertAway(s1, s2);

        }

        private bool isOneInsertAway(string s1, string s2)
        {
            int len = s1.Length;
            //bool bDifferentFirst = true;

            int index1 = 0, index2 = 0;
            
            while(index1<s1.Length&&index2<s2.Length)
            {
                if (s1[index1] != s2[index2])
                {
                    if (index1 != index2)// initially index1=index2, if they are different it means this is the 2nd difference, so it's more than two inserts away now
                        return false;
                    else
                        index2++; //this is the first insert, forward the index for the longer string
                }
                else
                {
                    index1++;
                    index2++;
                }
            }
            return true;
        }

        private bool isOneEditAway(string s1, string s2)
        {
            int len = s1.Length;
            bool bDifferentFirst = true;

            for(int i=0;i<len-1;i++)
            {
                if(s1[i]!=s2[i])
                {
                    if (!bDifferentFirst)
                        return false;
                    else
                        bDifferentFirst = false; //next found will be the 2nd difference
                }

            }

            return true;
        }
    }
}
