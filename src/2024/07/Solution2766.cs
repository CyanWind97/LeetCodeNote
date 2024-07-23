using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2766
/// title: 新放置石块
/// problems: https://leetcode.cn/problems/find-the-sum-of-subsequence-powers
/// date: 20240724
/// </summary>
public static class Solution2766
{
    public static IList<int> RelocateMarbles(int[] nums, int[] moveFrom, int[] moveTo) {
        var map = new Dictionary<int, int>();
        var reMap = new Dictionary<int, List<int>>();
        int length = moveFrom.Length;

        for(int i = 0; i < length; i++){
            var (from, to) = (moveFrom[i], moveTo[i]);
            if (from == to)
                continue;

            if (!reMap.ContainsKey(to))
                reMap[to] = [];

            if (!map.ContainsKey(from)){
                map[from] = to;
                reMap[to].Add(from);
            }

            if (reMap.ContainsKey(from)){
                foreach(var item in reMap[from]){
                    map[item] = to;
                    reMap[to].Add(item);
                }

                reMap.Remove(from);
            }
        }

        return nums.Select(x => map.GetValueOrDefault(x, x))
            .Distinct()
            .OrderBy(x => x)
            .ToList();
    }

    public static IList<int> RelocateMarbles_1(int[] nums, int[] moveFrom, int[] moveTo) {
        int length = moveFrom.Length;
        var visited = new HashSet<int>();
        var reMap = new Dictionary<int, List<int>>();

        for(int i = 0; i < length; i++){
            var (from, to) = (moveFrom[i], moveTo[i]);
            if (from == to)
                continue;

            if (!reMap.ContainsKey(to))
                reMap[to] = [];

            if (visited.Add(from))
                reMap[to].Add(from);
                
            if (reMap.ContainsKey(from)){
                reMap[to].AddRange(reMap[from]);
                reMap.Remove(from);
            }

        }

        var map = reMap.SelectMany(x => x.Value.Select(y => (Key: y, Value: x.Key)))
            .ToDictionary(x => x.Key, x => x.Value);

        return nums.Select(x => map.GetValueOrDefault(x, x))
            .Distinct()
            .OrderBy(x => x)
            .ToList();
    }
    
    // 直接HashSet
    public static IList<int> RelocateMarbles_2(int[] nums, int[] moveFrom, int[] moveTo) {
        var set = new SortedSet<int>(nums);
        int length = moveFrom.Length;

        for(int i = 0; i < length; i++){
            var (from, to) = (moveFrom[i], moveTo[i]);
            if (from == to)
                continue;

            set.Remove(from);
            set.Add(to);
        }

        return [.. set];
    }
}
