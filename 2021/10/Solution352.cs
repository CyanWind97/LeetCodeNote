using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 352
    /// title: 将数据流变为多个不相交区间
    /// problems: https://leetcode-cn.com/problems/data-stream-as-disjoint-intervals/
    /// date: 20211009
    /// </summary>
    public static class Solution352
    {
        public class SummaryRanges {
            List<int[]> _list;
            
            public SummaryRanges() {
                _list = new List<int[]>();
            }
            
            public void AddNum(int val) {
                var tmp = _list.Select(x => x[1]).ToList();
                var index = tmp.BinarySearch(val);

                if (index >= 0)
                    return;

                index = ~index;

                if (index < tmp.Count && val >= _list[index][0])
                    return;

                bool joinLeft = index > 0 && _list[index - 1][1] == val - 1;
                bool joinRight = index < tmp.Count && _list[index][0] == val + 1;

                if (joinLeft && joinRight){
                    _list[index - 1][1] = _list[index][1];
                    _list.RemoveAt(index);
                }else if (joinLeft){
                    _list[index - 1][1] = val;
                }else if (joinRight){
                    _list[index][0] = val;
                }else{
                    _list.Insert(index, new int[]{val, val});
                }
            }
            
            public int[][] GetIntervals() {
                return _list.ToArray();
            }
        }

    }
}