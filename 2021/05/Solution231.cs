namespace LeetCodeNote
{
    // <summary>
    /// no: 231
    /// title: 2 的幂
    /// problems: https://leetcode-cn.com/problems/power-of-two/
    /// date: 20210530
    /// </summary>
    public class Solution231
    {
        public static bool IsPowerOfTwo(int n) {
            return n > 0 && (n & (n - 1)) == 0;
        }
    }
}