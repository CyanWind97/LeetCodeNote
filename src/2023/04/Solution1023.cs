using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1023
    /// title: 驼峰匹配
    /// problems: https://leetcode.cn/problems/camelcase-matching/
    /// date: 20230414
    /// </summary>
    public static class Solution1023
    {
        
        public static IList<bool> CamelMatch(string[] queries, string pattern) {
            var regexBuilder = new StringBuilder();
            regexBuilder.Append("^([a-z])*");
            regexBuilder.Append(string.Join(@"([a-z])*", pattern.ToCharArray()));
            regexBuilder.Append(@"([a-z])*$");
            var regex = new Regex(regexBuilder.ToString());
            
            return queries.Select(q => regex.IsMatch(q)).ToArray();
        }
    }
}