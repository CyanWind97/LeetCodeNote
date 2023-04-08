using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2399
    /// title: 检查相同字母间的距离
    /// problems: https://leetcode.cn/problems/check-distances-between-same-letters/
    /// date: 20230409
    /// </summary>
    public static class Solution2399
    {
        public static bool CheckDistances(string s, int[] distance) {
            var valid = new int[26];
            Array.Fill(valid, -1);

            for(int i = 0; i < s.Length; i++){
                int index = s[i] - 'a';
                if(valid[index] == -1)
                    valid[index] = i;
                else if(i - valid[index] - 1 != distance[index])
                    return false;
            }

            return true;
        }
    }
}