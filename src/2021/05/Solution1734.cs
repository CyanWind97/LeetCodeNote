namespace LeetCodeNote
{
    /// <summary>
    /// no: 1734
    /// title: 解码异或后的排列
    /// problems: https://leetcode-cn.com/problems/decode-xored-permutation/
    /// date: 20210511
    /// </summary>
    public static class Solution1734
    {
        public static int[] Decode(int[] encoded) {
            int length = encoded.Length + 1;
            int total = 0;
            for(int i = 1; i <= length; i++){
                total ^= i;
            }

            int odd = 0;
            for(int i = 1; i < length - 1; i += 2){
                odd ^= encoded[i];
            }

            int[] perm = new int[length];
            perm[0] = total ^ odd;
            for(int i = 0; i < length - 1; i++){
                perm[i + 1] = perm[i] ^ encoded[i];
            }

            return perm;
        }
    }
}