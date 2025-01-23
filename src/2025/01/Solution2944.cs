using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2944
/// title: 购买水果需要的最少金币数
/// problems: https://leetcode.cn/problems/minimum-number-of-coins-for-fruits
/// date: 20250124
/// </summary>
public static class Solution2944
{
    // 参考解答
    // 单调队列
    public static int MinimumCoins(int[] prices) {
        int n = prices.Length;
        var linkList = new LinkedList<(int Index, int Prices)>();
        linkList.AddFirst((n, 0));
        for(int i = n - 1; i >= 0; i--){
            while(linkList.Last.Value.Index >= 2 * i + 3){
                linkList.RemoveLast();
            }

            var curr = linkList.Last.Value.Prices + prices[i];
            while(linkList.First.Value.Prices >= curr){
                linkList.RemoveFirst();
            }

            linkList.AddFirst((i, curr));
        }

        return linkList.First.Value.Prices;
    }
}
