using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

 /// <summary>
/// no: 638
/// title: 大礼包
/// problems: https://leetcode-cn.com/problems/shopping-offers/
/// date: 20241103
/// </summary>
public static partial class Solution638
{
    // 参考解答 记忆搜索
        public static int ShoppingOffers(IList<int> price, IList<IList<int>> special, IList<int> needs) {
            var memo = new Dictionary<IList<int>, int>();
            int length = price.Count;

            // 过滤不需要计算的大礼包，只保留需要计算的大礼包
            var filterSpecial = new List<IList<int>>();
            foreach (var sp in special) {
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
                if (memo.TryGetValue(curNeeds, out int value))
                    return value;

                int minPrice = 0;
                for (int i = 0; i < length; ++i) {
                    minPrice += curNeeds[i] * price[i]; // 不购买任何大礼包，原价购买购物清单中的所有物品
                }
                foreach (var curSpecial in filterSpecial) {
                    int specialPrice = curSpecial[length];
                    var nxtNeeds = new List<int>();
                    for (int i = 0; i < length; ++i) {
                        if (curSpecial[i] > curNeeds[i])  // 不能购买超出购物清单指定数量的物品
                            break;
                        
                        nxtNeeds.Add(curNeeds[i] - curSpecial[i]);
                    }
                    
                    if (nxtNeeds.Count == length)  // 大礼包可以购买
                        minPrice = Math.Min(minPrice, DFS(nxtNeeds) + specialPrice);
                    
                }
                
                return memo[curNeeds] = minPrice;
            }

            return DFS(needs);
        }
}
