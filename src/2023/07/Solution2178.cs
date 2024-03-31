using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2178
    /// title:  拆分成最多数目的正偶数之和
    /// problems: https://leetcode.cn/problems/maximum-split-of-positive-even-integers/
    /// date: 20230706
    /// </summary>
    public static class Solution2178
    {
        public static IList<long> MaximumEvenSplit(long finalSum) {
            if (finalSum % 2 == 1)
                return Array.Empty<long>();
            
            var result = new List<long>();
            for(int i  = 2; i <= finalSum; i += 2){
                result.Add(i);
                finalSum -= i;
            }

            result[^1] += finalSum;
            return result;
        }
    }
}