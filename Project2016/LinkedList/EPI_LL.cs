using System;
using System.Collections.Generic;
using System.Text;
using Project2016.Helpers;

namespace Project2016.LinkedList
{
    class EPI_LL
    {
        //write a function that takes L and F, and returns the merge of L and F.
        // assuming both L and F are in sorted order(assending), and the merged LL should be in sorted order.
        // Your code should use O(1) additional storage. 
        public  Node<T>  EPI_LL_7_1_Merge<T>(LList<T> first, LList<T> second) where T : IComparable<T>
        {
            
             Node<T> firstNode = first.head;
             Node<T> secondNode = second.head;

             Node<T> newHeadNode=null, newTailNode=null;
             
             while(firstNode!=null && secondNode!=null)
             {
                 if(firstNode.Value.CompareTo(secondNode.Value)<=0)
                 {
                     appendNode(ref newHeadNode, ref newTailNode, ref firstNode);
                     firstNode=firstNode.Next;
                 }
                 else
                 {
                     appendNode(ref newHeadNode, ref newTailNode, ref secondNode);
                     secondNode=secondNode.Next;
                 }
             }

             if(firstNode ==null)
                 appendNode(ref newHeadNode, ref newTailNode, ref secondNode);
             if(secondNode ==null)
                  appendNode(ref newHeadNode, ref newTailNode, ref firstNode);
             
             return newHeadNode;

         

        }

        private void appendNode<T>(ref Node<T> newHeadNode, ref Node<T> newTailNode, ref Node<T> linkedListNode)
        {
            if (newHeadNode!=null)
                newTailNode.Next  = linkedListNode;
            else
                newHeadNode = linkedListNode;
            
            newTailNode = linkedListNode;

        }

       

        //EPI_LL_7_2Given a reference to the head of a singly linked list L, how would you determin  
        // whether L ends in a null  or reaches a cycle of nodes?
         public Node<T>  EPI_LL_7_2_Cycle<T>(LList<T> list)
        {
             //step 1 to detect a circle, ussing two pointers
             bool bCycle = false;
             Node<T> ndFast = list.head, ndSlow = list.head;
             while(ndFast!=null && ndFast.Next!=null && ndSlow!=null && !bCycle)
             {
                 ndFast = ndFast.Next.Next;
                 ndSlow = ndSlow.Next;
                 if (ndSlow == ndFast)
                     bCycle = true;

             }

             int length=0;
             //step 2: find the lengh of the cycle
             if (bCycle) // cycle found
             {
                 ndFast = ndFast.Next;
                 while (ndFast != ndSlow)
                 {
                     length++;
                     ndFast = ndFast.Next;
                 }
                 length++;

             }
             else
                 return null; // no cycle;
             
             //step 3: locate the start of the cycle
             ndFast = list.head;
             ndSlow = list.head;

             for (int i = 0; i < length; i++) // move the fast node length steps so that ndFast and ndSlow are length steps away
                 ndFast = ndFast.Next;

             while(ndSlow != ndFast)
             {
                 ndFast = ndFast.Next;
                 ndSlow = ndSlow.Next;

             }

             return ndSlow; //once ndSlow meets ndFast, the start of the loop is found

            
        }

        //EPI_LL_7_3 Write a function that takes a sorted circular singly linked list and a pointer
        // to an arbitrary node in this linked list, and returns the median of the linked list.
        public int  EPI_LL_7_3_Median(Node<int> nd) //where T : IComparable<T>, I
         {
             Node<int> smallNode;
             int nodeNumber=0;
            //step 0: 
             if (nd.Next == null)
                 throw new Exception("not a valid circluar LL");

             if (nd.Next == nd)
                 return nd.Value;

            
            //step 1: find the length of the circular length
             Node<int> currentNode = nd;
             bool isIdentical = true; 
            do
             {
                 currentNode = currentNode.Next;
                 nodeNumber++;

                 if (currentNode.Value != nd.Value)
                     isIdentical = false;
             }
             while (currentNode != nd);

            if (isIdentical == true)
                return currentNode.Value;

             //step1: find the node with the smallest value ndFirst
             smallNode = nd;
            while (smallNode.Next.Value < smallNode.Value)
                 smallNode = smallNode.Next;
            //smallnode now points the largest value, move to the next;
            smallNode = smallNode.Next;

            //step 3: move length/2 steps from ndFirst
            //we may use the right shift for the division
            int movestep = nodeNumber%2 ==0?nodeNumber/2-1:nodeNumber/2;
            currentNode = smallNode;
            for (int i = 0; i < movestep; i++)
                currentNode = currentNode.Next;

            if (nodeNumber % 2 == 0)
                return (currentNode.Value + currentNode.Next.Value) / 2;
            else
                return currentNode.Value;


         }

