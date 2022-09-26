using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 17.19
    /// title: 17.19. 消失的两个数字
    /// problems: https://leetcode.cn/problems/missing-two-lcci/
    /// date: 20220926
    /// type: 面试题 lcci
    /// </summary>
    public static class Solution_lcci_17_19
    {
        // 参考解答 
        // 异或
        public static int[] MissingTwo(int[] nums) {
            int xorsum = 0;
            int n = nums.Length + 2;
            foreach (int num in nums) {
                xorsum ^= num;
            }
            for (int i = 1; i <= n; i++) {
                xorsum ^= i;
            }
            // 防止溢出
            int lsb = (xorsum == int.MinValue ? xorsum : xorsum & (-xorsum));
            int type1 = 0, type2 = 0;
            foreach (int num in nums) {
                if ((num & lsb) != 0)
                    type1 ^= num;
                else
                    type2 ^= num;
            }
            for (int i = 1; i <= n; i++) {
                if ((i & lsb) != 0)
                    type1 ^= i;
                else
                    type2 ^= i;
            }

            return new int[]{type1, type2};
        }

        // 参考解答
        // 求和 分界
        public static int[] MissingTwo_1(int[] nums) {
            int n = nums.Length + 2;
            int sum =  nums.Sum();
            int ts = (1 + n) * n / 2 - sum; //两个缺失元素之和
            int m = ts / 2; //两个元素之间的“分界”（一个缺失元素大于这个值，另一个小于这个值）

            // 将问题转换为求一个缺失元素
            sum = nums.Where(i => i <= m).Sum();
            int res = (1 + m) * m / 2 - sum;

            return new int[] {res, ts - res};
        }
    }
}