using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2007
/// title: 从双倍数组中还原原数组
/// problems: https://leetcode.cn/problems/find-original-array-from-doubled-array
/// date: 20240418
/// </summary>
public class Solution2007
{
    public static int[] FindOriginalArray(int[] changed) {
        int length = changed.Length;
        if(length % 2 != 0)
            return Array.Empty<int>();

        Array.Sort(changed);
        var count = new Dictionary<int, int>();
        var result = new List<int>();
        foreach(var num in changed){
            if(count.TryGetValue(num, out int value) && value > 0)
                count[num]--;
            else {
                result.Add(num);
                count.TryAdd(num * 2, 0);
                count[num * 2]++;
            }
        }

        return count.Values.All(x => x == 0) 
            ? result.ToArray() 
            : Array.Empty<int>();
    }
}
