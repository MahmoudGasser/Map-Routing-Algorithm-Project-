using Map.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map.Graph
{
    class Dijkstra
    {
         
        internal static (List<int> path, double totalTime, double vehicleDistance, double walkingDistance)
        FindShortestPath(Dictionary<int, List<Edge>> graph, Node[] nodes, double x1, double y1, double x2, double y2, double R)
        {
            var (virtualStart, virtualEnd, virtualStartEdges, virtualEndEdges) = Graph.FindReachableNodes(nodes, x1, y1, x2, y2, R);

            int totalNodes = nodes.Length + 2;

           
            graph[virtualStart] = virtualStartEdges;
            graph[virtualEnd] = new List<Edge>();

            foreach (Edge edge in virtualEndEdges)
            {
                if (!graph.ContainsKey(edge.DistnationNode))
                {
                    graph[edge.DistnationNode] = new List<Edge>();
                }

                Edge newEdge = new Edge(virtualEnd, edge.speed, edge.distance);
                newEdge.time = edge.time;
                graph[edge.DistnationNode].Add(newEdge);
            }


            
            double[] times = new double[totalNodes];
            int[] previous = new int[totalNodes];
            bool[] visited = new bool[totalNodes];
            PriorityQueue<int, double> pq = new PriorityQueue<int, double>();

            for (int i = 0; i < totalNodes; i++)
            {
                times[i] = double.MaxValue;
                previous[i] = -1;
            }

            times[virtualStart] = 0;
            pq.Enqueue(virtualStart, 0);

            while (pq.Count > 0)
            {
                int u = pq.Dequeue();
                if (u == virtualEnd) 
                {
                    break;
                }
                if (visited[u]) 
                { 
                    continue; 
                }

                visited[u] = true;

                if (!graph.ContainsKey(u)) 
                {
                    continue;
                }

                foreach (Edge edge in graph[u])
                {
                    int v = edge.DistnationNode;
                    double newTime = times[u] + edge.time;
                    if (newTime < times[v])
                    {
                        times[v] = newTime;
                        previous[v] = u;
                        pq.Enqueue(v, newTime);
                    }
                }
            }

            List<int> fullPath = new List<int>();
            double vehicleDist = 0;
            double walkingDist = 0;

            if (times[virtualEnd] != double.MaxValue)
            {
                fullPath = ReconstructPath(previous, virtualEnd);

                
                if (fullPath.Count > 0 && fullPath[0] == virtualStart)
                {
                    fullPath.RemoveAt(0);
                }
                if (fullPath.Count > 0 && fullPath[fullPath.Count - 1] == virtualEnd)
                {
                    fullPath.RemoveAt(fullPath.Count - 1);
                }

                
                if (fullPath.Count > 0)
                {
                    var (walkTime, walkDist) = Map.Helpers.DistanceCalculator.CalculateWalkingTime(nodes[fullPath[0]], nodes[fullPath[fullPath.Count - 1]], x1, y1, x2, y2);
                    walkingDist = walkDist;
                    vehicleDist = Map.Helpers.DistanceCalculator.CalculateVehicleDistance(graph, fullPath);
                }
            }

            
            graph.Remove(virtualStart);
            graph.Remove(virtualEnd);
            
            foreach (Edge edge in virtualEndEdges)
            {
                List<Edge> edgesFromNode = graph[edge.DistnationNode];
                for (int i = edgesFromNode.Count - 1; i >= 0; i--)
                {
                    if (edgesFromNode[i].DistnationNode == virtualEnd)
                    {
                        edgesFromNode.RemoveAt(i);
                    }
                }
            }

            return (fullPath, times[virtualEnd], vehicleDist, walkingDist);
        }

        
        internal static List<int> ReconstructPath(int[] previous, int end)
        {
            List<int> path = new List<int>();
            int current = end;

            while (current != -1)
            {
                path.Add(current);
                current = previous[current];
            }

            path.Reverse();
            return path;
        }
    }
}
