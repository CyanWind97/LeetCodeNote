namespace LeetCodeNote
{
    /// <summary>
    /// no: 1037
    /// title: 有效的回旋镖
    /// problems: https://leetcode.cn/problems/valid-boomerang/
    /// date: 20220608
    /// </summary>
    public static class Solution1037
    {
        public static bool IsBoomerang(int[][] points) {
            (int X, int Y) v1 = (points[1][0] - points[0][0], points[1][1] - points[0][1]);
            (int X, int Y) v2 = (points[2][0] - points[0][0], points[2][1] - points[0][1]);
            
            return v1.X * v2.Y - v1.Y * v2.X != 0;
        }
    }
}