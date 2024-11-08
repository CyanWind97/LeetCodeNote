using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3242
/// title: 设计相邻元素求和服务
/// problems: https://leetcode.cn/problems/design-neighbor-sum-service
/// date: 20241109
/// </summary>
public class Solution3242
{
    public class NeighborSum {
        private int[][] _grid;
        private Dictionary<int, (int X, int Y)> _valueToIndex = [];

        private int _n;


        public NeighborSum(int[][] grid) {
            _grid = grid;
            _n = grid.Length;

            for (int i = 0; i < _n; i++) {
                for (int j = 0; j < _n; j++) {
                    _valueToIndex[grid[i][j]] = (i, j);
                }
            }
        }
        
        public int AdjacentSum(int value) {
            var (x, y) = _valueToIndex[value];
            int sum = 0;
            if (x > 0) 
                sum += _grid[x - 1][y];
                
            if (x < _n - 1) 
                sum += _grid[x + 1][y];
            
            if (y > 0) 
                sum += _grid[x][y - 1];
            
            if (y < _n - 1) 
                sum += _grid[x][y + 1];
            
            return sum;
        }
        
        public int DiagonalSum(int value) {
            (int x, int y) = _valueToIndex[value];
            int sum = 0;
            if (x > 0 && y > 0) 
                sum += _grid[x - 1][y - 1];
            
            if (x < _n - 1 && y < _n - 1)
                sum += _grid[x + 1][y + 1];
            
            if (x > 0 && y < _n - 1)
                sum += _grid[x - 1][y + 1];
            
            if (x < _n - 1 && y > 0)
                sum += _grid[x + 1][y - 1];

            return sum;
        }
    }

}
