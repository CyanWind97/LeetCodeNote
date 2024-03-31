using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 39
    /// title:  组合总和
    /// problems: https://leetcode.cn/problems/combination-sum/
    /// date: 20220511
    /// priority: 0033
    /// time: 00:28:27.09 timeout
    /// </summary>
    public static class CodeTop39
    {
        // 有问题 没去重
        public static IList<IList<int>> CombinationSum(int[] candidates, int target) {
            var lookup = new Dictionary<int, IList<IList<int>>>();
            int length = candidates.Length;
            var calced = new HashSet<int>();
            Array.Sort(candidates);

            foreach(var num in candidates){
                if(num > target)
                    continue;
                
                lookup[num] = new List<IList<int>>();
                lookup[num].Add(new List<int>(){num});
            }

            void Calc(int value){
                if(!calced.Add(value))
                    return;

                var index = Array.BinarySearch(candidates, value);
                if(index < 0)
                    index = ~index;
                
                if(!lookup.ContainsKey(value))
                    lookup[value] = new List<IList<int>>();

                // 说明没有更小都数了
                if(index == 0)
                    return;
                
                var tmps = new List<IList<int>>();

                for(int i = index - 1; i >= 0; i--){
                    var x = value - candidates[i];
                    Calc(x);

                    foreach(var combination in lookup[x]){
                        if(candidates[i] > combination.Last())
                            continue;

                        var tmp = new List<int>(combination);
                        tmp.Add(candidates[i]);

                        tmps.Add(tmp);
                    }
                }

                foreach(var tmp in tmps){
                    lookup[value].Add(tmp);
                }
            }

            Calc(target);

            return lookup[target];
        }

        
        /// <summary>
        /// 参考解答 回溯
        /// </summary>
        /// <param name="candidates"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static IList<IList<int>> CombinationSum_1(int[] candidates, int target) {
            int length = candidates.Length;
            var result = new List<IList<int>>();
            var combine = new List<int>();

            void DFS(int value, int index){
                if(index == length)
                    return;
                
                if(value == 0){
                    result.Add(new List<int>(combine));
                    return;
                }

                // 跳过
                DFS(value, index + 1);
                // 选择
                if(value - candidates[index] >= 0){
                    combine.Add(candidates[index]);
                    DFS(value - candidates[index], index);
                    combine.RemoveAt(combine.Count - 1);
                }
            }

            DFS(target, 0);

            return result;
        }
    }
}