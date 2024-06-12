using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2813
/// title: 子序列最大优雅度
/// problems: https://leetcode.cn/problems/maximum-elegance-of-a-k-length-subsequence
/// date: 20240613
/// </summary>
public static class Solution2813
{
    // 参考解答
    // 贪心
    public static long FindMaximumElegance_1(int[][] items, int k){
        var candidates = items
            .Select(item => (Profit: item[0], Category: item[1]))
            .OrderByDescending(item => item.Profit)
            .ToArray();
        
        var categorySet = new HashSet<int>();
        var profitSum = 0L;
        var result = 0L;

        var stack = new Stack<int>();

        for (int i = 0; i < candidates.Length; i++){
            var (profit, category) = candidates[i];
            if (i < k){
                profitSum += profit;
                if (!categorySet.Add(category))
                    stack.Push(profit);
            }else if (stack.Count > 0 &&  categorySet.Add(category)){
                profitSum += profit - stack.Pop();
            }

            result = Math.Max(result, profitSum + (long)categorySet.Count * categorySet.Count);
        }

        return result;
    }

    // 失败例子：[[12,8],[38,6],[7,14],[39,7],[8,9],[28,2],[12,11],[48,13],[5,12],[41,3],[33,9],[42,3],[9,3],[27,2],[12,4],[27,3]];
    // 倒数2个数的比较，5 - 27 -> 11 -> 10
    public static long FindMaximumElegance(int[][] items, int k) {
        int n = items.Length;
        var candidates = Enumerable.Range(0, n)
                            .Select(_ => new PriorityQueue<int, int>())
                            .ToArray();
        var distinctQueue = new PriorityQueue<int, int>();
        var existQueue = new PriorityQueue<int, int>();

        foreach (var item in items) {
            (int profit, int category) = (item[0], item[1] - 1);
            candidates[category].Enqueue(profit, -profit);
        }

        int upperCategory = 0;
        for(int c = 0; c < n; c++){
            if (candidates[c].Count == 0)
                continue;
            
            var profit = candidates[c].Dequeue();
            distinctQueue.Enqueue(c, -profit);
            upperCategory++;
        }

        upperCategory = Math.Min(upperCategory, k);
        var result = 0L;
        var distinctCategory = 0;

        for(int i = k; i > 0; i--){
            var useDistinct = distinctQueue.TryPeek(out var category, out var profit);
            var useExist = existQueue.TryPeek(out var existCategory, out var existProfit);
            var isEffectUpper = distinctCategory + i <= upperCategory;
            var diff = isEffectUpper
                    ? 2 * upperCategory - 1
                    : 0; // 计算差值
            
            if (!useDistinct || (useExist && -profit < -existProfit - diff)){
                result += -existProfit;
                existQueue.Dequeue();

                if (candidates[existCategory].Count > 0){
                    var newProfit = candidates[existCategory].Dequeue();
                    existQueue.Enqueue(existCategory, -newProfit);
                }

                if (isEffectUpper)
                    upperCategory--;
            }else{
                result += -profit;
                distinctQueue.Dequeue();

                if (candidates[category].Count > 0){
                    var newProfit = candidates[category].Dequeue();
                    existQueue.Enqueue(category, -newProfit);
                }

                distinctCategory++;
            }
        }

        result += distinctCategory * distinctCategory;

        return result;
    }
}
