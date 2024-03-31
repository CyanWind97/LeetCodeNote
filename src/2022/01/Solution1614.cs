using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1614
    /// title: 括号的最大嵌套深度
    /// problems: https://leetcode-cn.com/problems/maximum-nesting-depth-of-the-parentheses/
    /// date: 20220107
    /// </summary>
    public static class Solution1614
    {
        public static int MaxDepth(string s) {
            int max = 0;
            int depth = 0;

            foreach(var c in s){
                if(c == '('){
                    depth++;
                    max = Math.Max(max, depth);
                }else if(c == ')')
                    depth--;
            }

            return max;
        }
    }
}