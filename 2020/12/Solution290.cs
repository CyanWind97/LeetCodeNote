using System.Collections.Generic;
namespace LeetCodeNote
{
    /// <summary>
    /// no: 290
    /// title: 单词规律
    /// problems: https://leetcode-cn.com/problems/word-pattern/
    /// date: 20201216
    /// </summary>
    public static class Solution290
    {
        public static bool WordPattern(string pattern, string s) {
            Dictionary<char, string> map = new Dictionary<char, string>();
            char[] chars = pattern.ToCharArray();
            string[] strs = s.Split(" ");
            if(chars.Length != strs.Length)
                return false;
            
            for(int i = 0; i < chars.Length; i++) {
                if(!map.ContainsKey(chars[i])){
                    if(map.ContainsValue(strs[i]))
                        return false;
                    
                    map.Add(chars[i], strs[i]);
                }else if(map[chars[i]] != strs[i])
                    return false; 
            }

            return true;
        }
    }
}