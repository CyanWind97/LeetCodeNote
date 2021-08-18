namespace LeetCodeNote
{
    /// <summary>
    /// no: 552
    /// title: 学生出勤记录 II
    /// problems: https://leetcode-cn.com/problems/student-attendance-record-ii/
    /// date: 20210818
    /// </summary>
    public static class Solution552
    {
        public static int CheckRecord(int n) {
            const int mod = 1000000007;
            int Sum((int End, int EndL, int EndLL) record)
                => ((record.End + record.EndL) % mod + record.EndLL) % mod;

            (int End, int EndL, int EndLL) record = (1, 1, 0);
            (int End, int EndL, int EndLL) recordA = (1, 0 , 0);

            for(int i = 1; i < n; i++){
                record = (Sum(record), record.End, record.EndL);
                recordA = ((record.End + Sum(recordA)) % mod, recordA.End, recordA.EndL);
            }

            return (Sum(record) + Sum(recordA)) % mod;
        }

        // 参考解答 矩阵快速幂
        public static int CheckRecord_1(int n)
        {
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
                long[,] ret = {{1, 0, 0, 0, 0, 0},
                            {0, 1, 0, 0, 0, 0},
                            {0, 0, 1, 0, 0, 0},
                            {0, 0, 0, 1, 0, 0},
                            {0, 0, 0, 0, 1, 0},
                            {0, 0, 0, 0, 0, 1}};
                while (n > 0) {
                    if ((n & 1) == 1) {
                        ret = Multiply(ret, mat);
                    }
                    n >>= 1;
                    mat = Multiply(mat, mat);
                }
                return ret;
            }

            long[,] mat = {{1, 1, 0, 1, 0, 0},
                            {1, 0, 1, 1, 0, 0},
                            {1, 0, 0, 1, 0, 0},
                            {0, 0, 0, 1, 1, 0},
                            {0, 0, 0, 1, 0, 1},
                            {0, 0, 0, 1, 0, 0}};
            long[,] res = Pow(mat, n);
            int sum = 0;
            for (int i = 0; i < 6; i++) {
                sum = (sum + (int) res[0, i]) % MOD;
            }

            return sum;
        }
    }
}