using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2591
    /// title: 将钱分给最多的儿童
    /// problems: https://leetcode.cn/problems/distribute-money-to-maximum-children/?envType=daily-question&envId=2023-09-22
    /// date: 20230922
    /// </summary>
    public static class Solution2591
    {
        public static int DistMoney(int money, int children) {
            if (money < children)
                return -1;
            
            money -= children;
            int count = Math.Min(money / 7, children);
            money -= count * 7;
            children -= count;
            if ((children == 0 && money > 0)
                || (children == 1 && money == 3))
                count--;
            
            return count;
        }
    }
}