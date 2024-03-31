namespace LeetCodeNote
{
    /// <summary>
    /// no: 639
    /// title: 解码方法 II
    /// problems: https://leetcode-cn.com/problems/decode-ways-ii/
    /// date: 20210927
    /// </summary>
    public static class Solution639
    {
        public static int NumDecodings(string s) {
            const int MOD = 1000000007;

            int Check1digit(char ch)  
                => ch == '0' 
                ? 0
                : ch == '*' ? 9 : 1;
            
            int Check2digits(char c0, char c1) {
                if (c0 == '*' && c1 == '*') 
                    return 15;
                
                if (c0 == '*') 
                    return c1 <= '6' ? 2 : 1;
                
                if (c1 == '*') {
                    if (c0 == '1') 
                        return 9;

                    if (c0 == '2') 
                        return 6;
                    
                    return 0;
                }

                return (c0 != '0' && (c0 - '0') * 10 + (c1 - '0') <= 26) ? 1 : 0;
            }

            int n = s.Length;
            // a = f[i-2], b = f[i-1], c = f[i]
            long a = 0, b = 1, c = 0;
            for (int i = 1; i <= n; ++i) {
                c = b * Check1digit(s[i - 1]) % MOD;
                if (i > 1)
                    c = (c + a * Check2digits(s[i - 2], s[i - 1])) % MOD;
                
                a = b;
                b = c;
            }
            
            return (int) c;
        }

    }
}