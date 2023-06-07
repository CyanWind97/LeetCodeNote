using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1240
    /// title: 铺瓷砖
    /// problems: https://leetcode.cn/problems/tiling-a-rectangle-with-the-fewest-squares/
    /// date: 20230608
    /// </summary>
    public static class Solution1240
    {
        // 参考解答
        public static int TilingRectangle(int n, int m) {
            if(n == m)
                return 1;
            
            var rect = new bool[n, m];
            int result = Math.Max(n, m);

            void DFS(int x, int y, int count){
                if (count >= result)
                    return;
                
                if (x >= n) {
                    result = count;
                    return;
                }
                
                if (y >= m){
                    DFS(x + 1, 0, count);
                    return;
                }

                if (rect[x, y]) {
                    DFS(x, y + 1, count);
                    return;
                }

                bool IsAvailable(int k) {
                    for (int i = 0; i < k; i++) {
                        for (int j = 0; j < k; j++) {
                            if (rect[x + i, y + j]) {
                                return false;
                            }
                        }
                    }
                    return true;
                }

                void FillUp(int k, bool val)
                    => Enumerable.Range(0, k)
                        .SelectMany(i => Enumerable.Range(0, k).Select(j => (i, j)))
                        .ToList()
                        .ForEach(t => rect[x + t.i, y + t.j] = val);
                

                for(int k = Math.Min(n - x, m - y); k >= 1 && IsAvailable(k); k--){
                    FillUp(k, true);
                    DFS(x, y + k, count + 1);
                    FillUp(k, false);
                }
            }

            DFS(0, 0, 0);
            return result;
        }
    }
}