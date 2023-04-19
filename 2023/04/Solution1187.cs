using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1187
    /// title: 使数组严格递增
    /// problems: https://leetcode.cn/problems/make-array-strictly-increasing/
    /// date: 20230420
    /// </summary>
    public static class Solution1187
    {

        // 参考解答
        // 动态规划
        public static int MakeArrayIncreasing(int[] arr1, int[] arr2) {
            const int INF = 0x3f3f3f3f;
            Array.Sort(arr2);
            var list = arr2.Distinct().ToList();
            int n = arr1.Length;
            int m = list.Count;
            int minLength = Math.Min(n, m);

            var dp = new int[n + 1, minLength + 1];
            for(int i = 0; i <= n; i++){
                for(int j = 0; j <= minLength; j++){
                    dp[i, j] = INF;
                }
            }

            dp[0, 0] = -1;
            for (int i = 1; i <= n; i++) {
                for (int j = 0; j <= Math.Min(i, m); j++) {
                    /* 如果当前元素大于序列的最后一个元素 */
                    if (arr1[i - 1] > dp[i - 1, j]) 
                        dp[i, j] = arr1[i - 1];
                    
                    if (j > 0 && dp[i - 1, j - 1] != INF) {
                        /* 查找严格大于 dp[i - 1][j - 1] 的最小元素 */
                        // int idx = BinarySearch(list, j - 1, dp[i - 1, j - 1]);
                        int idx =  list.BinarySearch(j - 1, list.Count - j + 1, dp[i - 1, j - 1], null);
                        if(idx < 0)
                            idx = ~idx;
                        else
                            idx++;
                        
                        if (idx < list.Count) 
                            dp[i, j] = Math.Min(dp[i, j], list[idx]);
                        
                    }

                    if (i == n && dp[i, j] != INF) 
                        return j;
                }
            }

            return -1;
        }
    }
}