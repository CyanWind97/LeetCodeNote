using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2865
    /// title: 美丽塔 I
    /// problems: https://leetcode.cn/problems/beautiful-towers-i/description/?envType=daily-question&envId=2024-01-24
    /// date: 20240124
    /// </summary>
    public static class Solution2865
    {
        public static long MaximumSumOfHeights(IList<int> maxHeights) {
            var n = maxHeights.Count;
            long result = 0;
            var prefix = new long[n];
            var suffix = new long[n];
            var stack1 = new Stack<int>();
            var stack2 = new Stack<int>();

            for(int i = 0; i < n; i++){
                while(stack1.Count > 0 && maxHeights[i] < maxHeights[stack1.Peek()])
                    stack1.Pop();
                
                prefix[i] = stack1.Count == 0 
                        ? (long)(i + 1) * maxHeights[i]
                        : prefix[stack1.Peek()] + (i - stack1.Peek()) * (long)maxHeights[i];
                
                stack1.Push(i);
            }

            for(int i = n - 1; i >= 0; i--){
                while(stack2.Count > 0 && maxHeights[i] < maxHeights[stack2.Peek()])
                    stack2.Pop();
                
                suffix[i] = stack2.Count == 0 
                        ? (long)(n - i) * maxHeights[i]
                        : suffix[stack2.Peek()] + (stack2.Peek() - i) * (long)maxHeights[i];
                
                stack2.Push(i);
                result = Math.Max(result, prefix[i] + suffix[i] - maxHeights[i]);
            }

            return result;
        }
    }
}