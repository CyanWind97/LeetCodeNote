using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1473
    /// title:  粉刷房子 III
    /// problems: https://leetcode-cn.com/problems/paint-house-iii/
    /// date: 20210504
    /// </summary>
    public static class Solution1473
    {
        // 参考解答
        public static int MinCost(int[] houses, int[][] cost, int m, int n, int target) {
            for(int i = 0; i < m; i++){
                --houses[i];
            }

            int[,,] dp  = new int[m, n, target];
            for(int i = 0; i < m; i++){
                for(int j = 0; j < n; j++){
                    for(int k = 0; k < target; k++){
                        dp[i, j, k] = int.MaxValue / 2;
                    }
                }
            }

            int[,,] best = new int[m, target, 3];
            for(int i = 0; i < m; i++){
                for(int j = 0; j < target; j++){
                    best[i, j, 0] = best[i, j, 2] = int.MaxValue / 2;
                    best[i, j, 1] = -1;
                }
            }

            for(int i = 0; i < m; i++){
                for(int j = 0; j < n; j++){
                    if(houses[i] != -1 && houses[i] != j)
                        continue;

                    for(int k = 0; k < target; k++){
                        if(i == 0){
                            if(k == 0)
                                dp[i, j, k] = 0;
                        }else{
                            dp[i, j , k] = dp[i - 1, j, k];
                            if(k > 0)
                                dp[i, j, k] = Math.Min(dp[i, j, k], (j == best[i - 1, k - 1, 1]? best[i - 1, k - 1, 2] : best[i - 1, k - 1, 0]));
                        } 

                        if(dp[i, j, k] != int.MaxValue / 2 && houses[i] == -1)
                            dp[i, j, k] += cost[i][j];
                        
                        int first = best[i, k, 0];
                        int firstIdx = best[i, k, 1];
                        int second = best[i, k, 2];
                        if(dp[i, j, k] < first){
                            best[i, k, 2] = first;
                            best[i, k, 0] = dp[i, j, k];
                            best[i, k, 1] = j;
                        }else if(dp[i, j, k] < second)
                            best[i, k, 2] = dp[i, j, k];
                    }
                }
            }

            int ans = int.MaxValue / 2;
            for(int j = 0; j < n; j++){
                ans = Math.Min(ans, dp[m - 1, j, target - 1]);
            }

            return ans == int.MaxValue / 2 ? -1 : ans;
        }
    }
}