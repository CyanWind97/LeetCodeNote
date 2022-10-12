using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 769
    /// title: 最多能完成排序的块
    /// problems: https://leetcode.cn/problems/max-chunks-to-make-sorted/
    /// date: 20221013
    /// </summary>
    public static class Solution769
    {
        public static int MaxChunksToSorted(int[] arr) {
            int chunks = 1;
            int start = 0;
            int size = 0;
            int length = arr.Length;
            
            for(int i = 0; i < length; i++){
                if(size > 0 && start + size == i){
                    chunks++;
                    start = i;
                    size = 0;
                }

                size = Math.Max(size, arr[i] - start + 1);
            }

            return chunks;
        }

        // 参考解答
        public static int MaxChunksToSorted_1(int[] arr) {
            int m = 0, res = 0;
            for (int i = 0; i < arr.Length; i++) {
                m = Math.Max(m, arr[i]);
                if (m == i) 
                    res++;
            }
            return res;
        }

    }
}