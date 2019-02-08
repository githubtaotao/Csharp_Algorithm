using System;
using System.Diagnostics;

namespace Basic_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            // 生成随机数组
            int[] ready_array = GetRandomArray(10,false, 0, 10);
            if(ready_array is null)
            {
                Console.WriteLine("随机数生成错误, 最大随机数与数组长度不符!");
                Console.ReadKey();
            }
            Console.WriteLine("随机数组: ");
            //foreach (var item in ready_array)
            //{
            //    Console.Write(item + " ");
            //}

            BasicAlgorithm ba = new BasicAlgorithm();

            // 冒泡排序
            ConsoleAlgorithm("冒泡排序1: ", ready_array, "bubble_sort1");

            // 冒泡排序2
            ConsoleAlgorithm("冒泡排序2: ", ready_array, "bubble_sort2");

            // 冒泡排序3
            ConsoleAlgorithm("冒泡排序3: ", ready_array, "bubble_sort3");

            // 选择排序
            ConsoleAlgorithm("选择排序: ", ready_array, "select_sort");

            // 插入排序
            ConsoleAlgorithm("插入排序: ", ready_array, "insert_sort");

            Console.ReadKey();
        }

        /// <summary>
        /// 输出排序算法结果
        /// </summary>
        /// <param name="name"></param>
        /// <param name="arr"></param>
        public static void ConsoleAlgorithm(string name, int[] arr, string switch_sort)
        {
            int[] sort_copy = new int[arr.Length];
            arr.CopyTo(sort_copy, 0);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            BasicAlgorithm ba = new BasicAlgorithm();
            switch (switch_sort)
            {
                case "bubble_sort1":
                    ba.BubbleSort(sort_copy);
                    break;
                case "bubble_sort2":
                    ba.BubbleSort2(sort_copy);
                    break;
                case "bubble_sort3":
                    ba.BubbleSort3(sort_copy);
                    break;
                case "select_sort":
                    ba.SelectSort(sort_copy);
                    break;
                case "insert_sort":
                    ba.InsertSort(sort_copy);
                    break;
                default:
                    ba.BubbleSort(sort_copy);
                    break;
            }

            sw.Stop();
            Console.WriteLine();
            Console.WriteLine(name);
            //foreach (var item in sort_copy)
            //{
            //    Console.Write(item + " ");
            //}
            Console.WriteLine();
            Console.WriteLine("运行时间:{0}", sw.ElapsedMilliseconds);
            Console.WriteLine("=================");
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
