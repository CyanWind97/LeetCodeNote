using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 456
    /// title: 132模式
    /// problems: https://leetcode-cn.com/problems/132-pattern/
    /// date: 20210324
    /// </summary>
    public static class Solution456
    {
        // 参考解答
        public static bool Find132pattern(int[] nums) {
            int length = nums.Length;
            Stack<int> stack = new Stack<int>();
            stack.Push(nums[length - 1]);
            int max = int.MinValue;

            for(int i = length - 2; i >= 0; i--){
                if(nums[i] < max)
                    return true;
                
                while(stack.Count() > 0 && nums[i] > stack.Peek()){
                    max = stack.Pop();
                }

                if(nums[i] > max){
                    stack.Push(nums[i]);
                }
            }

            return false;
        }
    }
}