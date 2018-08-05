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


    }
}
