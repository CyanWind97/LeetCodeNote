namespace LeetCodeNote
{
    /// <summary>
    /// no: 1716
    /// title: 计算力扣银行的钱
    /// problems: https://leetcode-cn.com/problems/calculate-money-in-leetcode-bank/
    /// date: 20220109
    /// </summary>
    public static class Solution1716
    {
        public static int TotalMoney(int n) {
            // 所有完整的周存的钱
            int weekNumber = n / 7;
            int firstWeekMoney = (1 + 7) * 7 / 2;
            int lastWeekMoney = firstWeekMoney + 7 * (weekNumber - 1);
            int weekMoney = (firstWeekMoney + lastWeekMoney) * weekNumber / 2;
            // 剩下的不能构成一个完整的周的天数里存的钱
            int dayNumber = n % 7;
            int firstDayMoney = 1 + weekNumber;
            int lastDayMoney = firstDayMoney + dayNumber - 1;
            int dayMoney = (firstDayMoney + lastDayMoney) * dayNumber / 2;
            return weekMoney + dayMoney;
        }
    }
}