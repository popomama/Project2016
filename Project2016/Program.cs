using System;
using System.Collections.Generic;
using System.Text;
using Project2016.LinkedList;
using Project2016.Array;
using Project2016.TreeGraph;
using Project2016.Helpers;
using Project2016.SortingSeraching;
using System.IO.Compression;
using Project2016.DP;
using Project2016.Generalquestions;



namespace Project2016
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestLL.testEPI701();
            // TestArray.testCC_Array_CCV6_IsPalindromePermutation();
            //TestLL.test_CC_v6_2_4_Partition();
            //TestTreeGraph.Test_CC_V6_47_BuildOrder_All();
            //TestGetMedian();
            // TestHelper.TestHeap();
            TestCoin();
            // GFG gfg = new GFG();
            //gfg.TestCoinCount();
            //TestArray.testMisc_Array_FindPermutation();
            //            TestSort.TestSortLinkedList();
            // TestSort.TestKLinkedList();
            // TestLL.test_CC_AddTwoLL();
            //TestArray.testMedianFromSortedArray();

        }

        public static void TestCoin()
        {
            //int[] arr = { 8, 15, 3, 7 };

            int[] arr={ 20, 30, 2, 2, 2, 10 };
            int[] arr2 = { 3, 2, 2, 3, 1, 2 };
            int max = DP.CoinLine.FindCoinLine(arr2);
        }
        public static void TestGetMedian()
        {
            int size = 10;
            int[] arr = new int[size];
            Random r = new Random();
            for(int i=0;i<size;i++)
            {
                arr[i] = r.Next(100);

            }
            int[] medianArr = Google1.GetMedian(arr);

        }
        public static void PrintNodeListTest()
        {

            Node<int> nd = Node<int>.BuildIntList(10, 100);
            Node<int>.PrintNodeList(nd);

        }

        private static void testzip()
        {
            //throw new NotImplementedException();

            string sourceDirectoryName= @"C:\Temp\MTTest\MTP771_Wei_Xia_Original";
            string destinationArchiveFileName = @"C:\Temp\MTTest\Wei771Archive.zip";


            //            public static void CreateFromDirectory(
            //    string sourceDirectoryName,
            //    string destinationArchiveFileName,
            //    CompressionLevel compressionLevel,
            //    bool includeBaseDirectory,
            //    Encoding entryNameEncoding
            //)


            ZipFile.CreateFromDirectory(sourceDirectoryName, destinationArchiveFileName, CompressionLevel.Optimal, false);
        }
    }
}
