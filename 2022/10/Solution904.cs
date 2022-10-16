using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 904
    /// title: 水果成篮
    /// problems: https://leetcode.cn/problems/fruit-into-baskets/
    /// date: 20221017
    /// </summary>
    public static class Solution904
    {
        public static int TotalFruit(int[] fruits) {
            var result = 0;
            int a = -1, b = -1;
            int prev = 0;
            int start = 0;

            int length = fruits.Length;
            a = fruits[0];

            for(int i = 1; i < length; i++){
                if(fruits[i] == a || fruits[i] == b){
                    if(fruits[i] != fruits[i - 1])
                        prev = i;
                }else{
                    result = Math.Max(i - start, result);
                    start = prev;
                    prev = i;
                    if(fruits[i - 1] == a)
                        b = fruits[i];
                    else
                        a = fruits[i];
                }
            }

            result = Math.Max(length - start, result);
            return result;
        }

        // 参考解答
        public static int TotalFruit_1(int[] fruits) {
            int n = fruits.Length;
            IDictionary<int, int> cnt = new Dictionary<int, int>();

            int left = 0, ans = 0;
            for (int right = 0; right < n; ++right) {
                cnt.TryAdd(fruits[right], 0);
                ++cnt[fruits[right]];
                while (cnt.Count > 2) {
                    --cnt[fruits[left]];
                    if (cnt[fruits[left]] == 0) {
                        cnt.Remove(fruits[left]);
                    }
                    ++left;
                }
                ans = Math.Max(ans, right - left + 1);
            }
            return ans;
        }

    }
}