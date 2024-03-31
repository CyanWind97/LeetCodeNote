using System;
namespace LeetCodeNote
{
    /// <summary>
    /// no: 978
    /// title: 最长湍流子数组
    /// problems: https://leetcode-cn.com/problems/longest-turbulent-subarray/
    /// date: 20210208
    /// </summary>
    public static class Solution978
    {
        public static int MaxTurbulenceSize(int[] arr) {
            int length = arr.Length;
            if(length == 1)
                return 1;
            
            int diff = arr[1] - arr[0];
            int sign = 0;
            int cur = 1;
            if(diff != 0)
                cur++;
            int max = cur;

            for(int i = 2; i < length; i++){
                sign = Math.Sign(diff);
                diff = arr[i] - arr[i - 1];
                if(sign * diff >= 0){
                    max = Math.Max(max, cur);
                    cur = 1;
                    if(diff != 0)
                        cur++;
                }else{
                    cur++;
                }
            }

            return  Math.Max(max, cur);
        }

        // 参考解答 dp
        public static int MaxTurbulenceSize_1(int[] arr) {
            int length = arr.Length;
            int dp1 = 1;
            int dp2 = 1;
            int result = 1;
            for(int i = 1; i <length; i++){
                if(arr[i] > arr[i - 1]){
                    dp1 = dp2 + 1;
                    dp2 = 1;
                }else if(arr[i] < arr[i - 1]){
                    dp2 = dp1 + 1;
                    dp1 = 1;
                }else{
                    dp1 = 1;
                    dp2 = 1;
                }

                result = Math.Max(result, Math.Max(dp1, dp2));
            }

            return result;
        }
    }
}