using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1590
    /// title: 使数组和能被 P 整除
    /// problems: https://leetcode.cn/problems/make-sum-divisible-by-p/
    /// date: 20230310
    /// </summary>
    public static class Soltuion1590
    {
        public static int MinSubarray(int[] nums, int p) {
            int n = nums.Length;
            var x = 0;
            
            foreach(var num in nums){
                x = (x + num) % p;
            }

            if(x == 0)
                return 0;
            
            var index = new Dictionary<int, int>();
            int result = n;
            int y = 0;

            for(int i = 0; i < n; i++){
                index[y] = i;

                y = (y + nums[i]) % p;
                int diff = (y - x + p) % p;
                if(index.ContainsKey(diff))
                    result = Math.Min(result, i - index[diff] + 1);
            }

            return result == n ? -1 : result;
        }
    }
}