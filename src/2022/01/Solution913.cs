using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 913
    /// title: 猫和老鼠
    /// problems: https://leetcode-cn.com/problems/cat-and-mouse/
    /// date: 20220104
    /// </summary>
    public static partial class Solution913
    {
        // 参考解答
        // 20220510 测试用例更新 已有不能通过 并且超时
        // 自底向下
        public static int CatMouseGame(int[][] graph) {
            int length = graph.Length;
            var degrees = new int[length, length, 2];
            var results = new int[length, length, 2];
            var queue = new Queue<(int Mouse ,int Cat, int Turn)>();

            const int MOUSE_TURN = 0, CAT_TURN = 1;
            const int DRAW = 0, MOUSE_WIN = 1, CAT_WIN = 2;

            #region Init 

            for(int i = 0; i < length; i++){
                for(int j = 1; j < length; j++){
                    degrees[i, j, MOUSE_TURN] = graph[i].Length;
                    degrees[i, j, CAT_TURN] = graph[j].Length;
                }
            }

            foreach(var node in graph[0]){
                for(int i = 0; i < length; i++){
                    degrees[i, node, CAT_TURN]--;
                }
            }

            for(int j = 1; j < length; j++){
                results[0, j, MOUSE_TURN] = MOUSE_WIN;
                results[0, j, CAT_TURN] = MOUSE_WIN;
                queue.Enqueue((0, j, MOUSE_TURN));
                queue.Enqueue((0, j, CAT_TURN));
            }

            for(int i = 1; i < length; i++){
                results[i, i, MOUSE_TURN] = CAT_WIN;
                results[i, i, CAT_TURN] = CAT_WIN;
                queue.Enqueue((i, i, MOUSE_TURN));
                queue.Enqueue((i, i, CAT_TURN));
            }

            #endregion

            #region Method
            IEnumerable<(int Mouse ,int Cat, int Turn)> GetPrevStates((int Mouse ,int Cat, int Turn) state){
                int prevTurn = state.Turn == MOUSE_TURN ? CAT_TURN : MOUSE_TURN;

                return prevTurn == MOUSE_TURN
                    ? graph[state.Mouse].Select(prev => (prev, state.Cat, prevTurn))
                    : graph[state.Cat].Where(prev => prev != 0).Select(prev => (state.Mouse, prev, prevTurn));
            }

            #endregion

            while(queue.Count > 0){
                var state = queue.Dequeue();
                int result = results[state.Mouse, state.Cat, state.Turn];
                foreach(var prevState in GetPrevStates(state)){
                    (var prevMouse, var prevCat, var prevTurn) = prevState;
                    if(results[prevMouse, prevCat, prevTurn] != DRAW)
                        continue;
                    
                    var canWin = (result == MOUSE_WIN && prevTurn == MOUSE_TURN) 
                                || (result == CAT_WIN && prevTurn == CAT_TURN);
                    
                    if(canWin){
                        results[prevMouse, prevCat, prevTurn] = result;
                        queue.Enqueue(prevState);
                    }else{
                        degrees[prevMouse, prevCat, prevTurn]--;
                        if(degrees[prevMouse, prevCat, prevTurn] == 0){
                            int loseResult = prevTurn == MOUSE_TURN ? CAT_WIN : MOUSE_WIN;
                            results[prevMouse, prevCat, prevTurn] = loseResult;
                            queue.Enqueue(prevState);
                        }
                    }
                }
            }

            return results[1, 2, MOUSE_TURN];
        }
    }
}