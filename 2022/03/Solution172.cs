namespace LeetCodeNote
{
    /// <summary>
    /// no: 172
    /// title: 阶乘后的零
    /// problems: https://leetcode-cn.com/problems/factorial-trailing-zeroes/
    /// date: 20220325
    /// </summary>
    public static class Solution172
    {
        public static int TrailingZeroes(int n) {
            int count = 0;   


            while(n > 0){
                count += n / 5;

                n /= 5;
            }

            return count;
        }
    }
}