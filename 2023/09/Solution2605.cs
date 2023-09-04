using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2605
    /// title: 从两个数字数组里生成最小数字
    /// problems: https://leetcode.cn/problems/form-smallest-number-from-two-digit-arrays/?envType=daily-question&envId=2023-09-05
    /// date: 20230905
    /// </summary>
    public static class Solution2605
    {
        public static int MinNumber(int[] nums1, int[] nums2) {
            var exists = new bool[10];
            var min1 = 10;
            var min2 = 10;
            var result = 10;
            foreach(var num in nums1){
                exists[num] = true;
                min1 = Math.Min(min1, num);
            }

            foreach(var num in nums2){
                if(exists[num]){
                    result = Math.Min(result, num);
                    continue;
                }else{
                    min2 = Math.Min(min2, num);
                }
            }

            if (result != 10)
                return result;
            
            if(min1 > min2)
                (min1, min2) = (min2, min1);
            
            return min1 * 10 + min2;
        }
    }
}