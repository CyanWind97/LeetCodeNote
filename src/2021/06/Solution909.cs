using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 909
    /// title: 蛇梯棋
    /// problems: https://leetcode-cn.com/problems/snakes-and-ladders/
    /// date: 20210627
    /// </summary>
    public static class Solution909
    {
        // 参考解答 广度优先
        public static int SnakesAndLadders(int[][] board) {
            int n = board.Length;
            bool[] vis = new bool[n * n + 1];

            (int Row, int Column) Id2Rc(int id) {
                int r = (id - 1) / n, c = (id - 1) % n;
                if (r % 2 == 1) {
                    c = n - 1 - c;
                }
                return (n - 1 - r, c);
            }

            var queue = new Queue<(int Row, int Column)>();
            queue.Enqueue((1, 0));
            while (queue.Count > 0) {
                var p = queue.Dequeue();
                for (int i = 1; i <= 6; ++i) {
                    int nxt = p.Row + i;
                    if (nxt > n * n) { // 超出边界
                        break;
                    }
                    var rc = Id2Rc(nxt); // 得到下一步的行列
                    if (board[rc.Row][rc.Column] > 0) { // 存在蛇或梯子
                        nxt = board[rc.Row][rc.Column];
                    }
                    if (nxt == n * n) { // 到达终点
                        return p.Column + 1;
                    }
                    if (!vis[nxt]) {
                        vis[nxt] = true;
                        queue.Enqueue((nxt, p.Column + 1)); // 扩展新状态
                    }
                }
            }
            return -1;
        }
    }
}