using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 995
    /// title: K 连续位的最小翻转次数
    /// problems: https://leetcode-cn.com/problems/minimum-number-of-k-consecutive-bit-flips/
    /// date: 20210218
    /// </summary>
    public static class Solution995
    {
        public static int MinKBitFlips(int[] A, int K) {
            int length =  A.Length;
            int n = length >= 2 * K ? K : length - K + 1;
            int result = 0;
            int[] count = new int[length];
            int flipCount = 0;

            for(int i = 0; i < n; i++){
                if(A[i] == flipCount % 2){
                    flipCount++;
                    count[i] = 1;
                }
            }
            
            result = flipCount;

            for(int i = K; i <= length - K; i++){
                flipCount = flipCount - count[i - K];
                if(A[i] == flipCount % 2){
                    count[i] = 1;
                    flipCount++;
                    result++;
                }
            }

            for(int i = length - K + 1; i < length; i++){
                if(i >= K)
                    flipCount = flipCount - count[i - K];
                
                if(A[i] == flipCount % 2)
                    return -1;
            }

            return result;
        }

        // 参考解答
        public static int MinKBitFlips_1(int[] A, int K) {
            int length = A.Length;
            int result = 0;
            int revCount = 0;

            for(int i = 0; i < length; i++){
                if(i >= K && A[i - K] > 1){
                    revCount ^= 1;
                    A[i - K] -= 2;
                }
                if(A[i] == revCount){
                    if(i + K > length)
                        return -1;
                    
                    result++;
                    revCount ^= 1;
                    A[i] += 2;
                }
            }
            return result;
        }
    }
}