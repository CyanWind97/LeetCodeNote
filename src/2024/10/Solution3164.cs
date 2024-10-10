using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3164
/// title: 优质数对的总数 II
/// problems: https://leetcode.cn/problems/find-the-number-of-good-pairs-ii
/// date: 20241011
/// </summary>
public static class Solution3164
{
    public static long NumberOfPairs(int[] nums1, int[] nums2, int k) {
        var count = new Dictionary<int, int>();
        var count2 = new Dictionary<int, int>();
        int max1 = 0;
        foreach(var num in nums1){
            if  (count.ContainsKey(num))
                count[num]++;
            else
                count[num] = 1;
            
            max1 = Math.Max(max1, num);
        }

        foreach(var num in nums2){
            if  (count2.ContainsKey(num))
                count2[num]++;
            else 
                count2[num] = 1;
        }

        long result = 0;
        foreach(int a in count2.Keys){
            for(int b = a * k; b <= max1; b += a * k){
                if(count.ContainsKey(b))
                    result += (long)count[b] * count2[a];
            }
        }

        return result;
    }
}
