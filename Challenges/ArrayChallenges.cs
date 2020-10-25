using System;
using System.Linq;
using System.Security.Principal;

namespace Challenges
{
    public class ArrayChallenges
    {
        // Complete the hourglassSum function below.
        //input:
        //1 1 1 0 0 0
        //0 1 0 0 0 0
        //1 1 1 0 0 0
        //0 0 2 4 4 0
        //0 0 0 2 0 0
        //0 0 1 2 4 0
        // output:
        // 19
        public static int HourglassSum()
        {
            int[][] arr = new int[6][];

            var str0 = "1 1 1 0 0 0";
            var str1 = "0 1 0 0 0 0";
            var str2 = "1 1 1 0 0 0";
            var str3 = "0 0 2 4 4 0";
            var str4 = "0 0 0 2 0 0";
            var str5 = "0 0 1 2 4 0";
            string[] strArr = new string[6] {str0, str1, str2, str3, str4, str5};

            for (int i = 0; i < 6; i++)
            {
                arr[i] = Array.ConvertAll(strArr[i].Split(' '), arrTemp => Convert.ToInt32(arrTemp));
            }

            // grid 6 x 6
            int max = int.MinValue;
            for (int x = 1; x < 6 - 1; x++)
            {
                for (int y = 1; y < 6 - 1; y++)
                {
                    //var sum = arr[y - 1][x - 1] + arr[y - 1][x] + arr[y - 1][x + 1] +
                    //          arr[y][x] +
                    //          arr[y + 1][x - 1] + arr[y + 1][x] + arr[y + 1][x + 1];
                    var sum = arr[x - 1][y - 1] + arr[x - 1][y] + arr[x - 1][y + 1] +
                              arr[x][y] +
                              arr[x + 1][y - 1] + arr[x + 1][y] + arr[x + 1][y + 1];

                    if (sum > max)
                    {
                        max = sum;
                    }
                }
            }

            return max;
        }

        public static int[] RotLeft(int[] a, int d)
        {
            //             0 1   2  3  4
            a = new int[] {1, 2, 3, 4, 5};

            return a.Skip(d).Concat(a.Take(d)).ToArray();

            //var maxIndex = a.Length - 1;
            //for (int i = 0; i < d; i++)
            //{
            //    var valueOfLast = a[maxIndex];
            //    for (int j = 0; j < a.Length; j++)
            //    {
            //        if (j == 0)
            //        {
            //            a[maxIndex] = a[j];
            //        }
            //        else if (j == a.Length - 1)
            //        {
            //            a[maxIndex - 1] = valueOfLast;
            //        }
            //        else
            //        {
            //            a[j - 1] = a[j];
            //        }
            //    }
            //}
        }

        // Complete the minimumBribes function below.
        public static void MinimumBribes(int[] q)
        {
            q = new[] {2, 1, 5, 3, 4};
            var numberOfPeople = q.Length;
            var arr = new[] {1, 2, 3, 4, 5};

            var bribes = 0;

            for (int i = q.Length - 1; i >= 0; i--)
            {
                if (q[i] - (i + 1) > 2)
                {
                    Console.WriteLine("Too chaotic");
                    return;
                }

                for (int j = Math.Max(0, q[i] - 2); j < i; j++)
                {
                    if (q[j] > q[i])
                    {
                        bribes++;
                    }
                }
            }

            Console.WriteLine($"{bribes}");
        }

        public static void MinimumSwaps()
        {
            int[] arr = new int[] { 4, 3, 1, 2 };
            //int[] arr = new int[] { 2, 3, 4, 1, 5 };
            //int[] arr = new int[] { 1, 3, 5, 2, 4, 6, 7 };

            int swaps = 0;
            int temp;

            //var i = 0;
            //while (i < arr.Length)
            //{
            //    if (arr[i] != i + 1)
            //    {
            //        temp = arr[i];
            //        arr[i] = arr[arr[i] - 1];
            //        arr[temp - 1] = temp;
            //        swaps++;
            //    }
            //    else i++;
            //}

            for (int i = 0; i < arr.Length; i++)
            {
                var min = arr.Skip(i).Min();
                if (min < arr[i])
                {
                    var index = Array.IndexOf(arr, min);
                    temp = arr[index];
                    arr[index] = arr[i];
                    arr[i] = temp;
                    swaps++;
                }
            }

            Console.WriteLine($"{string.Join(",", arr)}");
            Console.WriteLine($"Swaps: {swaps}");
        }

        public static void ArrayManipulation()
        {
            int n = 10;
            int m = 4;
            int[][] queries = new int[m][];
            queries[0] = new int[3] { 2, 6, 8 };
            queries[1] = new int[3] { 3, 5, 7 };
            queries[2] = new int[3] { 1, 8, 1 };
            queries[3] = new int[3] { 5, 9, 15 };

            // n + 2
            long[] manipulated = new long[n];

            for (int i = 0; i < queries.GetLength(0); i++)
            {
                var leftIndex = queries[i][0];
                var rightIndex = queries[i][1];
                var summand = queries[i][2];

                for (int j = leftIndex - 1; j <= rightIndex - 1; j++)
                {
                    manipulated[j] += summand;
                }
            }

            //for (int i = 0; i < queries.GetLength(0); i++)
            //{
            //    var leftIndex = queries[i][0];
            //    var rightIndex = queries[i][1];
            //    var summand = queries[i][2];

            //    manipulated[leftIndex] += summand;
            //    manipulated[rightIndex + 1] -= summand;
            //}

            //long sum = 0;
            //long max = 0;
            //for (int j = 0; j < manipulated.Length; j++)
            //{
            //    sum += manipulated[j];
            //    max = Math.Max(max, sum);
            //}

            long maxValue = manipulated.Max();
            // 31
            Console.WriteLine($"Max Value: {maxValue}");
        }
    }
}
