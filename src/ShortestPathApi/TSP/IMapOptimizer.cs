using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortestPathApi.TSP
{
    public interface IMapOptimizer
    {
        void Optimize(Map map);
    }
}
