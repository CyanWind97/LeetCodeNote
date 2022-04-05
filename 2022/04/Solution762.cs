using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 762
    /// title: 二进制表示中质数个计算置位
    /// problems: https://leetcode-cn.com/problems/prime-number-of-set-bits-in-binary-representation/
    /// date: 20220405
    /// </summary>
    public static class Solution762
    {
        public static int CountPrimeSetBits(int left, int right) {
            int BitCount(int i) {
                i = i - ((i >> 1) & 0x55555555);
                i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
                i = (i + (i >> 4)) & 0x0f0f0f0f;
                i = i + (i >> 8);
                i = i + (i >> 16);
                
                return i & 0x3f;
            }

            return Enumerable.Range(left, right - left + 1)
                            .Count(x => ((1 << BitCount(x)) & 665772) != 0);
        }
    }
}