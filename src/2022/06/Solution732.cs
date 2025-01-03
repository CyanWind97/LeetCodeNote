using System;
using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 732
    /// title: 我的日程安排表 III
    /// problems: https://leetcode.cn/problems/my-calendar-iii/
    /// date: 20220606
    /// </summary>
    public static partial class Solution732
    {
        // 参考解答 线段树
        public class MyCalendarThree {

            private Dictionary<int, (int Start, int End)> _tree;

            public MyCalendarThree() {
                _tree = new ();
            }
            
            public int Book(int start, int end) {
                Update(start, end - 1, 0 , 1000000000, 1);
                return _tree[1].Start;
            }

            private void Update(int start, int end, int l, int r, int idx){
                if (r < start || end < l)
                    return;
                
                if (start <= l && r <= end){
                    if(!_tree.ContainsKey(idx))
                        _tree.Add(idx, (0, 0));
                    
                    _tree[idx] = (_tree[idx].Start + 1, _tree[idx].End + 1);
                } else {
                    int mid = (l + r) / 2;
                    Update(start, end, l, mid, 2 * idx);
                    Update(start, end, mid + 1, r, 2 * idx + 1);
                    if (!_tree.ContainsKey(idx))
                        _tree.Add(idx, (0, 0));
                    
                    if(!_tree.ContainsKey(2 * idx))
                        _tree.Add(2 * idx, (0, 0));
                    
                    if(!_tree.ContainsKey(2 * idx + 1))
                        _tree.Add(2 * idx + 1, (0, 0));
                    
                    var tmp = _tree[idx].End + Math.Max(_tree[2 * idx].Start, _tree[2 * idx + 1].Start);
                    _tree[idx] = (tmp, _tree[idx].End);
                }
            }
        }
    }
}