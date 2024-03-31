using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 862
    /// title: 和至少为 K 的最短子数组
    /// problems: https://leetcode.cn/problems/shortest-subarray-with-sum-at-least-k/
    /// date: 20221026
    /// </summary>
    public static class Solution862
    {
        // 参考解答
        // 前缀和 + 双端队列
        public static int ShortestSubarray(int[] nums, int k) {
            int length = nums.Length;
            var preSums = new long[length + 1];
            for(int i = 0; i < length; i++){
                preSums[i + 1] = preSums[i] + nums[i];
            }

            int result = length + 1;
            var list = new LinkedList<int>(){};
            list.AddFirst(0);
            for(int i = 0; i <= length; i++){
                long curSum = preSums[i];
                while(list.Any() && curSum - preSums[list.First.Value] >= k ){
                    result = Math.Min(i - list.First.Value, result);
                    list.RemoveFirst();
                }

                while(list.Any() && curSum <= preSums[list.Last.Value]){
                    list.RemoveLast();
                }

                list.AddLast(i);
            }

            return result == length + 1 ? - 1 : result;
        }
    }
}