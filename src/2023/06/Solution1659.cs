using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1659
    /// title: 最大化网格幸福感
    /// problems: https://leetcode.cn/problems/maximize-grid-happiness/
    /// date: 20230624
    /// </summary>
    public static class Solution1659
    {
        // 参考解答
        // 状态压缩+动态规划
        // 感觉这题毫无意义？ 或者有更优解法
        public static int GetMaxGridHappiness(int m, int n, int introvertsCount, int extrovertsCount) {
            const int T = 243, N = 5, M = 6;
            int tot = (int)Math.Pow(3, n);
            var maskBits = new int[T, N];
            var ivCount = new int[T];
            var evCount = new int[T];
            var innerScore = new int[T];
            var interScore = new int[T, T];
            var d = new int[N, T, M + 1, M + 1];
            // 邻居间的分数
            var score = new int[,]{
                {0, 0, 0},
                {0, -60, -10},
                {0, -10, 40}
            };

            #region InitData
            for (int mask = 0; mask < tot; mask++) {
                int cur = mask;
                for (int i = 0; i < n; i++) {
                    int x = cur % 3;
                    maskBits[mask, i] = x;
                    cur /= 3;
                    if(x == 1){
                        ivCount[mask]++;
                        innerScore[mask] += 120;
                    }else if(x == 2){
                        evCount[mask]++;
                        innerScore[mask] += 40;
                    }

                    if(i > 0)
                        innerScore[mask] += score[x, maskBits[mask, i - 1]];
                }
            }

            for(int i = 0; i < tot; i++){
                for(int j = 0; j < tot; j++){
                    interScore[i, j] =0 ;
                    for(int k = 0; k < n; k++){
                        interScore[i, j] += score[maskBits[i, k], maskBits[j, k]];
                    }
                }
            }
            #endregion

            for(int i = 0; i < N; i++){
                for(int j = 0; j < T; j++){
                    for(int k = 0; k <= M; k++){
                        for(int l = 0; l <= M; l++){
                            d[i, j, k, l] = -1;
                        }
                    }
                }
            }

            int DFS(int row, int premak, int iv, int ev){
                if(row == m || (iv == 0 && ev == 0))
                    return 0;
                
                if(d[row, premak, iv, ev] != -1)
                    return d[row, premak, iv, ev];
                
                int res = 0;
                for(int mask = 0; mask < tot; mask++){
                    int curIv = ivCount[mask]; 
                    int curEv = evCount[mask];
                    if(curIv > iv || curEv > ev)
                        continue;
                    
                    int cur = innerScore[mask] + interScore[premak, mask] + DFS(row + 1, mask, iv - curIv, ev - curEv);
                    res = Math.Max(res, cur);
                }

                d[row, premak, iv, ev] = res;
                return res;
            }
        
            return DFS(0, 0, introvertsCount, extrovertsCount);
        }
    }
}