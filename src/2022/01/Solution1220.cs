namespace LeetCodeNote
{
    /// <summary>
    /// no: 1220
    /// title: 统计元音字母序列的数目
    /// problems: https://leetcode-cn.com/problems/count-vowels-permutation/
    /// date: 20220117
    /// </summary>
    public static class Solution1220
    {
        // 快速幂
        public static int CountVowelPermutation(int n) {
            const int MOD = 1000000007;

            long[,] Multiply(long[,] a, long[,] b) {
                int rows = a.GetLength(0), columns = b.GetLength(1), temp = b.GetLength(0);
                long[,] c = new long[rows, columns];
                for (int i = 0; i < rows; i++) {
                    for (int j = 0; j < columns; j++) {
                        for (int k = 0; k < temp; k++) {
                            c[i, j] += a[i, k] * b[k, j];
                            c[i, j] %= MOD;
                        }
                    }
                }
                return c;
            }

            long[,] Pow(long[,] mat, int n) {
                long[,] ret = {{1, 0, 0, 0, 0},
                            {0, 1, 0, 0, 0},
                            {0, 0, 1, 0, 0},
                            {0, 0, 0, 1, 0},
                            {0, 0, 0, 0, 1}};
                while (n > 0) {
                    if ((n & 1) == 1) {
                        ret = Multiply(ret, mat);
                    }
                    n >>= 1;
                    mat = Multiply(mat, mat);
                }
                return ret;
            }

            long[,] mat = {{0, 1, 1, 0, 1},
                            {1, 0, 1, 0, 0},
                            {0, 1, 0, 1, 0},
                            {0, 0, 1, 0, 0},
                            {0, 0, 1, 1, 0}};
            
            long[,] res = Pow(mat, n - 1);
            int sum = 0;
            for (int i = 0; i < 5; i++) {
                for(int j = 0; j < 5; j ++){
                    sum = (sum + (int) res[i, j]) % MOD;
                }
            }

            return sum;
        }   
    }
}