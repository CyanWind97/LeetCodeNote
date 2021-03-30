namespace LeetCodeNote
{
    /// <summary>
    /// no: 74
    /// title: 搜索二维矩阵
    /// problems: https://leetcode-cn.com/problems/search-a-2d-matrix/
    /// date: 20210330
    /// </summary>
    public static class Solution74
    {
        public static bool SearchMatrix(int[][] matrix, int target) {
            int m = matrix.Length;
            int n = matrix[0].Length;

            int i = 0; 
            int j = n - 1;
            while(i < m && j >= 0){
                if(target == matrix[i][j]){
                    return true;
                }else if(target < matrix[i][j] ){
                    j--;
                }else{
                    i++;
                }
            }
            
            return false;
        }

        public static bool SearchMatrix_1(int[][] matrix, int target) {
            int m = matrix.Length;
            int n = matrix[0].Length;

            int left = 0;
            int right = m * n - 1;
            while(left <= right){
                int mid = left + (right - left) >> 1;
                if(target == matrix[mid / n][mid % n]){
                    return true;
                }else if(target < matrix[mid / n][mid % n]){
                    right = mid - 1;
                }else{
                    left = mid + 1;
                }
            }

            
            return false;
        }
    }
}