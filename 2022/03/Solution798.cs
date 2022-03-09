namespace LeetCodeNote
{
    /// <summary>
    /// no: 798
    /// title: 得分最高的最小轮调
    /// problems: https://leetcode-cn.com/problems/smallest-rotation-with-highest-score/
    /// date: 20220309
    /// </summary>
    public class Solution798
    {
        // 参考解答 差分数组
        public static int BestRotation(int[] nums) {
            int length = nums.Length;
            int[] diffs = new int[length];
            for (int i = 0; i < length; i++) {
                int low = (i + 1) % length;
                int high = (i - nums[i] + length + 1) % length;
                diffs[low]++;
                diffs[high]--;
                if (low >= high) 
                    diffs[0]++;
            }
            int bestIndex = 0;
            int maxScore = 0;
            int score = 0;
            for (int i = 0; i < length; i++) {
                score += diffs[i];
                if (score > maxScore) {
                    bestIndex = i;
                    maxScore = score;
                }
            }
            return bestIndex;
        }
    }
}