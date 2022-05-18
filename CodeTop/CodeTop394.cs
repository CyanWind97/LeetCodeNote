using System.Collections.Generic;
using System.Text;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 394
    /// title:   字符串解码
    /// problems: https://leetcode.cn/problems/decode-string/
    /// date: 20220518
    /// priority: 0082
    /// time: 00:15:21.13
    /// </summary>
    public static class CodeTop394
    {
        public static string DecodeString(string s) {
            var stack = new Stack<string>();
            var count = new Stack<int>();
            var result = new StringBuilder();
            int num = 0;
            
            foreach(var c in s){
                if(char.IsDigit(c)){
                    num = num * 10 + c - '0';
                }else if(c == '['){
                    count.Push(num);
                    stack.Push(result.ToString());
                    num = 0;
                    result.Clear();
                }else if(c == ']'){
                    var sub = result.ToString();
                    result.Clear();
                    result.Append(stack.Pop());

                    int n = count.Pop();
                    for(int i = n; i > 0; i--){
                        result.Append(sub);
                    }
                }else{
                    result.Append(c);
                }
            }

            return result.ToString();
        }
    }
}