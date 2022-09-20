using System.Collections.Generic;

namespace LeetCodeNote
{
    // <summary>
    /// no: 854
    /// title: 相似度为 K 的字符串
    /// problems: https://leetcode.cn/problems/k-similar-strings/
    /// date: 20220921
    /// </summary>
    public static class Solution854
    {
        // 参考解答 
        // 广度优先搜索
        public static int KSimilarity(string s1, string s2) {
            string Swap(string cur, int i, int j) {
                char[] arr = cur.ToCharArray();
                char c = arr[i];
                arr[i] = arr[j];
                arr[j] = c;
                return new string(arr);
            }

            int n = s1.Length;
            var queue = new Queue<(string S, int Pos)>();
            var visit = new HashSet<string>();
            queue.Enqueue((s1, 0));
            visit.Add(s1);
            int step = 0;
            while (queue.Count > 0) {
                int sz = queue.Count;
                for (int i = 0; i < sz; i++) {
                    (var cur, var pos) = queue.Dequeue();
                    if (cur.Equals(s2)) {
                        return step;
                    }
                    while (pos < n && cur[pos] == s2[pos]) {
                        pos++;
                    }
                    for (int j = pos + 1; j < n; j++) {
                        if (s2[j] == cur[j]) {
                            continue;
                        }
                        if (s2[pos] == cur[j]) {
                            string next = Swap(cur, pos, j);
                            if (!visit.Contains(next)) {
                                visit.Add(next);
                                queue.Enqueue((next, pos + 1));
                            }
                        }
                    }
                }
                step++;
            }

            return step;
        }
    }
}