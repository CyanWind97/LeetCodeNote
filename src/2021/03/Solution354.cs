using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 354
    /// title: 俄罗斯套娃信封问题
    /// problems: https://leetcode-cn.com/problems/russian-doll-envelopes/
    /// date: 20210304
    /// </summary>
    public static class Solution354
    {
        // 参考解答  排序方法
        public static int MaxEnvelopes(int[][] envelopes) {
            int length = envelopes.Length;
            if(length == 0)
                return 0;
            Array.Sort(envelopes, (a, b) => (a[0] == b[0] ? b[1] - a[1] : a[0] - b[0]));
            int[] dp = new int[length];
            Array.Fill(dp, 1);
            for(int i = 1; i < length; i++){
                for(int j = 0; j < i; j++){
                    if(envelopes[j][1] < envelopes[i][1])
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
 
            return dp.Max();
        }

        // 参考解答 二分查找 LTS
        public static int MaxEnvelopes_1(int[][] envelopes) {
            int length = envelopes.Length;
            if(length == 0)
                return 0;
            Array.Sort(envelopes, (a, b) => (a[0] == b[0] ? b[1] - a[1] : a[0] - b[0]));

            List<int> dp = new List<int>();
            int BinarySearch(int target) {
                int low = 0, high = dp.Count() - 1;
                while (low < high) {
                    int mid = (high - low) / 2 + low;
                    if (dp[mid] < target) {
                        low = mid + 1;
                    } else {
                        high = mid;
                    }
                }
                return low;
            }

            dp.Add(envelopes[0][1]);
            for(int i = 1; i < length; i++){
                int num = envelopes[i][1];
                if(num > dp.Last()){
                    dp.Add(num);
                }else{
                    int index = BinarySearch(num);
                    dp[index] = num;
                }
            }
 
            return dp.Count();
        }
    }
}