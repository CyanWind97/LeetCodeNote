namespace LeetCodeNote
{
    /// <summary>
    /// no: 268
    /// title:  丢失的数字
    /// problems: https://leetcode-cn.com/problems/missing-number/
    /// date: 20211106
    /// </summary>
    public static class Solution268
    {
        public static int MissingNumber(int[] nums) {
            int length = nums.Length;
            int result = (length + 1) * length / 2;

            foreach(var num in nums){
                result -= num;
            }

            return result;
        }
    }
}