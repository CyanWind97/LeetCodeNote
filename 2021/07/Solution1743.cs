using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1743
    /// title: 从相邻元素对还原数组
    /// problems: https://leetcode-cn.com/problems/restore-the-array-from-adjacent-pairs/
    /// date: 20210725
    /// </summary>
    public static class Solution1743
    {
        public static int[] RestoreArray(int[][] adjacentPairs) {
            var dic = new Dictionary<int, IList<int>>();
            foreach(var pair in adjacentPairs)
            {
                if(!dic.ContainsKey(pair[0]))
                    dic.Add(pair[0], new List<int>(2));
                
                if(!dic.ContainsKey(pair[1]))
                    dic.Add(pair[1], new List<int>(2));
                
                dic[pair[0]].Add(pair[1]);
                dic[pair[1]].Add(pair[0]);
            }

            int length = adjacentPairs.Length;
            int[] result = new int[length + 1];
            result[0] = dic.First(x => x.Value.Count() == 1).Key;
            result[1] = dic[result[0]][0];
            for(int i = 2; i <= length; i++){
                var list = dic[result[i - 1]];
                result[i] = result[i - 2] == list[0] ? list[1] : list[0];
            }

            return result;
        }
    }
}