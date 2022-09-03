using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1582
    /// title: 二进制矩阵中的特殊位置
    /// problems: https://leetcode.cn/problems/special-positions-in-a-binary-matrix/
    /// date: 20220904
    /// </summary>
    public static class Solution1582
    {
        public static int NumSpecial(int[][] mat) {
            int m = mat.Length;
            int n = mat[0].Length;

            for(int i = 0; i < m; i++){
                int count = mat[i].Count(num => num == 1);

                if(i == 0)
                    count--;
                
                if(count > 0){
                    for(int j = 0; j < n; j++){
                        if(mat[i][j] == 1)
                            mat[0][j] += count;
                    }
                }
            }
            
            return mat[0].Count(num => num == 1);
        }
    }
}