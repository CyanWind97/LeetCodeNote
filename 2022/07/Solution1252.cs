using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1252
    /// title: 奇数值单元格的数目
    /// problems: https://leetcode.cn/problems/cells-with-odd-values-in-a-matrix/
    /// date: 20220712
    /// </summary>
    public static class Solution1252
    {
        public static int OddCells(int m, int n, int[][] indices) {
            var rows = new int[m];
            var cols = new int[n];
            foreach(var indice in indices){
                rows[indice[0]]++;
                cols[indice[1]]++;
            }

            return Enumerable.Range(0, m)
                            .Sum(i => Enumerable.Range(0, n).Count(j => (rows[i] + cols[j]) % 2 == 1));
        }

        // 参考解答 计数优化
        public static int OddCells_1(int m, int n, int[][] indices) {
            var rows = new int[m];
            var cols = new int[n];
            foreach(var indice in indices){
                rows[indice[0]]++;
                cols[indice[1]]++;
            }

            int oddx = rows.Count(r => (r & 1) != 0);
            int oddy = cols.Count(c => (c & 1) != 0);

            return oddx * (n - oddy) + (m - oddx) * oddy;
        }
    }
}