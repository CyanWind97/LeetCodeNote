using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1200
    /// title: 最小绝对差
    /// problems: https://leetcode.cn/problems/minimum-absolute-difference/
    /// date: 20220704
    /// </summary>
    public static class Solution1200
    {
        public static IList<IList<int>> MinimumAbsDifference(int[] arr) {
            Array.Sort(arr);
            int length = arr.Length;

            int min = int.MaxValue;
            var result = new List<IList<int>>();
            
            for(int i = 0; i < length - 1; i++){
                int diff = arr[i + 1] - arr[i];
                if(diff > min)
                    continue;
                
                if(diff < min){
                    result.Clear();
                    min = diff;
                }

                result.Add(new int[]{arr[i], arr[i + 1]});
            }

            return result;
        }
    }
}