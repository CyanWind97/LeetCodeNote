using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2940
/// title: 到 Alice 和 Bob 可以相遇的建筑
/// problems: https://leetcode.cn/problems/find-building-where-alice-and-bob-can-meet
/// date: 20240810
/// </summary>
public static class Solution2940
{
    // 参考解答
    // 线段树
    public static int[] LeftmostBuildingQueries(int[] heights, int[][] queries) {
        int n = heights.Length;
        var zd = new int[n * 4];

        void Build(int l, int r, int rt){
            if(l == r){
                zd[rt] = heights[l - 1];
                return;
            }

            int mid = (l + r) >> 1;
            Build(l, mid, rt << 1);
            Build(mid + 1, r, rt << 1 | 1);
            zd[rt] = Math.Max(zd[rt << 1], zd[rt << 1 | 1]);
        }

        int Query(int pos, int val, int l, int r, int rt){
            if (val >= zd[rt])
                return 0;
            
            if (l == r)
                return l;
            
            int mid = (l + r) >> 1;
            if (pos <= mid){
                int res = Query(pos, val, l, mid, rt << 1);
                if (res is not 0)
                    return res;
            }

            return Query(pos, val, mid + 1, r, rt << 1 | 1);
        }

        Build(1, n, 1);
        int m = queries.Length;
        int[] result = new int[m];

        for(int i = 0; i < m; i++){
            var (a, b) = (queries[i][0], queries[i][1]);
            if(a > b)
                (a, b) = (b, a);
            
            if (a == b || heights[a] < heights[b]){
                result[i] = b;
                continue;
            }

            result[i] = Query(b + 1, heights[a], 1, n, 1) - 1;
        }

        return result;
    }
}
