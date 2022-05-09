using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 23
    /// title:  最长有效括号
    /// problems: https://leetcode.cn/problems/longest-valid-parentheses/
    /// date: 20220509
    /// priority: 0025
    /// time: timeout
    public static class CodeTop23
    {
        public static int LongestValidParentheses(string s) {
            int length = s.Length;
            if(length < 2)  
                return 0;
            
            var stack = new Stack<int>();
            var count = new List<int>();

            for(int i = 0; i < length; i++){
                if(s[i] == ')'){
                    if(stack.Count == 0){
                        count.Add(0);
                    }else{
                        stack.Pop();
                        count.Add(2);
                        
                        int index = count.Count - 1;
                        while(index > 0 && count[index - 1] != 0){
                            count[index - 1] += count[index];
                            count.RemoveAt(index);
                            index--;
                        }
                    }
                }else{
                    stack.Push(0);
                }
            }

            return count.Max(); 
        }
    }
}