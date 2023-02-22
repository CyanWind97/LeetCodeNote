using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1238
    /// title: 循环码排列
    /// problems: https://leetcode.cn/problems/circular-permutation-in-binary-representation/
    /// date: 20230223
    /// </summary>
    public static class Solution1238
    {
        public static IList<int> CircularPermutation(int n, int start) {
            var result = new List<int>();
            for(int i = 0; i < 1 << n; i++){
                result.Add((i >> 1) ^ i ^ start);
            }

            return result;
        }
    }
}