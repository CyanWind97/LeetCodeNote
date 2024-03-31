using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 205
    /// title: 同构字符串
    /// problems: https://leetcode-cn.com/problems/isomorphic-strings/
    /// date: 20201227
    /// </summary>
    public static class Solution205
    {
        public static bool IsIsomorphic(string s, string t) {
            int length = s.Length;
            char[] sChars = s.ToCharArray();
            char[] tChars = t.ToCharArray();
            Dictionary<char, char> map = new Dictionary<char, char>();
            for(int i = 0; i < length; i++){
                if(!map.ContainsKey(sChars[i])){
                    if(map.Values.Contains(tChars[i]))
                        return false;
                    map.Add(sChars[i], tChars[i]);
                }else if(map[sChars[i]] != tChars[i])
                    return false;
            }

            return true;
        }


        // 参考解答
        public static bool IsIsomorphic_1(string s, string t) {
            int length = s.Length;
            char[] sChars = s.ToCharArray();
            char[] tChars = t.ToCharArray();
            int[] sMap = new int[256];
            int[] tMap = new int[256];
            for(int i = 0; i < length; i++){
                if(sMap[sChars[i]] != tMap[tChars[i]])
                    return false;
                sMap[sChars[i]] = i + 1;
                tMap[tChars[i]] = i + 1;
            }

            return true;
        }
    }
}