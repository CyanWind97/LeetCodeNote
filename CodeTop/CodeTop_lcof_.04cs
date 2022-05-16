namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 04
    /// title:  二维数组中的查找
    /// problems: https://leetcode.cn/problems/er-wei-shu-zu-zhong-de-cha-zhao-lcof/
    /// date: 20220516
    /// type: 剑指Offer lcof
    /// priority: 0063
    /// time: 00:03:29.18
    /// </summary>
    public static class CodeTop_lcof_04
    {   
        // leetcode 240 同题
        public static bool FindNumberIn2DArray(int[][] matrix, int target) {
            int m = matrix.Length; 
            if(m == 0)
                return false;

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