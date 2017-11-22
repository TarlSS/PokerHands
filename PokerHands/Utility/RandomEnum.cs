using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHands.Utility
{

    /// <summary>
    /// Provides a static way to get random values for convenience.
    /// </summary>
    public static class RandomUtility
    {
        private static Random _Random = new Random(Environment.TickCount);

        /// <summary>
        /// static Random Enum implementation from User:Whol
        /// https://stackoverflow.com/questions/3132126/how-do-i-select-a-random-value-from-an-enumeration
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T EnumOf<T>()
        {
            if (!typeof(T).IsEnum)
                throw new InvalidOperationException("Must use Enum type");

            Array enumValues = Enum.GetValues(typeof(T));
            return (T)enumValues.GetValue(_Random.Next(enumValues.Length));
        }

        /// <summary>
        /// Static random to get ints
        /// </summary>
        /// <param name="range"></param>
        /// <returns></returns>
        public static int NextInt(int range)
        {
            return _Random.Next(range);

        }
    }
}
