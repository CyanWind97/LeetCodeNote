using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3132
/// title: 找出与数组相加的整数 II
/// problems: https://leetcode.cn/problems/find-the-integer-added-to-array-ii
/// date: 20240809
/// </summary>
public static class Solution3132
{
    public static int MinimumAddedInteger(int[] nums1, int[] nums2) {
        var span1 = new Span<int>(nums1);
        var span2 = new Span<int>(nums2);

        int l2 = Math.Min(5, span2.Length);
        int l1 = l2 + 2;
        span1.Sort();
        span2.Sort();

        span1 = span1[..l1];
        span2 = span2[..l2];

        for(int i = 2; i >= 0; i--){
            var (left, right) = (i + 1, 1);
            while(left < l1 && right < l2){
                if(span1[left] - span1[i] == span2[right] - span2[0])
                    right++;
                
                left++;
            }

            if(right == l2)
                return span2[0] - span1[i];
        }

        return 0;
    }
}
