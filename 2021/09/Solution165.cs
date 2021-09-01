using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 165
    /// title: 比较版本号
    /// problems: https://leetcode-cn.com/problems/compare-version-numbers/
    /// date: 20210901
    /// </summary>
    public static class Solution165
    {
        public static int CompareVersion(string version1, string version2) {
            int n = version1.Length;
            int m = version2.Length;
            int i = 0, j = 0;
            while (i < n || j < m) {
                int x = 0;
                for (; i < n && version1[i] != '.'; ++i) {
                    x = x * 10 + version1[i] - '0';
                }
                ++i; // 跳过点号
                int y = 0;
                for (; j < m && version2[j] != '.'; ++j) {
                    y = y * 10 + version2[j] - '0';
                }
                ++j; // 跳过点号
                if (x != y) 
                    return x > y ? 1 : -1;
            }
            
            return 0;
        }
    }
}