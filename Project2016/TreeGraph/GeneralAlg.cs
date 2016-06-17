using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project2016.Helpers;

namespace Project2016.TreeGraph
{
    class GeneralAlg
    {

        //Depth first search, 
        public void DFS(Graph g, int startVertex)
        {

            int numVertex = g.VertexNum;
            
            if (startVertex >= numVertex)
                return; // the startIndex is beyond the number of the vertices, return immediately

            bool[] isVisited = new bool[numVertex];
            for (int i = 0; i < numVertex; i++)
                isVisited[i] = false;//initialize the isVisited array to false;

            DFS(g, startVertex, isVisited);

        }
        //leverage recursive call to implement DFS
        private void DFS(Graph g, int currentVertex, bool[] isVisited)
        {
            isVisited[currentVertex] = true; // mark the current Vertex to be visited
            Console.Write(currentVertex + "->");

            //if the vertex is not visited, mark it as visited.
            isVisited[currentVertex] = true;
            for(int i=0;i<g.adjancencyList[currentVertex].Count;i++) // loop through the current adjacencyList
            {
                if (!isVisited[g.adjancencyList[currentVertex][i]])  // if the neighbor is not visisted, recurse
                    DFS(g, g.adjancencyList[currentVertex][i], isVisited);
            }
        }

        //leverage stack to implement DFS
        //private void DFS2(Graph g, Stack<int> workingStack, bool[] isVisited)
        //{

        //    int currentVertex, currentAdjacent;

        //    while(workingStack.Count>0)
        //    {
        //        currentVertex = workingStack.Pop();
        //        isVisited[currentVertex] = true;
        //        Console.Write(currentVertex + "->");

        //        for (int i = 0; i < g.adjancencyList[currentVertex].Count; i++) // loop through the current adjacencyList
        //        {

        //            currentAdjacent = g.adjancencyList[currentVertex][i];
        //            if (!isVisited[currentAdjacent])  // if the neighbor is not visisted, recurse
        //                workingStack.Push(currentVertex);
        //        }


        //    }
        //    isVisited[currentVertex] = true; // mark the current Vertex to be visited
        //    Console.Write(currentVertex + "->");

        //    //if the vertex is not visited, mark it as visited.
        //    isVisited[currentVertex] = true;
        //    for (int i = 0; i < g.adjancencyList[currentVertex].Count; i++) // loop through the current adjacencyList
        //    {
        //        if (isVisited[g.adjancencyList[currentVertex][i]])  // if the neighbor is not visisted, recurse
        //            DFS(g, g.adjancencyList[currentVertex][i], isVisited);
        //    }
        //}


        //breadth first search
        public void BFS(Graph g, int startVertex)
        {

            int numVertex = g.VertexNum;

            if (startVertex >= numVertex)
                return; // the startIndex is beyond the number of the vertices, return immediately

            bool[] isVisited = new bool[numVertex];
            for (int i = 0; i < numVertex; i++)
                isVisited[i] = false;//initialize the isVisited array to false;

            Queue<int> q = new Queue<int>();
            q.Enqueue(startVertex);
            BFS(g, q, isVisited);

        }

        private void BFS(Graph g, Queue<int> workingQueue, bool[] isVisited)
        {
            int currentVertex, currentAdjacent;

            while(workingQueue.Count!=0)    //loop until the working queue is empty
            {
                currentVertex = workingQueue.Dequeue(); // remove the first vertex in the queue

                isVisited[currentVertex] = true;      // mark the currentVex to be visited
                Console.Write(currentVertex + "->"); //print the current vertex

                for(int i=0;i<g.adjancencyList[currentVertex].Count;i++) //loop through the neighbors
                {
                    currentAdjacent = g.adjancencyList[currentVertex][i]; // get the next neighbor
                    if (!isVisited[currentAdjacent])    //if the neighbor is not visited yet, add it to the end of the queue
                        workingQueue.Enqueue(currentAdjacent);
                }
            }
        }


        //Find the shortest path from start vertex
        //complexity: O(V+E)
        int[] ShortestPath_Unweighted(Graph g, int startVertex)
        {

            int[] distance = new int[g.VertexNum];//record the path length;
            for (int i = 0; i < g.VertexNum; i++)
                distance[i] = -1; //initialize the value to -1 or infinite

            distance[startVertex] = 0; //set the distance of the startVertex to 0

            Queue<int> workingQueue = new Queue<int>();
            workingQueue.Enqueue(startVertex); // push the startVertex to working queue

            int currentAdjacent, currentVertex;

            while(workingQueue.Count>0) //loop through the working queue until it's empty
            {
                currentVertex = workingQueue.Dequeue(); // get the current Vertex


                for (int i=0;i<g.adjancencyList[currentVertex].Count;i++) //find all the neighbors
                {
                    currentAdjacent = g.adjancencyList[currentVertex][i]; //loop through the neighbors

                    if (distance[currentAdjacent] != -1) // this means the neighbor hasnt been visited yet
                        distance[currentAdjacent] = distance[currentVertex]++; // set the distance

                    workingQueue.Enqueue(currentAdjacent); //add the neighbor into the queue
                }
            }

            return distance;

        }


    }
}
