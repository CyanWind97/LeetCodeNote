using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1410
    /// title: HTML 实体解析器
    /// problems: https://leetcode.cn/problems/html-entity-parser/description/?envType=daily-question&envId=2023-11-23
    /// date: 20231123
    /// </summary>
    public static class Solution1410
    {
        public static string EntityParser(string text) {
            var dic = new Dictionary<string, char>{
                {"&quot;", '\"'},
                {"&apos;", '\''},
                {"&amp;", '&'},
                {"&gt;", '>'},
                {"&lt;", '<'},
                {"&frasl;", '/'}
            };

            int length = text.Length;
            var result = new List<char>();
            for(int i = 0; i < length; i++){
                if(text[i] == '&'){
                    int j = i + 1;
                    var flag = false;
                    for(; j < length && !flag; j++){
                        if(text[j] != ';')
                            continue;
                        
                        flag = true;
                        var key = text.Substring(i, j - i + 1);
                        if(dic.ContainsKey(key)){
                            result.Add(dic[key]);
                            i = j;
                        }else{
                            result.Add(text[i]);
                        }
                    }

                    if(j == length && !flag) {
                        for(int k = i; k < j; k++){
                            result.Add(text[k]);
                        }

                        i = j;
                    }
                    
                }else{
                    result.Add(text[i]);
                }
            }

            return new string(result.ToArray());
        }
    }
}