using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3181
/// title: 执行操作可获得的最大总奖励 I
/// problems: https://leetcode.cn/problems/maximum-total-reward-using-operations-i
/// date: 20241026
/// </summary>
public static class Solution3181
{
    // 参考解答
    public static int MaxTotalReward(int[] rewardValues) {
        rewardValues = [..rewardValues.Distinct()];
        Array.Sort(rewardValues);

        BigInteger f = new(1);
        foreach (int v in rewardValues) {
            BigInteger mask = (BigInteger.One << v) - 1;
            f |= (f & mask) << v;
        }

        return (int)(f.GetBitLength() - 1);
    }
}
