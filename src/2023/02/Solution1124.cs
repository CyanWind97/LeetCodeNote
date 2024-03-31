using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1124
    /// title: 表现良好的最长时间段
    /// problems: https://leetcode.cn/problems/longest-well-performing-interval/
    /// date: 20230214
    /// </summary>
    public static class Solution1124
    {
        public static int LongestWPI(int[] hours) {
            int length = hours.Length;
            var s = new int[length + 1];
            var stack = new Stack<int>();
            stack.Push(0);
            for(int i = 1; i <= length; i++){
                s[i] = s[i - 1] + (hours[i - 1] > 8 ? 1 : -1);
                if(s[stack.Peek()] > s[i])
                    stack.Push(i);
            }

            int result = 0;
            for(int r = length; r >= 1; r--){
                while(stack.Count > 0 && s[stack.Peek()] < s[r])
                    result = Math.Max(result, r - stack.Pop());
            }

            return result;
        }
    }
}