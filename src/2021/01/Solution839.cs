using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 839
    /// title: 相似字符串组
    /// problems: https://leetcode-cn.com/problems/similar-string-groups/
    /// date: 20210131
    /// </summary>
    public static class Solution839
    {
        public static int NumSimilarGroups(string[] strs) {
            int length = strs.Length;
            int[] parent = new int[length];
            int setCount = length;
            var map = new Dictionary<string, List<int>>();
            int Find(int x) => x == parent[x] ? x : parent[x] = Find(parent[x]);
            int CompareUnion(int x, int y){
                int rootX = Find(x);
                int rootY = Find(y);

                if(rootX == rootY)
                    return 1;
                
                char[] charsX = strs[x].ToCharArray();
                char[] charsY = strs[y].ToCharArray();
                int diff = 0;
                int n = charsX.Length;
                for(int i = 0; i < n; i++){
                    if(charsX[i] != charsY[i])
                        diff++;
                    
                    if(diff > 2)
                        return -1;
                }

                parent[rootX] = rootY;
                setCount--;

                return diff;
            }

            for(int i = 0; i < length; i++){
                parent[i] = i;
                string key = new string(strs[i].ToCharArray().OrderBy(x => x).ToArray());
                if(!map.ContainsKey(key))
                    map[key] = new List<int>();
                
                int compare = -1;
                foreach(var index in map[key]){
                    compare = CompareUnion(i, index);
                    if(0 == compare)
                        break;
                }

                if(0 != compare)
                    map[key].Add(i);
            }

            return setCount;
        }
    }
}