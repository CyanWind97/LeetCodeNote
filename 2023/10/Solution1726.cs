using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1726
    /// title: 同积元组
    /// problems: https://leetcode.cn/problems/tuple-with-same-product/?envType=daily-question&envId=2023-10-19
    /// date: 20231019
    /// </summary>
    public static class Solution1726
    {
        public static int TupleSameProduct(int[] nums) {
            int length = nums.Length;
            var map = new Dictionary<int, int>();
            for(int i = 0; i < length; i++){
                for(int j = i + 1; j < length; j++){
                    int product = nums[i] * nums[j];
                    map.TryAdd(product, 0);
                    map[product]++;
                }
            }

            int result = 0;
            foreach(var pair in map){
                int count = pair.Value;
                if(count > 1){
                    result += count * (count - 1) * 4;
                }
            }

            return result;
        }
    }
}