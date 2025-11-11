using Map.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Map.Graph
{
    class Graph
    {
         
        public static (Dictionary<int, List<Edge>>, Node[]) ConstructGraph(string[] mapLines)
        {
            Dictionary<int, List<Edge>> graph = new Dictionary<int, List<Edge>>();
            

            int index = 0;
            int node_count = int.Parse(mapLines[index++]);
            index += node_count;

            int edge_count = int.Parse(mapLines[index++]);

            Node[] nodes = new Node[node_count];

            for (int i = 0; i < edge_count; i++)
            {
                string[] parts = mapLines[index++].Split(' ');

                int u = int.Parse(parts[0]);
                int v = int.Parse(parts[1]);
                double dist = double.Parse(parts[2]);
                double speed = double.Parse(parts[3]);

                if (nodes[u] == null)
                {
                    string[] nodeParts = mapLines[u + 1].Split(' ');
                    nodes[u] = new Node(u, double.Parse(nodeParts[1]), double.Parse(nodeParts[2]));

                    graph[u] = new List<Edge>();
                }

                if (nodes[v] == null)
                {
                    string[] nodeParts = mapLines[v + 1].Split(' ');
                    nodes[v] = new Node(v, double.Parse(nodeParts[1]), double.Parse(nodeParts[2]));
                    graph[v] = new List<Edge>();

                }

                graph[u].Add(new Edge(v, speed, dist));
                graph[v].Add(new Edge(u, speed, dist));
            }

            return (graph, nodes);
        }
          
        public static (int virtualStartIndex, int virtualEndIndex, List<Edge> virtualStartEdges, List<Edge> virtualEndEdges)
        FindReachableNodes(Node[] nodes, double x_source, double y_source, double x_destination, double y_destination, double maxR)
        {
            List<Edge> virtualStartEdges = new List<Edge>();
            List<Edge> virtualEndEdges = new List<Edge>();

            int virtualStartIndex = nodes.Length;
            int virtualEndIndex = nodes.Length + 1;

            double maxRKm_squared = (maxR / 1000.0) * (maxR / 1000.0); 

            for (int i = 0; i < nodes.Length; i++)
            {
                if (nodes[i] == null) 
                {
                    continue;
                }

               
                double dx = nodes[i].x - x_source;
                double dy = nodes[i].y - y_source;
                double dist_squared = dx * dx + dy * dy;

                if (dist_squared <= maxRKm_squared)
                {
                    double dist = Math.Sqrt(dist_squared);
                    double walkSpeed = 5.0;
                    double time = (dist / walkSpeed) * 60;

                    Edge walkingEdge = new Edge(i, 1, dist); 
                    walkingEdge.time = time;
                    virtualStartEdges.Add(walkingEdge);
                }

                
                dx = nodes[i].x - x_destination;
                dy = nodes[i].y - y_destination;
                dist_squared = dx * dx + dy * dy;

                if (dist_squared <= maxRKm_squared)
                {
                    double dist = Math.Sqrt(dist_squared);
                    double walkSpeed = 5.0;
                    double time = (dist / walkSpeed) * 60;
                    Edge walkingEdgee = new Edge(i, 1, dist);
                    walkingEdgee.time = time;
                    virtualEndEdges.Add(walkingEdgee);
                }
            }

            return (virtualStartIndex, virtualEndIndex, virtualStartEdges, virtualEndEdges);
        }


    }
}
