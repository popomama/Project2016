using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project2016.Helpers;

namespace Project2016.LinkedList
{
    class CodeCrack_LL
    {
        //v6 2.3 Delete Middle Node: Implement an algorithm to delete a node in the middle(ie. any node but the first and 
        // last node, not necessarilyt the exact middle) of a singly linked list, giveon only access to that node.
        //Example:
        // input: the node c from the LL a->b->c->d->e->f
        // result: nothing is returned, but the new LL looks like a->b->d->e->f
        bool CC_LL23_v6_RemoveMiddleNode(LList<int> list, Node<int> nd)
        {
            if (nd == null || nd.Next == null)
                return false;  // nd is not in the middle, so return false, and nothing changes/is removed

            nd.Value = nd.Next.Value;
            nd.Next = nd.Next.Next;

            return true;
        }

        //v6 2.4 Write code to partition a linked list around a value x, such that all nodes less than x come before
        // all nodes greater than or equal to x. if x is contained within the list, the values of x only need to be 
        // after the elements less than (x). The partition element x can appear anywhere in the "right partition"; it 
        // doesn't need to appear between the left and right partitions.
        //Example:
        //INPUT  3->5->8->5->10->2->1 (partition =5)
        //Output 3->1->2->10->5->5->8
        public Node<int> CC_v6_2_4_Partition(LList<int> ll, int partition)
        {
            Node<int> currentNode = ll.head, smallHead = null, smallTail = null, bigHead = null, nextNode = null;
          
            while (currentNode!=null)
            {
                nextNode = currentNode.Next;

                if (currentNode.Value > partition)
                {
                    if (bigHead == null)
                    {
                        bigHead = currentNode;
                        bigHead.Next = null;
                    }
                    else
                    {
                        currentNode.Next = bigHead;
                        bigHead = currentNode;
                    }
                }
                else
                {
                    if (smallHead == null)
                    {
                        smallHead = currentNode;
                        smallTail = currentNode;

                    }
                    else
                    {
                        currentNode.Next = smallHead;
                        smallHead = currentNode;
                    }
                }
                currentNode = nextNode;
            }

            if (smallTail != null)
            {
                smallTail.Next = bigHead;
                return smallHead;
            }

            return bigHead;
        }


        //v6 2.5 Intersection:
        //Given two singly linked list, determine if the two lists intersect. Return the intersecting node. Note that
        //the intersection is defined based on reference, not value. That is , if the kth node of the first linked list
        // is the exact same node(by reference) as the jth node of the 2nd linked list, then they are intersecting.
        Node<int> CC_v6_25_findIntersection(Node<int> nd1, Node<int> nd2)
        {
            //first calculate the length of the two LLs l1, l2
            int len1 = 0, len2 = 0;
            Node<int> temp = nd1;

            //notice: one improvement can be done in the first path when calculating the length is to get the tail of both
            // then compare the tail, if they are not equal then return false immediately.
            len1 = calculateLength(nd1);
            len2 = calculateLength(nd2);

            if (len1 == 0 || len2 == 0)
                return null;

            int diff = 0;
            if(len1>len2)
            {
                diff = len1 - len2;
                while (diff > 0)
                {
                    nd1 = nd1.Next;
                    diff--;
                }
            }
            else
            {
                diff = len2 - len1;
                while (diff > 0)
                {
                    nd2 = nd2.Next;
                    diff--;
                }
            }

            while(nd1!=null&&nd2!=null)
            {
                if (nd1 == nd2)
                    return nd1;
                else
                {
                    nd1 = nd1.Next;
                    nd2 = nd2.Next;
                }
            }
            return null;

        }

        private int calculateLength(Node<int> nd1)
        {
            int length = 0;
            while(nd1!= null)
            {
                nd1 = nd1.Next;
                length++;
            }

            return length;
        }

        //You have two numbers represented by a linked list, where each node
        //contains a single digit.The digits are stored in forward order, such that the 1's
        //digit is at the head of the list.Write a function that adds the two numbers and
        //returns the sum as a linked list.
        //Example:
        //Given 6->1->7 + 2->9->5. That is, 617 + 295.
        //Return 9->1->2. That is, 912.
        public Node<int> AddTwoLL(Node<int> nd1, Node<int> nd2)
        {
            Node<int> result = new Node<int>(-1);
            Node<int> prev=null;

            nd1 = ReverseNodeList(nd1);
            nd2 = ReverseNodeList(nd2);

            int carry = 0;
            int val;
            Node<int> current=null;
            while (nd1 != null && nd2!=null)
            {
                val = nd1.Value + nd2.Value + carry;
                carry = val / 10;
                val = val % 10;
                current = new Node<int>(val);
                current.Next = prev;
                prev = current;

                nd1 = nd1.Next;
                nd2 = nd2.Next;

            }

            //between nd1 and nd2, at least one is null;
            Node<int> nd=null;
            if (nd1 == null)
                nd = nd2;
            else
                nd = nd1;


            if (current != null)//we have added some bits from low to high
            {
                while (nd != null)
                {
                    val = nd.Value+carry;
                    carry = val / 10;
                    val = val % 10;
                    prev = current;

                    current = new Node<int>(val);
                    current.Next = prev ;
//                    current = current.Next;

                    nd = nd.Next;
                }

                if(carry!=0)
                {
                    nd = new Node<int>(1);
                    nd.Next = current;
                    current = nd;
                    //current = current.Next;
                }

                result = current;
            }
            else//one of the original list is empty
                result = ReverseNodeList(nd);

            return result;
        }

        //reverse the linked list
        Node<int> ReverseNodeList(Node<int> nd)
        {
            Node<int> current = nd;
            Node<int> pre = null, next; 

            while(current!=null)
            {
                next = current.Next;
                current.Next = pre;
                pre = current;
                current = next;
            }

            return pre;
        }


    }
}
