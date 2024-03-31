using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2437
    /// title: 有效时间的数目
    /// problems: https://leetcode.cn/problems/number-of-valid-clock-times/
    /// date: 20230509
    /// </summary>
    public static class Solution2437
    {
        public static int CountTime(string time) {
            int countHour = 0;
            int countMinute = 0;
            for (int i = 0; i < 24; i++) {
                int hiHour = i / 10;
                int loHour = i % 10;
                if ((time[0] == '?' || time[0] == hiHour + '0') && 
                    (time[1] == '?' || time[1] == loHour + '0')) {
                    countHour++;
                }
            } 

            for (int i = 0; i < 60; i++) {
                int hiMinute = i / 10;
                int loMinute = i % 10;
                if ((time[3] == '?' || time[3] == hiMinute + '0') && 
                    (time[4] == '?' || time[4] == loMinute + '0')) {
                    countMinute++;
                }
            }
            
            return countHour * countMinute;
        }
    }
}