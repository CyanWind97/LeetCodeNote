using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 380
    /// title: O(1) 时间插入、删除和获取随机元素
    /// problems: https://leetcode-cn.com/problems/insert-delete-getrandom-o1/
    /// date: 20220413
    /// </summary>
    public static class Solution380
    {
        public class RandomizedSet {
            
            private List<int> _nums;
            private Random _random;

            private Dictionary<int, int> _lookup;

            public RandomizedSet() {
                _random = new Random();
                _nums = new List<int>();
                _lookup = new Dictionary<int, int>();
            }
            
            public bool Insert(int val) {
                if(_lookup.ContainsKey(val))
                    return false;

                _lookup.Add(val, _nums.Count);
                _nums.Add(val);

                return true;
            }
            
            // 参考解答，每次Remove最后一位
            public bool Remove(int val) {
                if(!_lookup.ContainsKey(val))
                    return false;

                int index = _lookup[val];
                int last = _nums.Last();
                
                _nums[index] = last;
                _lookup[last] = index;

                _nums.RemoveAt(_nums.Count - 1);
                _lookup.Remove(val);

                return true;
            }
            
            public int GetRandom() {
                var index = _random.Next(_nums.Count);

                return _nums[index];
            }
        }
    }
}