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
         

    }
}
