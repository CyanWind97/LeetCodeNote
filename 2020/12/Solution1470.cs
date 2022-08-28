namespace LeetCodeNote
{
    /// <summary>
    /// no: 1470
    /// title: 重新排列数组
    /// problems: https://leetcode-cn.com/problems/shuffle-the-array/
    /// date: 20201216
    /// </summary>
    public static partial class Solution1470
    {
        public static int[] Shuffle(int[] nums, int n) {
            int[] result = new int[2 * n];
            for(int i = 0; i < n; i++) {
                result[2*i] = nums[i];
                result[2*i+1] = nums[i + n];
            }

            return result;
        } 
    }
}