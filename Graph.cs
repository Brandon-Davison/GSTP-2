using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace GTSP_2
{
    /// <summary>
    /// Weighted graph implementation using an adjacency list.
    /// </summary>
    public class Graph
    {
        public Dictionary<Vertex, LinkedList<KeyValuePair<Vertex, Edge>>> Adj { get; }
        private Canvas canvas;

        public static int VertexCount { get; }
        public static int EdgeCount { get; }

        /// <summary>
        /// Creates new graph
        /// </summary>
        public Graph(Canvas canvas)
        {
            //adj = new Dictionary<Vertex, LinkedList<Vertex>>();
            Adj = new Dictionary<Vertex, LinkedList<KeyValuePair<Vertex, Edge>>>();
            this.canvas = canvas;
        }

        /// <summary>
        /// Adds unconnected vertex to graph
        /// </summary>
        /// <param name="v">Vertex to add</param>
        public void AddVertex(Vertex v)
        {
            Adj[v] = new LinkedList<KeyValuePair<Vertex, Edge>>();
        }

        /// <summary>
        /// Add u and v to adjacency matrix
        /// </summary>
        /// <param name="u">Vertex 1</param>
        /// <param name="v">Vertex 2</param>
        public void AddEdge(Vertex u, Vertex v)
        {
            Edge edge = new Edge(u, v, canvas);
            Adj[u].AddLast(new KeyValuePair<Vertex, Edge>(v, edge));
            Adj[v].AddLast(new KeyValuePair<Vertex, Edge>(u, edge));
        }

        /// <summary>
        /// TODO: Add support for multiple edges
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public Edge GetConnectedEdges(Vertex v)
        {
            if (Adj[v].Count == 0) return null;
            return Adj[v].First.Value.Value;
        }

        /// <summary>
        /// Disclaimer: I've coded Dijstra's before just for interview prep, but
        /// this implementation was found online.
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="source"></param>
        /// <param name="verticesCount"></param>
        public static void Dijkstra(int[,] graph, int source, int verticesCount)
        {
            int[] distance = new int[verticesCount];
            bool[] shortestPathTreeSet = new bool[verticesCount];

            for (int i = 0; i < verticesCount; ++i)
            {
                distance[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
            }

            distance[source] = 0;

            for (int count = 0; count < verticesCount - 1; ++count)
            {
                int u = MinimumDistance(distance, shortestPathTreeSet, verticesCount);
                shortestPathTreeSet[u] = true;

                for (int v = 0; v < verticesCount; ++v)
                {
                    if (!shortestPathTreeSet[v] && Convert.ToBoolean(graph[u, v]) && distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
                    {
                        distance[v] = distance[u] + graph[u, v];
                    }
                }
            }
        }

        /// <summary>
        /// Finds the min distance for Dijkstra's
        /// </summary>
        /// <param name="distance"></param>
        /// <param name="shortestPathTreeSet"></param>
        /// <param name="verticesCount"></param>
        /// <returns></returns>
        private static int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
        {
            int min = int.MaxValue;
            int minIndex = 0;

            for (int v = 0; v < verticesCount; ++v)
            {
                if (shortestPathTreeSet[v] == false && distance[v] <= min)
                {
                    min = distance[v];
                    minIndex = v;
                }
            }
            return minIndex;
        }

    }
}
