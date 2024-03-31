using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2824
    /// title: 统计和小于目标的下标对数目
    /// problems: https://leetcode.cn/problems/count-pairs-whose-sum-is-less-than-target/description/?envType=daily-question&envId=2023-11-24
    /// date: 20231124
    /// </summary>
    public static class Solution2824
    {
        public static int CountPairs(IList<int> nums, int target) {
            var tmp = nums.ToArray();
            Array.Sort(tmp);
            int length = tmp.Length;
            int result = 0;
            var limit = Math.Max(0, target);

            for (int i = 0; i < length && tmp[i] < limit; i++){
                var key = target - tmp[i];
                var index = Array.BinarySearch(tmp, i + 1, length - i - 1, key);
                if (index < 0)
                    index = ~index - 1;
                else
                    while(index > i && tmp[index] == key)
                        index--;
                
                result += index - i;
            }

            return result;
        }
    }
}