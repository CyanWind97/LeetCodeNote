namespace LeetCodeNote
{
    /// <summary>
    /// no: 258
    /// title: 各位相加
    /// problems: https://leetcode-cn.com/problems/add-digits/
    /// date: 20220303
    /// </summary>
    public static class Solution258
    {
        public static int AddDigits(int num) {
            while(num >= 10){
                var sum = 0;
                while(num > 0){
                    sum += num % 10;
                    num /= 10;
                }

                num = sum;
            }

            return num;
        }

        // 参考解答 数学
        public static int AddDigits_1(int num)
            =>  (num - 1) % 9 + 1;
    }
}