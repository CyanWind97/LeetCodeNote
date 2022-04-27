using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 417
    /// title: 太平洋大西洋水流问题
    /// problems: https://leetcode-cn.com/problems/pacific-atlantic-water-flow/
    /// date: 20220427
    /// </summary> 
    public static class Solution417
    {
        public static IList<IList<int>> PacificAtlantic(int[][] heights) {
            int m = heights.Length;
            int n = heights[0].Length;
            var result = new List<IList<int>>();

            var pStates = new int[m, n];
            var aStates = new int[m, n];

            for(int i = 0; i < m; i++){

                CalcState(i, 0, pStates);
                CalcState(i, n - 1, aStates);
            }

            for(int j = 0; j < n; j++){
                CalcState(0, j, pStates);
                CalcState(m - 1, j, aStates);
            }


            void CalcState(int r, int c, int[,] states){
                states[r, c] = 1;

                var height = heights[r][c];
                IEnumerable<(int R, int C)> GetAdjacentPoints(){
                    bool IsValid(int i, int j)
                        => heights[i][j] >= height && states[i, j] == 0;

                    if(r > 0 && IsValid(r - 1, c))
                        yield return (r - 1, c);

                    if(r < m - 1 && IsValid(r + 1, c))
                        yield return (r + 1, c);

                    if(c > 0 && IsValid(r, c - 1))
                        yield return (r, c - 1);

                    if(c < n - 1 && IsValid(r, c + 1))
                        yield return (r, c + 1);
                }

                foreach(var point in GetAdjacentPoints()){
                    CalcState(point.R, point.C, states);
                }
            }

            for(int i = 0; i < m; i ++){
                for(int j = 0; j < n; j++){;
                    if(aStates[i, j] == 1 && pStates[i, j] == 1)
                        result.Add(new int[]{i ,j});
                }
            }

            return result;
        }
    }
}