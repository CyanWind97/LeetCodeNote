namespace LeetCodeNote
{
    /// <summary>
    /// no: 2054
    /// title: 到达目的地的第二短时间
    /// problems: https://leetcode-cn.com/problems/second-minimum-time-to-reach-destination/
    /// date: 20220124
    /// </summary>
    public static class Solution2054
    {
        public static int SecondMinimum(int n, int[][] edges, int time, int change) {
            IList<int>[] graph = new IList<int>[n + 1];
            for (int i = 0; i <= n; i++) {
                graph[i] = new List<int>();
            }
            foreach (int[] edge in edges) {
                graph[edge[0]].Add(edge[1]);
                graph[edge[1]].Add(edge[0]);
            }

            // path[i][0] 表示从 1 到 i 的最短路长度，path[i][1] 表示从 1 到 i 的严格次短路长度
            int[,] path = new int[n + 1, 2];
            for (int i = 0; i <= n; i++) {
                for (int j = 0; j < 2; j++) {
                    path[i, j] = int.MaxValue;
                }
            }
            path[1, 0] = 0;
            Queue<int[]> queue = new Queue<int[]>();
            queue.Enqueue(new int[]{1, 0});
            while (path[n, 1] == int.MaxValue) {
                int[] arr = queue.Dequeue();
                int cur = arr[0], len = arr[1];
                foreach (int next in graph[cur]) {
                    if (len + 1 < path[next, 0]) {
                        path[next, 0] = len + 1;
                        queue.Enqueue(new int[]{next, len + 1});
                    } else if (len + 1 > path[next, 0] && len + 1 < path[next, 1]) {
                        path[next, 1] = len + 1;
                        queue.Enqueue(new int[]{next, len + 1});
                    }
                }
            }

            int ret = 0;
            for (int i = 0; i < path[n, 1]; i++) {
                if (ret % (2 * change) >= change) {
                    ret = ret + (2 * change - ret % (2 * change));
                }
                ret = ret + time;
            }
            return ret;
        }

    }
}