using System;
using System.Collections.Generic;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 32
    /// title:  最长有效括号
    /// problems: https://leetcode.cn/problems/longest-valid-parentheses/
    /// date: 20220506
    /// priority: 0025
    /// time: tiemout
    public static class CodeTop32
    {
        public static int LongestValidParentheses(string s) {
            int length = s.Length;
            if(length < 2)  
                return 0;
            
            var stack = new Stack<int>();
            var count = new List<int>();
            int size = 0;

            for(int i = 0; i < length; i++){
                if(s[i] == ')'){
                    if(stack.Count == 0){
                        count.Add(0);
                        size++;
                    }else{
                        var index = stack.Pop();
                        count[index] = 2;
                        
                    }
                }else{
                    count.Add(0);
                    stack.Push(size);
                    size++;
                }
            }

            int max = 0;
            int sum = 0;
            for(int i = 0; i < size; i++){
                if(count[i] == 0){
                    max = Math.Max(sum, max);
                    sum = 0;
                }else{
                    sum += count[i];
                }

            }

            return Math.Max(sum, max);  
        }

        // 参考解答 栈 优化
        public static int LongestValidParentheses_1(string s) {
            int length = s.Length;
            int max = 0;
            var stack = new Stack<int>();
            stack.Push(-1);

            for (int i = 0; i < length; i++) {
                if (s[i] == '(') {
                    stack.Push(i);
                } else {
                    stack.Pop();
                    if (stack.Count == 0) 
                        stack.Push(i);
                    else 
                        max = Math.Max(max, i - stack.Peek());
                }
            }
            return max;
        }
    }
}