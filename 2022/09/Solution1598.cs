using System.Collections.Generic;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1598
    /// title: 文件夹操作日志搜集器
    /// problems: https://leetcode.cn/problems/crawler-log-folder/
    /// date: 20220909
    /// </summary>

    public static class Solution1598
    {
        public static int MinOperations(string[] logs) {
            int operations = 0;
            
            foreach(var log in logs){
                if(log == "../"){
                    if(operations > 0)
                        operations--;
                }else if(log == "./"){
                    continue;
                }else{
                    operations++;
                }
            }

            return operations;
        }   
    }
}