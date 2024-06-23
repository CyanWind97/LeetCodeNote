using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 503
    /// title: 下一个更大元素 II
    /// problems: https://leetcode-cn.com/problems/next-greater-element-ii/
    /// date: 20210306
    /// </summary>
    public static partial class Solution503
    {
        public static int[] NextGreaterElements(int[] nums) {
            int length = nums.Length;
            if(length == 0)
                return new int[]{};
            
            int[] result = new int[length];
            Array.Fill(result, -1);
            Stack<int> stack = new Stack<int>();
            int index = 0;
            stack.Push(index++);
        
            int pre = 0;
            while(index < length){
                while(stack.TryPop(out pre) && nums[index] > nums[pre]){
                    result[pre] = nums[index];
                }
                if(nums[pre] >= nums[index])
                    stack.Push(pre);

                stack.Push(index);
                index++;
            }
            index = 0;
            while(index < length && stack.Count > 0){
                pre = stack.Peek();
                if(index == pre)
                    stack.Pop();
                
                if(nums[index] > nums[pre]){
                    result[pre] = nums[index];
                    stack.Pop();
                }else
                    index++;
            }
            
            return result;
        }


        // 参考解答 更直观的写法
        public static int[] NextGreaterElements_1(int[] nums) {
            int length = nums.Length;
            if(length == 0)
                return [];
            
            int[] result = new int[length];
            Array.Fill(result, -1);
            Stack<int> stack = new Stack<int>();

            for(int i = 0; i < length * 2 - 1; i++){
                while(stack.Count > 0 && nums[stack.Peek()] < nums[i % length]){
                    result[stack.Pop()] = nums[i % length];
                }
                stack.Push(i % length);
            }

            
            return result;
        }
    }
}