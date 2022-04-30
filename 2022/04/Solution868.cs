using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 868
    /// title: 二进制间距
    /// problems: https://leetcode-cn.com/problems/binary-gap/
    /// date: 20220424
    /// </summary>
    public static class Solution868
    {
        public static int BinaryGap(int n) {
            int last = -1;
            int result = 0;

            for (int i = 0; n != 0; ++i) {
                if ((n & 1) == 1) {
                    if (last != -1) 
                        result = Math.Max(result, i - last);
                    
                    last = i;
                }
                n >>= 1;
            }

            return result;
        }
    }
}