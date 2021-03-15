using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 54
    /// title: 螺旋矩阵
    /// problems: https://leetcode-cn.com/problems/spiral-matrix/
    /// date: 20210316
    /// </summary>
    public static class Solution54
    {
        public static IList<int> SpiralOrder(int[][] matrix) {
            int m = matrix.Length;
            int n = matrix[0].Length;
            int[] result = new int[m * n];

            int left = 0, right = n - 1, top = 0, bottom = m - 1;
            int index = 0;

            while(left <= right && top <= bottom){
                for(int j = left; j <= right; j++){
                    result[index++] = matrix[top][j];
                }

                for(int i = top + 1;  i <= bottom; i++){
                    result[index++] = matrix[i][right];
                }

                if(left < right && top < bottom){
                    for(int j = right - 1; j > left; j--){
                        result[index++] = matrix[bottom][j];
                    }

                    for(int i =  bottom;  i > top; i--){
                        result[index++] = matrix[i][left];
                    }
                }
                left++;
                right--;
                top++;
                bottom--;
            }

            return result;
        }
    }
}