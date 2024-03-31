using System;
namespace LeetCodeNote
{
    /// <summary>
    /// no: 793
    /// title: 阶乘函数后K个零
    /// problems: https://leetcode-cn.com/problems/preimage-size-of-factorial-zeroes-function/
    /// date: 20201216
    /// </summary>
    public static partial class Solution793
    {   
        // 假设 K + n =  5x + x + x/5 + x/25 + ... (n >= 0)
        // (K + n) -  (K + n) / 5 = 5x
        // 故有 K - K/5 + i = 5y (y = 5x 或 y = 5(x-1))
        // 当y为5^a的倍数时, 跳过的数量为a, 即y % 5 == 0 时，跳过的数count++;
        // 例如y = 25, 有25 * 4 = 100; 即 y % 5 = 0; count = 1; 
        // y = y / 5 = 5, y % 5 = 0; count = 2;
        // 令sum = 5y + y + y/5 + ....
        // 当 K 属于 [sum - count, sum) U (sum + 4, ...)时，返回0，否则返回5
        public static int PreimageSizeFZF(int k) {
            int x = k -  k / 5;
            while(x % 5 != 0){
                x++;
            }
            int sum = 0;
            int count = 0;
            bool flag = true;
            while(x > 0) {
                sum += x;
                if(flag){
                    if( x % 5 == 0)
                        count++;
                    else
                        flag = false;
                }
                x /= 5;
            }

            return ((k >= sum - count && k < sum) || (k > sum && k - sum > 4)) ? 0 : 5;
        }


        // 官方解答: 二分查找
        public static int PreimageSizeFZF_1(int K) {
            long low=0,high=5000000000;
            while(low<high){
                long mid=low+(high-low)/2;
                long k=Help(mid);
                if(k==K) return 5;
                if(k<K) low=mid+1;
                else high=mid;
            }
            return 0;
        }

        public static long Help(long x){
            if(x==0) return 0;
            return x/5+Help(x/5);
        }
    }
}