namespace LeetCodeNote
{
    /// <summary>
    /// no: 1791
    /// title: 找出星型图的中心节点
    /// problems: https://leetcode-cn.com/problems/find-center-of-star-graph/
    /// date: 20220218
    /// </summary>
    public static class Solution1791
    {
        public static int FindCenter(int[][] edges) {
            return edges[0][0] == edges[1][0] || edges[0][1] == edges[1][0]
                ? edges[1][0]
                : edges[1][1];
        }
    }
}