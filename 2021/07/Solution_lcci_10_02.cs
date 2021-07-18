using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 10.02
    /// title: 变位词组
    /// problems: https://leetcode-cn.com/problems/group-anagrams-lcci/
    /// date: 20210718
    /// type: 面试题 lcci
    /// </summary>
    public static class Solution_lcci_10_02
    {
        public static IList<IList<string>> GroupAnagrams(string[] strs) {
            Dictionary<string, IList<string>> dic = new Dictionary<string, IList<string>>();
            foreach(string s in strs) {
                string key = new string(s.ToCharArray().OrderBy(x => x).ToArray());
                if(!dic.ContainsKey(key))
                    dic.Add(key, new List<string>());
                dic[key].Add(s);
            }
            
            return dic.Values.ToList();
        }
    }
}