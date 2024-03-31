using System.Collections.Generic;
namespace LeetCodeNote
{
    /// <summary>
    /// no: 947
    /// title: 移除最多的同行或同列石头
    /// problems: https://leetcode-cn.com/problems/most-stones-removed-with-same-row-or-column/
    /// date: 20210115
    /// </summary>
    public static class Solution947
    {
        public static int RemoveStones(int[][] stones) {
            int length = stones.Length;
            int[] parent = new int[length];
            Dictionary<int,int> parentX = new Dictionary<int, int>();
            Dictionary<int,int> parentY = new Dictionary<int, int>();
            for(int i = 0; i < length; i++){
                parent[i] = i;
            }

            int find(int x){
                if(x != parent[x]){
                    parent[x] = find(parent[x]);
                }
                return parent[x];
            }

            for(int i = 0; i < length; i++){
                int x = stones[i][0];
                int y = stones[i][1];

                if(!parentX.ContainsKey(x))
                    parentX.Add(x, i);
                
                if(!parentY.ContainsKey(y))
                    parentY.Add(y, i);
                
                int rootX = find(parentX[x]);
                int rootY = find(parentY[y]);

                
                if(rootX != i && rootY != i)
                    parent[i] = rootX;

                if(rootX == rootY)
                    continue;
                
                parent[rootY] = rootX;
            }
            
            int count = length;
            for(int i = 0; i < length; i++){
                if(parent[i] == i)
                    count--;
            }

            return count;
        }

        // 参考解答 根据题目限制增加区分x和y;
        public static int RemoveStones_1(int[][] stones) {
            int length = stones.Length;
            int count = length;
            Dictionary<int,int> parent = new Dictionary<int, int>();

            int find(int x){
                if(x != parent[x]){
                    parent[x] = find(parent[x]);
                }
                return parent[x];
            }

            for(int i = 0; i < length; i++){
                int x = stones[i][0];
                int y = ~stones[i][1];
                
                if(!parent.ContainsKey(x)){
                    parent.Add(x, x);
                    count--;
                }

                if(!parent.ContainsKey(y)){
                    parent.Add(y, y);
                    count--;
                }

                int rootX = find(x);
                int rootY = find(y);

                
                if(rootX == rootY)
                    continue;
                
                parent[rootY] = rootX;
                count++;
            }
            
            return count;
        }
    }
}