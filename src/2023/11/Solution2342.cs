using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2342
    /// title: 数位和相等数对的最大和
    /// problems: https://leetcode.cn/problems/max-sum-of-a-pair-with-equal-sum-of-digits/description/?envType=daily-question&envId=2023-11-18
    /// date: 20231118
    /// </summary>
    public static class Solution2342
    {
        public static int MaximumSum(int[] nums) {
            var map = new Dictionary<int, int>();
            var result = -1;

            foreach(var num in nums){
                int key = 0;
                int tmp = num;
                while(tmp > 0){
                    key += tmp % 10;
                    tmp /= 10;
                }

                if(!map.ContainsKey(key)){
                    map[key] = num;
                }else{
                    result = Math.Max(map[key] + num, result);
                    map[key] = Math.Max(map[key], num);
                }
            }

            return result;
        }
    }
}