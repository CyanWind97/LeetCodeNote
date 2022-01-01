namespace LeetCodeNote
{
    /// <summary>
    /// no: 2022
    /// title: 将一维数组转变成二维数组
    /// problems: https://leetcode-cn.com/problems/convert-1d-array-into-2d-array/
    /// date: 20220101
    /// </summary>
    public static class Solution2022
    {
        public static int[][] Construct2DArray(int[] original, int m, int n) {
            int length = original.Length;

            if(m * n != length)
                return new int[0][];
            
            int index = 0;
            var result = new int[m][];

            for(int i = 0; i < m; i++){
                result[i] = new int[n];
                for(int j = 0; j < n; j++){
                    result[i][j] = original[index++];
                }
            }

            return result;
        }
    }
}