namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 240
    /// title:  搜索二维矩阵 II
    /// problems: https://leetcode.cn/problems/search-a-2d-matrix-ii/
    /// date: 20220512
    /// priority: 0041
    /// time: 00:03:29.18
    public static class CodeTop240
    {
        public static bool SearchMatrix(int[][] matrix, int target) {
            int m = matrix.Length; 
            int n = matrix[0].Length;

            int i = 0; 
            int j = n - 1;
            while(i < m && j >= 0){
                if(matrix[i][j] == target)
                    return true;
                else if(matrix[i][j] < target) 
                    i++;
                else
                    j--;
            }


            return false;
        }
    }
}