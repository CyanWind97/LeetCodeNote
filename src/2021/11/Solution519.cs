using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 519
    /// title: 随机翻转矩阵
    /// problems: https://leetcode-cn.com/problems/random-flip-matrix/
    /// date: 20211127
    /// </summary>
    public static class Solution519
    {
        // 参考解答 将每次随机到的数与最后一位数进行交换
        public class Solution {

            private int _m;

            private int _n;

            private int _count;

            private Random _random;

            private Dictionary<int, int> _dic;

            public Solution(int m, int n) {
                _m = m;
                _n = n;
                _count = m * n;
                _random = new Random();
                _dic = new Dictionary<int, int>();
            }
            
            public int[] Flip() {
                int x = _random.Next(_count);
                _count--;

                int idx = _dic.GetValueOrDefault(x, x);
                int value = _dic.GetValueOrDefault(_count, _count);

                if (_dic.ContainsKey(x))
                    _dic[x] = value;
                else
                    _dic.Add(x, value);

                return new int[] { idx / _n, idx % _n};
            }
            
            public void Reset() {
                _count = _m * _n;
                _dic.Clear();
            }
        }
    }
}