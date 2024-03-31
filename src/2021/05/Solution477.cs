namespace LeetCodeNote
{
    /// <summary>
    /// no: 477
    /// title:  汉明距离总和
    /// problems: https://leetcode-cn.com/problems/total-hamming-distance/
    /// date: 20210528
    /// </summary>
    public static class Solution477
    {
        public static int TotalHammingDistance(int[] nums) {
            int length = nums.Length;
            int k = 1;
            int result = 0;

            while(k < 1000000000){
                int count = 0;
                for(int i = 0; i < length; i++){
                    if((k & nums[i]) != 0)
                        count++;
                }
                result += count * (length - count);
                k = k << 1;
            }

            return result;
        }
    }
}