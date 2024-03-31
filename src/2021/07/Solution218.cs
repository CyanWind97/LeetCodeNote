using System;
using System.Collections.Generic;

namespace LeetCodeNote
{

    /// <summary>
    /// no: 218
    /// title: 天际线问题
    /// problems: https://leetcode-cn.com/problems/the-skyline-problem/
    /// date: 20210713
    /// </summary>
    public static class Solution218
    {
        // 参考解答 排序 红黑树 扫描
        public static IList<IList<int>> GetSkyline(int[][] buildings) {
            var ans = new List<IList<int>>();//返回列表
            var all = new List<int[]>();//总排序列表
            var high = new SortedSet<int>();//高度红黑树
            var highDic = new Dictionary<int, int>();//记录高度次数
            foreach (var item in buildings)
            {
                all.Add(new int[2] { item[0], -item[2] });//高度取负表示是开始
                all.Add(new int[2] { item[1], item[2] });//高度取正表示是结束
            }
            all.Sort((x, y) => x[0] == y[0] ? x[1] - y[1] : x[0] - y[0]);//排序，注意先加入后删除
            foreach (var item in all)
            {
                int o = high.Max, h = item[1];
                if (h < 0)//加入标记
                {
                    if (!highDic.ContainsKey(-h)) highDic[-h] = 0;
                    highDic[-h]++;
                    high.Add(-h);
                }
                else//删除标记
                {
                    highDic[h]--;
                    if (highDic[h] <= 0) high.Remove(h);
                }
                int c = high.Max;
                if (o != c) ans.Add(new List<int> { item[0], c });//最大高度发生改变时进行记录
            }
            return ans;
        }

        
    }
}