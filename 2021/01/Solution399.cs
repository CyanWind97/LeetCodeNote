using System.Collections;
using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 399
    /// title: 除法求值
    /// problems: https://leetcode-cn.com/problems/evaluate-division/
    /// date: 20210106
    /// </summary>
    public static class Solution399
    {
        public static double[] CalcEquation(IList<IList<string>> equations, double[] values, IList<IList<string>> queries) {
            int eLength = values.Length;
            Dictionary<string, int> map = new Dictionary<string, int>();
            int count = 0;
            foreach(var pair in equations){
                if(map.TryAdd(pair[0], count))
                    count++;

                if(map.TryAdd(pair[1], count))
                    count++;
            }
            
            double[,] ans = new double[count, count];

            for(int i = 0; i < count; i++){
                for(int j = 0; j < count; j++){
                    ans[i, j] = i == j ? 1 : -1;
                }
            }
            
            for(int k = 0; k < eLength; k++){
                int i = map[equations[k][0]];
                int j = map[equations[k][1]];
                ans[i, j] = values[k];
                ans[j, i] = 1 / values[k];
                
                Queue<(int x, int y)> queue = new Queue<(int x, int y)>();
                queue.Enqueue((i,j));
                
                while(queue.Count > 0){
                    var pair = queue.Dequeue();
                    var value = ans[pair.x, pair.y];
                    for(int l = 0; l < count; l++){
                        if(l == i || l == pair.y)
                            continue;
                        
                        if(ans[pair.x, l] != -1 && ans[l, pair.y] == -1){
                            ans[l, pair.y] = value / ans[pair.x, l];
                            ans[pair.y, l] = 1 / ans[l,pair.y];
                            queue.Enqueue((l, pair.y));
                        }else if(ans[pair.x,l] == -1 && ans[l, pair.y] != -1){
                            ans[pair.x, l] = value / ans[l ,pair.y];
                            ans[l, pair.x] = 1 / ans[pair.x, l];
                            queue.Enqueue((pair.x, l));
                        }
                    }
                }
            }

            int qLength = queries.Count;
            double[] result = new double[qLength];
            
            for(int k = 0; k < qLength; k++){
                result[k] = (map.TryGetValue(queries[k][0], out int i)
                            && map.TryGetValue(queries[k][1], out int j))
                            ? ans[i,j]
                            : -1;
            }


            return result;
        }

        // 优化 Floyd算法
        public static double[] CalcEquation_1(IList<IList<string>> equations, double[] values, IList<IList<string>> queries) {
            int eLength = values.Length;
            Dictionary<string, int> map = new Dictionary<string, int>();
            int count = 0;
            foreach(var pair in equations){
                if(map.TryAdd(pair[0], count))
                    count++;

                if(map.TryAdd(pair[1], count))
                    count++;
            }
            
            double[,] ans = new double[count, count];

            for(int i = 0; i < count; i++){
                for(int j = 0; j < count; j++){
                    ans[i, j] = i == j ? 1 : -1;
                }
            }
            
            for(int k = 0; k < eLength; k++){
                int i = map[equations[k][0]];
                int j = map[equations[k][1]];
                ans[i, j] = values[k];
                ans[j, i] = 1 / values[k];
            }

            for(int k = 0; k < count; k++){
                for(int i = 0; i < count; i++){
                    for(int j = 0; j < count; j++){
                        if(i != j && ans[i,j] == -1 
                          && ans[i, k] != -1 && ans[k, j] != -1)
                          ans[i, j] = ans[i, k] * ans[k, j];
                    }
                }
            }

            int qLength = queries.Count;
            double[] result = new double[qLength];
            
            for(int k = 0; k < qLength; k++){
                result[k] = (map.TryGetValue(queries[k][0], out int i)
                            && map.TryGetValue(queries[k][1], out int j))
                            ? ans[i,j]
                            : -1;
            }


            return result;
        }

        // 官方解答 查并集
        public static double[] CalcEquation_2(IList<IList<string>> equations, double[] values, IList<IList<string>> queries) {
            int eLength = values.Length;
            Dictionary<string, int> map = new Dictionary<string, int>();
            int size = 0;
            foreach(var pair in equations){
                if(map.TryAdd(pair[0], size))
                    size++;

                if(map.TryAdd(pair[1], size))
                    size++;
            }
            
            int[] parent = new int[size];
            double[] weight = new double[size];
            for(int i = 0; i < size; i++){
                parent[i] = i;
                weight[i] = 1;
            }
            
            int root(int x){
                if(x != parent[x]){
                    int origin = parent[x];
                    parent[x] = root(parent[x]);
                    weight[x] *= weight[origin];
                }
                
                return parent[x];
            }


            for(int k = 0; k < eLength; k++){
                int i = map[equations[k][0]];
                int j = map[equations[k][1]];

                int rootI = root(i);
                int rootJ = root(j);

                if(rootI == rootJ)
                    continue;

                parent[rootI] = rootJ;
                weight[rootI] = weight[j] * values[k] / weight[i];
            }

            
            int qLength = queries.Count;
            double[] result = new double[qLength];
            for(int k = 0; k < qLength; k++){
                result[k] = (map.TryGetValue(queries[k][0], out int i)
                            && map.TryGetValue(queries[k][1], out int j))
                            ? root(i) == root(j)
                                ? weight[i] / weight[j] 
                                : -1
                            : -1;
            }

            return result;
        }

        public class UnionFind {
            int[] parent;

            double[] weight;

            public UnionFind(int size){
                parent = new int[size];
                weight = new double[size];
                for(int i = 0; i < size; i++){
                    parent[i] = i;
                    weight[i] = 1;
                }
            
            }
            public int Find(int x){
                if(x != parent[x]){
                    int origin = parent[x];
                    parent[x] = Find(parent[x]);
                    weight[x] *= weight[origin];
                }
                
                return parent[x];
            }
            public void Union(int x, int y, double value){
                int rootX = Find(x);
                int rootY = Find(y);

                if(rootX == rootY)
                    return; 

                parent[rootX] = rootY;
                weight[rootX] = weight[y] * value / weight[x];
            }

            public double Get(int x, int y){
                int rootX = Find(x);
                int rootY = Find(y);
                
                return rootX == rootY ? weight[x]/weight[y] : -1;
            }
        }        
    }
}