using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1640
    /// title: 能否连接形成数组
    /// problems: https://leetcode.cn/problems/check-array-formation-through-concatenation/
    /// date: 20220922
    /// </summary>
    public static class Solution1640
    {
        public static bool CanFormArray(int[] arr, int[][] pieces) {
            int n = arr.Length, m = pieces.Length;
            var index = new Dictionary<int, int>();
            for (int i = 0; i < m; i++) {
                index.Add(pieces[i][0], i);
            }

            for (int i = 0; i < n;) {
                if (!index.ContainsKey(arr[i])) {
                    return false;
                }
                int j = index[arr[i]];
                int length = pieces[j].Length;
                for (int k = 0; k < length; k++) {
                    if (arr[i + k] != pieces[j][k]) 
                        return false;
                }

                i = i + length;
            }

            return true;
        }
    }
}