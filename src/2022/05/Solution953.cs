using System;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 953
    /// title: 验证外星语词典
    /// problems: https://leetcode.cn/problems/verifying-an-alien-dictionary/
    /// date: 20220517
    /// </summary>
    public static class Solution953
    {
        public static bool IsAlienSorted(string[] words, string order) {
            var map = new int[26];
            for(int i = 0; i < 26; i++){
                map[order[i] - 'a'] = i;
            }
            
            bool IsGreater(string s1, string s2){
                int l1 = s1.Length;
                int l2 = s2.Length;

                int l = Math.Min(l1, l2);
                for(int i = 0; i < l; i++){
                    var o1 = map[s1[i] - 'a'];
                    var o2 = map[s2[i] - 'a'];

                    if(o2 > o1)
                        return false;
                    else if(o2 < o1)
                        return true;
                }

                return l1 > l2;
            }

            int length = words.Length;
            for(int i = 0; i < length - 1; i++){
                if(IsGreater(words[i], words[i + 1]))
                    return false;
            }

            return true;
        }
    }
}