namespace LeetCodeNote
{
    /// <summary>
    /// no: 374
    /// title: 猜数字大小
    /// problems: https://leetcode-cn.com/problems/guess-number-higher-or-lower/
    /// date: 20210614
    /// </summary>
    public class Solution374
    {
        public static int GuessNumber(int n) {
            int left = 1;
            int right = n;
            while(left < right){
                int mid = left + (right - left) / 2;
                int result = guess(mid);
                if(result == -1)
                    right = mid - 1;
                else if(result == 1)
                    left = mid + 1;
                else
                    return mid;
            }

            return left;
        }

        public static int guess(int num) => -1;
    }
}