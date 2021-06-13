using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace _02__Parallel_MergeSort
{
    class Program
    {
       public static async Task Main(string[] args)
        {
            var sw = new Stopwatch();
            sw.Start();
            var list = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            ;
            //Task task = new Task(() => MergeSort(list));
            //await task;
           list= MergeSort(list);
            Console.WriteLine(string.Join(",",list));
            sw.Stop();
            Console.WriteLine(sw.Elapsed);


        }

        public static List<int> MergeSort (List<int> list)
        {
            if (list.Count <= 1)
            {
                return list;
            }
            var left = new List<int>();
            var right = new List<int>();
            for (int i = 0; i < list.Count; i++)
            {
                if (i%2==0)
                {
                    left.Add(list[i]);
                }
                else
                {
                    right.Add(list[i]);
                }
            }
            ;
            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            while (left.Count>0 && right.Count>0)
            {
                int leftOne = left[0];
                left.RemoveAt(0);
                int rightOne = right[0];
                right.RemoveAt(0);
                if (leftOne <= rightOne)
                {
                    result.Add(leftOne);
                    result.Add(rightOne);
                }
                else
                {
                    result.Add(rightOne);
                    result.Add(leftOne);
                }
            }
            if (left.Count > 0)
            {
                result.AddRange(left);
            }
            if (right.Count > 0)
            {
                result.AddRange(right);
            }

            return result;
        }
    }
}
