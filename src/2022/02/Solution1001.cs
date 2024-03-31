using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1001
    /// title: 网格照明
    /// problems: https://leetcode-cn.com/problems/grid-illumination/
    /// date: 20220208
    /// </summary>
    public static class Solution1001
    {
        // 参考解答 哈希表
        public static int[] GridIllumination(int n, int[][] lamps, int[][] queries) {
            long Hash(int x, int y) => (long) x + ((long) y << 32);

            var row = new Dictionary<int, int>();
            var col = new Dictionary<int, int>();
            var diagonal = new Dictionary<int, int>();
            var antiDiagonal = new Dictionary<int, int>();
            var points = new HashSet<long>();
            foreach (int[] lamp in lamps) {
                if (!points.Add(Hash(lamp[0], lamp[1]))) 
                    continue;
                
                if (!row.ContainsKey(lamp[0]))
                    row.Add(lamp[0], 0);
                
                row[lamp[0]]++;
                if (!col.ContainsKey(lamp[1])) 
                    col.Add(lamp[1], 0);
                
                col[lamp[1]]++;
                if (!diagonal.ContainsKey(lamp[0] - lamp[1])) 
                    diagonal.Add(lamp[0] - lamp[1], 0);
                
                diagonal[lamp[0] - lamp[1]]++;
                if (!antiDiagonal.ContainsKey(lamp[0] + lamp[1])) 
                    antiDiagonal.Add(lamp[0] + lamp[1], 0);
                
                antiDiagonal[lamp[0] + lamp[1]]++;
            }

            int[] result = new int[queries.Length];
            for (int i = 0; i < queries.Length; i++) {
                int r = queries[i][0], c = queries[i][1];

                if (row.ContainsKey(r) && row[r] > 0) 
                    result[i] = 1;
                else if (col.ContainsKey(c) && col[c] > 0)
                    result[i] = 1;
                else if (diagonal.ContainsKey(r - c) && diagonal[r - c] > 0) 
                    result[i] = 1;
                else if (antiDiagonal.ContainsKey(r + c) && antiDiagonal[r + c] > 0) 
                    result[i] = 1;
                
                for (int x = r - 1; x <= r + 1; x++) {
                    for (int y = c - 1; y <= c + 1; y++) {
                        if (x < 0 || y < 0 || x >= n || y >= n) 
                            continue;
                        
                        if (!points.Remove(Hash(x, y))) 
                            continue;
                        
                        row[x]--;
                        if (row[x] == 0) 
                            row.Remove(x);
                        
                        col[y]--;
                        if (col[y] == 0) 
                            col.Remove(y);
                        
                        diagonal[x - y]--;
                        if (diagonal[x - y] == 0) 
                            diagonal.Remove(x - y);
                        
                        antiDiagonal[x + y]--;
                        if (antiDiagonal[x + y] == 0) 
                            antiDiagonal.Remove(x + y);
                    }
                }
            }

            return result;
        }
    }
}