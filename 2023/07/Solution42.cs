using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 42
    /// title: 接雨水
    /// problems: https://leetcode.cn/problems/trapping-rain-water/submissions/
    /// date: 20230723
    /// </summary>
    public static class Solution42
    {
        public static int Trap(int[] height) {
            int length = height.Length;
            var stack = new Stack<int>();
            int result = 0;
            for(int i = 0; i < length; i++){
                while(stack.Count > 0 && height[i] > height[stack.Peek()]){
                    int top = stack.Pop();
                    if(stack.Count == 0)
                        break;
                    
                    int left = stack.Peek();
                    int currWidth = i - left  - 1;
                    int currHeight = Math.Min(height[left], height[i]) - height[top];
                    result += currWidth * currHeight;
                }

                stack.Push(i);
            }

            return result;
        }
    }
}