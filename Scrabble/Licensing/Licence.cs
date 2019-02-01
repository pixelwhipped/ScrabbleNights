using System;
using System.Collections.Generic;
using System.Linq;

namespace Scrabble.Licensing
{
    public class Licence
    {
        private static readonly Random Rand = new Random();

        public static string GeneratePrivateKey(int sKeys, int dKeys)
        {
            var key = string.Empty;
            for (var sKey = 0; sKey < sKeys; sKey++)
            {
                for(var dKey = 0; dKey < dKeys; dKey++)
                {
                    if (Rand.Next(2) == 1)
                    {
                        key += Rand.Next(9);
                    }
                    else
                    {
                        key +=
                            Char.ToString(
                                (char) ((char) (Rand.NextDouble()*25) + (char) ((Rand.Next(2) == 1) ? 65 : 97)));
                    }
                }
                key += " ";
            }
            return key.Trim();
        }

        public static IEnumerable<string> GenerateKeys(string privateKey, out long keys)
        {
            keys = 0;
            var sKeys = privateKey.Split(' ');
            var passes = new List<string>();
            foreach(var s in sKeys)
            {
                long nkeys;
                passes.AddRange(PGenerateKeys(s, out nkeys));
                keys += nkeys;
            }
            return passes;
        }

        public static bool ValidateKey(string publicKey, string privateKey)
        {

            var sKeys = privateKey.Split(' ');
            return sKeys.Any(s => PValidateKey(publicKey, s) && s.Length == publicKey.Length);
        }

        private static bool PValidateKey(IEnumerable<char> publicKey, IEnumerable<char> privateKey)
        {
            var p = privateKey.ToArray();
            var s = publicKey.ToArray();
            var v = s.Select((t, index) => (t + index) / 4).Aggregate(1L, (current, x) => current * x);
            var k = 1L;
            for (var index = 0; index < p.Length; index++)
            {
                var x = (p[index] + index) / 4;
                k *= x;
                if (k == v) return true;
            }

            return false;
        }

        private static IEnumerable<string> PGenerateKeys(string privateKey, out long keys)
        {
            var p = Permute(privateKey.ToArray());
            var s = privateKey.ToArray();
            var v = s.Select((t, index) => (t + index) / 4).Aggregate(1L, (current, x) => current * x);
            var l = (from mut in p
                     let k = mut.Select((t, index) => (t + index)/4).Aggregate(1L, (current, x) => current*x)
                     let str = new String(mut)
                     where k == v && !str.Equals(privateKey, StringComparison.CurrentCulture)
                     select str).ToList();             
            var ret =  new List<string>(l.Distinct());
            keys = ret.Count();
            return ret;
        }
        
        private static long Factorial(long f)
        {
            var frac = f;
            if (frac < 0L)
            {
                return 0L;
            }
            var fact = 1L;
            while (frac > 1L)
            {
                fact = fact * frac;
                frac = frac - 1L;
            }
            return fact;
        }

        private static IEnumerable<char[]> Permute(IList<char> values)
        {
            values = values.OrderBy(n => n).ToArray();
            var permutations = new char[Factorial(values.Count())][];
            var count = 0;
            Permute(values, ref permutations, 0, ref count);
            return permutations;
        }

        private static void Permute(IList<char> values, ref char[][] permutations, int start, ref int count)
        {
            permutations[count] = new char[values.Count()];
            for (var i = 0; i < values.Count(); i++)
            {
                permutations[count][i] = values[i];
            }
            count++;
            if (start >= values.Count()) return;
            for (var i = values.Count() - 2; i >= start; i--)
            {
                char temp;
                for (var j = i + 1; j < values.Count(); j++)
                {
                    #region Swap

                    temp = values[i];
                    values[i] = values[j];
                    values[j] = temp;

                    #endregion

                    Permute(values, ref permutations, i + 1, ref count);
                }

                #region Rotate Left

                temp = values[i];
                for (var x = i; x < values.Count() - 1; x++)
                {
                    values[x] = values[x + 1];
                }
                values[values.Count() - 1] = temp;

                #endregion
            }
        }
    }
}
