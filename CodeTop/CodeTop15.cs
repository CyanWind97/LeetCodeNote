using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 15
    /// title:  三数之和
    /// problems: https://leetcode-cn.com/problems/3sum/
    /// date: 20220506
    /// priority: 0011
    /// time: 00:24:08.65
    /// </summary>
    public static class CodeTop15
    {
        public static IList<IList<int>> ThreeSum(int[] nums){
            var result = new List<IList<int>>();
            
            if(nums.Length == 0)
                return result;

            var count = nums.GroupBy(x => x)
                            .ToDictionary(g => g.Key, g => g.Count());

            var keys = count.Keys.ToArray();
            Array.Sort(keys);
            
            var length = keys.Length;
            var divide = Array.BinarySearch(keys, 0);
            var existZero = divide >= 0;
            if(divide < 0)
                divide = ~divide;

            for(int i = 0; i < divide; i++){
                int num = keys[i];
                
                for(int j = count[num] == 1 ? i + 1 : i; j < divide; j++){
                    var key = - num - keys[j];
                    if(count.ContainsKey(key))
                        result.Add(new int[]{ num, keys[j], key});
                }

                if(existZero && count.ContainsKey(-num))
                    result.Add(new int[]{ num, 0, -num});
            }

            for(int i = existZero ? divide + 1 : divide; i < length; i++){
                int num = keys[i];

                for(int j = count[num] == 1 ? i + 1 : i; j < length; j++){
                    var key = - num - keys[j];
                    if(count.ContainsKey(key))
                        result.Add(new int[]{ key, num, keys[j]});
                }
            }

            if(existZero && count[0] > 2)
                result.Add(new int[]{0 , 0, 0});
            
            return result;
        }

        // 参考解答 双指针
        public static IList<IList<int>> ThreeSum_1(int[] nums){
            int length = nums.Length;
            Array.Sort(nums);
            var result = new List<IList<int>>();

            for(int first = 0; first < length; first++){
                if(first > 0 && nums[first] == nums[first - 1])
                    continue;
                
                int third = length - 1;
                int target = -nums[first];

                for(int second = first + 1; second < length; second++){
                    if(second > first + 1 && nums[second] == nums[second - 1])
                        continue;
                    
                    while(second < third && nums[second] + nums[third] > target){
                        --third;
                    }

                    if(second == third)
                        break;
                    
                    if(nums[second] + nums[third] == target){
                        result.Add(new int[3]{nums[first], nums[second], nums[third]});
                    }
                }
            }

            return result;
        }
    }
}