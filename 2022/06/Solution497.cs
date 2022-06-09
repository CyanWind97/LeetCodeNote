using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 497
    /// title: 非重叠矩形中的随机点
    /// problems: https://leetcode.cn/problems/random-point-in-non-overlapping-rectangles/
    /// date: 20220609
    /// </summary>
    public static class Solution497
    {
        // 参考解答 前缀和 二分查找
        public class Solution {
            private Random _rand;
            private List<int> _arr;

            private int[][] _rects;

            public Solution(int[][] rects) {
                _rand = new();
                _arr = new List<int>();
                _arr.Add(0);
                _rects = rects;
                foreach(var rect in rects){
                    int a = rect[0], b = rect[1], x = rect[2], y = rect[3];
                    _arr.Add(_arr.Last() + (x - a + 1) * (y - b + 1));
                }
            }
            
            public int[] Pick() {
                int k = _rand.Next(_arr.Last());
                int rectIndex = _arr.BinarySearch(k + 1);
                if(rectIndex < 0)
                    rectIndex = ~rectIndex;
                
                rectIndex--;

                k -= _arr[rectIndex];
                int[] rect = _rects[rectIndex];
                int a = rect[0], b = rect[1], y = rect[3];
                int col = y - b + 1;
                int da = k / col;
                int db = k - col * da;

                return new int[]{a + da, b + db};
            }
        }
    }
}