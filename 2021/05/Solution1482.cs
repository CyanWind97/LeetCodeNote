using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1428
    /// title:  制作 m 束花所需的最少天数
    /// problems: https://leetcode-cn.com/problems/minimum-number-of-days-to-make-m-bouquets/
    /// date: 20210509
    /// </summary>
    public static class Solution1482
    {
        public static int MinDays(int[] bloomDay, int m, int k) {
            int length = bloomDay.Length;
            if(m * k > length)
                return -1;
            
            bool CanMake(int days){
                int bouquets = 0;
                int flowers = 0;
                for(int i = 0; i < length && bouquets < m; i++){
                    if(bloomDay[i] <= days){
                        flowers++;
                        if(flowers == k){
                            bouquets++;
                            flowers = 0;
                        }
                    }else{
                        flowers = 0;
                    }
                }
                return bouquets >= m;
            }

            int low = bloomDay[0];
            int high = bloomDay[0];

            for(int i = 1; i < length; i++){
                if(bloomDay[i] < low)
                    low = bloomDay[i];
                else if(bloomDay[i] > high)
                    high = bloomDay[i];
            }

            while(low < high){
                int mid = (high - low) / 2 + low;
                if(CanMake(mid))
                    high = mid;
                else
                    low = mid + 1;
            }

            return low;
        }
    }
}