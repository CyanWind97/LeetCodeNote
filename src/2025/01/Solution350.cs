using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 350
/// title: 两个数组的交集 II
/// problems: https://leetcode.cn/problems/intersection-of-two-arrays-ii
/// date: 20250130
/// </summary>
public static class Solution350
{
    public static int[] Intersect(int[] nums1, int[] nums2) {
        List<int> result = new List<int>();
        Array.Sort(nums1);
        Array.Sort(nums2);

        int i = 0;
        int j = 0;

        while(i < nums1.Length && j < nums2.Length){
            if(nums1[i] == nums2[j]){
                result.Add(nums1[i++]);
                j++;
            }
            else if(nums1[i] > nums2[j])
                j++;
            else
                i++;

        }

        
        return result.ToArray();
    }
}
