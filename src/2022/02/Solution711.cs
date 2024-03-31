namespace LeetCodeNote
{
    /// <summary>
    /// no: 711
    /// title: 1 比特与 2 比特字符
    /// problems: https://leetcode-cn.com/problems/1-bit-and-2-bit-characters/
    /// date: 20220220
    /// </summary>
    public static class Solution711
    {
        public static bool IsOneBitCharacter(int[] bits) {
            int length = bits.Length;
            int i = 0;
            while(i < length - 1){
                i += bits[i] + 1;
            }

            return i == length ? false : bits[i] == 0;
        }
    }
}