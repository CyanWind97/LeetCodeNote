using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1436
    /// title: 旅行终点站
    /// problems: https://leetcode-cn.com/problems/destination-city/
    /// date: 20211001
    /// </summary>

    public static class Solution1436
    {
        public static string DestCity(IList<IList<string>> paths) {
            var cities = new HashSet<string>();
            foreach (var path in paths) {
                cities.Add(path[0]);
            }
            foreach (var path in paths) {
                if (!cities.Contains(path[1])) {
                    return path[1];
                }
            }
            return "";
        }
    }
}