using System;
using System.Collections.Generic;
using System.Text;

namespace Basic_Algorithm
{
    class BasicAlgorithm
    {
        /// <summary>
        /// 冒泡排序
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[] BubbleSort(int[] arr)
        {
            int array_length = arr.Length;
            for(int i=0;i< array_length; i++)
            {
                for(int j=0;j< array_length - 1-i;j++)
                {
                    if (arr[j] > arr[j+1])
                    {
                        int temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                    }                
                }
            }
            return arr;
        }

        /// <summary>
        /// 冒泡排序2, 这种改进和原本的冒泡排序思路基本一致，只是外层循环少了一次而已。原本的冒牌外层是for，这个是while
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[] BubbleSort2(int[] arr)
        {
            int array_length = arr.Length - 1;
            while (array_length > 0)
            {
                int pos = 0;
                for(int i = 0; i < array_length; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        pos = i;
                        int temp = arr[i + 1];
                        arr[i + 1] = arr[i];
                        arr[i] = temp;
                    }
                }
                array_length = pos;
            }

            return arr;
        }

        /// <summary>
        /// 冒泡排序3, 每次排序分别进行一个最大值和一个最小值的排排序
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[] BubbleSort3(int[] arr)
        {
            int low = 0;
            int high = arr.Length - 1;
            int temp, j;
            while (low < high)
            {
                for (j = low; j < high; ++j)
                {
                    if(arr[j]>arr[j+1])
                    {
                        temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                    }
                }
                --high;

                for (j = high; j > low; --j)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        temp = arr[j + 1];
                        arr[j + 1] = arr[j];
                        arr[j] = temp;
                    }
                }
                ++low;
            }

            return arr;
        }

        /// <summary>
        /// 选择排序
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[] SelectSort(int[] arr)
        {
            int array_length = arr.Length;
            int minIndex, temp;
            for(int i = 0; i < array_length - 1; i++)
            {
                minIndex = i;
                for(int j = i + 1; j < array_length; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }
                temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
            }

            return arr;
        }

        /// <summary>
        /// 插入排序
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[] InsertSort(int[] arr)
        {
            int array_length = arr.Length;
            for(int i = 1; i < array_length; i++)
            {
                int key = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = key;
            }

            return arr;
        }

        /// <summary>
        /// 希尔排序
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[] ShellSort(int[] arr)
        {
            int array_length = arr.Length;
            int temp = 0;
            while (array_length >= 1)
            {
                for (int i = array_length; i < arr.Length; i++)
                {
                    for (int j = i; j >= array_length && arr[j] < arr[j - array_length]; j -= array_length)
                    {
                        temp = arr[j];
                        arr[j] = arr[j - array_length];
                        arr[j - array_length] = temp;

                    }
                }
                array_length /= 30000;
            }

            return arr;
        }


    }
}
