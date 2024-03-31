namespace LeetCodeNote
{
    /// <summary>
    /// no: 1137
    /// title:  第 N 个泰波那契数
    /// problems: https://leetcode-cn.com/problems/n-th-tribonacci-number/
    /// date: 20210808
    /// </summary>
    public static class Solution1137
    {
        
        public static int Tribonacci(int n) {
            int[] result = new int[n + 1];
            result[0] = 0;
            if(n > 0)
                result[1] = 1;
            
            if(n > 1)
                result[2] = 1;

            for(int i = 3; i < n + 1; i++){
                result[i] = result[i - 3] + result[i - 2] + result[i - 1];
            }

            return result[n];
        }

        // 参考解答  矩阵快速幂
        public static int Tribonacci_1(int n){
            if (n == 0)
                return 0;
            
            if (n <= 2)
                return 1;
            
            int[,] Pow(int[,] a, int n) {
                int[,] ret = {{1, 0, 0}, {0, 1, 0}, {0, 0, 1}};
                while (n > 0) {
                    if ((n & 1) == 1) {
                        ret = Multiply(ret, a);
                    }
                    n >>= 1;
                    a = Multiply(a, a);
                }
                return ret;
            }

            int[,] Multiply(int[,] a, int[,] b) {
                int[,] c = new int[3, 3];
                for (int i = 0; i < 3; i++) {
                    for (int j = 0; j < 3; j++) {
                        c[i, j] = a[i, 0] * b[0, j] + a[i, 1] * b[1, j] + a[i, 2] * b[2, j];
                    }
                }
                return c;
            }


            int[,] q = {{1, 1, 1}, {1, 0, 0}, {0, 1, 0}};
            int[,] res = Pow(q, n);
            return res[0, 2];
        }
    }
}