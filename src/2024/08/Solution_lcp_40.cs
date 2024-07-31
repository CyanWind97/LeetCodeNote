using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote;

/// <summary>
/// no: 40
/// title: 心算挑战
/// problems: https://leetcode.cn/problems/uOAnQW
/// date: 20240801
/// type: lcp
/// </summary>
public static class Solution_lcp_40
{
    public static int MaxmiumScore(int[] cards, int cnt) {
        Array.Sort(cards, (a, b) => b - a);
        var even = new List<int>();
        var oddSum = new List<int>();

        var prev = -1;
        foreach(var card in cards){
            if (card % 2 == 0)
                even.Add(card);
            else if (prev != -1){
                oddSum.Add(prev + card);
                prev = -1;
            }else
                prev = card;
        }

        if ((cnt & 1) == 1 && even.Count == 0)
            return 0;
        
        var dp = new (int Value, int EIndex, int OIndex)[cnt + 1];
        dp[1] = even.Count > 0 ? (even[0], 1, 0) : (0, 0, 0);

        for(int i = 2; i <= cnt; i++){
            var (value0, eIndex0, oIndex0) = dp[i - 2];
            var (value1, eIndex1, oIndex1) = dp[i - 1];
            if (oIndex0 < oddSum.Count)
                value0 += oddSum[oIndex0];
            
            if (eIndex1 < even.Count)
                value1 += even[eIndex1];

            // din't pick any card
            if (value0 == dp[i - 2].Value && value1 == dp[i - 1].Value)
                return 0;
            
            if (value0 > value1)
                dp[i] = (value0, eIndex0, oIndex0 + 1);
            else
                dp[i] = (value1, eIndex1 + 1, oIndex1);
        }

        return dp[cnt].Value;
    }

    // 参考解答
    // 将 cards 从大到小排序后，先贪心的将后 cnt 个数字加起来，若此时 sum 为偶数，直接返回即可。
    // 若此时答案为奇数，有两种方案:
    // 1. 在数组前面找到一个最大的奇数与后 cnt 个数中最小的偶数进行替换；
    // 2. 在数组前面找到一个最大的偶数与后 cnt 个数中最小的奇数进行替换。
    private static int MaxmiumScore_1(int[] cards, int cnt){
        Array.Sort(cards);
        int sum = 0;
        int odd = -1;
        int even = -1;
        for(int i = 1; i <= cnt; i++){
            sum += cards[^i];

            if (cards[^i] % 2 == 0 )
                even = cards[^i];
            else
                odd = cards[^i];
        }

        if (sum % 2 == 0)
            return sum;
        
        var result = 0;
        for(int i = cnt + 1; i <= cards.Length; i++){
            if (cards[^i] % 2 != 0 && even != -1){
                result = Math.Max(result, sum - even + cards[^i]);
                break;
            }
        }

        for(int i = cnt + 1; i <= cards.Length; i++){
            if (cards[^i] % 2 == 0 && odd != -1){
                result = Math.Max(result, sum - odd + cards[^i]);
                break;
            }
        }

        return result;
    }
}
