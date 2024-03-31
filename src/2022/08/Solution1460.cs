using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1460
    /// title:  通过翻转子数组使两个数组相等
    /// problems: https://leetcode.cn/problems/make-two-arrays-equal-by-reversing-sub-arrays/
    /// date: 20220824
    /// </summary>
    public static class Solution1460
    {
        public static bool CanBeEqual(int[] target, int[] arr) {
            var count = new Dictionary<int,int>();
            
            foreach(var num in target){
                if(!count.ContainsKey(num))
                    count[num] = 1;
                else
                    count[num]++;
            }

            foreach(var num in arr){
                if(!count.ContainsKey(num))
                    return false;
                else
                    count[num]--;
            }

            return count.All(pair => pair.Value == 0);
        }
    }
}