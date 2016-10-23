using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project2016.Array
{
    class TestArray
    {
        public static void testCC_Array_CCV6_IsPalindromePermutation()
        {

            string s1 = "tact coa";
            CrackCode_Array cca = new CrackCode_Array();
            bool result = false;
            result = cca.CCV6_IsPalindromePermutation_sol2(s1);

            s1 = "abcd dcf";
            result = cca.CCV6_IsPalindromePermutation_sol2(s1);
        }

        public static void testMisc_Array_FindPermutation()
        {
            //            FindPermutation()
            Misc ms = new Misc();
            ms.FindPermutation(5, 2);

        }
    }
}
