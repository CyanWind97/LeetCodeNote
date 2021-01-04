namespace LeetCodeNote
{
    /// <summary>
    /// no: 509
    /// title: 斐波那契数
    /// problems: https://leetcode-cn.com/problems/fibonacci-number/
    /// date: 20210104
    /// </summary>
    public static class Solution509
    {
        public static int Fib(int n) {
            if(n == 0 || n == 1)
                return n;

            int[] fib = new int[n + 1];
            fib[0] = 0;
            fib[1] = 1;
            for(int i = 2; i < n + 1; i++){
                fib[i] = fib[i - 1] + fib[i - 2];
            }

            return fib[n];
        }
    }
}