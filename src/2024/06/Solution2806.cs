using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2806
/// title: 取整购买后的账户余额
/// problems: https://leetcode.cn/problems/account-balance-after-rounded-purchase
/// date: 20240612
/// </summary>
public static class Solution2806
{
    public static int AccountBalanceAfterPurchase(int purchaseAmount) {
        return 100 - (purchaseAmount + 5) / 10 * 10;
    }
}
