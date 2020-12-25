using System;
namespace LeetCodeNote
{
    /// <summary>
    /// no: 455
    /// title: 分发饼干
    /// problems: https://leetcode-cn.com/problems/assign-cookies/
    /// date: 20201225
    /// </summary>
    public static class Solution455
    {

        public static int FindContentChildren(int[] g, int[] s) {
            int gLength = g.Length;
            int sLength = s.Length;
            Array.Sort(g);
            Array.Sort(s);
            int i = 0, j = 0;
            int count = 0;
            while(i < gLength && j < s.Length){
                if(g[i] <= s[j]){
                    i++;
                    j++;
                    count++;
                }else{
                    j++;
                }
            }

            return count;
        }

        // 优化
        public static int FindContentChildren_1(int[] g, int[] s) {
            int sLength = s.Length;
            if (sLength == 0) 
                return 0;
            
            int gLength = g.Length;
            
            Array.Sort(g);
            Array.Sort(s);

            int c = 0;
            for (int i = 0; i < sLength && c < gLength; i++) {
                if (s[i] >= g[c]) 
                    c++;
            }

            return c;
        }
    }
}