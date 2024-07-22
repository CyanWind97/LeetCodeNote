using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;


/// <summary>
/// no: 3098
/// title: 求出所有子序列的能量和
/// problems: https://leetcode.cn/problems/find-the-sum-of-subsequence-powers
/// date: 20240723
/// </summary>
public static class Solution3098
{

    // 参考解答
    // dp
    public static int SumOfPowers(int[] nums, int k) {
        const int MOD = 1_000_000_007;
        const int INF = int.MaxValue >> 1;

        int n = nums.Length;
        int result = 0;
        var d = new Dictionary<int, int>[n, k + 1];
        for(int i = 0; i < n; i++){
            for(int j = 0; j <= k; j++){
                d[i, j] = [];
            }
        }

        Array.Sort(nums);

        for (int i = 0; i < n; i++){
            d[i, 1].Add(INF, 1);

            for(int j = 0; j  < i; j++){
                int diff = Math.Abs(nums[i] - nums[j]);

                for (int p = 2; p <= k; p++){
                    foreach(var (v, count) in d[j, p - 1]){
                        int currKey = Math.Min(diff, v);
                        d[i, p].TryAdd(currKey, 0);
                        d[i, p][currKey] = (d[i, p][currKey] + count) % MOD;
                    }
                }
            }

            foreach(var (v, count) in d[i, k]){
                result = (int)((result + 1L * v * count % MOD) % MOD);
            }
        }

        return result;
    }
}
