using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2446
    /// title: 判断两个事件是否存在冲突
    /// problems: https://leetcode.cn/problems/determine-if-two-events-have-conflict/
    /// date: 20230517
    /// </summary>
    public static class Solution2446
    {
        public static bool HaveConflict(string[] event1, string[] event2) {

            return !(event1[1].CompareTo(event2[0]) < 0 || event2[1].CompareTo(event1[0]) < 0);
        }
    }
}