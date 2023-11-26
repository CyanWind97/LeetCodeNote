using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 907
    /// title: 子数组的最小值之和
    /// problems: https://leetcode.cn/problems/sum-of-subarray-minimums/
    /// date: 20221028
    /// </summary>    
    public static partial class Solution907
    {
        public static int SumSubarrayMins(int[] arr) {
            int MOD = 1_000_000_007;

            var stack = new Stack<(int Value, int Count)>();
            int result = 0;
            int dot = 0;

            int length= arr.Length;
            for(int j = 0; j < length; j++){
                int count = 1;
                int num = arr[j];
                while(stack.Count > 0 && stack.Peek().Value >= num){
                    var top = stack.Pop();
                    count += top.Count;
                    dot -= top.Value * top.Count;                    
                }

                stack.Push((num, count));
                dot += num * count;
                result += dot;
                result %= MOD;
            }
            

            return result;
        }
    }
}