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
            for(int i=0;i<arr.Length;i++)
            {
                for(int j=0;j<arr.Length-1-i;j++)
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
    }
}
