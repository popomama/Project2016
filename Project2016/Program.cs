﻿using System;
using System.Collections.Generic;
using System.Text;
using Project2016.LinkedList;
using Project2016.Array;
using Project2016.TreeGraph;
using Project2016.Helpers;
using Project2016.SortingSeraching;
using System.IO.Compression;
using Project2016.DP;



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

            //TestHelper.TestHeap();
            // GFG gfg = new GFG();
            //gfg.TestCoinCount();
            //TestArray.testMisc_Array_FindPermutation();
//            TestSort.TestSortLinkedList();
            TestSort.TestKLinkedList();
            


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
