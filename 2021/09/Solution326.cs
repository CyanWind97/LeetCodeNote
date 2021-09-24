namespace LeetCodeNote
{
    /// <summary>
    /// no: 326
    /// title: 3的幂
    /// problems: https://leetcode-cn.com/problems/power-of-three/
    /// date: 20210923
    /// </summary>
    public static class Solution326
    {
        public static bool IsPowerOfThree(int n) {
            while(n > 1){
                if(n % 3 != 0)
                    return false;
                
                n /= 3;
            }

            return n == 1;
        }

        // 参考解答 倍数 约数
        public static bool IsPowerOfThree_1(int n) {
            return n > 0 && 1162261467 % n == 0;
        }
    }
}