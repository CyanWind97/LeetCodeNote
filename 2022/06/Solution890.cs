using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 890
    /// title: 查找和替换模式
    /// problems: https://leetcode.cn/problems/find-and-replace-pattern/
    /// date: 20220612
    /// </summary>
    public static class Solution890
    {
        public static IList<string> FindAndReplacePattern(string[] words, string pattern) {
            int length = pattern.Length;
            var result = new List<string>();

            int last = 0;
            var map = new Dictionary<char, char>();
            var keys = new char[length];
            for(int i = 0; i < length; i++){
                var c = pattern[i];
                if(!map.ContainsKey(c)){
                   map.Add(c, (char)('a' + last));
                   last++;
                }

                keys[i] = map[c];
            }

            bool IsPartternWord(string word){
                if(word.Length != length)
                    return false;
                
                last = 0;
                map = new Dictionary<char, char>();
                for(int i = 0; i < length; i++){
                    var c = word[i];
                    if(!map.ContainsKey(c)){
                        map.Add(c, (char)('a' + last));
                        last++;
                    }

                    if(map[c] != keys[i])
                        return  false;
                }

                return true;
            }

            return words.Where(IsPartternWord).ToList();
        }
    }
}