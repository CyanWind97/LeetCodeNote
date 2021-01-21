using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1489
    /// title: 找到最小生成树里的关键边和伪关键边
    /// problems: https://leetcode-cn.com/problems/find-critical-and-pseudo-critical-edges-in-minimum-spanning-tree/
    /// date: 20210121
    /// </summary>
    public static class Solution1489
    {
        public static IList<IList<int>> FindCriticalAndPseudoCriticalEdges(int n, int[][] edges) {
            int length = edges.Length;
            var newEdges = edges.Select((item, index) => (X: item[0], Y: item[1], V: item[2], Index: index))
                            .OrderBy(item => item.V)
                            .ToArray();
            
            UnionFind unionFind = new UnionFind(n);
            int minValue = 0;

            for(int i = 0; i < length; i++){
                if(unionFind.Union(newEdges[i].X, newEdges[i].Y))
                    minValue += newEdges[i].V;
            }

            IList<IList<int>> result = new List<IList<int>>();
            for(int i = 0; i < 2; i++){
                result.Add(new List<int>());
            }

            for(int i = 0; i < length; i++){
                UnionFind uf = new UnionFind(n);
                int value = 0;
                for(int j = 0; j < length; j++){
                    if(i != j && uf.Union(newEdges[j].X, newEdges[j].Y))
                        value += newEdges[j].V;
                }

                if(uf.SetCount != 1 || (uf.SetCount == 1 && value > minValue)){
                    result[0].Add(newEdges[i].Index);
                    continue;
                }

                uf = new UnionFind(n);
                uf.Union(newEdges[i].X, newEdges[i].Y);
                value = newEdges[i].V;
                for (int j = 0; j < length; ++j) {
                    if (i != j && uf.Union(newEdges[j].X, newEdges[j].Y)) {
                        value += newEdges[j].V;
                    }
                }
                if (value == minValue)
                    result[1].Add(newEdges[i].Index);
                
            }

            return result;
        }

        public class UnionFind{
            int[] parent;
            public int SetCount;

            public UnionFind(int n){
                SetCount = n;
                parent = new int[n];
                for(int i = 0; i < n; i++){
                    parent[i] = i;
                }
            }

            public int Find(int x) => x == parent[x] ? x : parent[x] = Find(parent[x]);

            public bool Union(int x, int y){
                int rootX = Find(x);
                int rootY = Find(y);

                if(rootX == rootY)
                    return false;
                
                parent[rootY] = rootX;
                SetCount--;

                return true;
            }
        }

        // 参考解答 连通性 + 最小生成树性质
        public static IList<IList<int>> FindCriticalAndPseudoCriticalEdges_1(int n, int[][] edges) {
            int length = edges.Length;
            var newEdges = edges.Select((item, index) => (X: item[0], Y: item[1], V: item[2], Index: index))
                            .OrderBy(item => item.V)
                            .ToArray();
            
            UnionFind unionFind = new UnionFind(n);
            int minValue = 0;

            for(int i = 0; i < length; i++){
                if(unionFind.Union(newEdges[i].X, newEdges[i].Y))
                    minValue += newEdges[i].V;
            }

            IList<IList<int>> result = new List<IList<int>>();
            for(int i = 0; i < 2; i++){
                result.Add(new List<int>());
            }

            for(int i = 0; i < length; i++){
                UnionFind uf = new UnionFind(n);
                int value = 0;
                for(int j = 0; j < length; j++){
                    if(i != j && uf.Union(newEdges[j].X, newEdges[j].Y))
                        value += newEdges[j].V;
                }

                if(uf.SetCount != 1 || (uf.SetCount == 1 && value > minValue)){
                    result[0].Add(newEdges[i].Index);
                    continue;
                }

                uf = new UnionFind(n);
                uf.Union(newEdges[i].X, newEdges[i].Y);
                value = newEdges[i].V;
                for (int j = 0; j < length; ++j) {
                    if (i != j && uf.Union(newEdges[j].X, newEdges[j].Y)) {
                        value += newEdges[j].V;
                    }
                }
                if (value == minValue)
                    result[1].Add(newEdges[i].Index);
                
            }

            return result;
        }
    }
}