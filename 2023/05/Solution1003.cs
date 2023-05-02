using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1003
    /// title:  检查替换后的词是否有效
    /// problems: https://leetcode.cn/problems/check-if-word-is-valid-after-substitutions/  
    /// date: 20230503
    /// </summary>
    public static class Solution1003
    {
        public static bool IsValid(string s) {
            int length = s.Length;
            if(length % 3 != 0)
                return false;
            
            var stack = new Stack<char>();
            foreach(var c in s){
                if(c == 'c'){
                    if(stack.Count < 2 || stack.Pop() != 'b' || stack.Pop() != 'a')
                        return false;
                }else{
                    stack.Push(c);
                }
            }

            return stack.Count == 0;
        }
    }
}