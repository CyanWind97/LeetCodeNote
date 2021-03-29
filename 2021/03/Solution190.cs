namespace LeetCodeNote
{
    /// <summary>
    /// no: 190
    /// title: 颠倒二进制位
    /// problems: https://leetcode-cn.com/problems/reverse-bits/
    /// date: 20210329
    /// </summary>
    public static class Solution190
    {
        public static uint reverseBits(uint n) {
            uint result = 0;
            for(int i = 0; i < 32; i++){
                uint t = n & 1;
                result <<= 1;
                result += t;
                n >>= 1;
            }
            
            return result;
        }

        // 查表
        public static uint reverseBits_1(uint n) {
            uint result = 0;
            uint[] map = new uint[]{ 0, 8, 4, 12, 2, 10, 6, 14, 1, 9, 5, 13, 3, 11, 7, 15};
            for(int i = 0; i < 8; i++){
                uint t = n & 15;
                result <<= 4;
                result += map[t];
                n >>= 4;
            }
            
            return result;
        }

        // 参考解答 分治
        public static uint reverseBits_2(uint n) {
            const uint M1 = 0x55555555; // 01010101010101010101010101010101
            const uint M2 = 0x33333333; // 00110011001100110011001100110011
            const uint M4 = 0x0f0f0f0f; // 00001111000011110000111100001111
            const uint M8 = 0x00ff00ff; // 00000000111111110000000011111111
            
            n = n >> 1 & M1 | (n & M1) << 1;
            n = n >> 2 & M2 | (n & M2) << 2;
            n = n >> 4 & M4 | (n & M4) << 4;
            n = n >> 8 & M8 | (n & M8) << 8;
            n = n >> 16 | n << 16;

            return n;
        }
    }
}