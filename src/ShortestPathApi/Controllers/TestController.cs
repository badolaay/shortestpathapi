using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShortestPathApi.Models;
using ShortestPathApi.TSP;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ShortestPathApi.Controllers
{
    [Route("api/test")]
    public class TestController : Controller
    {
        [Route("path")]
        [HttpPost]
        public string Path([FromBody]ItemsForPath value)
        {
            Calculate calculate = new Calculate();
            IList<Point> points = calculate.CalculatePath(value.ItemIds);
            return JsonConvert.SerializeObject(points, Formatting.None, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }
    }
}
