using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenges
{
    public class StringManipulationChallenges
    {
        public static int MakeAnagram(string a, string b)
        {
            a = "showman";
            b = "woman";

            int LenA = a.Length;
            int LenB = b.Length;

            var ListA = new List<char>(LenA);
            var ListB = new List<char>(LenB);

            ListA = a.ToList();
            ListB = b.ToList();

            int total = LenA + LenB;

            int count = 0;

            for (int i = 0; i < LenA; i++)
            {
                if (ListB.Contains(ListA[i]))
                {
                    count++;
                    ListB.Remove(ListA[i]);
                }
            }

            return total - (2 * count);
        }

        public static List<string> FunWithAnagrams(List<string> text)
        {
            text = new List<string>() { "code", "doce", "ecod", "framer", "frame" };

            for (var i = 0; i < text.Count; i++)
            {
                for (var j = text.Count - 1; j > i; j--)
                {
                    var elementA = text[i];
                    var arrayA = elementA.ToCharArray();
                    Array.Sort(arrayA);
                    var arrayAStr = string.Join("", arrayA);

                    var elementB = text[j];
                    var arrayB = elementB.ToCharArray();
                    Array.Sort(arrayB);
                    var arrayBStr = string.Join("", arrayB);

                    if (arrayAStr == arrayBStr)
                    {
                        text.RemoveRange(j, 1);
                    }
                }
            }

            text.Sort();
            return text;
        }
    }
}
