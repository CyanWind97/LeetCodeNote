namespace LeetCodeNote
{
    /// <summary>
    /// no: 6
    /// title: Z 字形变换
    /// problems: https://leetcode-cn.com/problems/zigzag-conversion/
    /// date: 20220301
    /// </summary>
    public static class Solution6
    {
        public static string Convert(string s, int numRows) {
            int length = s.Length;
            if(numRows == 1 || length <= numRows)
                return s;
            
            int n = 2 * numRows - 2;
            int m = length / n;
            int r = length % n;

            var chars = new char[length];

            for(int i = 0; i < m; i++){
                chars[i] = s[i * n];
            }

            int next = m;
            if(r > 0)
                chars[next++] = s[m * n];

            for(int i = 1; i < numRows - 1; i++){
                
                for(int j = 0; j < m; j++){
                    chars[next + 2 * j] = s[ j * n + i];
                    chars[next + 2 * j + 1] = s[j * n + n - i];
                }

                next += 2 * m;
                if(r > i)
                    chars[next++] = s[m * n + i];
                
                if(r > n - i)
                    chars[next++] = s[m * n + n - i];
            }

            for(int i = 0; i < m; i++){
                chars[next++] = s[i * n + numRows - 1];
            }

            if(r >= numRows)
                chars[next++] = s[m * n + numRows - 1];

            return new string(chars);
        }
    }
}