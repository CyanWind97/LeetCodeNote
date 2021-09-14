using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 524
    /// title: 通过删除字母匹配到字典里最长单词
    /// problems: https://leetcode-cn.com/problems/longest-word-in-dictionary-through-deleting/
    /// date: 20210914
    /// </summary>
    public static class Solution524
    {
        public static string FindLongestWord(string s, IList<string> dictionary) {
            int legnth = s.Length;
            var strs = dictionary.OrderByDescending(x => x.Length)
                                 .Where(x => x.Length <= legnth)
                                 .ToList();
            int maxLength = 0;
            string maxStr = "";

            bool IsMatch(string str)
            {
                int strLength = str.Length;
                
                int i = 0; 
                int j = 0;
                while(i < legnth && j < strLength){
                    if(s[i] == str[j])
                        j++;
                    
                    i++;
                }

                return j == strLength;
            }

            foreach(var str in strs)
            {
                int curLength = str.Length;
                if(curLength < maxLength)
                    break;

                if(IsMatch(str)){
                    if(maxLength == 0 || str.CompareTo(maxStr) < 0)
                        maxStr = str;
                    
                    maxLength = curLength;
                }
            }

            return maxStr;
        }

        // 参考解答 动态规划 序列自动机
        public static string FindLongestWord_1(string s, IList<string> dictionary) {
            int m = s.Length;
            int[,] f = new int[m + 1, 26];
            for (int j = 0; j < 26; ++j) {
                f[m, j] = m;
            }

            for (int i = m - 1; i >= 0; --i) {
                for (int j = 0; j < 26; j++) {
                    if (s[i] == (char) ('a' + j))
                        f[i, j] = i;
                    else
                        f[i, j] = f[i + 1, j];
                }
            }
            string res = "";
            foreach (string t in dictionary) {
                bool match = true;
                int j = 0;
                for (int i = 0; i < t.Length; ++i) {
                    if (f[j, t[i] - 'a'] == m) {
                        match = false;
                        break;
                    }
                    j = f[j, t[i] - 'a'] + 1;
                }
                if (match) {
                    if (t.Length > res.Length ||  (t.Length == res.Length && t.CompareTo(res) < 0)) {
                        res = t;
                    }
                }
            }
            return res;
        }

    }
}