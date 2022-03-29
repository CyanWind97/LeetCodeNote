namespace LeetCodeNote
{
    /// <summary>
    /// no: 693
    /// title: 交替位二进制数
    /// problems: https://leetcode-cn.com/problems/binary-number-with-alternating-bits/
    /// date: 20220328
    /// </summary>
    public static class Solution693
    {
        public static bool HasAlternatingBits(int n) {
            int a = n ^ (n >> 1);
            
            return (a & (a + 1)) == 0;
        }
    }
}