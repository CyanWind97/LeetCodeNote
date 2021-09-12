using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 678
    /// title: 有效的括号字符串
    /// problems: https://leetcode-cn.com/problems/valid-parenthesis-string/
    /// date: 20210912
    /// </summary>
    public static class Solution678
    {
        public static bool CheckValidString(string s) {
            Stack<int> leftStack = new Stack<int>();
            Stack<int> asteriskStack = new Stack<int>();
            int n = s.Length;
            for (int i = 0; i < n; i++) {
                char c = s[i];
                if (c == '(') 
                    leftStack.Push(i);
                else if (c == '*') 
                    asteriskStack.Push(i);
                else if (leftStack.Count > 0)
                    leftStack.Pop();
                else if (asteriskStack.Count > 0)
                    asteriskStack.Pop();
                 else
                    return false;
            }

            while (leftStack.Count > 0 && asteriskStack.Count > 0) {
                int leftIndex = leftStack.Pop();
                int asteriskIndex = asteriskStack.Pop();
                if (leftIndex > asteriskIndex) 
                    return false;
            }
            
            return leftStack.Count == 0;
        }
    }
}