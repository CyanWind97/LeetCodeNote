namespace LeetCodeNote
{
    /// <summary>
    /// no: 829
    /// title: 连续整数求和
    /// problems: https://leetcode.cn/problems/consecutive-numbers-sum/
    /// date: 20220603
    /// </summary>
    public class Solution829
    {
        // 参考解答
        public static int ConsecutiveNumbersSum(int n) {
            int result = 0;
            int bound = 2 * n;

            bool IsKConsecutive(int k){
                if(k % 2 == 1)
                    return n % k == 0;
                else
                    return n % k != 0 && 2 * n % k == 0;
            }

            for(int k = 1; k * (k + 1) <= bound; k++){
                if(IsKConsecutive(k))
                    result++;
            }

            return result;
        }
    }
}