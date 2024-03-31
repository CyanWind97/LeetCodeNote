using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 896
    /// title: 单调数列
    /// problems: https://leetcode-cn.com/problems/monotonic-array/
    /// date: 20210228
    /// </summary>
    public static class Solution896
    {
        public static bool IsMonotonic(int[] A) {
            int length = A.Length;
            if(length < 2)
                return true;
            
            int sign = Math.Sign(A[1] - A[0]);

            for(int i = 2; i < length; i++){
                int diff = Math.Sign(A[i] - A[i - 1]);
                if(sign * diff < 0)
                    return false;
                sign += diff;
            }

            return true;
        }
    }
}