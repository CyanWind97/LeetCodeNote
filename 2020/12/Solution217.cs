using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 217
    /// title: 存在重复元素
    /// problems: https://leetcode-cn.com/problems/contains-duplicate/
    /// date: 20201213
    /// </summary>
    public static class Solution217
    {
        public static bool ContainsDuplicate(int[] nums) {
            HashSet<int> set = new HashSet<int>();
            for(int i = 0; i < nums.Length; i++) {
                if(!set.Add(nums[i]))
                    return true;
            }

            return false;
        }
    }
}