using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1233
    /// title: 删除子文件夹
    /// problems: https://leetcode.cn/problems/remove-sub-folders-from-the-filesystem/
    /// date: 20230208
    /// </summary>
    public static class Solution1233
    {
        public static IList<string> RemoveSubfolders(string[] folder) {
            Array.Sort(folder);
            var result = new List<string>();
            int length = folder.Length;
            result.Add(folder[0]);
            for(int i = 1; i < length; i++){
                var pre = result.Last();
                
                if(!(pre.Length < folder[i].Length
                    && folder[i].StartsWith(pre)
                    && folder[i][pre.Length] == '/'))
                    result.Add(folder[i]);
            }

            return result;
        }
    }
}