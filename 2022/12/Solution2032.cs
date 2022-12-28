using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2032
    /// title: 至少在两个数组中出现的值
    /// problems: https://leetcode.cn/problems/two-out-of-three/
    /// date: 20221229
    /// </summary>
    public static class Solution2032
    {
        public static IList<int> TwoOutOfThree(int[] nums1, int[] nums2, int[] nums3) {
            var set1 = nums1.ToHashSet();
            var result = new HashSet<int>();
            var set2 = new HashSet<int>();

            foreach(var num in nums2){
                if(set1.Contains(num))
                    result.Add(num);
                else
                    set2.Add(num);
            }

            foreach(var num in nums3){
                if(set1.Contains(num) || set2.Contains(num))
                    result.Add(num);
            }

            return result.ToList();
        }
    }
}