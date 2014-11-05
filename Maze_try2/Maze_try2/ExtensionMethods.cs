using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_try2
{
    public static class ExtensionMethods
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            var r = new Random();
            var len = list.Count;
            for (var i = len - 1; i >= 1; --i)
            {
                var j = r.Next(i);
                var tmp = list[i];
                list[i] = list[j];
                list[j] = tmp;
            }
        }

        public static void Shuffle<T>(this LinkedList<T> list)
        {
            var tempList = list.ToList();
            tempList.Shuffle();
            var l = list.First;
            foreach (var v in tempList)
            {
                l.Value = v;
                l = l.Next;
            }
        }
    }
}
