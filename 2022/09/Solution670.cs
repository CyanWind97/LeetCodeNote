namespace LeetCodeNote
{
    // <summary>
    /// no: 670
    /// title: 最大交换
    /// problems: https://leetcode.cn/problems/maximum-swap/
    /// date: 20220913
    /// </summary>
    public static class Solution670
    {
        public static int MaximumSwap(int num) {
            var chars = num.ToString().ToCharArray();
            int n = chars.Length;
            int maxIndex = n - 1;
            int index1 = -1;
            int index2 = -1;
            for (int i = n - 1; i >= 0; i--) {
                if (chars[i] > chars[maxIndex]) {
                    maxIndex = i;
                } else if (chars[i] < chars[maxIndex]) {
                    index1 = i;
                    index2 = maxIndex;
                }
            }
            if (index1 >= 0) {
                (chars[index1], chars[index2]) = (chars[index2], chars[index1]);
                return int.Parse(new string(chars));
            } else {
                return num;
            }
        }
    }
}