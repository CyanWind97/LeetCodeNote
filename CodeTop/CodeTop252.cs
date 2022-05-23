using System;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 252
    /// title:  会议室
    /// problems: https://leetcode.cn/problems/meeting-rooms/
    /// date: 20220523
    /// priority: 0099
    /// time: 00:13:55.46
    /// </summary>
    public static class CodeTop252
    {
        public static bool CanAttendMeetings(int[][] intervals){
            int length = intervals.Length;
            if(length == 0)
                return true;
            
            Array.Sort(intervals, (a,b) => a[0] - b[0]);
            
            for(int i = 0; i < length - 1; i++){
                if(intervals[i + 1][0] < intervals[i][1])
                    return false;
            }

            return true;
        }
    }
}   