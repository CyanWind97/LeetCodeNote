using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1004
    /// title: 最大连续1的个数 III
    /// problems: https://leetcode-cn.com/problems/max-consecutive-ones-iii/
    /// date: 20210219
    /// </summary>
    public static class Solution1004
    {
        public static int LongestOnes(int[] A, int K) {
            int length = A.Length;
            int left = 0;
            int right = 0;
            int maxCount = 0;
            int count = K;
            while(right < length){
                if(A[right] == 0){
                    if(count == 0){
                        maxCount = Math.Max(maxCount, right - left);
                        while(left < right && A[left] == 1)
                            left++;
                        left++;
                    }else{
                        count--;
                    }
                }
                
                right++;
            }

            return Math.Max(maxCount, right - left);
        }

        public static int LongestOnes_1(int[] A, int K) {
            int length = A.Length;
            int left = 0;
            int right = 0;
            int result = 0;
            int lsum = 0;
            int rsum = 0;

            for(; right < length; right++){
                rsum += 1 - A[right];
                while(lsum < rsum - K){
                    lsum +=  1 - A[left];
                    left++;
                }

                result = Math.Max(result, right - left + 1);
            }

            return result;
        }
    }
}