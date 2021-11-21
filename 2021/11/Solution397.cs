namespace LeetCodeNote
{
    /// <summary>
    /// no: 397
    /// title:  整数替换
    /// problems: https://leetcode-cn.com/problems/integer-replacement/
    /// date: 20211119
    /// </summary>
    public static class Solution397
    {
        public static int IntegerReplacement(int n) {
            int count = 0;
            
            while(n > 1){
                if (n % 2== 0){
                    n /= 2;
                    count++;
                }else if(n % 4 == 1){
                    count += 2;
                    n /= 2;
                }else if(n == 3){
                    count += 2;
                    n = 1;
                } else{
                    count += 2;
                    n = n / 2 + 1;
                }
            }

            return count;
        }
    }
}