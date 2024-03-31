using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1807
    /// title: 替换字符串中的括号内容
    /// problems: https://leetcode.cn/problems/evaluate-the-bracket-pairs-of-a-string/
    /// date: 20230112
    /// </summary>
    public static class Solution1807
    {
        public static string Evaluate(string s, IList<IList<string>> knowledge) {
            var map = knowledge.ToDictionary(k => k[0], k => k[1]);
            var result = new StringBuilder();
            var keyBuilder = new StringBuilder();
            int n = s.Length;
            for(int i = 0; i < n; i++){
                if(s[i] == '('){
                    i++;
                    while(s[i] != ')'){
                        keyBuilder.Append(s[i]);
                        i++;
                    }

                    var key = keyBuilder.ToString();
                    if(map.ContainsKey(key))
                        result.Append(map[key]);
                    else
                        result.Append('?'); 
                    
                    keyBuilder.Clear();
                    
                }else{
                    result.Append(s[i]);
                }
            }

            return result.ToString();
        }
    }
}