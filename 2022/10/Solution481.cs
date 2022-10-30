namespace LeetCodeNote
{
    /// <summary>
    /// no: 481
    /// title: 神奇字符串
    /// problems: https://leetcode.cn/problems/magical-string/
    /// date: 20221031
    /// </summary>
    public static class Solution481
    {
        // 参考解答
        // 双指针
        public static int MagicalString(int n) {
            if(n < 4)
                return 1;
            
            var s = new int[n];
            s[0] = 1;
            s[1] = 2;
            s[2] = 2;

            int result = 1;
            int i = 2;
            int j = 3;

            while(j < n){
                int size = s[i];
                int num = 3 - s[j - 1];
                while(size > 0 && j < n){
                    s[j] = num;
                    if(num == 1)
                        result++;
                    
                    j++;
                    size--;
                }

                i++;
            }

            return result;
         }
    }
}