using System.Threading;
using System;
using System.Globalization;
using System.Collections;
using System.Collections.Generic;
namespace LeetCodeNote
{
    /// <summary>
    /// no: 17.21
    /// title: 直方图的水量
    /// problems: https://leetcode-cn.com/problems/volume-of-histogram-lcci/
    /// date: 20210402
    /// type: 面试题 lcci
    /// </summary>
    public static class Solution_lcci_17_21
    {
        // 参考解答 单调栈
        public static int Trap(int[] height) {
            int length = height.Length;
            if(length <= 1)
                return 0;
            
            int result = 0;
            Stack<int> stack = new Stack<int>();

            for(int i = 0; i < length; i++)
            {
                while(stack.Count > 0 && height[i] > height[stack.Peek()])
                {
                    int top = stack.Pop();
                    if(stack.Count == 0)
                        break;
                    
                    int left = stack.Peek();
                    int w = i - left - 1;
                    int h = Math.Min(height[left], height[i]) - height[top];
                    result += w * h;
                }

                stack.Push(i);
            }

            return result;
        }


        // 参考解答 双指针
        public static int Trap_1(int[] height) {
            int length = height.Length;
            if(length <= 1)
                return 0;
            
            int result = 0;
            int left = 0, right = length - 1;
            int leftMax = height[left], rightMax = height[right];
            while(left < right)
            {
                if(height[left] < height[right])
                {
                    result += leftMax - height[left];
                    left++;
                    leftMax = Math.Max(leftMax, height[left]);
                }else
                {
                    result += rightMax - height[right];
                    right--;
                    rightMax = Math.Max(rightMax, height[right]);
                }
            }

            return result;
        }
    }
}