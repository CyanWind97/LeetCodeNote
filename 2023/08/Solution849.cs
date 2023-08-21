using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 849
    /// title: 到最近的人的最大距离
    /// problems: https://leetcode.cn/problems/maximize-distance-to-closest-person/
    /// date: 20230822
    /// </summary>
    public static class Solution849
    {
        public static int MaxDistToClosest(int[] seats) {
            int length = seats.Length;
            var dist = new int[length];
            int prev = -30000;
            for(int i = 0; i < length; i++){
                if (seats[i] == 1){
                    dist[i] = int.MaxValue;
                    prev = i;
                }else
                    dist[i] = i - prev;
            }

            prev = 30000; 
            int result = 1;
            for(int i = length - 1; i >= 0; i--){
                if(seats[i] == 1){
                    prev = i; 
                }else{
                    dist[i] = Math.Min(dist[i], prev - i);
                    result = Math.Max(result, dist[i]);
                }
            }

            return result;
        }

        // 参考解答 双指针
        public static int MaxDistToClosest_1(int[] seats) {
            int res = 0;
            int l = 0;
            while (l < seats.Length && seats[l] == 0) {
                ++l;
            }
            res = Math.Max(res, l);
            while (l < seats.Length) {
                int r = l + 1;
                while (r < seats.Length && seats[r] == 0) {
                    ++r;
                }
                if (r == seats.Length) {
                    res = Math.Max(res, r - l - 1);
                } else {
                    res = Math.Max(res, (r - l) / 2);
                }
                l = r;
            }
            return res;
        }

    }
}