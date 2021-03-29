namespace LeetCodeNote
{
    /// <summary>
    /// no: 191
    /// title: 位1的个数
    /// problems: https://leetcode-cn.com/problems/number-of-1-bits/
    /// date: 20210322
    /// </summary>
    public static class Solution191
    {
        public static int HammingWeight(uint n) {
            int result = 0;
            while(n != 0){
                n &= n - 1;
                result++;
            }

            return result;
        }
    }
}