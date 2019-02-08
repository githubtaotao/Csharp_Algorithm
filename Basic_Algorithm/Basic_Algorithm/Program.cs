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


            int flag = HalfSearch(10000, 899);

            //// 冒泡排序
            //ConsoleAlgorithm("冒泡排序1: ", ready_array, "bubble_sort1", false);

            //// 冒泡排序2
            //ConsoleAlgorithm("冒泡排序2: ", ready_array, "bubble_sort2", false);

            //// 冒泡排序3
            //ConsoleAlgorithm("冒泡排序3: ", ready_array, "bubble_sort3", false);

            //// 选择排序
            //ConsoleAlgorithm("选择排序: ", ready_array, "select_sort", false);

            //// 插入排序
            //ConsoleAlgorithm("插入排序: ", ready_array, "insert_sort", false);

            //// 希尔排序
            //ConsoleAlgorithm("希尔排序: ", ready_array, "shell_sort", false);

            Console.ReadKey();
        }

        /// <summary>
        /// 输出排序算法结果
        /// </summary>
        /// <param name="name"></param>
        /// <param name="arr"></param>
        /// <param name="is_show_console"></param>
        public static void ConsoleAlgorithm(string name, int[] arr, string switch_sort, Boolean is_show_console)
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
                case "shell_sort":
                    ba.ShellSort(sort_copy);
                    break;
                default:
                    ba.BubbleSort(sort_copy);
                    break;
            }

            sw.Stop();
            Console.WriteLine();
            Console.WriteLine(name);

            if(is_show_console)
            {
                foreach (var item in sort_copy)
                {
                    Console.Write(item + " ");
                }
            }
            
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

        /// <summary>
        /// 拆半查找
        /// </summary>
        /// <param name="array_length"></param>
        /// <param name="find_key"></param>
        /// <returns></returns>
        public static int HalfSearch(int array_length, int find_key)
        {
            //初始化有序数组
            int[] temp = new int[array_length];
            for(int i = 0; i < array_length; i++)
            {
                temp[i] = i + 1;
            }

            int low = 0;
            int high = array_length - 1;
            int count = 0;
            int flag = 0;
            while(low<= high)
            {
                count++;
                int mid = (low + high) / 2;
                Console.WriteLine("第{0}次查找,value值为:{4}, index值为:{1}, low:{2}, high:{3}", count, mid, low, high, temp[mid]);
                if (find_key == temp[mid])
                {
                    flag = 1;
                    
                    break;
                }
                if (find_key > temp[mid])
                {
                    low = mid + 1;
                }
                if (find_key < temp[mid])
                {
                    high = mid - 1;
                }
               
            }
            if (flag == 1)
            {
                return flag;
            }
            return -1;
        }
    }
}
