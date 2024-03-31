using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2127
    /// title: 参加会议的最多员工数
    /// problems: https://leetcode.cn/problems/maximum-employees-to-be-invited-to-a-meeting/?envType=daily-question&envId=2023-11-01
    /// date: 20231101
    /// </summary>
    public static class Solution2127
    {
        // 参考解答 
        // 拓扑排序 + 分类讨论
        public static int MaximumInvitations(int[] favorite) {
            int n = favorite.Length;
            // 统计入度，便于进行拓扑排序
            int[] indeg = new int[n];
            for (int i = 0; i < n; ++i) {
                ++indeg[favorite[i]];
            }
            bool[] used = new bool[n];
            int[] f = new int[n];
            Array.Fill(f, 1);
            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < n; ++i) {
                if (indeg[i] == 0) {
                    queue.Enqueue(i);
                }
            }
            while (queue.Count > 0) {
                int u = queue.Dequeue();
                used[u] = true;
                int v = favorite[u];
                // 状态转移
                f[v] = Math.Max(f[v], f[u] + 1);
                --indeg[v];
                if (indeg[v] == 0) {
                    queue.Enqueue(v);
                }
            }
            // ring 表示最大的环的大小
            // total 表示所有环大小为 2 的「基环内向树」上的最长的「双向游走」路径之和
            int ring = 0, total = 0;
            for (int i = 0; i < n; ++i) {
                if (!used[i]) {
                    int j = favorite[i];
                    // favorite[favorite[i]] = i 说明环的大小为 2
                    if (favorite[j] == i) {
                        total += f[i] + f[j];
                        used[i] = used[j] = true;
                    }
                    // 否则环的大小至少为 3，我们需要找出环
                    else {
                        int u = i, cnt = 0;
                        while (true) {
                            ++cnt;
                            u = favorite[u];
                            used[u] = true;
                            if (u == i) {
                                break;
                            }
                        }
                        ring = Math.Max(ring, cnt);
                    }
                }
            }
            return Math.Max(ring, total);
        }
    }
}