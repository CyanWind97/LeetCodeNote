namespace LeetCodeNote
{
    /// <summary>
    /// no: 1406
    /// title:  数组异或操作
    /// problems: https://leetcode-cn.com/problems/xor-operation-in-an-array/
    /// date: 20210507
    /// </summary>
    public static class Solution1406
    {
        public static int XorOperation(int n, int start) {
            int result = start;
            int cur = 0;

            for(int i = 1; i < n; i++){
                cur = start + 2 * i;
                result = result ^ cur;
            }

            return result;
        }

        // 参考 数学解
        public static int XorOperation_1(int n, int start) {
            int SumXor(int x)
            {
                switch(x % 4)
                {
                    case 0 : 
                        return x;
                    case 1 : 
                        return 1;
                    case 2 :
                        return x + 1;
                    default:
                        return 0;
                }
            }

            int s = start >> 1;
            int e = n & start & 1;

            int result = SumXor(s - 1) ^ SumXor(s + n - 1);
            return result << 1 | e;
        }
    }
}