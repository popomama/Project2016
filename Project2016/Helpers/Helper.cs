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

    class Graph
    {
        public int VertexNum;
        public List<List<int>> adjancencyList;
        public int[] indgree;

        public Graph(int num)
        {
            this.VertexNum = num;
            adjancencyList = new List<List<int>>(VertexNum);
            indgree = new int[VertexNum];
            for (int i = 0; i < VertexNum; i++)
            {
                adjancencyList.Add(new List<int>());
                indgree[i] = 0;
            }
            

        }

        public void AddEdge(int source, int destination)
        {
            adjancencyList[source].Add(destination);
            indgree[destination]++;
        }
    }

    class Vertex
    {
        int value;
        int indegree;
       
    }

    //MiniHeap
    //3 operations: Insert(percolate up), DeletreMin(percolate down), CreateHeap
    // On Average it takes 2.67 comparision to do an Insert, but worst case is O(LogN)
    //Other Operations: DecreaseKey(p, delta) at position p, IncreaseKey(p, delta) at position p, removeKet(p) at position p
    class Heap
    {
        int capacity, count;
       public int[] Items;

        public Heap(int capacity=10)
        {
            this.capacity = capacity;
            Items = new int[capacity];
            count = 0;

        }

        public void insert(int value)
        {
            if (capacity == count)
                return; //the capacity is full, can't add new item;
            else
            {
                Items[count] = value;
                count++;
                BubbleUp(count-1);

            }

        }

        public int deleteMin()
        {
            if (count == 0)
                throw new Exception("no value to delete");

            int minValue = Items[0];
            
            if (count > 1)

            {
                Items[0] = Items[count - 1]; //move the last to the root
                count--; //redcue the count #

                TrippleDown(0);
            }

            return minValue;

        }

        

        private void TrippleDown(int currentIndex)
        {
//            int temp;
            while (currentIndex * 2 + 1 <= count - 1)// only loop until the current node is a leaf
            {
                if(count == 2*currentIndex+1)// the current node only has left child, but no right child, 
                {
                    if(Items[currentIndex]<=Items[currentIndex*2+1]) // if the current node is smaller than its left child, swap the value
                    {
                        Helper.swap(Items, currentIndex, currentIndex * 2 + 1);
                        //temp = Items[currentIndex * 2 + 1];
                        //Items[currentIndex * 2 + 1] = Items[currentIndex];
                        //Items[currentIndex] = temp;

                    }
                    //since the current child has no right child, after swap, it's already leaf, we stop here.                    
                }
                else//the current node has both left and right child
                {
                    if ((Items[currentIndex] <= Items[currentIndex * 2 + 1]) && (Items[currentIndex] <= Items[currentIndex * 2 + 2]))
                        return;
                    else
                    {
                        if(Items[currentIndex * 2 + 1] < Items[currentIndex * 2 + 2]) // if left<right, swap current with left
                        {
                            Helper.swap(Items, currentIndex, currentIndex * 2 + 1);

                            //temp = Items[currentIndex * 2 + 1];
                            //Items[currentIndex * 2 + 1] = Items[currentIndex];
                            //Items[currentIndex] = temp;
                            currentIndex = currentIndex * 2 + 1; // reset the current index
                        }
                        else// if left>right, swap current with right
                        {
                            Helper.swap(Items, currentIndex, currentIndex * 2 + 2);
                            //temp = Items[currentIndex * 2 + 2];
                            //Items[currentIndex * 2 + 2] = Items[currentIndex];
                            //Items[currentIndex] = temp;
                            currentIndex = currentIndex * 2 + 2; //reset the current index;
                        }
                    }
                }
            }
        }
        private void BubbleUp(int currentIndex)
        {
            while(currentIndex>0) //keep looping until it reaches the root;
            {
                if (Items[currentIndex] < Items[(currentIndex - 1) / 2])//only need to move up if the current node > its parent
                {
                    Helper.swap(Items, currentIndex, (currentIndex - 1) / 2);
                    currentIndex = (currentIndex - 1) / 2; // reset the currentIndex to its parent
                }
                else
                    return; //otherwise, we can return
            }
        }

        
    }

}
