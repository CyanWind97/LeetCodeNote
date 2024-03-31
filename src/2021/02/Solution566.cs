namespace LeetCodeNote
{
    /// <summary>
    /// no: 566
    /// title: 重塑矩阵

    /// problems: https://leetcode-cn.com/problems/reshape-the-matrix/
    /// date: 20210217
    /// </summary>

    public class Solution566
    {
        public static int[][] MatrixReshape(int[][] nums, int r, int c) {
            int m = nums.Length;
            int n = nums[0].Length;
            if(m * n != r * c)
                return nums;

            int i1 = 0;
            int j1 = 0;
            int[][] result = new int[r][];
            for(int i = 0; i < r; i++){
                result[i] = new int[c];
                for(int j = 0; j < c; j++){
                    result[i][j] = nums[i1][j1++];
                    if(j1 == n){
                        j1 = 0;
                        i1++;
                    }
                }
            }

            return result;
        }
    }
}