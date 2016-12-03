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
                {"0_4", 4},
                {"0_5", 5},
                {"0_6", 6},
                {"0_7", 1},
                {"0_8", 2},
                {"0_9", 3},
                {"0_10", 7},
                {"1_1", 2},
                {"1_2", 3},
                {"1_3", 4},
                {"1_4", 5},
                {"1_5", 6},
                {"1_6", 6},
                {"1_7", 1},
                {"1_8", 2},
                {"1_9", 3},
                {"2_1", 1},
                {"2_2", 2},
                {"2_3", 3},
                {"2_4", 4},
                {"2_5", 5},
                {"2_6", 6},
                {"2_7", 1},
                {"2_8", 2},
                {"2_9", 3},
                {"3_1", 1},
                {"3_2", 2},
                {"3_3", 3},
                {"3_4", 4},
                {"3_5", 5},
                {"3_6", 6},
                {"3_7", 1},
                {"3_8", 2},
                {"3_9", 3},
                {"4_1", 1},
                {"4_2", 2},
                {"4_3", 3},
                {"4_4", 4},
                {"4_5", 5},
                {"4_6", 6},
                {"4_7", 1},
                {"4_8", 2},
                {"4_9", 3},
                {"5_1", 1},
                {"5_2", 2},
                {"5_3", 3},
                {"5_4", 4},
                {"5_5", 5},
                {"5_6", 6},
                {"5_7", 1},
                {"5_8", 2},
                {"5_9", 3},
                {"6_1", 1},
                {"6_2", 2},
                {"6_3", 3},
                {"6_4", 4},
                {"6_5", 5},
                {"6_6", 6},
                {"6_7", 1},
                {"6_8", 2},
                {"6_9", 3},
                {"7_1", 1},
                {"7_2", 2},
                {"7_3", 3},
                {"7_4", 4},
                {"7_5", 5},
                {"7_6", 6},
                {"7_7", 1},
                {"7_8", 2},
                {"7_9", 3},
                {"8_1", 1},
                {"8_2", 2},
                {"8_3", 3},
                {"8_4", 4},
                {"8_5", 5},
                {"8_6", 6},
                {"8_7", 1},
                {"8_8", 2},
                {"8_9", 3},
                {"9_1", 1},
                {"9_2", 2},
                {"9_3", 3},
                {"9_4", 4},
                {"9_5", 5},
                {"9_6", 6},
                {"9_7", 1},
                {"9_8", 2},
                {"9_9", 3},
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
