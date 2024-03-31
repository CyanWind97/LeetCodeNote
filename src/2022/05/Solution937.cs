using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 937
    /// title: 重新排列日志文件
    /// problems: https://leetcode-cn.com/problems/reorder-data-in-log-files/
    /// date: 20220503
    /// </summary>
    public static class Solution937
    {
        public static string[] ReorderLogFiles(string[] logs) {
            (int Key, string Info, string Tag, string Log) Trans(string log){
                var splits = log.Split(" ", 2);
                return  char.IsDigit(splits[1][0])
                    ? (1, "", "", log)
                    : (0, splits[1], splits[0], log);
            }

            return logs.Select(Trans)
                       .OrderBy(x => x.Key)
                       .ThenBy(x => x.Info)
                       .ThenBy(x => x.Tag)
                       .Select(x => x.Log)
                       .ToArray();
        }
    }
}