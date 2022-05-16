using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 691
    /// title: 贴纸拼词
    /// problems: https://leetcode.cn/problems/stickers-to-spell-word/
    /// date: 20220514
    /// </summary>
    public static class Solution691
    {
        public static int MinStickers(string[] stickers, string target) {
            var map = new Dictionary<char, int>();
            var targetKey = new List<int>();
            
            foreach(var c in target){
                if(!map.ContainsKey(c)){
                    map.Add(c, targetKey.Count);
                    targetKey.Add(1);
                }else{
                    targetKey[map[c]]++;
                }
            }
            
            # region init 

            int keyLength = targetKey.Count;
            var visited = new bool[keyLength];
            var validKeys = new List<int[]>();
            var keySet = new HashSet<int[]>(validKeys, new IntSequenceComparer());

            foreach(var sticker in stickers){
                var key = new int[keyLength];
                
                foreach(var c in sticker){
                    if(map.ContainsKey(c)){
                        int index = map[c];
                        visited[index] = true;
                        
                        // 数量超过忽略，减少validkeys的数量
                        if(key[index] < targetKey[index])
                            key[index]++;
                    }                
                }

                // 没有需要的字符
                if(key.All(count => count == 0))
                    continue;
                
                // 减少validkeys的数量
                if(keySet.Add(key))
                    validKeys.Add(key);
            }

            // 有字符不存在
            if(visited.Any(x => !x))
                return -1;

            #region 去除被覆盖的Key
            var revmoveIndexs = new HashSet<int>();
            var tmp = validKeys.Select(key => (key, key.Count(count => count > 0)))
                                    .OrderByDescending(x => x.Item2)
                                    .ToList<(int[] Key, int Count)>();

            bool IsCover(int[] key, int[] target)
                => Enumerable.Range(0, keyLength)
                        .All(i => key[i] >= target[i]);
            
            for(int i = 0; i < tmp.Count; i++){
                for(int j = tmp.Count - 1; j > i; j--){
                    if(revmoveIndexs.Contains(j))
                        continue;
                    
                    if(IsCover(tmp[i].Key, tmp[j].Key))
                        revmoveIndexs.Add(j);
                }
            }
        
            foreach(var index in revmoveIndexs.AsEnumerable().OrderByDescending(x => x)){
                tmp.RemoveAt(index);
            }

            validKeys = tmp.Select(x => x.Key).ToList();

            #endregion

            #endregion

            bool IsNeed(int[] key, int[] need)
                => Enumerable.Range(0, keyLength)
                        .Any(i => key[i] > 0 && need[i] > 0);
            
            int CalcDis(int[] key)
                => Enumerable.Range(0, keyLength)
                        .Aggregate(0, (sum, i) => sum + Math.Max(targetKey[i] - key[i], 0));
            
            int[] Sum(int[] key1, int[] key2)
                => Enumerable.Range(0, keyLength)
                        .Select(i => Math.Min(key1[i] + key2[i], targetKey[i]))
                        .ToArray();
             
            IEnumerable<int[]> GetNext(int[] key){
                var need = Enumerable.Range(0, keyLength)
                                .Select(i => targetKey[i] - key[i])
                                .ToArray();

                foreach(var validKey in validKeys){
                    if(!IsNeed(validKey, need))
                        continue;
                    
                    var nextKey = Sum(key, validKey);
                    if(!keySet.Add(nextKey))
                        continue;
                    
                    yield return nextKey;
                }
            }

            var queue = new PriorityQueue<(int[] CurKey, int Count, int Dis), int>();

            foreach(var validKey in validKeys){
                var dis = CalcDis(validKey);
                queue.Enqueue((validKey, 1, dis), 6 * 1 + dis);
            }

            while(queue.Count > 0){
                (var curKey, int count, int dis) = queue.Dequeue();
                if(dis == 0)
                    return count;
                
                foreach(var next in GetNext(curKey)){
                    var nextDis = CalcDis(next);
                    queue.Enqueue((next, count + 1, nextDis), 6 * (count + 1) + dis);
                }
            }

            return -1;
        }

        internal class IntSequenceComparer : IEqualityComparer<int[]>
        {
            public bool Equals(int[] x, int[] y)
                => x.SequenceEqual(y);

            public int GetHashCode([DisallowNull] int[] obj)
                => 0;
        }

        // 参考解答 记忆搜索 + 状态压缩
        public static int MinStickers_1(string[] stickers, string target) {
            int m = target.Length;
            int[] memo = new int[1 << m];
            Array.Fill(memo, -1);
            memo[0] = 0;

            int DP(int mask){
                if(memo[mask] < 0){
                    memo[mask] = m + 1;
                    foreach(var sticker in stickers){
                        int left = mask;
                        int[] count = new int[26];
                        int length = sticker.Length;
                        for(int i = 0; i < length; i++){
                            count[sticker[i] - 'a']++;
                        }

                        for(int i = 0; i < m; i++){
                            var c = target[i];
                            if(((mask >> i) & 1) == 1 && count[c - 'a'] > 0){
                                count[c - 'a']--;
                                left ^= 1 << i;
                            }
                        }

                        if(left < mask)
                            memo[mask] = Math.Min(memo[mask], DP(left) + 1);
                    }
                }

                return memo[mask];
            }

            int result = DP((1 << m) - 1);
            return result <= m ? result : - 1;
        }
    }
}