using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project2016.Helpers;

namespace Project2016.SortingSeraching
{
    class Sort1
    {

        //leetcode: Sort List | LeetCode OJ lintcode: (98) Sort List
        //Sort a linked list in O(n log n) time using constant space complexity.
        //note: the complexity means the number of the comparisons in O(nlogn), the node access will be much more. 
        public Node<int> SortList(Node<int> nd)
        {
            //only 1 element or empty in the list
            if (nd == null || nd.Next == null)
                return nd;


            Node<int> ndSorted;// = new Node<int>(-1); //this is the dummy head;

            Node<int> ndMid = FindMidNode(nd);// thie means at each level, it cost ~1.5n time to access the list, the overcost at all levels is 1.5nlogn

            
            Node<int> rightList = SortList(ndMid.Next);
            ndMid.Next = null;
            Node<int> leftList = SortList(nd);

            ndSorted = MergeList(leftList, rightList);

            return ndSorted;

        }

        private Node<int> FindMidNode(Node<int> nd)
        {
            if (nd == null || nd.Next == null)
                return nd; // return immediately if there is only one node or no node on the list;

            Node<int> ndSlow=nd, ndQuick=nd;

            while(ndQuick.Next!=null && ndQuick.Next.Next!=null)
            {
                ndSlow = ndSlow.Next;
                ndQuick = ndQuick.Next.Next;
            }

            return ndSlow;
        }

        private Node<int> MergeList(Node<int> ndLeft, Node<int> ndRight)
        {
            //Node<int> ndDummy = new Node<int>(-1);
            Node<int> ndDummy;
            Node<int> ndCurrent = new Node<int>(-1);
            ndDummy = ndCurrent;//ndDummy;
            while(ndLeft!=null && ndRight!=null)
            {
                if (ndLeft.Value > ndRight.Value)
                {
                    ndCurrent.Next = ndRight;
                    ndRight = ndRight.Next;
                }
                else
                {
                    ndCurrent.Next = ndLeft;
                    ndLeft = ndLeft.Next;
                }
                ndCurrent = ndCurrent.Next;

            }

            //deal with what's left
            if (ndLeft == null)
                ndCurrent.Next = ndRight;
            else
                ndCurrent.Next = ndLeft;

            //remove the dummy head point;
            return ndDummy.Next;
        }


        //Node<int> nd1 = Node<int>.BuildIntList(5, 100);
        //Node<int> nd2 = Node<int>.BuildIntList(5, 100);


    }
}
