namespace LeetCodeNote
{
    /// <summary>
    /// no: 342
    /// title: 4的幂
    /// problems: https://leetcode-cn.com/problems/power-of-four/
    /// date: 20210531
    /// </summary>
    public static class Solution342
    {
        public static bool IsPowerOfFour(int n) {
            return (n > 0) && (n & (n - 1)) == 0 && (0x2AAAAAAA & n) == 0;
        }
    }
}