using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 553
    /// title: 最优除法
    /// problems: https://leetcode-cn.com/problems/optimal-division/
    /// date: 20220227
    /// </summary>
    public static class Solution553
    {
        public static string OptimalDivision(int[] nums) {
            int length = nums.Length;

            if(length == 1)
                return $"{nums[0]}";
            else if(length == 2)
                return string.Join("/", nums);
            else
                return $"{nums[0]}/({string.Join("/", nums.Skip(1))})";
        }
    }
}