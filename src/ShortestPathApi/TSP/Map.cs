using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortestPathApi.TSP
{
    public class Map
    {

        public IList<Point> Points { get; private set; }

        public Map() : this(new List<Point>()) { }

        public Map(IList<Point> points)
        {
            Points = points;
        }

        public Map AddPoint(Point point)
        {
            Points.Add(point);
            return this;
        }

        public Point GetPoint(int id)
        {
            return Points.Single(x => x.Id == id);
        }

        public void Optimize(IMapOptimizer optimizer)
        {
            optimizer.Optimize(this);
        }

        public float GetCostOfWholeRoute()
        {
            Point startingPoint = Points.First();
            float cost = startingPoint.OutgoingConnection.Cost;

            Point currentPoint = startingPoint.OutgoingConnection.To;
            float lastCost = 0;
            while (currentPoint != startingPoint)
            {
                cost += currentPoint.OutgoingConnection.Cost;
                lastCost = currentPoint.OutgoingConnection.Cost;
                currentPoint = currentPoint.OutgoingConnection.To;
            }

            return cost - lastCost;
        }
    }
}
