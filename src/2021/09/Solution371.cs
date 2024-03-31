namespace LeetCodeNote
{
    /// <summary>
    /// no: 371
    /// title: 两整数之和
    /// problems: https://leetcode-cn.com/problems/sum-of-two-integers/
    /// date: 20210926
    /// </summary>
    public static class Solution371
    {
        // 参考解答 位运算
        public static int GetSum(int a, int b) {
            while (b != 0) {
                int carry = (a & b) << 1;
                a = a ^ b;
                b = carry;
            }
            return a;
        }
    }
}