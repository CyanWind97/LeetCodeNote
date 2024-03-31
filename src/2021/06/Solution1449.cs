using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1449
    /// title: 数位成本和为目标值的最大数字
    /// problems: https://leetcode-cn.com/problems/form-largest-integer-with-digits-that-add-up-to-target/
    /// date: 20210612
    /// </summary>
    public static class Solution1449
    {
        public static string LargestNumber(int[] cost, int target) {
            int length = cost.Length;
            Dictionary<int,int>  costMax = new Dictionary<int, int>();
            var desc = Comparer<int>.Create((a,b) => b.CompareTo(a));

            bool IsBig(List<int> list, List<int> target){
                int count = list.Count;
                for(int i = 0; i < count; i++){
                    if(list[i] == target[i])
                        continue;
                    
                    return list[i] > target[i];
                }

                return true;
            }

            int BinarySearch(List<int> list, int start, int end, int val){
                while (start < end) {
                    int mid = start + (end - start) / 2;
                    int num = list[mid];
                    if (num >= val) {
                        start = mid + 1;
                    } else {
                        end = mid;
                    }
                }
                return start;   
            }

            void Add(List<int> list, int num){
                int index = BinarySearch(list, 0, list.Count, num);
                list.Insert(index, num);
            }

            for(int i = 0; i < length; i++){
                if(cost[i] > target)
                    continue;
                
                if(costMax.ContainsKey(cost[i]))
                    costMax[cost[i]] = i + 1;
                else
                    costMax.Add(cost[i], i + 1);
            }

            var dp = new List<int>[target + 1];
            
            for(int i = 1; i <= target; i++){
                dp[i] = new List<int>();
            }

            foreach(var pair in costMax){
                int m = pair.Key;
                int num = pair.Value;
                
                if(dp[m].Count == 0){
                    dp[m].Add(num);
                }

                for(int i = m + 1; i <= target; i++){
                    if(dp[i - m].Count == 0 || dp[i].Count > dp[i - m].Count + 1)
                        continue;

                    List<int> newList = new List<int>(dp[i - m]);
                    Add(newList, num);

                    if(dp[i].Count == dp[i - m].Count + 1  && IsBig(dp[i], newList))
                        continue;

                    dp[i] = newList;
                }
            }

            if(dp[target].Count == 0)
                return "0";

            return string.Join("", dp[target]);
        }
    
        // 参考解答
        public static string LargestNumber_1(int[] cost, int target) {
            int[] dp = new int[target + 1];
            Array.Fill(dp, int.MinValue);
            dp[0] = 0;
            foreach (int c in cost) {
                for (int j = c; j <= target; ++j) {
                    dp[j] = Math.Max(dp[j], dp[j - c] + 1);
                }
            }

            if (dp[target] < 0)
                return "0";
            
            StringBuilder sb = new StringBuilder();
            for (int i = 8, j = target; i >= 0; i--) {
                for (int c = cost[i]; j >= c && dp[j] == dp[j - c] + 1; j -= c) {
                    sb.Append(i + 1);
                }
            }
            return sb.ToString();
        }
    }
}