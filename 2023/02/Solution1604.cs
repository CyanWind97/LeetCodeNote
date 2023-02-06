using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    // <summary>
    /// no: 1604
    /// title: 警告一小时内使用相同员工卡大于等于三次的人
    /// problems: https://leetcode.cn/problems/alert-using-same-key-card-three-or-more-times-in-a-one-hour-period/
    /// date: 20230207
    /// </summary>
    public static class Solution1604
    {
        public static IList<string> AlertNames(string[] keyName, string[] keyTime) {
            var times = new Dictionary<string, List<int>>();
            int n = keyName.Length;
            for (int i = 0; i < n; i++) {
                string name = keyName[i];
                string time = keyTime[i];
                times.TryAdd(name, new List<int>());
                int hour = (time[0] - '0') * 10 + (time[1] - '0');
                int minute = (time[3] - '0') * 10 + (time[4] - '0');
                times[name].Add(hour * 60 + minute);
            }

            var result = new List<string>();
            foreach(var pair in times) {
                var name = pair.Key;
                var list = pair.Value;
                list.Sort();
                int size = list.Count;
                for (int i = 2; i < size; i++) {
                    int time1 = list[i - 2];
                    int time2 = list[i];
                    int difference = time2 - time1;
                    if (difference <= 60) {
                        result.Add(name);
                        break;
                    }
                }
            }

            result.Sort();
            return result;
        }
    }
}