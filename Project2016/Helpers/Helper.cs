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

        public static void swap(KeyValuePair<int, double>[] items, int i, int j)
        {
            KeyValuePair<int, double> temp = items[i];
            items[i] = items[j];
            items[j] = temp;  

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

    class adjVertex 
    {
       public  int dest;
       public double  weight;
      // public List<VertexG> adjacencyList;   
      
        public adjVertex(int dest,double weight)
        {
            this.dest = dest;
            this.weight = weight;
        }      
    }

    class GraphG
    {
       public int vertexNumber; //number of vertices
        //int startVertex;
        // VertexG[] vertexes;
        double[] pathWeights;
        int[] position;
        public List<Dictionary<int, double>> adjacencyList; //key value pair record the destination and weight between source and destination
     //   pair

        public GraphG(int number)
        {
            vertexNumber = number;
            adjacencyList = new List<Dictionary<int, double>>();

            //for(int i=0;i<vertexNumber;i++)
            //{
            //    adjacencyList[i] = new List<Dictionary<int, double>>(); // initialize each individual adjacentList
            //}
            //pathWeights = new double[vertexNumber];
            //position = new int[vertexNumber];

        }

        public void AddEdge(int source, int destination, double weight)
        {
            //adjancencyList[source].Add(destination);
            adjacencyList[source].Add(destination, weight);
        }

        //public int StartVertex {
        //    get { return startVertex; }
        //    set { startVertex = value; }
        //}
        //public void shortestPath(int start) // function builds the shortest path from start point
        //{s

        //}

    }

    //this is a generic heap, each item has a <key,value> pair
    class HeapG
    {
        int capacity; // the capacity of the heap
        int count;  // current size, count can't exceed capacity
        public KeyValuePair<int, double>[] items;
        int[] itemPositions; // this array is used to quickly locate a specific item in the heap when doing lookup
                            // the itemPositions array is important for us to get item in the heap in O(1) time 
        public HeapG(int capacity = 10)
        {
            this.capacity = capacity;
            items = new KeyValuePair<int, double>[capacity];
            count = 0;
            itemPositions = new int[capacity];

        }


        public void Insert(KeyValuePair<int, double> pair)
        {
            if (capacity == count)
                return; //the capacity is full, can't add new item;
            else
            {
                items[count] = pair;  // add the value to the last element
                itemPositions[count] = count;// set the position
                count++;    // increase the count
                BubbleUp(count - 1);      // Bublle up the last value

            }

        }

        private void BubbleUp(int currentIndex)
        {
            while (currentIndex > 0) //keep looping until it reaches the root;
            {
                if (items[currentIndex].Value < items[(currentIndex - 1) / 2].Value)//only need to move up if the current node > its parent
                {
                    Helper.swap(items, currentIndex, (currentIndex - 1) / 2);
                    itemPositions[items[currentIndex].Key] = currentIndex;
                    itemPositions[items[(currentIndex - 1) / 2].Key] = (currentIndex - 1) / 2;
                    currentIndex = (currentIndex - 1) / 2; // reset the currentIndex to its parent
                }
                else
                    return; //otherwise, we can return
            }
        }

        //take the minimum value off the heap
        public double DeleteMin()
        {
            if (count == 0)
                throw new Exception("no value to delete");

            double minValue = items[0].Value;

            if (count > 1)

            {
                items[0] = items[count - 1]; //move the last to the root
                count--; //redcue the count #

                itemPositions[items[0].Key] = 0;
               // itemPositions[items[currentIndex * 2 + 1].Key] = currentIndex * 2 + 1;

                TrippleDown(0);
            }
            else // the heap is empty after the minimum is taken off
                count--;

            return minValue;

        }


        private void TrippleDown(int currentIndex)
        {
            //            int temp;
            while (currentIndex * 2 + 1 <= count - 1)// only loop until the current node is a leaf
            {
                if (count == 2 * currentIndex + 1)// the current node only has left child, but no right child, 
                {
                    if (items[currentIndex].Value <= items[currentIndex * 2 + 1].Value) // if the current node is smaller than its left child, swap the value
                    {
                        Helper.swap(items, currentIndex, currentIndex * 2 + 1);

                        itemPositions[items[currentIndex].Key] = currentIndex;
                        itemPositions[items[currentIndex * 2 + 1].Key] = currentIndex * 2 + 1;

                        //temp = Items[currentIndex * 2 + 1];
                        //Items[currentIndex * 2 + 1] = Items[currentIndex];
                        //Items[currentIndex] = temp;

                    }
                    //since the current child has no right child, after swap, it's already leaf, we stop here.                    
                }
                else//the current node has both left and right child
                {
                    if ((items[currentIndex].Value <= items[currentIndex * 2 + 1].Value) && (items[currentIndex].Value <= items[currentIndex * 2 + 2].Value))
                        return;
                    else
                    {
                        if (items[currentIndex * 2 + 1].Value < items[currentIndex * 2 + 2].Value) // if left<right, swap current with left
                        {
                            Helper.swap(items, currentIndex, currentIndex * 2 + 1);
                            itemPositions[items[currentIndex].Key] = currentIndex;
                            itemPositions[items[currentIndex * 2 + 1].Key] = currentIndex * 2 + 1;

                            //temp = Items[currentIndex * 2 + 1];
                            //Items[currentIndex * 2 + 1] = Items[currentIndex];
                            //Items[currentIndex] = temp;
                            currentIndex = currentIndex * 2 + 1; // reset the current index
                        }
                        else// if left>right, swap current with right
                        {
                            Helper.swap(items, currentIndex, currentIndex * 2 + 2);
                            itemPositions[items[currentIndex].Key] = currentIndex;
                            itemPositions[items[currentIndex * 2 + 2].Key] = currentIndex * 2 + 2;
                            //temp = Items[currentIndex * 2 + 2];
                            //Items[currentIndex * 2 + 2] = Items[currentIndex];
                            //Items[currentIndex] = temp;
                            currentIndex = currentIndex * 2 + 2; //reset the current index;
                        }
                    }
                }
            }
        }

    }
    //MiniHeap
    //3 operations: Insert(percolate up), DeletreMin(percolate down), CreateHeap
    // On Average it takes 2.67 comparision to do an Insert, but worst case is O(LogN)
    //Other Operations: DecreaseKey(p, delta) at position p, IncreaseKey(p, delta) at position p, removeKet(p) at position p
    class Heap
    {
        int capacity; // the capacity of the heap
        int count;  // current size, count can't exceed capacity
       public int[] Items;

        public Heap(int capacity=10)    // set the default capacity value to 10
        {
            this.capacity = capacity;
            Items = new int[capacity];
            count = 0;

        }

        // add new number to the heap
        public void insert(int value) 
        {
            if (capacity == count)
                return; //the capacity is full, can't add new item;
            else
            {
                Items[count] = value;  // add the value to the last element
                count++;    // increase the count
                BubbleUp(count-1);      // Bublle up the last value

            }

        }

        //take the minimum value off the heap
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
            else // the heap is empty after the minimum is taken off
                count--;

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
