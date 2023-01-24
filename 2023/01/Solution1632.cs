using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1632
    /// title: 矩阵转换后的秩
    /// problems: https://leetcode.cn/problems/rank-transform-of-a-matrix/
    /// date: 20230125
    /// </summary>
    public static class Solution1632
    {
        // 参考解答
        // 并查集 + 拓扑排序
        public static int[][] MatrixRankTransform(int[][] matrix) {
            var m = matrix.Length;
            int n = matrix[0].Length;
            
            #region 并查集
            var parent = Enumerable.Range(0, m * n).ToArray();
            var size = Enumerable.Range(0, m * n).Select(i => 1).ToArray();

            int Find(int x)
                => parent[x] = parent[x] == x ? x : Find(parent[x]);
            
            void Union(int x, int y){
                int rootX = Find(x);
                int rootY = Find(y);

                if(rootX == rootY)
                    return;
                
                if(size[rootX] >= size[rootY]){
                    parent[rootY] = rootX;
                    size[rootX] += size[rootY];
                }else{
                    parent[rootX] = rootY;
                    size[rootY] += size[rootX];
                }
            }
            #endregion

            #region 构建并查集
            
            var rows = Enumerable.Range(0, m).Select(i => new Dictionary<int, List<int>>()).ToArray();
            var cols = Enumerable.Range(0, n).Select(i => new Dictionary<int, List<int>>()).ToArray();
            for(int i = 0; i < m; i++){
                for(int j = 0; j < n; j++){
                    int num = matrix[i][j];
                    int index = n * i + j;
                    rows[i].TryAdd(num, new List<int>());
                    rows[i][num].Add(index);
                    cols[j].TryAdd(num, new List<int>());
                    cols[j][num].Add(index);
                }

            }

            var indexsSet = rows.SelectMany(row => row.Values.Where(list => list.Count  > 1))
                                .Union(cols.SelectMany(col => col.Values.Where(list => list.Count > 1)));
            
            foreach(var indexs in indexsSet){
                var first = indexs.First();
                foreach(var index in indexs){
                    Union(first, index);
                }
            }

            #endregion
            

            #region 计算度
            var degree = new int[m * n];
            var adjs = new Dictionary<int, List<int>>();
            void AddAdj(SortedDictionary<int,int> sorted){
                int prev = Find(sorted.First().Value);
                foreach(var pair in sorted){
                    int curr = Find(pair.Value);
                    if(curr == prev)
                        continue;

                    degree[curr]++;
                    adjs.TryAdd(prev, new List<int>());
                    adjs[prev].Add(curr);
                    prev = curr;
                }
            }

            for(int i = 0; i < m; i++){
                var sorted = new SortedDictionary<int, int>();
                for(int j = 0; j < n; j++){
                    if(!sorted.ContainsKey(matrix[i][j]))
                        sorted.Add(matrix[i][j], n * i + j);
                }

                AddAdj(sorted);
            }

            for(int j = 0; j < n; j++){
                var sorted = new SortedDictionary<int, int>();
                for(int i = 0; i < m; i++){
                    if(!sorted.ContainsKey(matrix[i][j]))
                        sorted.Add(matrix[i][j], n * i + j);
                }

                AddAdj(sorted);
            }
            #endregion

            #region 拓扑排序
            var ranks = new int[m * n];
            Array.Fill(ranks, 1);
            
            
            var rootSet = Enumerable.Range(0, m * n)
                                .Select(index => Find(index))
                                .Distinct()
                                .Where(index => degree[index] == 0);
            var queue = new Queue<int>(rootSet);

            while(queue.Count > 0){
                int index = queue.Dequeue();

                if(!adjs.ContainsKey(index))
                    continue;
                
                foreach(var adj in adjs[index]){
                    degree[adj]--;
                    if(degree[adj] == 0)
                        queue.Enqueue(adj);
                    
                    ranks[adj] = Math.Max(ranks[adj], ranks[index] + 1);
                }
            }
            #endregion
            
            var answer = new int[m][];
            for(int i = 0; i < m; i++){
                answer[i] = new int[n];
                for(int j = 0; j < n; j++){
                    int root = Find(i * n + j);
                    answer[i][j] = ranks[root];
                }
            }

            return answer;
        }
    }
}