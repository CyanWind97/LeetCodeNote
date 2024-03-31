namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 10
    /// title:  正则表达式匹配
    /// problems: https://leetcode.cn/problems/regular-expression-matching/
    /// date: 20220523
    /// priority: 0098
    /// time: 00:13:55.46 timeout
    /// </summary>
    public static class CodeTop10
    {
        // 参考解答 dp
        public static bool IsMatch(string s, string p) {
            int m = s.Length;
            int n = p.Length;

            var f = new bool[m + 1, n + 1];
            f[0, 0] = true;

            bool Matches(int i, int j){
                if(i == 0)
                    return false;
                
                if(p[j - 1] == '.')
                    return true;
                
                return s[i - 1] == p[j - 1];
            }

            for(int i = 0; i <= m; i++){
                for(int j = 1; j <= n; j++){
                    if(p[j - 1] == '*'){
                        f[i, j] = f[i, j - 2];
                        if(Matches(i, j - 1))
                            f[i, j] = f[i, j] || f[i - 1, j];
                    }else{
                        if(Matches(i, j))
                            f[i, j] = f[i - 1, j - 1];
                    }
                }
            }

            return f[m, n];
        }
    }
}