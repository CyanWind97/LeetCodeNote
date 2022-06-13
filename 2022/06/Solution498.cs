using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 498
    /// title: 对角线遍历
    /// problems: https://leetcode.cn/problems/diagonal-traverse/
    /// date: 20220614
    /// </summary>
    public static class Solution498
    {
        public static int[] FindDiagonalOrder(int[][] mat) {
            int m = mat.Length;
            int n = mat[0].Length;
            var result = new int[m * n];

            int index = 0;
            for(int k = 0; k < m + n - 1; k++){
                if(k % 2 == 0){
                    int start = Math.Max(0, k - m + 1);
                    int end = Math.Min(k, n - 1);
                    for(int col = start; col <= end; col++){
                        result[index++] = mat[k - col][col];
                    }
                }else{
                    int start = Math.Max(0, k - n + 1);
                    int end = Math.Min(k, m - 1);
                    for(int row = start; row <= end; row++){
                        result[index++] = mat[row][k - row];
                    }
                }
            }

            return result;
        }

        // 参考解答
        // x和y的计算表达式更易于理解
        public static int[] FindDiagonalOrder_1(int[][] mat) {
            int m = mat.Length;
            int n = mat[0].Length;
            int[] res = new int[m * n];
            int pos = 0;
            for (int i = 0; i < m + n - 1; i++) {
                if (i % 2 == 1) {
                    int x = i < n ? 0 : i - n + 1;
                    int y = i < n ? i : n - 1;
                    while (x < m && y >= 0) {
                        res[pos] = mat[x][y];
                        pos++;
                        x++;
                        y--;
                    }
                } else {
                    int x = i < m ? i : m - 1;
                    int y = i < m ? 0 : i - m + 1;
                    while (x >= 0 && y < n) {
                        res[pos] = mat[x][y];
                        pos++;
                        x--;
                        y++;
                    }
                }
            }
            return res;
        }
    }
}