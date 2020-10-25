using System;
using System.Linq;

namespace Challenges
{
    public static class SortingChallenges
    {
        public static void BubbleSort()
        {
            int n = 3;
            var a = new int[] { 3, 2 ,1 };

            int temp;
            int swaps = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n - 1; j++)
                {
                    if (a[j] > a[j + 1])
                    {
                        temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                        swaps++;
                    }
                }
            }

            Console.WriteLine($"Array is sorted in {swaps} swaps.");
            Console.WriteLine($"First Element: {a.FirstOrDefault()}");
            Console.WriteLine($"Last Element: {a.LastOrDefault()}");
        }

        public static void MaximumToys()
        {
            int[] prices = { 1, 12, 5, 111, 200, 1000, 10 };
            int k = 50;

            Array.Sort(prices);

            int toys = 0;
            long sum = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                sum += prices[i];
                if (sum <= k)
                {
                    toys++;
                }
            }

            Console.WriteLine($"Can buy toys: {toys}");
        }

        public static void ActivityNotifications()
        {
            //int[] expenditure = { 2, 3, 4, 2, 3, 6, 8, 4, 5 };
            int[] expenditure = { 10, 20, 30, 40, 50 };
            //int[] expenditure = { 1, 2, 3, 4, 4 };
            int n = expenditure.Length;
            // trailing days to calculate median
            int d = 3;

            int notifications = 0;
            int iteration = 0;

            var arr = expenditure.ToArray();
            Array.Sort(arr);

            for (int i = d; i < expenditure.Length; i++)
            {
                var median = GetMedian(arr, d);

                if (expenditure[i] >= 2 * median)
                {
                    notifications++;
                }

                iteration++;
                if (iteration <= expenditure.Length - d)
                {
                    arr = arr.Skip(1).ToArray();
                }
            }

            //int notifications = 0;
            //var arr = new int[d];
            //Array.Copy(expenditure, arr, d);
            //Array.Sort(arr);
            //for (int i = d; i < expenditure.Length; i++)
            //{
            //    if (expenditure[i] >= arr[d / 2] + arr[(d - 1) / 2])
            //    {
            //        notifications++;
            //    }
            //    int index = Array.BinarySearch(arr, expenditure[i - d]);
            //    Array.Copy(arr, index + 1, arr, index, d - index - 1);
            //    index = Array.BinarySearch(arr, 0, d - 1, expenditure[i]);
            //    index = index >= 0 ? index : ~index;
            //    Array.Copy(arr, index, arr, index + 1, d - index - 1);
            //    arr[index] = expenditure[i];
            //}
            //return notifications;

            Console.WriteLine($"Notifications: {notifications}");
        }

        private static double GetMedian(int[] arr, int d)
        {
            // if odd pick middle, else pick average
            if (d % 2 == 0)
            {
                return (double)arr.Take(d).Sum() / d;
            }

            var middle = d / 2;
            return arr[middle];
        }
    }
}
