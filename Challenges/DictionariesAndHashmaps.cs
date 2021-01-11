using System;
using System.Linq;

namespace Challenges
{
    public static class DictionariesAndHashmaps
    {
        // Complete the checkMagazine function below.
        public static void CheckMagazine(string[] magazine, string[] note)
        {
            magazine = new string[] { "give", "me", "one", "grand", "today", "night" };
            note = new string[] { "give", "one", "grand", "today" };
            const string Yes = "Yes";
            const string No = "No";
            string answer = Yes;

            //var intersect = note.Intersect(magazine, StringComparer.OrdinalIgnoreCase).Count();

            //if (!intersect.Equals(note.Length))
            //{
            //    answer = No;
            //}

            //for (int i = 0; i < note.Length; i++)
            //{
            //    var res = magazine.FirstOrDefault(x => x.Equals(note[i]));
            //    if (string.IsNullOrEmpty(res))
            //    {
            //        Console.WriteLine($"{No}");
            //        return;
            //    }
            //    else
            //    {
            //        magazine = magazine.Where(x => !x.Equals(res)).ToArray();
            //    }
            //}

            Console.WriteLine($"{answer}");
        }
    }
}
