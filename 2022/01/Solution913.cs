using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 913
    /// title: 猫和老鼠
    /// problems: https://leetcode-cn.com/problems/cat-and-mouse/
    /// date: 20220104
    /// </summary>
    public static class Solution913
    {
        // 参考解答
        public static int CatMouseGame(int[][] graph) {
            int length = graph.Length;
            var dp = new int[length, length, length * 2];
            for (int i = 0; i < length; i++) {
                for (int j = 0; j < length; j++) {
                    for (int k = 0; k < length * 2; k++) {
                        dp[i, j, k] = -1;
                    }
                }
            }
            
            int GetResult(int mouse, int cat, int truns) {
                if(truns == 2 * length)
                    return 0; // Draw
                
                if(dp[mouse, cat, truns] < 0)
                    if(mouse == 0)
                        dp[mouse, cat, truns] = 1; // Mouse_win
                    else if(cat == mouse)
                        dp[mouse, cat, truns] = 2; // Cat_win;
                    else
                        GetNextResult(mouse, cat, truns);
                
                return dp[mouse, cat, truns];
            }

            void GetNextResult(int mouse, int cat, int turns){
                int curMove = turns % 2 == 0 ? mouse : cat;
                int defaultResult = curMove == mouse ? 2 : 1; // Cat_win : Mouse_win
                int result = defaultResult;
                foreach(var next in graph[curMove]){
                    if(curMove == cat && next == 0)
                        continue;
                    
                    int nextMouse = curMove == mouse ? next : mouse;
                    int nextCat = curMove == cat ? next : cat;
                    int nextResult = GetResult(nextMouse, nextCat, turns + 1);
                    if(nextResult != defaultResult){
                        result = nextResult;
                        if(result != 0)
                            break;
                    }
                }

                dp[mouse, cat, turns] = result;
            }


            return GetResult(1, 2, 0);
        }
    }
}