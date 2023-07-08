using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 15
    /// title:  三数之和
    /// problems: https://leetcode.cn/problems/3sum/
    /// date: 20230709
    /// </summary>
    public static class Solution15
    {
        public static IList<IList<int>> ThreeSum(int[] nums) {
            int length = nums.Length;
            Array.Sort(nums);
            var result = new List<IList<int>>();
            for(int first = 0; first < length - 2; first++){
                if(first > 0 && nums[first] == nums[first - 1])
                    continue;
                
                int left = first + 1;
                int right = length - 1;
                while(left < right){
                    int sum = nums[first] + nums[left] + nums[right];
                    if(sum == 0){
                        result.Add(new List<int>{nums[first], nums[left], nums[right]});
                        while(left < right && nums[left] == nums[left + 1])
                            left++;
                        while(left < right && nums[right] == nums[right - 1])
                            right--;
                        left++;
                        right--;
                    }else if(sum < 0)
                        left++;
                    else
                        right--;
                }
            }

            return result;
        }
    }
}