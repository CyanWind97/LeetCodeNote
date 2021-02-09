using System.Collections.Generic;
namespace LeetCodeNote
{
    /// <summary>
    /// no: 992
    /// title: K 个不同整数的子数组
    /// problems: https://leetcode-cn.com/problems/subarrays-with-k-different-integers/
    /// date: 20210209
    /// </summary>
    public static class Solution992
    {
        // 参考解答 滑动窗口
        // 将恰好K个的问题转化为(最多K个 - 最多K-1个)的问题，妙啊
        public static int SubarraysWithKDistinct(int[] A, int K) {
            int length = A.Length;
            
            int MostDistinct(int n){
                int[] freq = new int[length + 1];
                int left = 0;
                int right = 0;
                int count = 0;
                int result = 0;
                while(right < length){
                    if(freq[A[right]] == 0){
                        count++;
                    }
                    freq[A[right]]++;
                    right++;
                    while(count > n){
                        freq[A[left]]--;
                        if(freq[A[left]] == 0)
                            count--;
                        left++;
                    }
                    result += right - left;
                }

                return result;
            }
            
            return MostDistinct(K) - MostDistinct(K - 1);
        }
    }
}