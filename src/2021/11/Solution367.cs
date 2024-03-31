using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 367
    /// title:  有效的完全平方数
    /// problems: https://leetcode-cn.com/problems/valid-perfect-square/
    /// date: 20211104
    /// </summary>
    public static  class Solution367
    {
        public static bool IsPerfectSquare(int num) {
            if (num == 1)
                return true;

            int left = 1;
            int right = Math.Min(num / 2, 46340);

            while(left <= right){
                int mid = left + (right - left) / 2;
                int pow = mid * mid;
                if (pow == num)
                    return true;
                else if (pow < num)
                    left = mid + 1;
                else 
                    right = mid - 1;
            }

            return false;
        }

        // 参考解答 牛顿迭代法
        public static bool IsPerfectSquare_1(int num) {
            double x0 = num;
            while (true) {
                double x1 = (x0 + num / x0) / 2;
                if (x0 - x1 < 1e-6) 
                    break;
                
                x0 = x1;
            }
            int x = (int) x0;
            return x * x == num;
        }


        // 参考解答 差分
        public static bool IsPerfectSquare_2(int num) {
            for(int i = 1; num > 0; i+=2){
                num -= i;
            }

            return num == 0;
        }
    }
}