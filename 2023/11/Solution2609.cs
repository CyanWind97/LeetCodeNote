using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2609
    /// title: 最长平衡子字符串
    /// problems: https://leetcode.cn/problems/find-the-longest-balanced-substring-of-a-binary-string/description/?envType=daily-question&envId=2023-11-08
    /// date: 20231108
    /// </summary>
    public static class Solution2609
    {
        public static int FindTheLongestBalancedSubstring(string s) {
            int length = s.Length;
            int result = 0;
            var count = new int[2];
            for(int i = 0; i < length; i++){
                if(s[i] == '1'){
                    count[1]++;
                    result = Math.Max(result, 2 * Math.Min(count[0], count[1]));
                }else if (i == 0 || s[i - 1] == '1'){
                    count[0] = 1;
                    count[1] = 0;
                }else{
                    count[0]++;
                }
            }

            return result;
        }
    }
}