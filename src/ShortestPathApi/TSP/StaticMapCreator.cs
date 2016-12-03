using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShortestPathApi.TSP
{
    public class StaticMapCreator : IMapCreator
    {
        /**Whenever you add a new point always make entries for that point in below dictionary*/

        public static readonly Dictionary<string, int> PathCostMapping = new Dictionary<string, int>
            {
                {"0_1", 1},
                {"0_2", 2},
                {"0_3", 3},
                {"1_2", 4},
                {"1_3", 5},
                {"2_3", 6}
            };

        public Map CreateMap(int[] selectedPoints)
        {
            Map map = new Map();
            for (int i = 0; i < selectedPoints.Length; i++)
            {
                GetOrCreatePoint(ref map, selectedPoints[i]);

                for (int j = i + 1; j < selectedPoints.Length; j++)
                {
                    Point b = GetOrCreatePoint(ref map, selectedPoints[j]);
                    var pointI = map.GetPoint(selectedPoints[i]);
                    var pointJ = map.GetPoint(selectedPoints[j]);
                    AddConnections(ref pointI, ref pointJ, PathCostMapping[selectedPoints[i] + "_" + selectedPoints[j]]);
                }
            }



            /*
            Point a = new Point(0);
            Point b = new Point(1);
            Point c = new Point(2);
            Point d = new Point(3);
            Point e = new Point(4);

            Connection ab = new Connection(a, b, 1);
            Connection ac = new Connection(a, c, 1);
            Connection ad = new Connection(a, d, 2);
            Connection ae = new Connection(a, e, 5);
            a.AddPossibleConnection(ab)
                .AddPossibleConnection(ac)
                .AddPossibleConnection(ad)
                .AddPossibleConnection(ae);

            Connection ba = new Connection(b, a, 1);
            Connection bc = new Connection(b, c, 2);
            Connection bd = new Connection(b, d, 1);
            Connection be = new Connection(b, e, 1);
            b.AddPossibleConnection(ba)
                .AddPossibleConnection(bc)
                .AddPossibleConnection(bd)
                .AddPossibleConnection(be);

            Connection ca = new Connection(c, a, 1);
            Connection cb = new Connection(c, b, 2);
            Connection cd = new Connection(c, d, 1);
            Connection ce = new Connection(c, e, 5);
            c.AddPossibleConnection(ca)
                .AddPossibleConnection(cb)
                .AddPossibleConnection(cd)
                .AddPossibleConnection(ce); ;

            Connection da = new Connection(d, a, 2);
            Connection db = new Connection(d, b, 1);
            Connection dc = new Connection(d, c, 1);
            Connection de = new Connection(d, e, 1);
            d.AddPossibleConnection(da)
                .AddPossibleConnection(db)
                .AddPossibleConnection(dc)
                .AddPossibleConnection(de);

            Connection ea = new Connection(e, a, 5);
            Connection eb = new Connection(e, b, 1);
            Connection ec = new Connection(e, c, 5);
            Connection ed = new Connection(e, d, 1);
            e.AddPossibleConnection(ea)
                .AddPossibleConnection(eb)
                .AddPossibleConnection(ec)
                .AddPossibleConnection(ed);

            map.AddPoint(a)
                .AddPoint(b)
                .AddPoint(c)
                .AddPoint(d)
                .AddPoint(e);
            */
            return map;
        }
        private static void AddConnections(ref Point a, ref Point b, int cost)
        {
            Connection ab = new Connection(a, b, cost);
            Connection ba = new Connection(b, a, cost);
            a.AddPossibleConnection(ab);
            b.AddPossibleConnection(ba);
        }

        private static Point GetOrCreatePoint(ref Map map, int pointId)
        {
            Point point = null;
            if (map.GetPoint(pointId) == null)
            {
                point = new Point(pointId);
                map.AddPoint(point);
            }
            else
            {
                point = map.GetPoint(pointId);
            }
            return point;
        }

    }
}
