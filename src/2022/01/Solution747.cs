namespace LeetCodeNote
{
    /// <summary>
    /// no: 747
    /// title: 至少是其他数字两倍的最大数
    /// problems: https://leetcode-cn.com/problems/largest-number-at-least-twice-of-others/
    /// date: 20220113
    /// </summary>
    public static class Solution747
    {
        public static int DominantIndex(int[] nums) {
            int index = 0;
            int max = nums[0];
            int max2 = -1;

            int length = nums.Length;
            for(int i = 1; i < length; i++){
                if(max < nums[i]){
                    max2 = 2 * max;
                    max = nums[i];
                    index = i;
                }else if(max2 < nums[i] * 2){
                    max2 = 2 * nums[i];
                }
            }

            return max >= max2 ? index : -1;
        }
    }
}