using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoverGame
{
    public static class Extensions
    {
        public static void Shuffle<T>(this IList<T> list)
        {
            var count = list.Count;

            while (count > 1)
            {
                count --;

                var k = RandomGenerator.Next(0, count + 1);
                var value = list[k];
                list[k] = list[count];
                list[count] = value;
            }
        }

        public static void Shift<T>(this IList<T> list)
        {
            var first = list.First();
            list.RemoveAt(0);
            list.Add(first);
        }
    }
}
