using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 721
/// title: 账户合并
/// problems: https://leetcode-cn.com/problems/accounts-merge/
/// date: 20240715
/// </summary>
public static partial class Solution721
{
    public static IList<IList<string>> AccountsMerge_2(IList<IList<string>> accounts) {
        int length = accounts.Count;
        var mailMap = new Dictionary<string, int>();
        int[] parent = new int[length];
        for(int i = 0; i < length; i++){
            parent[i] = i;
        }

        int Find(int x)
            => x != parent[x] 
            ? parent[x] = Find(parent[x]) 
            : parent[x];

        for(int i = 0; i < length; i++){
            foreach(var mail in accounts[i].Skip(1)){
                mailMap.TryAdd(mail, i);
                int rootX = Find(mailMap[mail]);
                int rootY = Find(i);

                if(rootX == rootY)
                    continue;
                
                parent[rootY] = rootX;
            }
        }

        var comparer = Comparer<string>.Create(string.CompareOrdinal);
        var result = new Dictionary<int, SortedSet<string>>();
        foreach(var map in mailMap){
            int root = Find(map.Value);
            if(!result.TryGetValue(root, out var value))
            {
                value = new SortedSet<string>(comparer);
                result.Add(root, value);
                // accounts[root][0]
            }

            value.Add(map.Key);
        }
        
        return result
            .Select(x => new List<string>([accounts[x.Key][0],..x.Value]))
            .Cast<IList<string>>()
            .ToList();
    }
}
