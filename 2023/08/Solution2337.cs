using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2337
    /// title: 移动片段得到字符串
    /// problems: https://leetcode.cn/problems/move-pieces-to-obtain-a-string/
    /// date: 20230821
    /// </summary>
    public static class Solution2337
    {
        // 参考解答
        public static bool CanChange(string start, string target) {
            int length = start.Length;
            int i = 0, j = 0;

            for(;i < length && j < length; i++, j++){
                while(i < length && start[i] == '_')
                    i++;
                
                while(j < length && target[j] == '_')
                    j++;
                
                if(i >= length || j >= length )
                    break;
                
                if(start[i] != target[j])
                    return false;
                    
                if((start[i] == 'L' && i < j)
                || (start[i] == 'R' && i > j))
                    return false;
            }

            if (start.Skip(i).Any(c => c != '_')
            || target.Skip(j).Any(c => c != '_'))
                return false;

            return true;
        }
    }
}