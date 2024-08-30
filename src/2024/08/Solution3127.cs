using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3127
/// title: 构造相同颜色的正方形
/// problems: https://leetcode.cn/problems/make-a-square-with-the-same-color
/// date: 20240831
/// </summary>
public static class Solution3127
{
    public static bool CanMakeSquare(char[][] grid) {
        int countB = 0;
        
        for(int i = 0; i < 2; i++){
            countB = 0; 
            foreach(var (x, y) in new (int X, int Y)[]{(i, 0), (i, 1), (i + 1, 0), (i + 1, 1)}){
                if(grid[x][y] == 'B')
                    countB++;
            }

            if (countB != 2)
                return true;
            
            for(int j = 2; j < 3; j++){
                foreach(var (x, y) in new (int X, int Y)[]{(i, j), (i + 1, j)}){
                    if(grid[x][y] == 'B')
                        countB++;
                }

                foreach(var (x, y) in  new (int X, int Y)[]{(i, j - 2), (i + 1, j - 2)}){
                    if(grid[x][y] == 'B')
                        countB--;
                }

                if(countB != 2)
                    return true;
            }
        }

        return false;
    }
}
