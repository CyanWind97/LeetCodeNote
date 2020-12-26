using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 85
    /// title: 最大矩形
    /// problems: https://leetcode-cn.com/problems/maximal-rectangle/
    /// date: 20201226
    /// </summary>
    public static class Solution85
    {
        public static int MaximalRectangle(char[][] matrix) {
            int m = matrix.Length;
            if(m == 0)
                return 0;
            int n = matrix[0].Length;
            int[,] rows = new int[m, n];
            int[,] cols = new int[m, n];
            int max = matrix[0][0] == '0' ? 0 : 1;
            rows[0, 0] = max;
            cols[0, 0] = max;

            for(int i = 1; i < m; i++){
                if(matrix[i][0] == '0'){
                    rows[i, 0] = 0;
                    cols[i, 0] = 0;
                }else{
                    rows[i, 0] = rows[i - 1, 0] + 1;
                    cols[i, 0] = 1;
                    max = Math.Max(max, rows[i, 0]);
                }
            }

            for(int j = 1; j < n; j++){
                if(matrix[0][j] == '0'){
                    rows[0, j] = 0;
                    cols[0, j] = 0;
                }else{
                    rows[0, j] = 1;
                    cols[0, j] = cols[0, j - 1] + 1;
                    max = Math.Max(max, cols[0, j]);
                }
            }

            for(int i = 1; i < m; i++){
                for(int j = 1; j < n; j++) {
                    if(matrix[i][j] == '0'){
                        rows[i, j] = 0;
                        cols[i, j] = 0;
                    }else{
                        rows[i, j] = rows[i - 1, j] + 1;
                        cols[i, j] = cols[i, j - 1] + 1;
                        int area = Math.Max(rows[i,j], cols[i,j]);

                        if(rows[i, j] > 1 &&  cols[i, j] > 1){
                            int[] tmpRows = new int[cols[i,j]];
                            int maxRow = 0;
                            for(int r = 0; r < cols[i,j]; r++){
                                tmpRows[r] = rows[i, j - r];
                                maxRow = Math.Max(maxRow, tmpRows[r]);
                            }
                            int[] tmpCols = new int[maxRow];
                            tmpCols[0] = cols[i, j];
                            for(int c = 1; c < maxRow; c++){
                                tmpCols[c] = Math.Min(tmpCols[c - 1], cols[i - c, j]);
                            }
                            for(int r = 0; r < cols[i, j]; r++){
                                area = Math.Max(area, tmpRows[r] * tmpCols[tmpRows[r] - 1]);
                            }
                        }
                        
                        max = Math.Max(max, area);
                    }
                }       
            }

            return max;
        }


        // 参考解答
         public static int MaximalRectangle_1(char[][] matrix) {
            int m = matrix.Length;
            if (m == 0) 
                return 0;
            int n = matrix[0].Length;
            if (n == 0) 
                return 0;

            int[] left = new int[n]; // initialize left as the leftmost boundary possible
            int[] right = new int[n];
            int[] height = new int[n];

            Array.Fill(right, n); // initialize right as the rightmost boundary possible

            int maxArea = 0;
            for (int i = 0; i < m; i++)
            {
                int currentLeft = 0, currentRight = n;
                // update height && update left
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i][j] == '1') {
                        height[j]++;
                        left[j] = Math.Max(left[j], currentLeft);
                    }else{
                        height[j] = 0;
                        left[j] = 0; 
                        currentLeft = j + 1; 
                    }
                }
                
                // update right && calc area
                for (int j = n - 1; j >= 0; j--)
                {
                    if (matrix[i][j] == '1') {
                        right[j] = Math.Min(right[j], currentRight);
                        maxArea = Math.Max(maxArea, (right[j] - left[j]) * height[j]);
                    }else 
                    {   
                        right[j] = n; 
                        currentRight = j; 
                    }
                }
            }

            return maxArea;
        }
    }
}