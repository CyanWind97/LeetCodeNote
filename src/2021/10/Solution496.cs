using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 496
    /// title: 下一个更大元素 I
    /// problems: https://leetcode-cn.com/problems/next-greater-element-i/
    /// date: 20211026
    /// </summary>
    public static class Solution496
    {
        public static int[] NextGreaterElement(int[] nums1, int[] nums2) {
            int length = nums2.Length;

            var lookup = new Dictionary<int, int>();
            var stack = new Stack<int>();

            for(int i = length - 1; i >= 0; i--){
                while(stack.Count > 0 && nums2[i] >= stack.Peek()){
                    stack.Pop();
                }

                lookup.Add(nums2[i], stack.Count > 0 ? stack.Peek() : - 1);
                stack.Push(nums2[i]);
            }


            return nums1.Select(x => lookup[x]).ToArray();
        }
    }
}