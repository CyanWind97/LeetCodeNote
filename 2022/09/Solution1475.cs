using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1475
    /// title: 商品折扣后的最终价格
    /// problems: https://leetcode.cn/problems/final-prices-with-a-special-discount-in-a-shop/
    /// date: 20220901
    /// </summary>
    public class Solution1475
    {
        public static int[] FinalPrices(int[] prices) {
            int length = prices.Length;
            var result = new int[length];
            var stack = new Stack<int>();
            for (int i = length - 1; i >= 0; i--) {
                while (stack.Count > 0 && stack.Peek() > prices[i]) {
                    stack.Pop();
                }

                result[i] = stack.Count == 0 ? prices[i] : prices[i] - stack.Peek();
                stack.Push(prices[i]);
            }
            
            return result;
        }
    }
}