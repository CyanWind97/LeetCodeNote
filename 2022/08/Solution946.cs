using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 946
    /// title: 验证栈序列
    /// problems: https://leetcode.cn/problems/validate-stack-sequences/
    /// date: 20220831
    /// </summary>
    public class Solution946
    {
        public static bool ValidateStackSequences(int[] pushed, int[] popped) {
            int length = pushed.Length;
            var stack = new Stack<int>();
            for(int i = 0, j = 0; i < length; i++){
                stack.Push(pushed[i]);
                while(stack.Count > 0 && stack.Peek() == popped[j]){
                    stack.Pop();
                    j++;
                }
            }

            return stack.Count == 0;
        }
    }
}