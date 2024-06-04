using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2072
/// title: 将元素分配到两个数组中 II
/// problems: https://leetcode.cn/problems/distribute-elements-into-two-arrays-ii
/// date: 20240605
/// </summary>
public static class Solution3072
{
    public static int[] ResultArray(int[] nums) {
        int n = nums.Length;
        var result1 = new List<int>();
        var result2 = new List<int>();
        var keys1 = new List<int>();
        var keys2 = new List<int>();

        int GreaterCount(List<int> keys, int val){
            var index = keys.BinarySearch(val);
            if (index >= 0)
                while (index < keys.Count && keys[index] == val)
                    index++;
            else
                index = ~index;
            
            return keys.Count - index;
        }

        void Insert(List<int> list, List<int> keys, int val){
            var index = keys.BinarySearch(val);
            if (index < 0)
                index = ~index;
            
            keys.Insert(index, val);
            list.Add(val);
        }

        result1.Add(nums[0]);
        keys1.Add(nums[0]);
        result2.Add(nums[1]);
        keys2.Add(nums[1]);

        for(int i = 2; i < n; i++){
            var count1 = GreaterCount(keys1, nums[i]);
            var count2 = GreaterCount(keys2, nums[i]);

            if (count1 > count2 
                || (count1 == count2 && keys1.Count <= keys2.Count)){
                Insert(result1, keys1, nums[i]);
            }else{
                Insert(result2, keys2, nums[i]);
            }
        }

        return [.. result1, .. result2];
    }
}
