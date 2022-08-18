using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1450
    /// title:  在既定时间做作业的学生人数
    /// problems: https://leetcode.cn/problems/number-of-students-doing-homework-at-a-given-time/
    /// date: 20220819
    /// </summary>
    public static class Solution1450
    {
        public static int BusyStudent(int[] startTime, int[] endTime, int queryTime) {
            int n = startTime.Length;
            
            return Enumerable.Range(0, n)
                            .Count(i => startTime[i] <= queryTime && endTime[i] >= queryTime);
        }
    }
}