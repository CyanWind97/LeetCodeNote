using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 18
    /// title:  四数之和
    /// problems: https://leetcode.cn/problems/4sum/
    /// date: 20230715
    /// </summary>
    public static class Solution18
    {
        public static IList<IList<int>> FourSum(int[] nums, int target) {
            int length = nums.Length;
            if(length < 4)
                return Array.Empty<IList<int>>();
            
            Array.Sort(nums);
            List<IList<int>> result = new List<IList<int>>();
            for(int i = 0; i < length - 3; i++){
                if(i > 0 && nums[i] == nums[i - 1])
                    continue;

                if ((long) nums[i] + nums[i + 1] + nums[i + 2] + nums[i + 3] > target) {
                    break;
                }
                if ((long) nums[i] + nums[length - 3] + nums[length - 2] + nums[length - 1] < target) {
                    continue;
                }
                
                for(int j = i + 1; j < length - 2; j++){
                    if(j > i + 1 && nums[j] == nums[j - 1])
                        continue;
                    
                    int left = j + 1;
                    int right = length - 1;
                    while(left < right){
                        long sum = (long)nums[i] + nums[j] + nums[left] + nums[right];
                        if(sum == target){
                            result.Add(new List<int>{nums[i], nums[j], nums[left], nums[right]});
                            while(left < right && nums[left] == nums[left + 1])
                                left++;
                            while(left < right && nums[right] == nums[right - 1])
                                right--;
                            
                            left++;
                            right--;
                        }else if(sum < target){
                            left++;
                        }else{
                            right--;
                        }
                    }
                }
            }

            return result;
        }
    }
}