using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1222
    /// title: 可以攻击国王的皇后
    /// problems: https://leetcode.cn/problems/queens-that-can-attack-the-king/?envType=daily-question&envId=2023-09-14
    /// date: 20230914
    /// </summary>
    public static class Solution1222
    {
        public static IList<IList<int>> QueensAttacktheKing(int[][] queens, int[] king) {
            int n = 8;
            var queensSet = new HashSet<(int, int)>(); 
            foreach(var queen in queens){
                queensSet.Add((queen[0], queen[1]));
            }

            var result = new List<IList<int>>();
            (int x, int y) = (king[0], king[1]);
            var dir = new List<(int, int)>{
                (0, 1), (0, -1), (1, 0), (-1, 0),
                (1, 1), (1, -1), (-1, 1), (-1, -1)
            };

            foreach(var (dx, dy) in dir){
                (int nx, int ny) = (x + dx, y + dy);
                while (nx >= 0 && nx < n && ny >= 0 && ny < n){
                    if (queensSet.Contains((nx, ny))){
                        result.Add(new int[]{nx, ny});
                        break;
                    }

                    (nx, ny) = (nx + dx, ny + dy);
                }
            }

            return result;
        }
    }
}