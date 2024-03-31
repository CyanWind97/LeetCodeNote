using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 804
    /// title: 唯一摩尔斯密码词
    /// problems: https://leetcode-cn.com/problems/unique-morse-code-words/
    /// date: 20220410
    /// </summary>
    public static class Solution804
    {
        public static int UniqueMorseRepresentations(string[] words) {
            var morse = new string[] {".-","-...","-.-.","-..",".","..-.","--.","....","..",".---","-.-",".-..","--","-.","---",".--.","--.-",".-.","...","-","..-","...-",".--","-..-","-.--","--.."};
            var set = new HashSet<string>();
            
            foreach(var word in words){
                var key = string.Join("", word.Select(c => morse[c - 'a']));
                set.Add(key);
            }

            return set.Count;
        }
    }
}