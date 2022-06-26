using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 710
    /// title: 黑名单中的随机数
    /// problems: https://leetcode.cn/problems/random-pick-with-blacklist/
    /// date: 20220626
    /// </summary>
    public static class Solution710
    {
        // 参考解答 映射
        public class Solution {
            private Dictionary<int,int> _b2w;
            private Random _random;

            private int _size;

            public Solution(int n, int[] blacklist) {
                _b2w = new();
                _random = new();
                _size = n - blacklist.Length;

                var black = blacklist.Where(b => b >= _size).ToHashSet();
                int w = _size;
                foreach(var b in blacklist){
                    if(b >= _size)
                        continue;
                    
                    while(black.Contains(w)){
                        w++;
                    }

                    _b2w.Add(b, w);
                    w++;
                }
            }
            
            public int Pick() {
                int x = _random.Next(_size);
                return _b2w.GetValueOrDefault(x, x);
            }
        }
    }
}