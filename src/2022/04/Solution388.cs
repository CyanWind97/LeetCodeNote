using System;
using System.Collections.Generic;
using System.IO;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 388
    /// title: 文件的最长绝对路径
    /// problems: https://leetcode-cn.com/problems/longest-absolute-file-path/
    /// date: 20220420
    /// </summary>
    public static class Solution388
    {
        public static int LengthLongestPath(string input) {
            var result = 0;
            var count = 0;
            var stack = new Stack<string>();

            foreach(var info in input.Split('\n')){
                int tabCount = 0;
                while(tabCount < info.Length && info[tabCount] == '\t'){
                    tabCount++;
                }
                
                // 弹出已有目录
                while(tabCount < stack.Count){
                    var dir = stack.Pop();
                    count -= dir.Length;
                }

                if(Path.HasExtension(info)){
                    result = Math.Max(result, count + info.Length - tabCount + stack.Count);
                }else{
                    var dir = info.Substring(tabCount);
                    count += dir.Length;
                    stack.Push(dir);
                }
            }

            return result;
        }
    }
}