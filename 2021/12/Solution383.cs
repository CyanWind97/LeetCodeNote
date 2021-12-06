using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 383
    /// title: 赎金信
    /// problems: https://leetcode-cn.com/problems/relative-ranks/
    /// date: 20211204
    /// </summary>
    public static class Solution383
    {
        public static bool CanConstruct(string ransomNote, string magazine) {
            var count = new int[26];
            
            foreach(var c in ransomNote){
                 count[c - 'a']++;
            }

            foreach(var c in magazine){
                count[c - 'a']--;
            }

            return !count.Any(x => x > 0);
        }
    }
}