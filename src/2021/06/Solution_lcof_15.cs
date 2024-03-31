namespace LeetCodeNote
{
    /// <summary>
    /// no: 15
    /// title: 二进制中1的个数
    /// problems: https://leetcode-cn.com/problems/er-jin-zhi-zhong-1de-ge-shu-lcof/
    /// date: 20210623
    /// type: 剑指Offer lcof
    /// </summary>
    public static class Solution_lcof_15
    {
        public static int HammingWeight(uint n) {
            int count = 0;
            while(n != 0){
                n = n & n -1;
                count++;
            }

            return count;
        }
    }
}