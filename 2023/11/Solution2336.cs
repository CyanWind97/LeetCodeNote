using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    
    /// <summary>
    /// no: 2336
    /// title: 无限集中的最小数字
    /// problems: https://leetcode.cn/problems/smallest-number-in-infinite-set/description/?envType=daily-question&envId=2023-11-29
    /// date: 20231129
    /// </summary>
    public static class Solution2336
    {
        public class SmallestInfiniteSet {

            private int _currPos = 1;

            private SortedSet<int> _set = new SortedSet<int>();

            public SmallestInfiniteSet() {
            }
            
            public int PopSmallest() {
                if (_set.Count == 0)
                    return _currPos++;
                
                int min = _set.Min;
                _set.Remove(min);
                
                return min;
            }
            
            public void AddBack(int num) {
                if (num >= _currPos)
                    return;
                
                if (!_set.Contains(num))
                    _set.Add(num);
            }
        }
    }
}