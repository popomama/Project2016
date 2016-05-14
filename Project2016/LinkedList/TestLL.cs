using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Project2016.Helpers;


namespace Project2016.LinkedList
{
    public class TestLL 
    {
       public static void testEPI701()
        {
            LList<int> l1, l2;
            Node<int> currentNode = null;
            l1 = new LList<int>();
            l2 = new LList<int>();
           for(int i = 0; i<6;i++)
           {
               currentNode = new Node<int>(2*i+1);
               l1.AddNode(currentNode);
               currentNode = new Node<int>(2*i);
               l2.AddNode(currentNode);

           }

           l1.printList();
           l2.printList();

           EPI_LL epiLL = new EPI_LL();
           Node<int> newHead = epiLL.EPI_LL_7_1_Merge(l1, l2);
           LList<int> mergedLL = new LList<int>(newHead);
           mergedLL.printList();

        }

        public static void test_CC_v6_2_4_Partition()
        {
            LList<int> l1 = new LList<int>();
            Node<int> tempNode;
            int temp;
            Random r = new Random();
            for (int i=0;i<10;i++)
            {
                temp = r.Next(50);
                tempNode = new Node<int>(temp);
                l1.AddNode(tempNode);
            }

            l1.printList();
            CodeCrack_LL ccLL = new CodeCrack_LL();
            
            tempNode = ccLL.CC_v6_2_4_Partition(l1, 25);
            l1.head = tempNode;
            l1.printList();
        }
    }
}