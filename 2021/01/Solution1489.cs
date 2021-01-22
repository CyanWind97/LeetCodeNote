using System;
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

        #region  Tarjan算法 桥边 连通性  最小生成树性质

        // 参考解答 连通性 + 最小生成树性质
        public static IList<IList<int>> FindCriticalAndPseudoCriticalEdges_1(int n, int[][] edges) {
            int length = edges.Length;
            var newEdges = edges.Select((item, index) => (X: item[0], Y: item[1], V: item[2], Index: index))
                            .OrderBy(item => item.V)
                            .ToArray();
            
            UnionFind unionFind = new UnionFind(n);
            IList<IList<int>> result = new List<IList<int>>();
            for(int i = 0; i < 2; i++){
                result.Add(new List<int>());
            }

            int[] label = new int[length];
            int index = 0;
            while(index < length){
                int v = newEdges[index].V;
                int j = index;

                while(j < length && newEdges[j].V == v)
                    j++;
                
                Dictionary<int, int> compToId = new Dictionary<int, int>();
                int gn = 0;

                for(int k = index; k < j; k++){
                    int x = newEdges[k].X;
                    int y = newEdges[k].Y;
                    if(x != y){
                        if(!compToId.ContainsKey(x))
                            compToId[x] = gn++;
                        
                        if(!compToId.ContainsKey(y))
                            compToId[y] = gn++;
                    }else
                        label[newEdges[k].Index] = -1;
                }

                List<int>[] gm = new List<int>[gn];
                List<int>[] gmid = new List<int>[gn];
                for(int k = 0; k < gn; k++){
                    gm[k] = new List<int>();
                    gmid[k] = new List<int>();
                }

                for(int k = index; k < j; k++){
                    int x = newEdges[k].X;
                    int y = newEdges[k].Y;
                    if(x == y) 
                        continue;
                    
                    int idX = compToId[x];
                    int idY = compToId[y];
                    gm[idX].Add(idY);
                    gmid[idX].Add(newEdges[k].Index);
                    gm[idY].Add(idX);
                    gmid[idY].Add(newEdges[k].Index);
                }

                List<int> bridges = new TarjanSCC(gn, gm, gmid).CuttingEdge;
                foreach(int id in bridges){
                    result[0].Add(id);
                    label[id] = 1;
                }

                for(int k = index; k < j; k++){
                    unionFind.Union(newEdges[k].X, newEdges[k].Y);
                }

                index = j;
            }

            for(int i = 0; i < length; i++){
                if(label[i] == 0)
                    result[i].Add(i);
            }

            return result;
        }


        public class TarjanSCC {
            List<int>[] edges;
            List<int>[] edgesId;
            int[] low;
            int[] dfn;

            List<int> ans;
            int n;
            int ts;

            public TarjanSCC(int n, List<int>[] edges, List<int>[] edgesId) {
                this.edges = edges;
                this.edgesId = edgesId;
                this.low = new int[n];
                Array.Fill(low, -1);
                this.dfn = new int[n];
                Array.Fill(dfn, -1);
                this.n = n;
                this.ts = -1;
                this.ans = new List<int>();
            }

            public List<int> CuttingEdge{
                get {
                    for(int i = 0; i < n; i++){
                        if(dfn[i] == -1)
                            DoCuttingEdge(i, -1);
                    }

                    return ans;
                }
            }

            private void DoCuttingEdge(int u, int parentEdgeId){
                low[u] = dfn[u] = ++ts;
                int length = edges[u].Count();
                for(int i = 0; i < length; i++){
                    int v = edges[u][i];
                    int id = edgesId[u][i];
                    if(dfn[v] == -1){
                        DoCuttingEdge(v, id);
                        if(low[v] < low[u])
                            low[u] = low[v];

                        if(low[v] > dfn[u])
                            ans.Add(id);
                    }else if(id != parentEdgeId)
                        if(dfn[v] < low[v])
                            low[u] = dfn[v];
                }
            }
        }
        #endregion
    }
}