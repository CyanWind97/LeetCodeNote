namespace LeetCodeNote
{
    /// <summary>
    /// no: 413
    /// title: 等差数列划分
    /// problems: https://leetcode-cn.com/problems/arithmetic-slices/
    /// date: 20210810
    /// </summary>
    public static class Solution413
    {
        public static int NumberOfArithmeticSlices(int[] nums) {
            int length = nums.Length;
            if(length <= 2)
                return 0;
            
            int result = 0;
            int diff = nums[1] - nums[0];
            int pre = 0;
            for(int i = 2; i < length; i++){
                if(nums[i] - nums[i - 1] != diff){
                    result += (i - pre - 2)*(i - pre - 1) / 2;
                    pre = i - 1;
                    diff = nums[i] - nums[i - 1];
                }
            }

            result += (length - pre - 2)*(length - pre - 1) / 2;

            return result;
        }
    }
}