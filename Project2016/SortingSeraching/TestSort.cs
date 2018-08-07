using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project2016.Helpers;

namespace Project2016.SortingSeraching
{
    class TestSort
    {

        public static void TestSortLinkedList()
        {
            Node<int> nd = Node<int>.BuildIntList(10, 100);
            Node<int>.PrintNodeList(nd);

            Sort1 st1 = new Sort1();
            Node<int> sortedNode = st1.SortList(nd);

            Node<int>.PrintNodeList(sortedNode);

        }

        public static void TestKLinkedList()
        {
            Node<int>[] ndList= new Node<int>[4];

            Sort1 st1 = new Sort1();

            for (int i = 0; i < 4; i++)

            {
               ndList[i]= Node<int>.BuildIntList(5, 100);
               ndList[i]= st1.SortList(ndList[i]);
                Console.Write("list " + i + ": ");
                Node<int>.PrintNodeList(ndList[i]);

            }
            //    Node<int>.PrintNodeList(nd);

            Node<int> sortedList = st1.MergeKSortedList(ndList.ToList());
            Console.Write("Final Sorted K list" + ": ");
            Node<int>.PrintNodeList(sortedList);

            //Node<int> sortedNode = st1.SortList(nd);

            //Node<int>.PrintNodeList(sortedNode);


        }


    }
}
