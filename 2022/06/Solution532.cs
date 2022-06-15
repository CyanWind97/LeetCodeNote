using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 532
    /// title: 数组中的 k-diff 数对
    /// problems: https://leetcode.cn/problems/k-diff-pairs-in-an-array/
    /// date: 20220616
    /// </summary>

    public static class Solution532
    {
        public static int FindPairs(int[] nums, int k) {
            if (k == 0)
                return nums.GroupBy(x => x).Count(g => g.Count() > 1);
            
            var set = new HashSet<int>();
            var count = 0;
            foreach(var num in nums){
                if(set.Contains(num))
                    continue;
                
                if (set.Contains(num - k))
                    count++;
                
                if  (set.Contains(num + k))
                    count++;

                set.Add(num);
            }

            return count;
        }

        // 参考解答 双hashset处理
        public static int FindPairs_1(int[] nums, int k) {
            ISet<int> visited = new HashSet<int>();
            ISet<int> res = new HashSet<int>();
            foreach (int num in nums) {
                if (visited.Contains(num - k)) {
                    res.Add(num - k);
                }
                if (visited.Contains(num + k)) {
                    res.Add(num);
                }
                visited.Add(num);
            }
            return res.Count;
        }
    }
}