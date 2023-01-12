using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    
    /// <summary>
    /// no: 2287
    /// title: 重排字符形成目标字符串
    /// problems: https://leetcode.cn/problems/rearrange-characters-to-make-target-string/
    /// date: 20230113
    /// </summary>
    public static class Solution2287
    {
        public static int RearrangeCharacters(string s, string target) {
            var need = new Dictionary<char, int>();
            var count = new Dictionary<char, int>();
            
            foreach(var c in target){
                if(need.ContainsKey(c)){
                    need[c]++;
                }else{
                    need[c] = 1;
                    count[c] = 0;
                }
            }

            foreach(var c in s){
                if(!need.ContainsKey(c))
                    continue;
                
                count[c]++;
            }

            int result = int.MaxValue;
            foreach(var pair in need){
                char c = pair.Key;
                result = Math.Min(result, count[c] / need[c]);
            }
            
            return result;
        }
    }
}