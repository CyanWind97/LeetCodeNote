using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1678
    /// title: 设计 Goal 解析器
    /// problems: https://leetcode.cn/problems/goal-parser-interpretation/
    /// date: 20221106
    /// </summary> 
    public static class Solution1678
    {
        public static string Interpret(string command) {
            var result = new StringBuilder();
            int length = command.Length;
            for(int i = 0; i < length; i++){
                if(command[i] == 'G'){
                    result.Append('G');
                }else if(command[i + 1] == 'a'){
                    result.Append("al");
                    i += 3;
                }else{
                    result.Append('o');
                    i++;
                }
            }

            return result.ToString();
        }
    }
}