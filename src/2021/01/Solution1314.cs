using System;
namespace LeetCodeNote
{
    /// <summary>
    /// no: 1314
    /// title: 矩阵区域和
    /// problems: https://leetcode-cn.com/problems/matrix-block-sum/
    /// date: 20210105
    /// </summary>
    public static class Solution1314
    {
        public static int[][] MatrixBlockSum(int[][] mat, int K) {
            int m = mat.Length;
            int n = mat[0].Length;
            int[][] colSum = new int[m][];
            int[][] answer = new int[m][];

            for(int i = 0; i < m; i++){
                colSum[i] = new int[n];
            }

            for(int j = 0; j < n; j++){
                for(int i = 0; i <= K; i++){
                    colSum[0][j] += mat[i][j];
                }

                for(int i = 1; i < m; i++){
                    colSum[i][j] = colSum[i - 1][j];
                    if(i - K > 0)
                        colSum[i][j] -= mat[i - K - 1][j];
                    
                    if(i + K < m)
                        colSum[i][j] += mat[i + K][j];
                }
            }

            for(int i = 0; i < m; i++){
                answer[i] = new int[n];
                for(int j = 0; j <= K && j < n; j++){
                    answer[i][0] += colSum[i][j];
                }
                
                for(int j = 1; j < n; j++){
                    answer[i][j] += answer[i][j - 1];
                    if(j - K > 0)
                        answer[i][j] -= colSum[i][j - K - 1];
                    
                    if(j + K < n)
                        answer[i][j] += colSum[i][j + K];

                }
            }

            return answer;
        }

        // 官方解答 二维前缀和
        public static int[][] MatrixBlockSum_1(int[][] mat, int K) {
            int m = mat.Length;
            int n = mat[0].Length;
            int[,] pre = new int[m + 1, n + 1];
            int[][] answer = new int[m][];
            int getPre(int x, int y){
                x = Math.Max(Math.Min(x, m), 0);
                y = Math.Max(Math.Min(y, n), 0);
                return pre[x, y];
            }

            for(int i = 1; i <= m; i++){
                for(int j = 1; j <= n; j++){
                    pre[i,j] = pre[i - 1, j] + pre[i, j - 1] 
                        - pre[i - 1, j - 1] + mat[i - 1][j - 1];
                }
            }

            for(int i = 0; i < m; i++){
                answer[i] = new int[n];
                for(int j = 0; j < n; j++){
                    answer[i][j] = getPre(i + K + 1, j + K + 1)
                                - getPre(i - K, j + K + 1)
                                - getPre(i + K + 1, j - K)
                                + getPre(i - K, j - K);
                }
            }

            return answer;
        }
    }
}