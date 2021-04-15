namespace LeetCodeNote
{
    /// <summary>
    /// no: 1006
    /// title: 笨阶乘
    /// problems: https://leetcode-cn.com/problems/clumsy-factorial/
    /// date: 20210401
    /// </summary>
    public static class Solution1006
    {
        public static int Clumsy(int N) {
            int result = 0;

            int Calc(int x, int sign = -1)
            {
                if(x >= 4)
                    return  sign * (x * (x - 1) / (x - 2)) + x -3;
                
                if(x == 3)
                    return sign * 6;
                
                if(x == 2 || x == 1)
                    return sign * x;

                return 0;

            }

            result = Calc(N, 1);
            N -= 4;
            while(N > 0){
                result += Calc(N);
                N -=4;
            }

            return result;
        } 


        // 参考解答 数学 通项公式
        public static int Clumsy_1(int N) {
            if (N == 1) {
                return 1;
            } else if (N == 2) {
                return 2;
            } else if (N == 3) {
                return 6;
            } else if (N == 4) {
                return 7;
            }

            if (N % 4 == 0) {
                return N + 1;
            } else if (N % 4 <= 2) {
                return N + 2;
            } else {
                return N - 1;
            }
        } 
    }
}