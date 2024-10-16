using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3193
/// title: 统计逆序对的数目
/// problems: https://leetcode.cn/problems/count-the-number-of-inversions
/// date: 20241017
/// </summary>
public static class Solution3193
{
    // 参考解答
    public static int NumberOfPermutations(int n, int[][] requirements) {
        const int MOD = 1000000007;
        var reqDictionary = new Dictionary<int, int>();
        int maxCount = 0;
        reqDictionary.Add(0, 0);

        foreach (int[] req in requirements) {
            if (!reqDictionary.ContainsKey(req[0]))
                reqDictionary.Add(req[0], req[1]);
            else
                reqDictionary[req[0]] = req[1];

            maxCount = Math.Max(maxCount, req[1]);
        }
        if (reqDictionary[0] != 0) 
            return 0;
        
        var dp = new long[n, maxCount + 1];
        for (int i = 0; i < n; i++) {
            for (int j = 0; j < maxCount + 1; j++) {
                dp[i, j] = -1;
            }
        }

        long DFS(int end, int count){
            if (count < 0)
                return 0;

            if (end == 0)
                return 1;

            if (dp[end, count] != -1)
                return dp[end, count];
            
            if (reqDictionary.ContainsKey(end - 1)){
                int r = reqDictionary[end - 1];
                return r <= count && count <= end + r
                    ? dp[end, count] = DFS(end - 1, r)
                    : 0;
            }else{
                return dp[end, count] 
                    = count > end
                    ? (DFS(end, count - 1) - DFS(end - 1, count - 1 - end) + DFS(end - 1, count) + MOD) % MOD
                    : (DFS(end, count - 1) + DFS(end - 1, count)) % MOD;
            }
        }

        return (int)DFS(n - 1, reqDictionary[n - 1]);
    }
}
