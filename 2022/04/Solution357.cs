namespace LeetCodeNote
{
    /// <summary>
    /// no: 357
    /// title: 统计各位数字都不同的数字个数
    /// problems: https://leetcode-cn.com/problems/count-numbers-with-unique-digits/
    /// date: 20220411
    /// </summary>
    public static class Solution357
    {
        

        public static int CountNumbersWithUniqueDigits(int n) {
            var table = new int[]{1,10,91,739,5275,32491,168571,712891,2345851};

            return table[n];
        }

        
        public static int CountNumbersWithUniqueDigits_1(int n){
            if(n == 0)
                return 1;
            
            if(n == 1)
                return 10;
            
            int result = 10; 
            int cur = 9;

            for(int i = 2; i <= n; i++){
                cur *= 11 - i;
                result += cur;
            }

            return result;
        }
    }
}