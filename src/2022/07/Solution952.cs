using System;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 952
    /// title:  按公因数计算最大组件大小
    /// problems: https://leetcode.cn/problems/largest-component-size-by-common-factor/
    /// date: 20220730
    /// </summary>
    public static class Solution952
    {
        // 参考解答 并查集
        public static int LargestComponentSize(int[] nums) {
            int max = nums.Max();
            var parent = Enumerable.Range(0, max + 1).ToArray();
            var rank = new int[max + 1];

            int Find(int x)
                => parent[x] != x ? parent[x] = Find(parent[x]) : parent[x];
            
            void Union(int x, int y){
                int rootX = Find(x);
                int rootY = Find(y);
                if(rootX == rootY)
                    return;

                if(rank[rootX] > rank[rootY]){
                    parent[rootY] = rootX;
                }else if(rank[rootX] < rank[rootY]){
                    parent[rootX] = rootY;
                }else{
                    parent[rootY] = rootX;
                    rank[rootX]++;
                }
            }

            foreach(var num in nums){
                for(int i = 2; i * i <= num; i++){
                    if(num % i == 0){
                        Union(num, i);
                        Union(num, num / i);
                    }
                }
            }

            var counts = new int[max + 1];
            int result = 0;
            foreach(var num in nums){
                int root = Find(num);
                counts[root]++;
                result = Math.Max(result, counts[root]);
            }

            return result;
        }
    }
}