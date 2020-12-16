using System;
namespace LeetCodeNote
{
    // <summary>
    /// no: 893
    /// title: 阶乘函数后K个零
    /// problems: https://leetcode-cn.com/problems/preimage-size-of-factorial-zeroes-function/
    /// date: 20201216
    /// </summary>
    public static class Solution793
    {   
        public static int PreimageSizeFZF(int K) {
            int x = K -  K / 5;
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
                if(x == 0 && K > sum) {
                    Console.WriteLine(sum);
                    x = K - K/5 + 5;
                    while(x % 5 != 0){
                        x++;
                    }
                    sum = 0;
                    count = 0;
                    flag = true;
                }
            }

            return (K >= sum - count && K < sum) ? 0 : 5;
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