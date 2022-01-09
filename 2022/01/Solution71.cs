using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 71
    /// title: 简化路径
    /// problems: https://leetcode-cn.com/problems/simplify-path/
    /// date: 20220106
    /// </summary>
    public static class Solution71
    {
        public static string SimplifyPath(string path) {
            var dirs = path.Split('/').Where(s => !string.IsNullOrEmpty(s) && s != ".");
            var list = new List<string>();
            
            foreach(var dir in dirs){
                if(dir != "..")
                    list.Add(dir);
                else if(list.Count > 0)
                    list.RemoveAt(list.Count - 1);
            }


            return $"/{string.Join("/", list)}";
        }
    }
}