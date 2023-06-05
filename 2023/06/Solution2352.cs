using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2352
    /// title: 相等行列对
    /// problems: https://leetcode.cn/problems/equal-row-and-column-pairs/
    /// date: 20230606
    /// </summary>
    public static class Solution2352
    {
        public static int EqualPairs(int[][] grid) {
            int n = grid.Length;
            int result = 0;
            var queue = new Queue<(IList<int> rows, IList<int> cols, int index)>();
            var map = new Dictionary<int, (IList<int> rows, IList<int> cols)>();
            var idnexs = Enumerable.Range(0, n).ToArray();
            queue.Enqueue((idnexs, idnexs, 0));
            
            while(queue.Count > 0) {
                (var rows, var cols, var index) = queue.Dequeue();
                if (index == n){
                    result += rows.Count * cols.Count;
                    continue;
                }

                map.Clear();
                foreach(var row in rows) {
                    int key = grid[row][index];
                    if (!map.ContainsKey(key))
                        map[key] = (new List<int>(), new List<int>());
                    
                    map[key].rows.Add(row);
                }

                foreach(var col in cols) {
                    int key = grid[index][col];
                    if (!map.ContainsKey(key) || map[key].rows.Count == 0)
                        continue;
                    
                    map[key].cols.Add(col);
                }

                foreach(var pair in map.Where(k => k.Value.rows.Count > 0)) {
                    queue.Enqueue((pair.Value.rows, pair.Value.cols, index + 1));
                }
            }
            
            return result;
        }
    }
}