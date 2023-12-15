using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2276
    /// title: 统计区间中的整数数目
    /// problems: https://leetcode.cn/problems/count-integers-in-intervals/description/?envType=daily-question&envId=2023-12-16
    /// date: 20231216
    /// </summary>
    public static class Solution2276
    {
        // 参考解答 线段树
        public class CountIntervals {
            
            private CountIntervals _left;
            private CountIntervals _right;
            private int _count;
            private int _l = 1;
            private int _r = 1_000_000_000;

            public CountIntervals() {

            }

            public CountIntervals(int l, int r) => (_l, _r) = (l, r);
            
            public void Add(int left, int right) {
                if (_count == _r - _l + 1) 
                    return;
                
                if (left <= _l && _r <= right){
                    _count = _r - _l + 1;
                    return;
                }

                int mid = (_l + _r) / 2;
                _left ??= new CountIntervals(_l, mid);
                _right ??= new CountIntervals(mid + 1, _r);
                if (left <= mid) 
                    _left.Add(left, right);
                
                if (right > mid)
                    _right.Add(left, right);
                
                _count = _left.Count() + _right.Count();
            }
            
            public int Count() {
                return _count;
            }
        }
    }
}