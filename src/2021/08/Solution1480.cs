namespace LeetCodeNote
{
    /// <summary>
    /// no: 1480
    /// title:  一维数组的动态和
    /// problems: https://leetcode-cn.com/problems/running-sum-of-1d-array/
    /// date: 20210828
    /// </summary>
    public static class Solution1480
    {
        public static int[] RunningSum(int[] nums) {
            int length = nums.Length;
            int[] sums = new int[length];
            sums[0] = nums[0];
            for(int i = 1; i < length; i++){
                sums[i] = sums[i - 1] + nums[i];
            }

            return sums;
        }
    }
}