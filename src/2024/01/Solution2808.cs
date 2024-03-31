using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2808
    /// title: 使循环数组所有元素相等的最少秒数
    /// problems: https://leetcode.cn/problems/minimum-seconds-to-equalize-a-circular-array/description/?envType=daily-question&envId=2024-01-30
    /// date: 20240130
    /// </summary>
    public static class Solution2808
    {
        public static int MinimumSeconds(IList<int> nums) {
            var count = new Dictionary<int, List<int>>();
            int n = nums.Count;
            for(int i = 0; i < n; i++){
                if(!count.ContainsKey(nums[i]))
                    count.Add(nums[i], new List<int>());
                
                count[nums[i]].Add(i);
            }

            int CalcMax(List<int> indexs){
                if (indexs.Count == 1)
                    return n;
                
                return indexs.Zip(indexs.Skip(1).Concat(indexs.Take(1)), (x, y) => (y + n - x) % n)
                        .Max();
            }

            return (count.Values.Select(CalcMax).Min()) / 2;
        }
    }
}