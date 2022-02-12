namespace LeetCodeNote
{
    /// <summary>
    /// no: 1020
    /// title: 飞地的数量
    /// problems: https://leetcode-cn.com/problems/number-of-enclaves/
    /// date: 20220212
    /// </summary>
    public static class Solution1020
    {
        // 参考解答 DFS
        public static int NumEnclaves(int[][] grid) {
            int[][] dirs = {new int[]{-1, 0}, new int[]{1, 0}, new int[]{0, -1}, new int[]{0, 1}};
            var m = grid.Length;
            var n = grid[0].Length;
            var visited = new bool[m][];

            void DFS(int[][] grid, int row, int col) {
                if (row < 0 || row >= m || col < 0 || col >= n || grid[row][col] == 0 || visited[row][col]) {
                    return;
                }
                visited[row][col] = true;
                foreach (int[] dir in dirs) {
                    DFS(grid, row + dir[0], col + dir[1]);
                }
            }

            for (int i = 0; i < m; i++) {
                visited[i] = new bool[n];
            }
            for (int i = 0; i < m; i++) {
                DFS(grid, i, 0);
                DFS(grid, i, n - 1);
            }
            for (int j = 1; j < n - 1; j++) {
                DFS(grid, 0, j);
                DFS(grid, m - 1, j);
            }
            int enclaves = 0;
            for (int i = 1; i < m - 1; i++) {
                for (int j = 1; j < n - 1; j++) {
                    if (grid[i][j] == 1 && !visited[i][j]) {
                        enclaves++;
                    }
                }
            }
            return enclaves;
        }
    }
}