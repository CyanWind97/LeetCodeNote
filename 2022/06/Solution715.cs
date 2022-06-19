using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 715
    /// title: Range 模块
    /// problems: https://leetcode.cn/problems/range-module/
    /// date: 20220620
    /// </summary>
    public static class Solution715
    {
        public class RangeModule {
            
            // 用列表来表示区间
            // [l1, r1, l2, r2, ...]
            private List<int> _intervals;

            public RangeModule() {
                _intervals = new();
            }
            
            public void AddRange(int left, int right) {                
                var leftIndex = _intervals.BinarySearch(left);
                var rightIndex = _intervals.BinarySearch(right);

                // left != right 可能的情况只有都下标小于0的情况
                if (leftIndex == rightIndex){
                    leftIndex = ~leftIndex;
                    // 不在已有区间内，才插入区间
                    if(leftIndex % 2 == 0){
                        _intervals.Insert(leftIndex, right);
                        _intervals.Insert(leftIndex, left);
                    }

                    return;
                }

                if (leftIndex < 0)
                    leftIndex = ~leftIndex;

                // left的下标为奇数时，表示left的值已经被覆盖，找到left所在区间的左边界
                // 为偶数时，更新已有区间的左边界                
                if (leftIndex % 2 == 1)
                    leftIndex--;
                else
                    _intervals[leftIndex] = left;

                if (rightIndex < 0){
                    rightIndex = ~rightIndex;
                    
                    // right值不在已有区间内时，更新最近区间的右边界
                    if(rightIndex % 2 == 0){
                        rightIndex--;
                        _intervals[rightIndex] = right;
                    }
                }else if(rightIndex % 2 == 0){ 
                    // right值与已有区间左边界重合时，合并区间
                    rightIndex++;
                }

                // 合并区间
                _intervals.RemoveRange(leftIndex + 1, rightIndex - leftIndex - 1);
            }
            
            public bool QueryRange(int left, int right) {
                var leftIndex = _intervals.BinarySearch(left);
                var rightIndex = _intervals.BinarySearch(right);

                if(leftIndex < 0)
                    leftIndex = ~leftIndex - 1;
                
                if(rightIndex < 0)
                    rightIndex = ~rightIndex;
                
                // 判断是否在同一区间内
                return rightIndex % 2 == 1 && rightIndex - leftIndex == 1;
            }
            
            public void RemoveRange(int left, int right) {
                var leftIndex = _intervals.BinarySearch(left);
                var rightIndex = _intervals.BinarySearch(right);

                // left != right 可能的情况只有都下标小于0的情况
                if (leftIndex == rightIndex){
                    leftIndex = ~leftIndex;
                    // 落在已有区间内，才拆分区间
                    if(leftIndex % 2 == 1){
                        _intervals.Insert(leftIndex, right);
                        _intervals.Insert(leftIndex, left);
                    }

                    return;
                }

                if(leftIndex < 0)
                    leftIndex = ~leftIndex;

                // left的下标为偶数时，表示与找到上一个区间的右边界
                // 为奇数时，更新已有区间右边界
                if(leftIndex % 2 == 0)
                    leftIndex--;
                else
                    _intervals[leftIndex] = left;
                
                
                if(rightIndex < 0){
                    rightIndex = ~rightIndex;
                    // right值在已有区间内，更新所在区间左边界
                    if(rightIndex % 2 == 1){
                        rightIndex--;
                        _intervals[rightIndex] = right;
                    }
                }else if (rightIndex % 2 == 1){
                    // right值与已有区间右边界重合时，找到下一个区间的左边界
                    rightIndex++;
                }

                // 合并区间
                _intervals.RemoveRange(leftIndex + 1, rightIndex - leftIndex - 1);
            }
            
        }
    }
}