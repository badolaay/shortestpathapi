using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortestPathApi.TSP
{
    public class Calculate
    {
        public string CalculatePath()
        {
            IMapCreator mapCreator = new StaticMapCreator();

            Map map = mapCreator.CreateMap(String.Empty); //data is static, no string necessary

            map.Optimize(new MapOptimizer());

            return "Optimized route has a cost of " + map.GetCostOfWholeRoute();

        }
    }
}
