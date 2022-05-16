using System;

namespace LeetCodeNote.CodeTop
{   
    /// <summary>
    /// no: 69
    /// title:  x 的平方根 
    /// problems: https://leetcode.cn/problems/sqrtx/
    /// date: 20220515
    /// priority: 0059
    /// time: 00:06:47.27
    /// </summary>

    public static class CodeTop69
    {
        public static int MySqrt(int x) {
            if(x == 0)
                return 0;
            
            if(x < 4)
                return 1;

            int left = 0;
            int right = x / 2;
            int result = -1;
            
            while(left <= right){
                var mid = left + (right - left) / 2;
                if(mid <= x / mid){
                    result = mid;
                    left = mid + 1;
                }else{
                    right = mid - 1;
                }
            }

            return result;
        }

        // 参考解答 牛顿迭代法
        public static int MySqrt_1(int x) {
            if(x == 0)
                return 0;
            
            if(x < 4)
                return 1;

            double C = x;
            double x0 = x;
            while(true){
                double xi = (x0 + C / x0) / 2;
                if(Math.Abs(x0 - xi) < 1e-7)
                    break;
                
                x0 = xi;
            }

            return (int)x0;
        }
    }
}