using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2006
    /// title:  差的绝对值为 K 的数对数目
    /// problems: https://leetcode-cn.com/problems/count-number-of-pairs-with-absolute-difference-k/
    /// date: 20220209
    /// </summary>
    public static class Solution2006
    {
        public static int CountKDifference(int[] nums, int k) {
            var dic = new Dictionary<int, int>();
            int count = 0;
            
            foreach(var num in nums){
                if(!dic.ContainsKey(num))
                    dic.Add(num, 0);
                
                dic[num]++;
                count += dic.GetValueOrDefault(num - k) + dic.GetValueOrDefault(num + k);
            }

            return count;
        }
    }
}