using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortestPathApi.TSP
{
    public interface IMapCreator
    {
        Map CreateMap(string data);
    }
}
