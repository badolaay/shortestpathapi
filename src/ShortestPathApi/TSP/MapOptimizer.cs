using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortestPathApi.TSP
{
    public class MapOptimizer : IMapOptimizer
    {
        public void Optimize(Map map)
        {
            Random random = new Random();

            {
                //connect first two points

                Point pointA = map.GetPoint(0);//the entry to store
                Point pointB = map.GetPoint(0);//just to initialize
                do
                {
                    int minCost = Int32.MaxValue;

                    //to make sure point B is the closest to point A
                    foreach (KeyValuePair<string, int> keyValuePair in StaticMapCreator.PathCostMapping)
                    {
                        string startIndex = keyValuePair.Key.Substring(0, 1);
                        int nextPointIndex = Int32.Parse(keyValuePair.Key.Substring(2, keyValuePair.Key.Length - 2));

                        if (startIndex.Equals("0") && map.SelectedPoints.Contains(nextPointIndex) && keyValuePair.Value < minCost)
                        {
                            minCost = keyValuePair.Value;
                            pointB = map.GetPoint(nextPointIndex);
                        }

                    }
                    //pointB = map.GetPoint(random.Next(map.Points.Count));
                } while (pointB == pointA);

                pointA.ConnectTo(pointB);

            }

            int connectedPoints = 2;
            while (map.Points.Any(x => x.IncommingConnection == null || x.OutgoingConnection == null))
            {
                connectedPoints++;
                //find a point without a connection
                Point point;
                do
                {
                    point = map.GetPoint(random.Next(map.Points.Count));
                } while (point != null && point.IncommingConnection != null);

                //find the nearest point with a connection
                Point nearestPoint = null;
                foreach (Point testPoint in map.Points.Where(x => x.IncommingConnection != null))
                {
                    if (
                        nearestPoint == null
                        || point.GetConnectionTo(testPoint).Cost < point.GetConnectionTo(nearestPoint).Cost
                    )
                    {
                        nearestPoint = testPoint;
                    }
                }

                //insert the point
                nearestPoint.ConnectTo(point);
            }
        }
    }
}
