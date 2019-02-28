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
        /// 希尔排序，插入排序的威力加强版
        /// </summary>
        /// <param name="arr"></param>
        /// <returns></returns>
        public int[] ShellSort(int[] arr)
        {
            int array_length = arr.Length;
            int gap = array_length / 2;
            while (1<=gap)
            {
                for (int i = gap; i < array_length; i++)
                {
                    int j = 0;
                    int temp = arr[i];
                    for (j = i - gap; j >= 0 && temp < arr[j]; j = j - gap)
                    {
                        arr[j + gap] = arr[j];
                    }
                    arr[j + gap] = temp;
                }
                gap /= 2;
            }

            return arr;
        }

        /// <summary>
        /// 快速排序
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        public int[] Quicksort(int[] arr, int low, int high)
        {
            if (low >= high)
            {
                return arr;
            }
            int first = low, last = high;
            //此时a[low]被保存到key，所以元素a[low]可以当作是一个空位，用于保存数据，之后每赋值一次，也会有一个位置空出来，直到last==first，此时a[last]==a[first]=key
            int key = arr[low];
            while (first < last)
            {
                while (first < last && arr[last] >= key)
                {
                    last--;
                }
                arr[first] = arr[last];
                while (first < last && arr[first] <= key)
                {
                    first++;
                }
                arr[last] = arr[first];
            }
            arr[first] = key;
            //递归排序数组左边的元素
            Quicksort(arr, low, first - 1);
            //递归排序右边的元素
            Quicksort(arr, first + 1, high);

            return arr;
        }

    }
}