        //EPI_LL_7_4 Let h1 and h2 be the heads of lists L1 and L2. Assume that L1 and L2 are well-formed, that is
        //each consists of a finite sequence of nodes.(neither one has a cycle.) how would you determine if there exists
        // a node r reachable from both h1 and h2 by following the next fiedls. If such a node exists, find the node that
        // appears earliest
        public Node<T> EPI_LL_7_4_OverlapListing<T>(LList<T> L1, LList<T> L2)
        {
            //step1: calculate the lenth of L1 and L2
            int length1 = 0, length2 = 0;
            Node<T> nd1 = L1.head, nd2 = L2.head;
            while (nd1 != null)
            {
                length1++;
                nd1 = nd1.Next;
            }

            while (nd2 != null)
            {
                length2++;
                nd2 = nd2.Next;
            }

            //step2: move the longer list abs(length1-length2) steps first, so that the remaining of both have the same length
            if (length1 >= length2)
            {
                nd1 = L1.head;
                for (int i = 0; i < length1 - length2; i++)
                    nd1 = nd1.Next;
            }
            else
            {
                nd2 = L2.head;
                for (int i = 0; i < length2 - length1; i++)
                    nd2 = nd2.Next;
            }

            //step3: move both list synchronously, and they will meet at the first merged node if they have common node
            while (nd2 != null && nd1 != null && nd2 != nd1)
            {
                nd1 = nd1.Next;
                nd2 = nd2.Next;
            }

            return nd1;
        }

        //EPI_7_5  Let h1 and h2 be the heads of lists L1 and L2. Assume that L1 and L2 may each or both have a cycle.
        // if such a node exists, return a node that appears first when traversing the lists. This node may not be unique.
        // If L1 has a cyccle <n0, n1,..., nk-1,n0> , where n0 is the first node envcountered when traversing L1, then L2
        // may have the same cycle but a differenct first node.
         public Node<T> EPI_LL_7_5_OverlapListingCycle<T>(LList<T> L1, LList<T> L2)
        {
            //basic idea is to follow EPI_LL_7_4 and EPI_LL_7_2_Cycle

             //step1 determin if L1 and L2 has cycle
            Node<T> nd1 = EPI_LL_7_2_Cycle<T>(L1);
            Node<T> nd2 = EPI_LL_7_2_Cycle<T>(L2);

            if (nd1 == null && nd2 == null)// both lists are well-formed, use 7_4 to find the first node that merges
                return EPI_LL_7_4_OverlapListing<T>(L1, L2);

             
            if (nd1 != null && nd2 != null)// both lists have the  cycle.
            {
                //we need to find out the overlapping node if there is one
                Node<T> tempNode = nd2; // set the tempnode start at the start of the cycle in L2
                
                do
                {
                    tempNode = tempNode.Next; //move tempNode until either it hits the start of cycle of L1(i.e. we found the overlapping node).
                                                // or tempNode hits the start of the cycle in L2 again(i.e. there is no over lap between the two lists.)

                }
                while (tempNode != nd2 && tempNode != nd1);
                if (tempNode == nd1)
                    return nd1;
                else
                    return null;


            }
            else// one of the lists has cycle but the other doesn't , so no overlap
                return null;




    
        }
    }
}
