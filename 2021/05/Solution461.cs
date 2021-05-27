namespace LeetCodeNote
{
    /// <summary>
    /// no: 461
    /// title: 汉明距离
    /// problems: https://leetcode-cn.com/problems/hamming-distance/
    /// date: 20210527
    /// </summary>
    public static class Solution461
    {
        public static int HammingDistance(int x, int y) {
            int xor = x ^ y;
            int result = 0;
            while(xor != 0){
                xor &= xor - 1;
                result++;
            }

            return result;
        }
    }
}