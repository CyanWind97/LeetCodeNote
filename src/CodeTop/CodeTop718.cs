using System;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 718
    /// title:  最长重复子数组
    /// problems: https://leetcode.cn/problems/maximum-length-of-repeated-subarray/
    /// date: 20220523
    /// priority: 0091
    /// time: 00:06:33.62
    /// </summary>
    public static class CodeTop718
    {
        public static int FindLength(int[] nums1, int[] nums2) {
            int l1 = nums1.Length;
            int l2 = nums2.Length;

            var dp = new int[l1 + 1, l2 + 1];
            var max = 0;
            
            for(int i = 0; i < l1; i++){
                for(int j = 0; j < l2; j++){
                    dp[i + 1, j + 1] = nums1[i] == nums2[j]
                                        ? dp[i, j] + 1
                                        : 0;

                    max = Math.Max(max, dp[i + 1, j + 1]);
                }
            }

            return max;
        }

        // 参考解答 滑动窗口
        public static int FindLength_1(int[] nums1, int[] nums2) {
            int l1 = nums1.Length;
            int l2 = nums2.Length;
            
            int MaxLength(int add1, int add2, int len){
                int result = 0;
                int k = 0;
                for(int i = 0; i < len; i++){
                    if(nums1[add1 + i] == nums2[add2 + i])
                        k++;
                    else
                        k = 0;
                    
                    result = Math.Max(result, k);
                }

                return result;
            }

            int result = 0;

            for(int i = 0; i < l1; i++){
                int len = Math.Min(l2, l1 - i);
                int maxLen = MaxLength(i, 0, len);
                result = Math.Max(result, maxLen);
            }
            
            for(int i = 0; i < l2; i++){
                int len = Math.Min(l1, l2 - i);
                int maxLen = MaxLength(0, i, len);
                result = Math.Max(result, maxLen);
            }


            return result;
        }
    }
}