namespace LeetCodeNote
{
    /// <summary>
    /// no: 292
    /// title: Nim 游戏
    /// problems: https://leetcode-cn.com/problems/nim-game/
    /// date: 20210918
    /// </summary>

    public static class Solution292
    {
        public static bool CanWinNim(int n) {
            return n % 4 != 0;
        }
    }
}