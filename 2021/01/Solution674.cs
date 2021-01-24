namespace LeetCodeNote
{
    /// <summary>
    /// no: 674
    /// title: 最长连续递增序列
    /// problems: https://leetcode-cn.com/problems/longest-continuous-increasing-subsequence/
    /// date: 20210124
    /// </summary>
    public static class Solution674
    {
        public static int FindLengthOfLCIS(int[] nums) {
            int length = nums.Length;
            if(length == 0)
                return 0;

            int result = 1;
            int cur = 1;
            for(int i = 1; i < length; i ++){
                if(nums[i] > nums[i - 1])
                    cur++;
                else
                {
                    if(cur > result)
                        result = cur;
                    
                    cur = 1;
                }
            }

            if(cur > result)
                result = cur;

            return result;
        }
    }
}