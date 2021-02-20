using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1438
    /// title: 绝对差不超过限制的最长连续子数组
    /// problems: https://leetcode-cn.com/problems/longest-continuous-subarray-with-absolute-diff-less-than-or-equal-to-limit/
    /// date: 20210221
    /// </summary>
    public static class Solution1438
    {
        // 参考解答 滑动窗口 + 单调队列
        public static int LongestSubarray(int[] nums, int limit) {
            int length = nums.Length;
            var min = new LinkedList<int>();
            var max = new LinkedList<int>();
            int left = 0;
            int right = 0;
            int result = 0;

            while(right < length){
                int num = nums[right];
                while(max.Count != 0 && max.Last.Value < num){
                    max.RemoveLast();
                }
                while(min.Count != 0 && min.Last.Value > num){
                    min.RemoveLast();
                }

                max.AddLast(num);
                min.AddLast(num);
                while(max.Count != 0 && min.Count != 0 && max.First.Value - min.First.Value > limit){
                    if(nums[left] == max.First.Value)
                        max.RemoveFirst();
                    
                    if(nums[left] == min.First.Value)
                        min.RemoveFirst();

                    left++;
                }
                
                right++;
                result = Math.Max(result, right - left);
            }
            
            return result;
        }
    }
}