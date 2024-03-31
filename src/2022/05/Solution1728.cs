using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1728
    /// title: 猫和老鼠 II
    /// problems: https://leetcode.cn/problems/cat-and-mouse-ii/
    /// date: 20220510
    /// </summary>
    
    public static class Solution1728
    {
        // 参考解答 拓扑排序
        public static bool CanMouseWin(string[] grid, int catJump, int mouseJump) {
            const int MOUSE_TURN = 0, CAT_TURN = 1;
            const int UNKNOWN = 0, MOUSE_WIN = 1, CAT_WIN = 2;
            const int MAX_MOVES = 1000;
            var dirs = new (int R, int C)[]{(-1, 0), (1, 0), (0, -1), (0, 1)};
            int rows = grid.Length;
            int cols = grid[0].Length;
            
            int startMouse = -1;
            int startCat = -1;
            int food = -1;

            #region Method
            int GetPos(int r, int c)
                => r * cols + c;

            bool IsValid(int r, int c)
                => r >= 0 && r < rows 
                && c >= 0 && c < cols
                && grid[r][c] != '#';

            (int R, int C) GetRowCol(int pos)
                => (pos / cols, pos % cols);


            IEnumerable<(int Mouse, int Cat, int Turn)> GetPrevStates((int Mouse, int Cat, int Turn) state){
                (int mouseR, int mouseC) = GetRowCol(state.Mouse);
                (int catR, int catC) = GetRowCol(state.Cat);
                (int prevTurn, int maxJump, int startR, int startC) 
                    = state.Turn == MOUSE_TURN
                    ? (CAT_TURN, catJump, catR, catC)
                    : (MOUSE_TURN, mouseJump, mouseR, mouseC);
                
                yield return (state.Mouse, state.Cat, prevTurn);

                foreach(var dir in dirs){
                    for(int r = startR + dir.R, c = startC + dir.C, jump = 1;
                        IsValid(r, c) && jump <= maxJump;
                        r += dir.R, c += dir.C, jump++)
                    {
                        (int prevMouseR, int preMouseC, int prevCatR, int prevCatC)
                            = prevTurn == MOUSE_TURN
                            ? (r, c, catR, catC)
                            : (mouseR, mouseC, r, c);
                        
                        yield return(GetPos(prevMouseR, preMouseC), GetPos(prevCatR, prevCatC), prevTurn);
                    }
                }
            }
     
            #endregion

            #region Init
            for(int i = 0; i < rows; i ++){
                for(int j = 0; j < cols; j++){
                    char c = grid[i][j];
                    if(c == 'M')
                        startMouse = GetPos(i, j);
                    else if(c == 'C')
                        startCat = GetPos(i, j);
                    else if(c == 'F')
                        food = GetPos(i, j);

                }
            }

            int total = rows * cols;
            int[,,] degrees = new int[total, total, 2];
            int[,,,] results = new int[total, total, 2, 2];

            var queue = new Queue<(int Mouse, int Cat, int Turn)>();

            
            // 计算度
            for(int mouse = 0; mouse < total; mouse++){
                (int mouseR, int mouseC) = GetRowCol(mouse);

                if(grid[mouseR][mouseC] == '#')
                    continue;
                
                for(int cat = 0; cat < total; cat++){
                    (int catR, int catC) = GetRowCol(cat);

                    if(grid[catR][catC] == '#')
                        continue;
                    
                    degrees[mouse, cat, MOUSE_TURN]++;
                    degrees[mouse, cat, CAT_TURN]++;

                    foreach(var dir in dirs){
                        for(int row = mouseR + dir.R, col = mouseC + dir.C, jump = 1;
                            IsValid(row, col) && jump <= mouseJump;
                            row += dir.R, col += dir.C, jump++)
                        {
                            int nextMous = GetPos(row, col);
                            int nextCat = GetPos(catR, catC);
                            degrees[nextMous, nextCat, MOUSE_TURN]++;
                        }

                        for(int row = catR + dir.R, col = catC + dir.C, jump = 1;
                            IsValid(row, col) && jump <= catJump;
                            row += dir.R, col += dir.C, jump++)
                        {
                            int nextMous = GetPos(mouseR, mouseC);
                            int nextCat = GetPos(row, col);
                            degrees[nextMous, nextCat, CAT_TURN]++;
                        }
                    }
                }
            }
            #endregion

            #region 添加已知状态
            // 猫和老鼠在同一个单元格，猫获胜
            for (int pos = 0; pos < total; pos++) {
                (int r, int c) = GetRowCol(pos);
                if (grid[r][c] == '#') 
                    continue;
                
                results[pos, pos, MOUSE_TURN, 0] = CAT_WIN;
                results[pos, pos, MOUSE_TURN, 1] = 0;
                results[pos, pos, CAT_TURN, 0] = CAT_WIN;
                results[pos, pos, CAT_TURN, 1] = 0;
                queue.Enqueue((pos, pos, MOUSE_TURN));
                queue.Enqueue((pos, pos, CAT_TURN));
            }

            // 猫和食物在同一个单元格，猫获胜
            for (int mouse = 0; mouse < total; mouse++) {
                (int mouseR, int mouseC) = GetRowCol(mouse);
                if (grid[mouseR][mouseC] == '#' || mouse == food) 
                    continue;
                
                results[mouse, food, MOUSE_TURN, 0] = CAT_WIN;
                results[mouse, food, MOUSE_TURN, 1] = 0;
                results[mouse, food, CAT_TURN, 0] = CAT_WIN;
                results[mouse, food, CAT_TURN, 1] = 0;
                queue.Enqueue((mouse, food, MOUSE_TURN));
                queue.Enqueue((mouse, food, CAT_TURN));
            }

            // 老鼠和食物在同一个单元格且猫和食物不在同一个单元格，老鼠获胜
            for (int cat = 0; cat < total; cat++) {
                (int catR, int catC) = GetRowCol(cat);
                if (grid[catR][catC] == '#' || cat == food) 
                    continue;
                
                results[food, cat, MOUSE_TURN, 0] = MOUSE_WIN;
                results[food, cat, MOUSE_TURN, 1] = 0;
                results[food, cat, CAT_TURN, 0] = MOUSE_WIN;
                results[food, cat, CAT_TURN, 1] = 0;
                queue.Enqueue((food, cat, MOUSE_TURN));
                queue.Enqueue((food, cat, CAT_TURN));
            }
            #endregion


            while(queue.Count > 0){
                var state = queue.Dequeue();
                int result = results[state.Mouse, state.Cat, state.Turn, 0];
                int moves = results[state.Mouse, state.Cat, state.Turn, 1];

                foreach(var prevState in GetPrevStates(state)){
                    (int prevMouse, int prevCat, int prevTurn) = prevState;
                    if(results[prevMouse, prevCat, prevTurn, 0] != UNKNOWN)
                        continue;
                    
                    bool canWin = (result == MOUSE_WIN && prevTurn == MOUSE_TURN)
                                || (result == CAT_WIN && prevTurn == CAT_TURN);
                    
                    if(canWin){
                        results[prevMouse, prevCat, prevTurn, 0] = result;
                        results[prevMouse, prevCat, prevTurn, 1] = moves + 1;
                        queue.Enqueue(prevState);
                    }else{
                        degrees[prevMouse, prevCat, prevTurn]--;
                        if(degrees[prevMouse, prevCat, prevTurn] == 0){
                            int loseResult = prevTurn == MOUSE_TURN ? CAT_WIN : MOUSE_WIN;
                            results[prevMouse, prevCat, prevTurn, 0] = loseResult;
                            results[prevMouse, prevCat, prevTurn, 1] = moves + 1;
                            queue.Enqueue(prevState);
                        }       
                    }

                }
            }

            return results[startMouse, startCat, MOUSE_TURN, 0] == MOUSE_WIN && results[startMouse, startCat, MOUSE_TURN, 1] <= MAX_MOVES;
        }
    }


    public class Solution1728_1
    {
        const int MOUSE_TURN = 0, CAT_TURN = 1;
        const int UNKNOWN = 0, MOUSE_WIN = 1, CAT_WIN = 2;
        const int MAX_MOVES = 1000;
        int[][] dirs = {new int[]{-1, 0}, new int[]{1, 0}, new int[]{0, -1}, new int[]{0, 1}};
        int rows, cols;
        string[] grid;
        int catJump, mouseJump;
        int food;
        int[,,] degrees;
        int[,,,] results;

        public bool CanMouseWin(string[] grid, int catJump, int mouseJump) {
            this.rows = grid.Length;
            this.cols = grid[0].Length;
            this.grid = grid;
            this.catJump = catJump;
            this.mouseJump = mouseJump;
            int startMouse = -1, startCat = -1;
            for (int i = 0; i < rows; i++) {
                for (int j = 0; j < cols; j++) {
                    char c = grid[i][j];
                    if (c == 'M') {
                        startMouse = GetPos(i, j);
                    } else if (c == 'C') {
                        startCat = GetPos(i, j);
                    } else if (c == 'F') {
                        food = GetPos(i, j);
                    }
                }
            }
            int total = rows * cols;
            degrees = new int[total, total, 2];
            results = new int[total, total, 2, 2];
            Queue<Tuple<int, int, int>> queue = new Queue<Tuple<int, int, int>>();

            // 计算每个状态的度
            for (int mouse = 0; mouse < total; mouse++) {
                int mouseRow = mouse / cols, mouseCol = mouse % cols;
                if (grid[mouseRow][mouseCol] == '#') {
                    continue;
                }
                for (int cat = 0; cat < total; cat++) {
                    int catRow = cat / cols, catCol = cat % cols;
                    if (grid[catRow][catCol] == '#') {
                        continue;
                    }
                    degrees[mouse, cat, MOUSE_TURN]++;
                    degrees[mouse, cat, CAT_TURN]++;
                    foreach (int[] dir in dirs) {
                        for (int row = mouseRow + dir[0], col = mouseCol + dir[1], jump = 1; row >= 0 && row < rows && col >= 0 && col < cols && grid[row][col] != '#' && jump <= mouseJump; row += dir[0], col += dir[1], jump++) {
                            int nextMouse = GetPos(row, col), nextCat = GetPos(catRow, catCol);
                            degrees[nextMouse, nextCat, MOUSE_TURN]++;
                        }
                        for (int row = catRow + dir[0], col = catCol + dir[1], jump = 1; row >= 0 && row < rows && col >= 0 && col < cols && grid[row][col] != '#' && jump <= catJump; row += dir[0], col += dir[1], jump++) {
                            int nextMouse = GetPos(mouseRow, mouseCol), nextCat = GetPos(row, col);
                            degrees[nextMouse, nextCat, CAT_TURN]++;
                        }
                    }
                }
            }
            // 猫和老鼠在同一个单元格，猫获胜
            for (int pos = 0; pos < total; pos++) {
                int row = pos / cols, col = pos % cols;
                if (grid[row][col] == '#') {
                    continue;
                }
                results[pos, pos, MOUSE_TURN, 0] = CAT_WIN;
                results[pos, pos, MOUSE_TURN, 1] = 0;
                results[pos, pos, CAT_TURN, 0] = CAT_WIN;
                results[pos, pos, CAT_TURN, 1] = 0;
                queue.Enqueue(new Tuple<int, int, int>(pos, pos, MOUSE_TURN));
                queue.Enqueue(new Tuple<int, int, int>(pos, pos, CAT_TURN));
            }
            // 猫和食物在同一个单元格，猫获胜
            for (int mouse = 0; mouse < total; mouse++) {
                int mouseRow = mouse / cols, mouseCol = mouse % cols;
                if (grid[mouseRow][mouseCol] == '#' || mouse == food) {
                    continue;
                }
                results[mouse, food, MOUSE_TURN, 0] = CAT_WIN;
                results[mouse, food, MOUSE_TURN, 1] = 0;
                results[mouse, food, CAT_TURN, 0] = CAT_WIN;
                results[mouse, food, CAT_TURN, 1] = 0;
                queue.Enqueue(new Tuple<int, int, int>(mouse, food, MOUSE_TURN));
                queue.Enqueue(new Tuple<int, int, int>(mouse, food, CAT_TURN));
            }
            // 老鼠和食物在同一个单元格且猫和食物不在同一个单元格，老鼠获胜
            for (int cat = 0; cat < total; cat++) {
                int catRow = cat / cols, catCol = cat % cols;
                if (grid[catRow][catCol] == '#' || cat == food) {
                    continue;
                }
                results[food, cat, MOUSE_TURN, 0] = MOUSE_WIN;
                results[food, cat, MOUSE_TURN, 1] = 0;
                results[food, cat, CAT_TURN, 0] = MOUSE_WIN;
                results[food, cat, CAT_TURN, 1] = 0;
                queue.Enqueue(new Tuple<int, int, int>(food, cat, MOUSE_TURN));
                queue.Enqueue(new Tuple<int, int, int>(food, cat, CAT_TURN));
            }
            

            // 拓扑排序
            while (queue.Count > 0) {
                Tuple<int, int, int> state = queue.Dequeue();
                int mouse = state.Item1, cat = state.Item2, turn = state.Item3;
                int result = results[mouse, cat, turn, 0];
                int moves = results[mouse, cat, turn, 1];
                IList<Tuple<int, int, int>> prevStates = GetPrevStates(mouse, cat, turn);
                foreach (Tuple<int, int, int> prevState in prevStates) {
                    int prevMouse = prevState.Item1, prevCat = prevState.Item2, prevTurn = prevState.Item3;
                    if (results[prevMouse, prevCat, prevTurn, 0] == UNKNOWN) {
                        bool canWin = (result == MOUSE_WIN && prevTurn == MOUSE_TURN) || (result == CAT_WIN && prevTurn == CAT_TURN);
                        if (canWin) {
                            results[prevMouse, prevCat, prevTurn, 0] = result;
                            results[prevMouse, prevCat, prevTurn, 1] = moves + 1;
                            queue.Enqueue(new Tuple<int, int, int>(prevMouse, prevCat, prevTurn));
                        } else {
                            degrees[prevMouse, prevCat, prevTurn]--;
                            if (degrees[prevMouse, prevCat, prevTurn] == 0) {
                                int loseResult = prevTurn == MOUSE_TURN ? CAT_WIN : MOUSE_WIN;
                                results[prevMouse, prevCat, prevTurn, 0] = loseResult;
                                results[prevMouse, prevCat, prevTurn, 1] = moves + 1;
                                queue.Enqueue(new Tuple<int, int, int>(prevMouse, prevCat, prevTurn));
                            }
                        }
                    }
                }
            }

            return results[startMouse, startCat, MOUSE_TURN, 0] == MOUSE_WIN && results[startMouse, startCat, MOUSE_TURN, 1] <= MAX_MOVES;
        }

        public  IList<Tuple<int, int, int>> GetPrevStates(int mouse, int cat, int turn) {
            IList<Tuple<int, int, int>> prevStates = new List<Tuple<int, int, int>>();
            int mouseRow = mouse / cols, mouseCol = mouse % cols;
            int catRow = cat / cols, catCol = cat % cols;
            int prevTurn = turn == MOUSE_TURN ? CAT_TURN : MOUSE_TURN;
            int maxJump = prevTurn == MOUSE_TURN ? mouseJump : catJump;
            int startRow = prevTurn == MOUSE_TURN ? mouseRow : catRow;
            int startCol = prevTurn == MOUSE_TURN ? mouseCol : catCol;
            prevStates.Add(new Tuple<int, int, int>(mouse, cat, prevTurn));
            foreach (int[] dir in dirs) {
                for (int i = startRow + dir[0], j = startCol + dir[1], jump = 1; i >= 0 && i < rows && j >= 0 && j < cols && grid[i][j] != '#' && jump <= maxJump; i += dir[0], j += dir[1], jump++) {
                    int prevMouseRow = prevTurn == MOUSE_TURN ? i : mouseRow;
                    int prevMouseCol = prevTurn == MOUSE_TURN ? j : mouseCol;
                    int prevCatRow = prevTurn == MOUSE_TURN ? catRow : i;
                    int prevCatCol = prevTurn == MOUSE_TURN ? catCol : j;
                    int prevMouse = GetPos(prevMouseRow, prevMouseCol);
                    int prevCat = GetPos(prevCatRow, prevCatCol);
                    prevStates.Add(new Tuple<int, int, int>(prevMouse, prevCat, prevTurn));
                }
            }
            return prevStates;
        }

        public int GetPos(int row, int col) {
            return row * cols + col;
        }
    }
}