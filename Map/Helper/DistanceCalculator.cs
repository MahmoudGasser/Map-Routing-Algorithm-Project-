using Map.Graph;
using Map.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map.Helpers
{
    class DistanceCalculator
    {

        internal static (double time, double distance) CalculateWalkingTime(Node startnode, Node endNode, double x1, double y1, double x2, double y2)
        {
            double dx1 = startnode.x - x1;
            double dy1 = startnode.y - y1;
            double dist1 = Math.Sqrt(dx1 * dx1 + dy1 * dy1);

            double dx2 = endNode.x - x2;
            double dy2 = endNode.y - y2;
            double dist2 = Math.Sqrt(dx2 * dx2 + dy2 * dy2);

            double walkingSpeed = 5.0;
            double time1 = (dist1 / walkingSpeed) * 60;
            double time2 = (dist2 / walkingSpeed) * 60;

            return (time1 + time2, dist1 + dist2);
        }






        internal static double CalculateVehicleDistance(Dictionary<int, List<Edge>> graph, List<int> path)
        {
            double distance = 0;
            bool found = false;
            int i = 0;

            while (i < path.Count - 1)
            {
                int current = path[i];
                int next = path[i + 1];

                if (graph.ContainsKey(current))
                {
                    foreach (Edge edge in graph[current])
                    {
                        if (edge.DistnationNode == next)
                        {
                            distance += edge.distance;
                            found = true;
                            break;
                        }
                    }
                }

                i++;
            }

            return distance;
        }
    }
}
