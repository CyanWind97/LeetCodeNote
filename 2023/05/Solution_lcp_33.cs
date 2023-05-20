using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 33
    /// title: 蓄水
    /// problems: https://leetcode.cn/problems/o8SXZn/
    /// date: 20230521
    /// type: lcp
    public class Solution_lcp_33
    {
        public static int StoreWater(int[] bucket, int[] vat) {
            int length = bucket.Length;
            int max = vat.Max();
            if (max == 0)
                return 0;
            
            int result = int.MaxValue;
            for(int i = 1; i <= max; i++){
                int count = 0;
                for(int j = 0; j < length; j++){
                    count += Math.Max((vat[j] + i - 1) / i - bucket[j], 0);
                }

                result = Math.Min(result, count + i);
            }

            return result;
        }
    }
}