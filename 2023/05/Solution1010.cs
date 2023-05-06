using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{

    /// <summary>
    /// no: 1010
    /// title:  总持续时间可被 60 整除的歌曲
    /// problems: https://leetcode.cn/problems/pairs-of-songs-with-total-durations-divisible-by-60/
    /// date: 20230507
    /// </summary>
    public static class Solution1010
    {
        public static int NumPairsDivisibleBy60(int[] time) {
            var count = new Dictionary<int, int>();
            int result = 0;
            foreach(var t in time){
                int key = t % 60;
                int pairKey = (60 - key) % 60;
                if (count.ContainsKey(pairKey)) 
                    result += count[pairKey];
                
                if(!count.ContainsKey(key))
                    count[key] = 0;
                
                count[key]++;
            }

            return result;
        }

        public static int NumPairsDivisibleBy60_1(int[] time) {
            var count = new int[60];
            int result = 0;
            foreach(var t in time){
                int key = t % 60;
                int pairKey = (60 - key) % 60;
                result += count[pairKey];                
                count[key]++;
            }

            return result;
        }
    }
}