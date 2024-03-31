using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2104
    /// title: 子数组范围和
    /// problems: https://leetcode-cn.com/problems/sum-of-subarray-ranges/
    /// date: 20220304
    /// </summary>
    public static class Solution2104
    {
        // 参考解答 单调栈
        public static long SubArrayRanges(int[] nums) {
            int n = nums.Length;
            int[] minLeft = new int[n];
            int[] minRight = new int[n];
            int[] maxLeft = new int[n];
            int[] maxRight = new int[n];
            var minStack = new Stack<int>();
            var maxStack = new Stack<int>();
            for (int i = 0; i < n; i++) {
                while (minStack.Count > 0 && nums[minStack.Peek()] > nums[i]) {
                    minStack.Pop();
                }
                minLeft[i] = minStack.Count == 0 ? -1 : minStack.Peek();
                minStack.Push(i);
                
                // 如果 nums[maxStack.Peek()] == nums[i], 那么根据定义，
                // nums[maxStack.Peek()] 逻辑上小于 nums[i]，因为 maxStack.Peek() < i
                while (maxStack.Count > 0 && nums[maxStack.Peek()] <= nums[i]) { 
                    maxStack.Pop();
                }
                maxLeft[i] = maxStack.Count == 0 ? -1 : maxStack.Peek();
                maxStack.Push(i);
            }
            minStack.Clear();
            maxStack.Clear();
            for (int i = n - 1; i >= 0; i--) {
                // 如果 nums[minStack.Peek()] == nums[i], 那么根据定义，
                // nums[minStack.Peek()] 逻辑上大于 nums[i]，因为 minStack.Peek() > i
                while (minStack.Count > 0 && nums[minStack.Peek()] >= nums[i]) { 
                    minStack.Pop();
                }
                minRight[i] = minStack.Count == 0 ? n : minStack.Peek();
                minStack.Push(i);

                while (maxStack.Count > 0 && nums[maxStack.Peek()] < nums[i]) {
                    maxStack.Pop();
                }
                maxRight[i] = maxStack.Count == 0 ? n : maxStack.Peek();
                maxStack.Push(i);
            }

            long sumMax = 0, sumMin = 0;
            for (int i = 0; i < n; i++) {
                sumMax += (long) (maxRight[i] - i) * (i - maxLeft[i]) * nums[i];
                sumMin += (long) (minRight[i] - i) * (i - minLeft[i]) * nums[i];
            }
            return sumMax - sumMin;
        }
    }
}