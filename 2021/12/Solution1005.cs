using System;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1005
    /// title:  K 次取反后最大化的数组和
    /// problems: https://leetcode-cn.com/problems/relative-ranks/
    /// date: 20211202
    /// </summary>
    public static class Solution1005
    {
        public static int LargestSumAfterKNegations(int[] nums, int k) {
            int length = nums.Length;

            Array.Sort(nums);

            int i = 0;
            for(; i < length && i < k; i++){
                if(nums[i] >= 0)
                    break;
                
                nums[i] = -nums[i];
            }

            if (i < k && (k - i) % 2 == 1) {
                if (i == length || i > 0 && nums[i - 1] < nums[i])
                    i = i - 1;
                
                nums[i] = -nums[i];
            }

            return nums.Sum();
        }
    }
}