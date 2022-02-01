namespace LeetCodeNote
{
    /// <summary>
    /// no: 1763
    /// title: 最长的美好子字符串
    /// problems: https://leetcode-cn.com/problems/longest-nice-substring/
    /// date: 20220201
    /// </summary>
    public static class Solution1763
    {
        public static string LongestNiceSubstring(string s) {
            var maxPos = 0;
            var maxLen = 0;

            void DFS(int start, int end) {
                if (start >= end) 
                    return;
                
                int lower = 0, upper = 0;
                for (int i = start; i <= end; ++i) {
                    if (char.IsLower(s[i])) {
                        lower |= 1 << (s[i] - 'a');
                    } else {
                        upper |= 1 << (s[i] - 'A');
                    }
                }

                if (lower == upper) {
                    if (end - start + 1 > maxLen) {
                        maxPos = start;
                        maxLen = end - start + 1;
                    }

                    return;
                } 
                
                int valid = lower & upper;
                int pos = start;
                while (pos <= end) {
                    start = pos;
                    while (pos <= end && (valid & (1 << char.ToLower(s[pos]) - 'a')) != 0) {
                        ++pos;
                    }
                    DFS(start, pos - 1);
                    ++pos;
                }
            }

            DFS(0, s.Length - 1);

            return s.Substring(maxPos, maxLen);
        }
    }
}