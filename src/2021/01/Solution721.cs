using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 721
    /// title: 账户合并
    /// problems: https://leetcode-cn.com/problems/accounts-merge/
    /// date: 20210118
    /// </summary>
    public static partial class Solution721
    {
        public static IList<IList<string>> AccountsMerge(IList<IList<string>> accounts) {
            int length = accounts.Count;
            SortedDictionary<string, int> mailMap = new SortedDictionary<string, int>(new ComparerString());
            int[] parent = new int[length];
            for(int i = 0; i < length; i++){
                parent[i] = i;
            }

            int find(int x){
                if(x != parent[x])
                    parent[x] = find(parent[x]);
                
                return parent[x];
            }

            for(int i = 0; i < length; i++){
                foreach(var mail in accounts[i].Skip(1)){
                    if(!mailMap.ContainsKey(mail))
                        mailMap.Add(mail, i);
                    
                    int rootX = find(mailMap[mail]);
                    int rootY = find(i);

                    if(rootX == rootY)
                        continue;
                    
                    parent[rootY] = rootX;
                }
            }

            Dictionary<int, IList<string>> result = new Dictionary<int, IList<string>>();
            foreach(var map in mailMap){
                int root = find(map.Value);
                if(!result.ContainsKey(root)){
                    result.Add(root, new List<string>());
                    result[root].Add(accounts[root][0]);
                }

                result[root].Add(map.Key);
            }

            return result.Values.ToList();
        }

        private class ComparerString : IComparer<string>
        {
            public int Compare(string x, string y)
            {
                return string.CompareOrdinal(x,y);
            }
        }

        // 缩小排序数量
        public static IList<IList<string>> AccountsMerge_1(IList<IList<string>> accounts) {
            int length = accounts.Count;
            Dictionary<string, int> mailMap = new Dictionary<string, int>();
            int[] parent = new int[length];
            for(int i = 0; i < length; i++){
                parent[i] = i;
            }

            int find(int x){
                if(x != parent[x])
                    parent[x] = find(parent[x]);
                
                return parent[x];
            }

            for(int i = 0; i < length; i++){
                foreach(var mail in accounts[i].Skip(1)){
                    if(!mailMap.ContainsKey(mail))
                        mailMap.Add(mail, i);
                    
                    int rootX = find(mailMap[mail]);
                    int rootY = find(i);

                    if(rootX == rootY)
                        continue;
                    
                    parent[rootY] = rootX;
                }
            }

            Dictionary<int, IList<string>> result = new Dictionary<int, IList<string>>();
            foreach(var map in mailMap){
                int root = find(map.Value);
                if(!result.ContainsKey(root)){
                    result.Add(root, new List<string>());
                    result[root].Add(accounts[root][0]);
                }

                result[root].Add(map.Key);
            }

            return result.Values
                        .Select(x => (IList<string>)x.OrderBy(x => x, new ComparerString()))
                        .ToList();
        }
    }
}