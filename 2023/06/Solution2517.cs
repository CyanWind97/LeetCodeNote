using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2517
    /// title: 盒的最大甜蜜度
    /// problems: https://leetcode.cn/problems/maximum-tastiness-of-candy-basket/
    /// date: 20230601
    /// </summary>
    public static class Solution2517
    {
        public static int MaximumTastiness(int[] price, int k) {
            Array.Sort(price);
            int length = price.Length;
            int left = 0;
            int right = price[^1] - price[0];

            bool Check(int tastiness) {
                int prev = int.MinValue / 2;
                int cnt = 0;
                foreach (int p in price) {
                    if (p - prev >= tastiness) {
                        cnt++;
                        prev = p;
                    }
                }

                return cnt >= k;
            
            }

            while(left < right){
                int mid =  (left + right + 1) / 2;
                if(Check(mid))
                    left = mid;
                else
                    right = mid - 1;
            }

            return left;
        }
    }
}