namespace LeetCodeNote
{
    /// <summary>
    /// no: 7
    /// title: 砖墙
    /// problems: https://leetcode-cn.com/problems/reverse-integer/
    /// date: 20210503
    /// </summary>
    public static class Solution7
    {
        public static int Reverse(int x) {
            long result = 0;
            while(x != 0){
                int a = x % 10;
                x = x / 10;
                result = 10 * result + a;
            }

            return (result <= int.MaxValue && result >= int.MinValue) ? (int)result : 0;
        }
    }
}