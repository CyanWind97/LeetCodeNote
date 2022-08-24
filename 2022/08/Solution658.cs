using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 658
    /// title:  找到 K 个最接近的元素
    /// problems: https://leetcode.cn/problems/find-k-closest-elements/
    /// date: 20220825
    /// </summary>
    public static class Solution658
    {
        public static IList<int> FindClosestElements(int[] arr, int k, int x) {
            int right = Array.BinarySearch(arr, x);
            if(right < 0)
                right = ~right;
            
            int left = right - 1;
            while (k-- > 0) {
                if (left < 0) 
                    right++;
                else if (right >= arr.Length) 
                    left--;
                else if (x - arr[left] <= arr[right] - x)
                    left--;
                else
                    right++;
            }
            var result = new List<int>();
            for (int i = left + 1; i < right; i++) {
                result.Add(arr[i]);
            }

            return result;
        }
    }
}