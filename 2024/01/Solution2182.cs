using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2182
    /// title: 构造限制重复的字符串
    /// problems: https://leetcode.cn/problems/construct-string-with-repeat-limit/description/?envType=daily-question&envId=2024-01-13
    /// date: 20240113
    /// </summary>
    public static class Solution2182
    {
        public static string RepeatLimitedString(string s, int repeatLimit) {
            var count = new int[26];
            foreach(var c in s){
                count[c - 'a']++;
            }

            var builder = new StringBuilder();
            int m = 0;
            for(int i = 25, j = 24; i >= 0 && j >= 0; ){
                if (count[i] == 0){
                    m = 0;
                    i--;
                }else if(m < repeatLimit){
                    builder.Append((char)(i + 'a'));
                    count[i]--;
                    m++;
                }else if(j >= i || count[j] == 0){
                    j--;
                }else{
                    count[j]--;
                    builder.Append((char)(j + 'a'));
                    m = 0;
                }
                
            }

            return builder.ToString();
        }
    }
}