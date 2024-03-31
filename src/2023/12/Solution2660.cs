using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2660
    /// title: 保龄球游戏的获胜者
    /// problems: https://leetcode.cn/problems/determine-the-winner-of-a-bowling-game/description/?envType=daily-question&envId=2023-12-27
    /// date: 20231227
    /// </summary>
    public static class Solution2660
    {
        public static int IsWinner(int[] player1, int[] player2) {

            int Score(int[] scores) {
                int n = scores.Length;
                int score = 0;
                int prev = -3;

                for(int i = 0; i < n; i++){
                    int multi = i - prev < 3 ? 2 : 1;
                    score += scores[i] * multi;
                    if (scores[i] == 10)
                        prev = i;
                }

                return score;
            }
            
            int score1 = Score(player1);
            int score2 = Score(player2);

            return score1 == score2 
                ? 0 
                : (score1 > score2 ? 1 : 2);
        }
    }
}