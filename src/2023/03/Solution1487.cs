using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1487
    /// title: 保证文件名唯一
    /// problems: https://leetcode.cn/problems/making-file-names-unique/
    /// date: 20230303
    /// </summary>
    public static class Solution1487
    {
        public static string[] GetFolderNames(string[] names) {
            int length = names.Length;
            var count = new Dictionary<string, int>();
            var reuslt = new string[length];
            for(int i = 0; i < length; i++){
                var name = names[i];
                if(!count.ContainsKey(name)){
                    reuslt[i] = name;
                } else {
                    int k = count[name];
                    while(count.ContainsKey($"{name}({k})")){
                        k++;
                    }

                    reuslt[i] = $"{name}({k})";
                    count[name] = k + 1;
                }
                
                count[reuslt[i]] = 1;
            }

            return reuslt;
        }
    }
}