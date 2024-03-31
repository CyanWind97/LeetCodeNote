using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 768
    /// title:  最多能完成排序的块 II
    /// problems: https://leetcode.cn/problems/max-chunks-to-make-sorted-ii/
    /// date: 20220813
    /// </summary>
    public static class Solution768
    {
        // 参考解答 单调栈
        public static int MaxChunksToSorted(int[] arr) {
            var stack = new Stack<int>();
            foreach (int num in arr) {
                if (stack.Count == 0 || num >= stack.Peek()) {
                    stack.Push(num);
                } else {
                    int max = stack.Pop();
                    while (stack.Count > 0 && stack.Peek() > num) {
                        stack.Pop();
                    }
                    stack.Push(max);
                }
            }
            return stack.Count;
        }   
    }
}