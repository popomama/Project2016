using System;
using System.Collections.Generic;
using System.Text;


namespace Project2016.Helpers
{
    class Helper
    {
        public static void swap(int[] arr, int i, int j)
        {

            int temp = arr[i];
            arr[i]= arr[j];
            arr[j]= temp;
        }
    }

    class Node<T>
    {
        public T Value;
        public Node<T> Next;

        public Node(T v)
        { Value=v; }

    }

    class LList<T>
    {
        public Node<T> head;
        public Node<T> tail;
        public LList()
        {
            head = null;
            tail = null; 
        }
        public LList(Node<T> head)
        { this.head = head;
        this.tail = head;

        }

        public void AddNode(Node<T> n)
        {
            if (head != null)
            {
                tail.Next = n;
                tail = n;
            }
            else
            {
                head = tail = n;
            }

        }       
            public void printList()
            {
                Node<T> currentNode = head;
                while(currentNode!=null)
                {
                    Console.Write(currentNode.Value+" -> ");
                    currentNode = currentNode .Next;
                }

                Console.WriteLine();
            }
    }

    class TreeNode
    {
        public int Value;
        public TreeNode Left;
        public TreeNode Right;
        public TreeNode(int v)
        {
            Value = v;
            Left = null;
            Right = null;   
        }
    }

    class Tree
    {
        public TreeNode root;
    }



}
