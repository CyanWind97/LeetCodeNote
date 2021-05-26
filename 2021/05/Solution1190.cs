using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1190
    /// title:  反转每对括号间的子串
    /// problems: https://leetcode-cn.com/problems/reverse-substrings-between-each-pair-of-parentheses/
    /// date: 20210526
    /// </summary>
    public static class Solution1190
    {
        public static string ReverseParentheses(string s) {
            int length = s.Length;
            int index = 0;

            void AddList(List<char> list)
            {
                while(index < length)
                {
                    char c = s[index];
                    if(c == ')'){
                        index ++;
                        break;
                    }
                    
                    if(c == '('){
                        Stack<char> stack = new Stack<char>();
                        index++;
                        AddStack(stack);
                        while(stack.Count > 0)
                        {
                            list.Add(stack.Pop());
                        }
                    }else{
                        list.Add(c);
                        index++;
                    }
                }
            }

            void AddStack(Stack<char> stack)
            {
                while(index < length)
                {
                    char c = s[index];
                    if(c == ')'){
                        index ++;
                        break;
                    }
                    
                    if(c == '('){
                        List<char> list = new List<char>();
                        index++;
                        AddList(list);
                        int count = list.Count;
                        for(int i = count - 1; i >= 0; i--)
                        {
                            stack.Push(list[i]);
                        }
                    }else{
                        stack.Push(c);
                        index++;
                    }
                }
            }
            
            List<char> list = new List<char>();
            AddList(list);

            return new string(list.ToArray());
        }
    }
}