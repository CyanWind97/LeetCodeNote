namespace LeetCodeNote
{
    /// <summary>
    /// no: 1319
    /// title: 连通网络的操作次数
    /// problems: https://leetcode-cn.com/problems/number-of-operations-to-make-network-connected/
    /// date: 20210123
    /// </summary>
    public static class Solution1319
    {
        public static int MakeConnected(int n, int[][] connections) {
            if (connections.Length < n - 1)
                return -1;

            int[] parent = new int[n];
            int setCount = n;

            int Find(int x) => x == parent[x] ? x : parent[x] = Find(parent[x]);

            for(int i = 0; i < n; i++){
                parent[i] = i;
            }

            foreach(var pair in connections){
                int rootX = Find(pair[0]);
                int rootY = Find(pair[1]);

                if(rootX == rootY)
                    continue;
                

                parent[rootY] = rootX;
                setCount--;
            }

            return  setCount - 1;
        }
    }
}