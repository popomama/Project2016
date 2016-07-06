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
            //isVisited[currentVertex] = true;
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

        //use the heap to implement Dijkstra algorithm
        public void  ShortestPathDijHeap(Graph g, int start)
        {
           //
        }


        //calculate the shortestPath by using Dijkstra's algorithm
        //it's not using heap to compare so the performance is O(V2)
        public void ShortestPath(GraphG g, int start)
        {
            int vertexNumber = g.vertexNumber;

            double[] distance = new double[vertexNumber]; // the distance of each node from start point
            bool[] isMarked = new bool[vertexNumber]; // record node whose path has been decided
            int[] predecessor = new int[vertexNumber]; // the array help to print the path of the shortest path from start to the destination

            //initialization
            for (int i=0;i<vertexNumber;i++)
            {
                distance[i] = double.PositiveInfinity; //set the distance to be max initially
                isMarked[i] = false;
                predecessor[i] = -1;

            }

            distance[start] = 0; // the distance of the start is 0;

            int markedCount = 0; //record the number of nodes whose distance has been decided

            int closestUnmarkedNode = -1;  

            int neighbor; //record the neighbor v of current node u
            double weight;// weight between u and v

            while (markedCount<vertexNumber && closestUnmarkedNode!=-1) //loop through only if the number of nodes whose distance has been decided is smaller than the vertext number 
            {
                //we have to loop through the vertex every time when calling getClosestUnmarkedNode, it take O(V) each time
                closestUnmarkedNode = getClosestUnmarkedNode(isMarked, distance, vertexNumber);//ideally, binary heap is used to reduce the complexity to O(logV)

                if (closestUnmarkedNode >= 0) // only mark the closestunmarked node to be marked if the value is not -1
                {
                    isMarked[closestUnmarkedNode] = true;

                    foreach (KeyValuePair<int, double> kvp in g.adjacencyList[closestUnmarkedNode]) // find all the neighbours of the current closestUnmarkedNode
                    {

                        neighbor = kvp.Key; //index of the neighbor,
                        weight = kvp.Value;//weight o fthe neighbor
                        if (distance[neighbor] > distance[closestUnmarkedNode] + weight) // if the distance to the neighbor via the current closestUnmarkedNode goes down
                        {
                            distance[neighbor] = weight + distance[closestUnmarkedNode]; // update the distance of the neighbor. If heap is used, we need to re-heapfy once the distance is changed to the node
                            predecessor[neighbor] = closestUnmarkedNode; // set the predecessor of the neighbor to be the current node, the predecessor[neighbor] may still change in the future
                        }
                    }

                    markedCount++; // we have one more node whose distance has been decided.
                }
            }

            PrintoutPath(start, distance, predecessor);

        }

        private void PrintoutPath(int start, double[] distance, int[] predecessor)
        {
            for(int i =0;i<predecessor.Length;i++)
            {
                PrintPath(start, i, distance, predecessor);
                Console.WriteLine(distance[i]);
            }
        }

        private void PrintPath(int start, int current, double[] distance, int[] predecessor )
        {
            if (start == current)
                Console.Write(start + "-->");
            else if(predecessor[current]==-1)
            {
                Console.WriteLine("No path exists from " + start + " to " + current);
            }
            else
            {   //recursively call
                PrintPath(start, predecessor[current], distance, predecessor);
                Console.Write(current + "-->");
            }
        }


        //find the node that hasn't been marked and has the min value in the distance array
        int getClosestUnmarkedNode(bool[] isMarked, double[] distance, int numberVertex)
        {
            double minDistance = double.PositiveInfinity; 
            int closestUnmarked = -1;
            for(int i=0;i<numberVertex;i++) //we have to loop through the vertex every time
            {
                if(!isMarked[i]&&minDistance>=distance[i])
                {
                    minDistance = distance[i];
                    closestUnmarked = i;
                }
            }

            return closestUnmarked;
        }


    }
}
