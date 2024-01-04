using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1944
    /// title: 队列中可以看到的人数
    /// problems: https://leetcode.cn/problems/number-of-visible-people-in-a-queue/description/?envType=daily-question&envId=2024-01-05
    /// date: 20240105
    /// </summary>
    public static class Solution1944
    {
        public static int[] CanSeePersonsCount(int[] heights) {
            var stack = new Stack<int>();
            int length = heights.Length;
            var result = new int[length];
            for(int i = 0; i < length; i++){
                
                while(stack.Count > 0 && heights[stack.Peek()] <= heights[i]){
                    result[stack.Pop()]++;
                }

                if (stack.Count > 0)
                    result[stack.Peek()]++;

                stack.Push(i);
            }

            return result;
        }
    }
}