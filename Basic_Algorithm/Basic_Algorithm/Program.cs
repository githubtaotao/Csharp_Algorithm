using System;
using System.Diagnostics;

namespace Basic_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            // 生成随机数组
            int[] ready_array = GetRandomArray(10000,false, 0, 88);
            if(ready_array is null)
            {
                Console.WriteLine("随机数生成错误, 最大随机数与数组长度不符!");
                Console.ReadKey();
            }
            Console.WriteLine("随机数组: ");
            foreach (var item in ready_array)
            {
                Console.Write(item + " ");
            }
            BasicAlgorithm ba = new BasicAlgorithm();

            // 冒泡排序
            int[] bubble_sort_copy = new int[ready_array.Length];
            ready_array.CopyTo(bubble_sort_copy, 0);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            ba.BubbleSort(bubble_sort_copy);
            sw.Stop();
            Console.WriteLine();
            Console.WriteLine("冒泡排序: ");
            foreach (var item in bubble_sort_copy)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            Console.WriteLine("运行时间:{0}", sw.ElapsedMilliseconds);
            Console.WriteLine("=================");
            Console.ReadKey();
        }

        /// <summary>
        /// 生成随机数组
        /// </summary>
        /// <param name="arrayLength">数组长度</param>
        /// <param name="isSame">是否允许重复元素</param>
        /// <param name="minInt">随机数区间min</param>
        /// <param name="maxInt">随机数区间max</param>
        /// <returns></returns>
        public static int[] GetRandomArray(int arrayLength,Boolean isSame, int minInt, int maxInt)
        {
            int[] temp = new int[arrayLength];
            for(int i=0;i<arrayLength;i++)
            {
                if (isSame)
                {
                    Random rd = new Random();
                    int random_temp = rd.Next(minInt, maxInt);
                    temp[i] = random_temp;
                }
                else
                {
                    if (arrayLength != maxInt)
                    {
                        return null;
                    }
                    Random rd = new Random();
                    int random_temp = rd.Next(minInt, maxInt);
                    if (!isSame)
                    {
                        int is_same_result = Array.IndexOf(temp, random_temp);
                        if (is_same_result == -1)
                        {
                            temp[i] = random_temp;
                        }
                        else if (i == arrayLength - 1 && random_temp == 0)
                        {
                            temp[i] = random_temp;
                        }
                        else
                        {
                            i = i - 1;
                        }
                    }
                }                    
            }
            return temp;
        }
    }
}
