using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 816
    /// title:  模糊坐标
    /// problems: https://leetcode.cn/problems/ambiguous-coordinates/
    /// date: 20221107
    /// </summary> 

    public static class Solution816
    {
        public static IList<string> AmbiguousCoordinates(string s) {
            int length = s.Length - 2;
            var res = new List<string>();
            s = s.Substring(1, length);

            IEnumerable<string> GetPos(string s) {
                var pos = new List<string>();
                if (s[0] != '0' || "0".Equals(s)) 
                    yield return s;
                
                for (int p = 1; p < s.Length; ++p) {
                    if ((p != 1 && s[0] == '0') || s.Last() == '0') 
                        continue;
                    
                   yield return s.Insert(p, ".");

                }
            }

            for (int i = 1; i < length; ++i) {
                var lt = GetPos(s.Substring(0, i)).ToList();;
                if (lt.Count == 0) 
                    continue;
                
                var rt = GetPos(s.Substring(i)).ToList();
                if (rt.Count == 0) 
                    continue;
                
                foreach (string l in lt) {
                    foreach (string r in rt) {
                        res.Add($"({l}, {r})");
                    }
                }
            }
            return res;
        }   
    }
}