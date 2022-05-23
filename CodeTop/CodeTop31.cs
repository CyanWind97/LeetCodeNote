using System;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 31
    /// title:  下一个排列
    /// problems: https://leetcode.cn/problems/next-permutation/
    /// date: 20220523
    /// priority: 0095
    /// time: 00:21:26.45 timeout
    /// </summary>
    public static class CodeTop31
    {
        // 参考解答
        public static void NextPermutation(int[] nums) {
            int length = nums.Length;
            int i = length - 2;

            while(i >= 0 && nums[i] >= nums[i + 1]){
                i--;
            }

            if(i >= 0){
                int j = length - 1;
                while(j >= 0 && nums[i] >= nums[j]){
                    j--;
                }

                (nums[i], nums[j]) = (nums[j], nums[i]);
            }
            
            Array.Reverse(nums, i + 1, length - i - 1);
        }
    }
}