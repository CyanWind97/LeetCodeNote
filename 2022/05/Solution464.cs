using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 464
    /// title: 我能赢吗
    /// problems: https://leetcode.cn/problems/can-i-win/
    /// date: 20220522
    /// </summary>  
    public static class Solution464
    {
        // 参考解答 记忆搜索 + 状态压缩
        public static bool CanIWin(int maxChoosableInteger, int desiredTotal) {
            int max = maxChoosableInteger * (maxChoosableInteger + 1) / 2;
            if(max < desiredTotal)
                return false;
            
            var memo = new Dictionary<int, bool>();

            bool DFS(int usedNumbers, int current){
                if(!memo.ContainsKey(usedNumbers)){
                    bool result = false;
                    for(int i = 0; i < maxChoosableInteger; i++){
                        if(((usedNumbers >> i) & 1) == 0){
                            if(i + 1 + current >= desiredTotal){
                                result = true;
                                break;
                            }

                            if(!DFS(usedNumbers | (1 << i), current + i + 1)){
                                result = true;
                                break;
                            }
                        }
                    }
                    
                    memo.Add(usedNumbers, result);
                }

                return memo[usedNumbers];
            }

            return DFS(0, 0);
        }
    }
}