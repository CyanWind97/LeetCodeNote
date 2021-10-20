using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 453
    /// title: 最小操作次数使数组元素相等
    /// problems: https://leetcode-cn.com/problems/minimum-moves-to-equal-array-elements/
    /// date: 20211020
    /// </summary>
    public static class Solution453
    {
        public static int MinMoves(int[] nums) {
            int minNum = nums.Min();
            int result = 0;
            foreach (int num in nums) {
                result += num - minNum;
            }
            return result;
        }
    }
}