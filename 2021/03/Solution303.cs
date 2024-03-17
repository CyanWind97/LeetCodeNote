namespace LeetCodeNote
{
    /// <summary>
    /// no: 303
    /// title: 区域和检索 - 数组不可变
    /// problems: https://leetcode-cn.com/problems/range-sum-query-immutable/
    /// date: 20210301
    /// </summary>
    public static partial class Solution303
    {
        public class NumArray {

            private int[] sums;

            public NumArray(int[] nums) {
                int length = nums.Length;
                sums = new int[length + 1];
                sums[0] = 0;
                for(int i = 0; i < length; i++){
                    sums[i + 1] = sums[i] + nums[i];
                }
            }
            
            public int SumRange(int i, int j) {
                return sums[j + 1] - sums[i];
            }
        }
    }
}