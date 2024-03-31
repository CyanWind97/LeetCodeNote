using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 47
    /// title:  全排列 II
    /// problems: https://leetcode.cn/problems/permutations-ii/
    /// date: 20220511
    /// priority: 0035
    /// time: 00:38:01.12 timeout
    public static class CodeTop47
    {
        public static IList<IList<int>> PermuteUnique(int[] nums) {
            int length = nums.Length;
            var infos = nums.GroupBy(x => x)
                        .Select(g => (g.Key, g.Count()))
                        .OrderByDescending(x => x.Item2)
                        .ToList<(int Num, int Count)>();
            

            List<List<int>> GetIndexs(int n, int k){
                if(k ==  1){
                    return Enumerable.Range(0, n)
                              .Select(i => new List<int>(){i})
                              .ToList();
                }

                var indexs = new List<List<int>>();
                var curIndex = new List<int>();

                void DFS(int count, int index){
                    if(count == k){
                        indexs.Add(new List<int>(curIndex));
                        return;
                    }

                    if(index == n || n - index < k - count)
                        return;

                    // 跳过
                    DFS(count, index + 1);
                    // 选择
                    curIndex.Add(index);
                    DFS(count + 1, index + 1);
                    curIndex.RemoveAt(count);
                }

                DFS(0, 0);

                return indexs;
            }

            var result = new List<IList<int>>();
            result.Add(new List<int>());

            foreach(var info in infos){
                var tmps = new List<IList<int>>();
                int n = result[0].Count;
                var insertIndexs = GetIndexs(n + info.Count, info.Count);
                var num = info.Num;
                foreach(var combine in result){
                    foreach(var insertIndex in insertIndexs){
                        var tmp = new List<int>(combine);
                        foreach(var index in insertIndex){
                            tmp.Insert(index, num);
                        }

                        tmps.Add(tmp);       
                    }
                }

                result = tmps;
            }

            return result;
        }

        // 参考解答 交换
        public static IList<IList<int>> PermuteUnique_1(int[] nums) {
            int length = nums.Length;
            var result = new List<IList<int>>();
            var perm = new List<int>();
            var visited = new bool[length];
            Array.Sort(nums);

            void BackTrack(int index){
                if(index == length){
                    result.Add(new List<int>(perm));

                    return;
                }

                for(int i = 0; i < length; i++){
                    if(visited[i] || (i > 0 && nums[i] == nums[i - 1] && !visited[i - 1]))
                        continue;
                    
                    perm.Add(nums[i]);
                    visited[i] = true;
                    BackTrack(index + 1);
                    visited[i] = false;
                    perm.RemoveAt(index);
                }
            }

            return result;
        }
    }
}