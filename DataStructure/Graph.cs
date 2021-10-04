using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructure
{
    class Graph
    {
        int vertex;
        Dictionary<int, LinkedList<int>> adjencyList;
        public Graph(int v)
        {
            vertex = v;
            adjencyList = new Dictionary<int, LinkedList<int>>();
            for (int i = 0; i < v; i++)
            {
                adjencyList[i] = new LinkedList<int>();
            }
        }
        public void AddEdge(int source, int dest)
        {
            adjencyList[source].AddLast(dest);
        }

        public void BFS(int startVertex)
        {
            bool[] visited = new bool[vertex];
            var queue = new Queue<int>();
            queue.Enqueue(startVertex);
            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                Console.WriteLine(vertex);
                visited[vertex] = true;
                foreach (var adVertex in adjencyList[vertex])
                {
                    if (visited[adVertex] == false)
                    {
                        queue.Enqueue(adVertex);
                    }
                }
            }
        }
        public void DFS(int startVertex)
        {
            bool[] visited = new bool[vertex];
            DFSUtil(startVertex, visited);
        }

        public void DFSUtil(int startVertex, bool[] visited)
        {
            visited[startVertex] = true;

            Console.Write(startVertex + " ");
            foreach (var vertex in adjencyList[startVertex])
            {
                if (visited[vertex] == false)
                {
                    DFSUtil(vertex, visited);
                }
            }
        }

        public static void GraphDriver()
        {
            Graph g = new Graph(4);

            g.AddEdge(0, 1);
            g.AddEdge(0, 2);
            g.AddEdge(1, 2);
            g.AddEdge(2, 0);
            g.AddEdge(2, 3);
            g.AddEdge(3, 3);

            Console.WriteLine(
                "Following is Depth First Traversal "
                + "(starting from vertex 2)");
            g.DFS(2);
            g.BFS(2);
        }
    }
}
