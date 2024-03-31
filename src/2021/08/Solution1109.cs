namespace LeetCodeNote
{
    /// <summary>
    /// no: 1109
    /// title: 航班预订统计
    /// problems: https://leetcode-cn.com/problems/corporate-flight-bookings/
    /// date: 20210831
    /// </summary>
    public static class Solution1109
    {
        // 参考解答 前缀和 差分数组
        public static int[] CorpFlightBookings(int[][] bookings, int n) {
            int[] answer = new int[n];
            foreach(var booking in bookings){
                answer[booking[0] - 1] += booking[2];
                if(booking[1] < n)
                    answer[booking[1]] -= booking[2];
            }

            for (int i = 1; i < n; i++) {
                answer[i] += answer[i - 1];
            }

            return answer;
        }
    }
}