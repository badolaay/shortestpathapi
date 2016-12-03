using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortestPathApi.TSP
{
    public class Calculate
    {
        public IList<Point> CalculatePath(int[] selectedPoints)
        {
            IMapCreator mapCreator = new StaticMapCreator();

            Map map = mapCreator.CreateMap(selectedPoints);
            map.SelectedPoints = selectedPoints;
            map.Optimize(new MapOptimizer());

            return map.Points;

        }
    }
}
