using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2306
/// title: 公司命名
/// problems: https://leetcode.cn/problems/naming-a-company
/// date: 20240925
/// </summary>
public static class Solution2306
{
    // 参考解答
    // 按照首字母进行分组
    public static long DistinctNames(string[] ideas) {
        var names = new Dictionary<char, HashSet<string>>();
        foreach(var idea in ideas){
            names.TryAdd(idea[0], []);
            names[idea[0]].Add(idea[1..]);
        }

        var result = 0L;
        foreach(var (preA, setA) in names){
            foreach(var (preB, setB) in names){
                if(preA == preB)
                    continue;
                
                int count = 0;
                
                result += (long)(setA.Count - count) * (setB.Count - count);
            }
        }

        return result;
    }
}
