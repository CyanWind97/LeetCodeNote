using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 554
    /// title: 砖墙
    /// problems: https://leetcode-cn.com/problems/brick-wall/
    /// date: 20210502
    /// </summary>
    public static class Solution554
    {
        public static int LeastBricks(IList<IList<int>> wall) {
            Dictionary<int,int> dic = new Dictionary<int, int>();
            foreach(var widths in wall) {
                int length = widths.Count;
                int sum = 0;
                for(int i = 0; i < length - 1; i++){
                    sum += widths[i];
                    if(!dic.ContainsKey(sum))
                        dic[sum] = 0;
                    
                    dic[sum]++;
                }
            }

            int max = 0;
            foreach(var pair in dic){
                max = Math.Max(max, pair.Value);
            }

            return wall.Count - max;
        }
    }
}