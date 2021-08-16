namespace LeetCodeNote
{
    /// <summary>
    /// no: 526
    /// title: 优美的排列
    /// problems: https://leetcode-cn.com/problems/beautiful-arrangement/
    /// date: 20210816
    /// </summary>
    public static class Solution526
    {
        // 打表
        public static int CountArrangement(int n){
            int[] result = {0,1,2,3,8,10,36,41,132,250,700,750,4010,4237,10680,24679};
            return result[n];
        }

        // 参考解答 状态压缩
        public static int CountArrangement_1(int n) {
            int[] f = new int[1 << n];
            f[0] = 1;
            for (int mask = 1; mask < (1 << n); mask++) {
                int num = BitCount(mask);
                for (int i = 0; i < n; i++) {
                    if ((mask & (1 << i)) != 0 && ((num % (i + 1)) == 0 || (i + 1) % num == 0)) {
                        f[mask] += f[mask ^ (1 << i)];
                    }
                }
            }
            return f[(1 << n) - 1];
        }

        private static int BitCount(int i) {
            i = i - ((i >> 1) & 0x55555555);
            i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
            i = (i + (i >> 4)) & 0x0f0f0f0f;
            i = i + (i >> 8);
            i = i + (i >> 16);
            return i & 0x3f;
        }

    }
}