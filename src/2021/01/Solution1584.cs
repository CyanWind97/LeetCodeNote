using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1584
    /// title: 连接所有点的最小费用
    /// problems: https://leetcode-cn.com/problems/min-cost-to-connect-all-points/
    /// date: 20210119
    /// </summary>
    public static class Solution1584
    {   
        // n^2的Kruskal不太想写
        // 参考解答 太长了
        public static int MinCostConnectPoints(int[][] points) {
            int length = points.Length;
            List<(int Len, int X, int Y)> edges = new List<(int Len, int X, int Y)>();

            #region UnionFind
            int[] f = new int[length];
            int[] rank = new int[length];
            for (int i = 0; i < length; i++) {
                f[i] = i;
                rank[i] = 1;
            }

            int Find(int x) =>  f[x] == x ? x : (f[x] = Find(f[x]));
            bool Union(int x, int y){
                int fx = Find(x), fy = Find(y);
                if (fx == fy) 
                    return false;
                
                if (rank[fx] < rank[fy]) {
                    int temp = fx;
                    fx = fy;
                    fy = temp;
                }
                rank[fx] += rank[fy];
                f[fy] = fx;
                return true;
            }
            #endregion

            #region 
            (int Id, int X, int Y)[] pos = new (int Id, int X, int Y)[length];
            void Build(int n){
                Array.Sort(pos, (a,b) => (a.X == b.X ? a.Y - b.Y : a.X - b.X));
                int[] a = new int[n];
                HashSet<int> set = new HashSet<int>();
                for (int i = 0; i < n; i++) {
                    a[i] = pos[i].Y - pos[i].X;
                    set.Add(pos[i].Y - pos[i].X);
                }
                int num = set.Count;
                int[] b = new int[num];
                int index = 0;
                foreach(int element in set) {
                    b[index++] = element;
                }
                Array.Sort(b);
                BIT bit = new BIT(num + 1);
                for (int i = n - 1; i >= 0; i--) {
                    int poss = BinarySearch(b, a[i]) + 1;
                    int j = bit.query(poss);
                    if (j != -1) {
                        int dis = Math.Abs(pos[i].X - pos[j].X) + Math.Abs(pos[i].Y - pos[j].Y);
                        edges.Add((dis, pos[i].Id, pos[j].Id));
                    }
                    bit.update(poss, pos[i].X + pos[i].Y, i);
                }
            }

            int BinarySearch(int[] array, int target) {
                int low = 0, high = array.Length - 1;
                while (low < high) {
                    int mid = (high - low) / 2 + low;
                    int num = array[mid];
                    if (num < target) {
                        low = mid + 1;
                    } else {
                        high = mid;
                    }
                }
                return low;
            }
            
            for(int i = 0; i < length; i++){
                pos[i] = (i, points[i][0], points[i][1]);
            }
            Build(length);
            for(int i = 0; i < length; i++){
                (pos[i].X, pos[i].Y) = (pos[i].Y, pos[i].X);
            }
            Build(length);
            for (int i = 0; i < length; i++) {
                pos[i].X = -pos[i].X;
            }
            Build(length);
            for (int i = 0; i < length; i++) {
                (pos[i].X, pos[i].Y) = (pos[i].Y, pos[i].X);
            }
            Build(length);
            #endregion

            edges.Sort((a,b) => a.Len - b.Len);
            
            int reuslt = 0, num = 1;
            foreach(var edge in edges) {
                int len = edge.Len, x = edge.X, y = edge.Y;
                if (Union(x, y)) {
                        reuslt += len;
                        num++;
                        if (num == length) {
                            break;
                        }
                    }
            }
            return reuslt;
        }

        class BIT {
            int[] tree;
            int[] idRec;
            int size;

            public BIT(int n) {
                size = n;
                tree = new int[n];
                Array.Fill(tree, int.MaxValue);
                idRec = new int[n];
                Array.Fill(idRec, -1);
            }

            public int lowbit(int k) {
                return k & (-k);
            }

            public void update(int pos, int val, int id) {
                while (pos > 0) {
                    if (tree[pos] > val) {
                        tree[pos] = val;
                        idRec[pos] = id;
                    }
                    pos -= lowbit(pos);
                }
            }

            public int query(int pos) {
                int minval = int.MaxValue;
                int j = -1;
                while (pos < size) {
                    if (minval > tree[pos]) {
                        minval = tree[pos];
                        j = idRec[pos];
                    }
                    pos += lowbit(pos);
                }
                return j;
            }
        }


    }
}