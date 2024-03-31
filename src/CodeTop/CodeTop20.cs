using System.Collections.Generic;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 20
    /// title: 有效的括号
    /// problems: https://leetcode.cn/problems/valid-parentheses/
    /// date: 20220510
    /// priority: 0030
    /// time: 00:05:38.06
    /// </summary>
    public static class CodeTop20
    {   

        public static bool IsValid(string s) {
            var match = new Dictionary<char, char>()
            {
                {')', '('},
                {']', '['},
                {'}', '{'},
            };

            var stack = new Stack<char>();

            foreach(var c in s){
                if(!match.ContainsKey(c)){
                    stack.Push(c);
                }else if(stack.Count == 0 || stack.Pop() != match[c]){
                    return false;
                }
            }

            return stack.Count == 0;
        }
    }
}