using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2103
    /// title: 环和杆
    /// problems: https://leetcode.cn/problems/rings-and-rods/?envType=daily-question&envId=2023-11-02
    /// date: 20231102
    /// </summary>
    public static class Solution2103
    {
        public static int CountPoints(string rings) {
            int length = rings.Length;
            int[] count = new int[10];
            var map = new Dictionary<char, int>()
            {
                {'R', 1}, 
                {'G', 2},
                {'B', 4},
            };

            for(int i = 0; i < length; i += 2){
                var color = map[rings[i]];
                var no = rings[i + 1] - '0';
                count[no] |= color;
            }
            
            return count.Count(x => x == 7);
        }
    }
}