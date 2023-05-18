using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1076
    /// title: 活字印刷
    /// problems: https://leetcode.cn/problems/letter-tile-possibilities/
    /// date: 20230519
    /// </summary>
    public static class Solution1076
    {
        public static int NumTilePossibilities(string tiles) {
            var count = new Dictionary<char, int>();
            foreach (char t in tiles) {
                if (count.ContainsKey(t)) {
                    count[t]++;
                } else {
                    count.Add(t, 1);
                }
            }
            var tile = new HashSet<char>(count.Keys);

            int DFS(int i) {
                if (i == 0) 
                    return 1;
                
                int res = 1;
                foreach (char t in tile) {
                    if (count[t] > 0) {
                        count[t]--;
                        res += DFS(i - 1);
                        count[t]++;
                    }
                }

                return res;
            }

            return DFS(tiles.Length) - 1;
        }
    }
}