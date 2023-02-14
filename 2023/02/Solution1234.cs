using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{

    ///<summary>
    /// no: 1234
    /// title: 替换子串得到平衡字符串
    /// problems: https://leetcode.cn/problems/replace-the-substring-for-balanced-string/
    /// date: 20230213
    /// </summary>
    public static class Solution1234
    {
        public static int BalancedString(string s) {
            var count = s.GroupBy(c => c)
                         .ToDictionary(g => g.Key, g => g.Count());
            
            int part = s.Length / 4;
            int result = s.Length;

            bool Check()
                 => !count.Any(pair => pair.Value > part);

            if(Check())
                return 0;
            

            for(int l = 0, r = 0; l < s.Length; l++){
                while(r < s.Length && !Check()){
                    count[s[r]]--;
                    r++;
                }

                if(!Check())
                    break;
                
                result = Math.Min(result, r - l);
                count[s[l]]++;
            }

            return result;
        }
    }
}