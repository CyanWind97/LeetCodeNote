using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 40
    /// title:  组合总和 II
    /// problems: https://leetcode.cn/problems/combination-sum-ii/
    /// date: 20220518
    /// priority: 0083
    /// time: 00:15:21.13 timeout
    /// </summary>
    public static class CodeTop118
    {
        // 参考解答 记录频率 用于回溯去重
        public static IList<IList<int>> CombinationSum2(int[] candidates, int target) {
            Array.Sort(candidates);

            var freq = candidates.GroupBy(x => x).ToDictionary(g => g.Key, g => g.Count());
            int length = freq.Count;
            var keys = freq.Keys.ToList();
            int sum = 0;
            var result = new List<IList<int>>();
            var combine = new List<int>();

            void DFS(int index){
                if(sum == target){
                    result.Add(new List<int>(combine));
                    return;
                }

                if(index == length)
                    return;

                int num = keys[index];
                if(sum + num > target)
                    return;
            
                DFS(index + 1);

                int most = Math.Min((target - sum) / num, freq[num]);
                for(int i = 1; i <= most; i++){
                    combine.Add(keys[index]);
                    sum += num;
                    DFS(index + 1);
                }

                for(int i = 1; i <= most; i++){
                    sum -= num;
                    combine.RemoveAt(combine.Count - 1);
                }

            }

            DFS(0);

            return result;
        }
    }
}