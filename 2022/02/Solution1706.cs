namespace LeetCodeNote
{
    /// <summary>
    /// no: 1706
    /// title: 球会落何处
    /// problems: https://leetcode-cn.com/problems/where-will-the-ball-fall/
    /// date: 20220224
    /// </summary>
    public static class Solution1706
    {
        public static int[] FindBall(int[][] grid) {
            int m =  grid.Length;
            int n = grid[0].Length;

            int[] result = new int[n];

            for(int j = 0; j < n; j++){
                int y = j;
                int x = 0;

                while(x < m){
                    var dir = grid[x][y];
                    int nextY =  y + dir;
                    if(nextY < 0 || nextY >= n)
                        break;
                    
                    if(grid[x][y] != grid[x][nextY])
                        break;

                    x++;
                    y = nextY;
                }

                result[j] = x < m ? - 1 : y;
            }

            return result;
        }
    }
}