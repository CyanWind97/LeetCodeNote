namespace LeetCodeNote
{
    /// <summary>
    /// no: 1342
    /// title: 将数字变成 0 的操作次数
    /// problems: https://leetcode-cn.com/problems/number-of-steps-to-reduce-a-number-to-zero/
    /// date: 20220131
    /// </summary>
    public static class Solution1342
    {
        public static int NumberOfSteps(int num) {
            int count = 0;
            while(num > 0){
                if(num > 1 && (num & 1) == 1)
                    count += 2;
                else
                    count++;
                
                num >>= 1;
            }

            return count;
        }
    }
}