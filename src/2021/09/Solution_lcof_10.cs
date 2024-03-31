namespace LeetCodeNote
{
    /// <summary>
    /// no: 10
    /// title: I. 斐波那契数列
    /// problems: https://leetcode-cn.com/problems/fei-bo-na-qi-shu-lie-lcof/
    /// date: 20210904
    /// type: 剑指Offer lcof
    /// </summary>
    public static class Solution_lcof_10
    {
        public static int Fib(int n) {
            if(n == 0)
                return 0;

            if(n == 1)
                return 1;

            const int MOD = 1000000007;
            int a = 0;
            int b = 1;
            int c = 1;

            for(int i = 2; i < n; i++){
                (a, b, c) = (b, c, (b + c) % MOD);
            }

            return c;
        }
    }
}