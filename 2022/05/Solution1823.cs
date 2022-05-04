using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1823
    /// title: 找出游戏的获胜者
    /// problems: https://leetcode-cn.com/problems/find-the-winner-of-the-circular-game/
    /// date: 20220504
    /// </summary>
    public class Solution1823
    {
        public static int FindTheWinner(int n, int k) {
            var queue = new Queue<int>();
            var count = 0;
            
            for(int i = 1; i <= n; i++){
                queue.Enqueue(i);
            }

            while(queue.Count > 1){
                var num = queue.Dequeue();
                count++;
                if(count < k)
                    queue.Enqueue(num);
                else
                    count = 0;
            }

            return queue.Dequeue();
        }

        // 参考解答 数学
        // 约瑟夫环
        public static int FindTheWinner_1(int n, int k) {
            int winner = 1;
            for(int i = 2; i <= n; i++){
                winner = (k + winner - 1) % i + 1;
            }

            return winner;
        }
    }
}