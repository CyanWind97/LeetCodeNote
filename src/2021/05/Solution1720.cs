namespace LeetCodeNote
{
    /// <summary>
    /// no: 1720
    /// title:  解码异或后的数组
    /// problems: https://leetcode-cn.com/problems/decode-xored-array/
    /// date: 20210506
    /// </summary>
    public static class Solution1720
    {
        public static int[] Decode(int[] encoded, int first) {
            int length = encoded.Length;
            int[] result = new int[length + 1];

            result[0] = first;
            for(int i = 1; i < length + 1; i++){
                result[i] = encoded[i -1] ^ result[i - 1];
            }

            return result;
        }
    }
}