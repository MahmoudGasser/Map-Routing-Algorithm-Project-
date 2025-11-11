using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Map.Models
{
    class Node
    {
        public double x, y;
        public int id;

        public Node(int id, double x, double y)
        {
            this.id = id;
            this.x = x;
            this.y = y;
        }
    }
}