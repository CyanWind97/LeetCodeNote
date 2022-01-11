using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1036
    /// title: 逃离大迷宫
    /// problems: https://leetcode-cn.com/problems/escape-a-large-maze/
    /// date: 20220111
    /// </summary>
    public static class Solution1036
    {
        // 参考解答 离散化
        public static bool IsEscapePossible(int[][] blocked, int[] source, int[] target) {
            if (blocked.Length < 2)
                return true;

            int n = 1000000;

            var rowsSet = new HashSet<int>();
            var columnsSet = new HashSet<int>();
            var rows = new List<int>();
            var columns = new List<int>();
            // 离散化
            foreach (int[] pos in blocked) {
                if (rowsSet.Add(pos[0])) 
                    rows.Add(pos[0]);
                
                if (columnsSet.Add(pos[1])) 
                    columns.Add(pos[1]);
            }

            if (rowsSet.Add(source[0])) 
                rows.Add(source[0]);
            
            if (rowsSet.Add(target[0])) 
                rows.Add(target[0]);
            
            if (columnsSet.Add(source[1])) 
                columns.Add(source[1]);
            
            if (columnsSet.Add(target[1])) 
                columns.Add(target[1]);
            
            rows.Sort();
            columns.Sort();

            var rDictionary = new Dictionary<int, int>();
            var cDictionary = new Dictionary<int, int>();

            int rId = (rows[0] == 0 ? 0 : 1);
            rDictionary.Add(rows[0], rId);
            for (int i = 1; i < rows.Count; ++i) {
                rId += (rows[i] == rows[i - 1] + 1 ? 1 : 2);
                rDictionary.Add(rows[i], rId);
            }

            if (rows[rows.Count - 1] != n - 1) 
                ++rId;
            
            int cId = (columns[0] == 0 ? 0 : 1);
            cDictionary.Add(columns[0], cId);
            for (int i = 1; i < columns.Count; ++i) {
                cId += (columns[i] == columns[i - 1] + 1 ? 1 : 2);
                cDictionary.Add(columns[i], cId);
            }
            
            if (columns[columns.Count - 1] != n - 1) 
                ++cId;

            var visited = new bool[rId + 1, cId + 1];

            foreach (int[] pos in blocked) {
                int x = pos[0], y = pos[1];
                visited[rDictionary[x], cDictionary[y]] = true;
            }
            
            int sx = rDictionary[source[0]], sy = cDictionary[source[1]];
            int tx = rDictionary[target[0]], ty = cDictionary[target[1]];

            bool IsEscape((int X, int Y) point) => point.X == tx && point.Y == ty;

            IEnumerable<(int X, int Y)> GetAdjacentPoints((int X, int Y) point){
                if(point.X > 0 && !visited[point.X - 1,point.Y])
                    yield return (point.X - 1, point.Y);
                
                if(point.Y > 0 && !visited[point.X , point.Y - 1])
                    yield return (point.X, point.Y - 1);
                
                if(point.X < rId && !visited[point.X + 1, point.Y])
                    yield return (point.X + 1, point.Y);

                if(point.Y < cId && !visited[point.X, point.Y + 1])
                    yield return (point.X, point.Y + 1);
            }

            var queue = new Queue<(int X, int Y)>();
            queue.Enqueue((sx, sy));
            visited[sx, sy] = true;
            while(queue.Count > 0){
                var point = queue.Dequeue();

                foreach(var adjacentPoint in GetAdjacentPoints(point)){
                    if(IsEscape(adjacentPoint))
                        return true;

                    queue.Enqueue(adjacentPoint);
                    visited[adjacentPoint.X, adjacentPoint.Y] = true;
                }
            }

            return false;
        }
    }
}