namespace LeetCodeNote
{
    /// <summary>
    /// no: 1893
    /// title: 检查是否区域内所有整数都被覆盖
    /// problems: https://leetcode-cn.com/problems/check-if-all-the-integers-in-a-range-are-covered/
    /// date: 20210723
    /// </summary>
    public static class Solution1893
    {
        
        public static bool IsCovered(int[][] ranges, int left, int right) {
            int[] diff = new int[52];   // 差分数组
            foreach (int[] range in ranges) {
                ++diff[range[0]];
                --diff[range[1] + 1];
            }
            // 前缀和
            int curr = 0;
            for (int i = 1; i <= 50; ++i) {
                curr += diff[i];
                if (i >= left && i <= right && curr <= 0) {
                    return false;
                }
            }
            return true;
        }
    }
}