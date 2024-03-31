using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2003
    /// title: 每棵子树内缺失的最小基因值
    /// problems: https://leetcode.cn/problems/smallest-missing-genetic-value-in-each-subtree/?envType=daily-question&envId=2023-10-31
    /// date: 20231031
    /// </summary>
    public static class Solution2003
    {
        // 参考解答
        // DFS + 启发式搜索
        public static int[] SmallestMissingValueSubtree(int[] parents, int[] nums) {
            int length = parents.Length;
            var children = Enumerable.Range(0, length)
                            .Select(i => new List<int>())
                            .ToArray();

            for(int i = 1; i < length; i++){
                children[parents[i]].Add(i);
            }
            
            int[] result = new int[length];
            Array.Fill(result, 1);
            var geneSet = Enumerable.Range(1, length)
                            .Select(i => new HashSet<int>())
                            .ToArray();

            int DFS(int node){
                geneSet[node].Add(nums[node]);
                foreach(var child in children[node]){

                    result[node] = Math.Max(result[node], DFS(child));
                    
                    if (geneSet[node].Count < geneSet[child].Count)
                        (geneSet[node], geneSet[child]) = (geneSet[child], geneSet[node]);
                    

                    foreach(int val in geneSet[child]){
                        geneSet[node].Add(val);
                    }
                }

                while(geneSet[node].Contains(result[node]))
                    result[node]++;
                
                return result[node];
            }

            DFS(0);

            return result;
        }
    }
}