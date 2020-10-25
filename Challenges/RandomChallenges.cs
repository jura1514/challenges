using System;
using System.Collections.Generic;
using System.Linq;

namespace Challenges
{
    public class RandomChallenges
    {
        public static int FindMatchingPairs()
        {
            var n = 9;
            int[] ar = {10, 20, 20, 10, 10, 30, 50, 10, 20};

            int count = 0;
            Array.Sort(ar);

            for (int i = 0; i < n - 1;)
            {
                if (ar[i] == ar[i + 1])
                {
                    count++;
                    i = i + 2;
                }
                else
                {
                    i++;
                }
            }

            Console.WriteLine($"{count}");
            return count;
        }

        public static int CountingValleys(int steps, string path)
        {
            steps = 8;
            path = "UDDDUDUU";

            var altitude = 0;

            var valleys = 0;
            for (int i = 0; i < steps; i++)
            {
                var step = path[i];
                var stepStr = step.ToString();
                var nextStep = i + 1 < steps ? path[i + 1].ToString() : null;

                if (stepStr == "U")
                {
                    altitude++;
                }
                if (stepStr == "D")
                {
                    altitude--;
                }

                if (altitude == -1 && nextStep == "U")
                {
                    valleys++;
                }
            }

            Console.WriteLine($"{valleys}");
            return valleys;
        }

        public static int JumpingOnClouds(int[] c)
        {
            // 0 is safe 
            // 1 must be avoided
            //c = new[] { 0, 0, 0, 0, 1, 0 };
            c = new[] { 0, 0, 1, 0, 0, 1, 0 };
            var jumps = 0;

            for (int i = 0; i < c.Length;)
            {
                var currentStep = c[i];
                var nextStep = i + 1 < c.Length ? c[i + 1] : -1;
                var previousStep = i - 1 >= 0 ? c[i - 1] : -1;

                if (currentStep == 0 && nextStep == 0)
                {
                    jumps++;
                    i = i + 2;

                }
                else if (currentStep == 0 && nextStep == 1)
                {
                    jumps++;
                    i = i + 2;

                }
                else if (currentStep == 1 && nextStep == 1)
                {
                    jumps++;
                    i = i + 2;

                }
                else if (currentStep == 1 && nextStep == 0)
                {
                    jumps++;
                    i++;
                }
                else
                {
                    i++;
                }
            }

            Console.WriteLine($"{jumps}");
            return jumps;
        }

        public static long RepeatedString(string s, long n)
        {
            s = "epsxyyflvrrrxzvnoenvpegvuonodjoxfwdmcvwctmekpsnamchznsoxaklzjgrqruyzavshfbmuhdwwmpbkwcuomqhiyvuztwvq"; // aba aba aba a
            n = 549382313570;

            var occurancies = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'a')
                {
                    occurancies++;
                }
            }

            var repeated = n / s.Length * occurancies;
            var t = n % s.Length;

            if (t > 0)
            {
                var newStr = s.Substring(0, (int) t);
                for (int i = 0; i < newStr.Length; i++)
                {
                    if (newStr[i] == 'a')
                    {
                        repeated++;
                    }
                }
            }

            return repeated;
        }

        public static List<string> GroupTransactions(List<string> transactions)
        {
            //transactions = new List<string>() { "a", "a", "a", "a", "a", "a", "a", "a", "a", "a", "a" };
            transactions = new List<string>() { "bin", "can", "bin", "bin" };

            var list = new List<KeyValuePair<string, int>>();
            transactions.Sort();
            for (int i = 0; i < transactions.Count; i++)
            {
                var count = 1;
                for (int j = i + 1; j < transactions.Count; j++)
                {
                    if (transactions[i] == transactions[j])
                    {
                        count++;
                    }
                }

                var exist = list.FirstOrDefault(x => x.Key == transactions[i]);
                if (exist.Key == null)
                {
                    list.Add(new KeyValuePair<string, int>(transactions[i], count));
                }
            }

            var result = list.OrderByDescending(x => x.Value).Select(x => $"{x.Key} {x.Value}").ToList();
            return result;
        }
    }
}