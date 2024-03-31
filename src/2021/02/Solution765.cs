namespace LeetCodeNote
{
    /// <summary>
    /// no: 765
    /// title: 情侣牵手
    /// problems: https://leetcode-cn.com/problems/couples-holding-hands/
    /// date: 20210214
    /// </summary>
    public static partial class Solution765
    {
        public static int MinSwapsCouples(int[] row) {
            int n = row.Length / 2;
            int[] parent = new int[n];
            int[] count = new int[n];
            for(int i = 0; i < n; i++){
                parent[i] = i;
                count[i] = 1;
            }

            int Find(int x) => x == parent[x] ? x : parent[x] = Find(parent[x]);

            void Union(int x, int y){
                int rootX = Find(x);
                int rootY = Find(y);
                if(rootX == rootY)
                    return;
                
                if (count[rootX] > count[rootY]) {
                    parent[rootX] = rootY;
                    count[rootY] += count[rootX];
                } else {
                    parent[rootY] = rootX;
                    count[rootX] += count[rootY];
                }
            }

            for(int i = 0; i < n; i++){
                Union(row[2 * i] / 2, row[2 * i + 1] / 2);
            }
            
            int result = 0;
            for(int i = 0; i < n; i++){
                if(parent[i] == i && count[i] > 1)
                    result += count[i] - 1;
            }

            return result;
        }
    }
}