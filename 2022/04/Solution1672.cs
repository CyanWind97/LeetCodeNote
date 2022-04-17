using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1672
    /// title: 最富有客户的资产总量
    /// problems: https://leetcode-cn.com/problems/richest-customer-wealth/
    /// date: 20220414
    /// </summary>
    public static class Solution1672
    {
        public static int MaximumWealth(int[][] accounts) {
            return accounts.Select(x => x.Sum()).Max();
        }
    }
}