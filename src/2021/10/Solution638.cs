using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 638
    /// title: 大礼包
    /// problems: https://leetcode-cn.com/problems/shopping-offers/
    /// date: 20211024
    /// </summary>
    public static class Solution638
    {
        // 参考解答 记忆搜索
        public static int ShoppingOffers(IList<int> price, IList<IList<int>> special, IList<int> needs) {
            Dictionary<IList<int>, int> memo = new Dictionary<IList<int>, int>();
            
            int length = price.Count;

            // 过滤不需要计算的大礼包，只保留需要计算的大礼包
            IList<IList<int>> filterSpecial = new List<IList<int>>();
            foreach (IList<int> sp in special) {
                int totalCount = 0, totalPrice = 0;
                for (int i = 0; i < length; ++i) {
                    totalCount += sp[i];
                    totalPrice += sp[i] * price[i];
                }
                if (totalCount > 0 && totalPrice > sp[length]) {
                    filterSpecial.Add(sp);
                }
            }

             int DFS(IList<int> curNeeds) {
                if (!memo.ContainsKey(curNeeds)) {
                    int minPrice = 0;
                    for (int i = 0; i < length; ++i) {
                        minPrice += curNeeds[i] * price[i]; // 不购买任何大礼包，原价购买购物清单中的所有物品
                    }
                    foreach (IList<int> curSpecial in filterSpecial) {
                        int specialPrice = curSpecial[length];
                        IList<int> nxtNeeds = new List<int>();
                        for (int i = 0; i < length; ++i) {
                            if (curSpecial[i] > curNeeds[i])  // 不能购买超出购物清单指定数量的物品
                                break;
                            
                            nxtNeeds.Add(curNeeds[i] - curSpecial[i]);
                        }
                        
                        if (nxtNeeds.Count == length)  // 大礼包可以购买
                            minPrice = Math.Min(minPrice, DFS(nxtNeeds) + specialPrice);
                        
                    }
                    memo.Add(curNeeds, minPrice);
                }
                return memo[curNeeds];
            }


            return DFS(needs);
        }
    }
}