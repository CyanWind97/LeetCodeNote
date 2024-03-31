using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2425
    /// title: 下一个更大元素 IV
    /// problems: https://leetcode.cn/problems/next-greater-element-iv/description/?envType=daily-question&envId=2023-12-12
    /// date: 20231212
    /// </summary>
    public static class Solution2425
    {
        public static int[] SecondGreaterElement(int[] nums) {
            int length = nums.Length;
            var result  = Enumerable.Repeat(-1, length).ToArray();
            var stack1 = new Stack<int>();
            var stack2 = new Stack<int>();
            for(int i = 0; i < length; i++){
                int num = nums[i];

                while(stack2.Count > 0 && nums[stack2.Peek()] < num){
                    result[stack2.Pop()] = num;
                }

                var tmp = new List<int>();
                while(stack1.Count > 0 && nums[stack1.Peek()] < num){
                    tmp.Add(stack1.Pop());
                }

                for(int j = tmp.Count - 1; j >= 0; j--){
                    stack2.Push(tmp[j]);
                }

                stack1.Push(i);
            }


            return result;
        }
    }
}