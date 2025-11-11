using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map.Models
{
    class Edge
    {
        public int DistnationNode;
        public double speed, distance, time;

        public Edge(int n1, double speed, double distance)
        {
            this.DistnationNode = n1;

            this.speed = speed;
            this.distance = distance;
            this.time = (distance / speed) * 60; 
        }
    }

}
