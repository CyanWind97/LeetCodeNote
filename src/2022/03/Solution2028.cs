using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2028
    /// title: 找出缺失的观测数据
    /// problems: https://leetcode-cn.com/problems/find-missing-observations/
    /// date: 20220327
    /// </summary>

    public static partial class Solution2028
    {
        public static int[] MissingRolls(int[] rolls, int mean, int n) {
            int m = rolls.Length;
            int sum = mean * (m + n);
            sum -= rolls.Sum();
            
            if(sum < n || sum > 6 * n)
                return [];

            int quotient = sum / n;
            int remainder = sum % n;
            int[] result = new int[n];
            for (int i = 0; i < n; i++) {
                result[i] = quotient + (i < remainder ? 1 : 0);
            }

            return result;
        }
    }
}