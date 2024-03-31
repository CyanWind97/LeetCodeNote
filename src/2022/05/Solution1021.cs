using System.Collections.Generic;
using System.Text;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1021
    /// title: 删除最外层的括号
    /// problems: https://leetcode.cn/problems/remove-outermost-parentheses/
    /// date: 20220528
    /// </summary>
    public static class Solution1021
    {
        public static string RemoveOuterParentheses(string s) {
            int level = 0;
            var result = new StringBuilder();
            foreach (char c in s) {
                if (c == ')') 
                    level--;
                
                if (level > 0) 
                    result.Append(c);
                
                if (c == '(') 
                    level++;
            }

            return result.ToString();
        }
    }
}