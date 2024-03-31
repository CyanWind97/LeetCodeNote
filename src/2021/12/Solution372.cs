namespace LeetCodeNote
{
    /// <summary>
    /// no: 372
    /// title: 超级次方
    /// problems: https://leetcode-cn.com/problems/super-pow/
    /// date: 20211205
    /// </summary>
    public static class Solution372
    {
        // 参考解答 数论
        public static int SuperPow(int a, int[] b) {
            const int MOD = 1337;

            int Pow(int x, int n){
                int res = 1;
                while(n != 0){
                    if (n % 2 != 0)
                        res = (int)((long)res * x % MOD);

                    x = (int)((long)x * x % MOD);
                    n /= 2;
                }

                return res;
            }

            int ans = 1;
            foreach(var e in b){
                ans = (int)((long) Pow(ans, 10) * Pow(a, e) % MOD);
            }
           

            return ans;
            
        }
    }
}