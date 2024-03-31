using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1774
    /// title:  最接近目标价格的甜点成本
    /// problems: https://leetcode.cn/problems/closest-dessert-cost/
    /// date: 20221204
    /// </summary>
    public class Solution1774
    {
        // 参考解答
        // 动态规划
        public static int ClosestCost(int[] baseCosts, int[] toppingCosts, int target) {
            int x = baseCosts.Min();
            if (x >= target) 
                return x;
            
            var can = new bool[target + 1];
            int res = 2 * target - x;
            foreach (var b in baseCosts) {
                if (b <= target) 
                    can[b] = true;
                else 
                    res = Math.Min(res, b);
            }

            foreach (var t in toppingCosts) {
                for (int count = 0; count < 2; ++count) {
                    for (int i = target; i > 0; --i) {
                        if (can[i] && i + t > target) {
                            res = Math.Min(res, i + t);
                        }
                        if (i - t > 0) {
                            can[i] = can[i] | can[i - t];
                        }
                    }
                }
            }

            for (int i = 0; i <= res - target; ++i) {
                if (can[target - i]) {
                    return target - i;
                }
            }

            return res;
        }
    }
}