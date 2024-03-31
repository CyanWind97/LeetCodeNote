using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1579
    /// title: 保证图可完全遍历
    /// problems: https://leetcode-cn.com/problems/remove-max-number-of-edges-to-keep-graph-fully-traversable/
    /// date: 20210127
    /// </summary>
    public static class Solution1579
    {
        public static int MaxNumEdgesToRemove(int n, int[][] edges) {
            int delCount = 0;
           
            UnionFind ufA = new UnionFind(n + 1);
            UnionFind ufB = new UnionFind(n + 1);

            foreach(var edge in edges){
                if(edge[0] == 3)
                    if(!ufA.Union(edge[1], edge[2]))
                        delCount++;
                    else
                        ufB.Union(edge[1], edge[2]);
            }

            foreach(var edge in edges){
                if(edge[0] == 1)
                    if(!ufA.Union(edge[1], edge[2]))
                        delCount++;
                
                if(edge[0] == 2)
                    if(!ufB.Union(edge[1], edge[2]))
                        delCount++;
            }

            return ufA.SetCount == 1 && ufB.SetCount == 1
                ? delCount
                : -1;
        }

        public class UnionFind
        {
            private int[] _parent;

            public int SetCount;

            public UnionFind(int size)
            {
                SetCount = size - 1;
                _parent = new int[size];
                for(int i = 1; i < size; i++)
                {
                    _parent[i] = i;
                }
            }


            public int Find(int x) => x == _parent[x] ? x : _parent[x] = Find(_parent[x]);

            public bool Union(int x, int y)
            {
                int rootX = Find(x);
                int rootY = Find(y);

                if(rootX == rootY)
                    return false;
                
                _parent[rootY] = rootX;
                SetCount--;   
                
                return true;
            }
        }
    }
}