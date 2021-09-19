namespace LeetCodeNote
{
    /// <summary>
    /// no: 650
    /// title: 只有两个键的键盘
    /// problems: https://leetcode-cn.com/problems/2-keys-keyboard/
    /// date: 20210919
    /// </summary>
    public static class Solution650
    {
        public static int MinSteps(int n) {
            int result = 0;
            for(int i = 2; i  * i <= n; i++){
                while(n % i == 0){
                    n /= i;
                    result += i;
                }
            }    
            if (n > 1)
                result += n;

            return result;
        }
    }
}