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

        //Merge k sorted linked lists and return it as one sorted list.
        //Analyze and describe its complexity.
        //we use devide and conquer.
        //Assuming there are N elements in each sorted array, then the complexity is O(N KlogK) and use O(1) space
        //Alternatively, we can also use Heap(creating a heap with K node, each time when removing a node,we move the node to the
        //next in the current. It taks O(N KlogK), but takes O(N) space
        public Node<int> MergeKSortedList(List<Node<int>> nodeList)
        {
            int size = nodeList.Count;
            if (size == 0)
                return null;
            if (size == 1)
                return nodeList[0];
            int mid = size / 2;

            Node<int> firstHalf = MergeKSortedListHelper(nodeList, 0, mid);
            Node<int> secondhalf = MergeKSortedListHelper(nodeList, mid+1, size-1);

            Node<int> finalList =MergeList(firstHalf, secondhalf);
            return finalList;
        }

        private Node<int> MergeKSortedListHelper(List<Node<int>> nodeList, int start, int end)
        {
            if (start > end)
                return null;
            if (start == end)
                return nodeList[start] ;
            int mid = (start + end) / 2;

            Node<int> firstHalf = MergeKSortedListHelper(nodeList, start, mid);
            Node<int> secondhalf = MergeKSortedListHelper(nodeList, mid + 1, end);

            return MergeList(firstHalf, secondhalf);


        }
    }
}
