using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1773
    /// title:  统计匹配检索规则的物品数量
    /// problems: https://leetcode.cn/problems/count-items-matching-a-rule/
    /// date: 20221029
    /// </summary>
    public static class Solution1773
    {
        public static int CountMatches(IList<IList<string>> items, string ruleKey, string ruleValue) {
            var keys = new string[]{"type", "color", "name"};
            var index = Array.IndexOf(keys, ruleKey);

            return items.Count(item => item[index] == ruleValue);
        }
    }
}