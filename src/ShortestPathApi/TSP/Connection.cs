using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortestPathApi.TSP
{
    public class Connection
    {
        public Point From { get; private set; }
        public Point To { get; private set; }
        public float Cost { get; private set; }

        public Connection(Point from, Point to, float cost)
        {
            From = from;
            To = to;
            Cost = cost;
        }
    }
}
