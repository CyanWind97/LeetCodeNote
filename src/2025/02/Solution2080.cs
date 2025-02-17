using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2080
/// title: 区间内查询数字的频率
/// problems: https://leetcode.cn/problems/range-frequency-queries
/// date: 20250218
/// </summary>
public static class Solution2080
{
    public class RangeFreqQuery {
        private Dictionary<int, List<int>> numIndices;

        public RangeFreqQuery(int[] arr) {
            numIndices = new Dictionary<int, List<int>>();
            
            // 记录每个数字出现的所有位置
            for (int i = 0; i < arr.Length; i++) {
                    if (!numIndices.ContainsKey(arr[i])) {
                        numIndices[arr[i]] = new List<int>();
                    }
                    numIndices[arr[i]].Add(i);
                }
            }
            
        public int Query(int left, int right, int value) {
            if (!numIndices.ContainsKey(value)) {
                return 0;
            }

            var indices = numIndices[value];
            
            // 使用二分查找找到第一个大于等于left的位置
            int leftPos = BinarySearch(indices, left, true);
            if (leftPos == -1) return 0;
            
            // 使用二分查找找到最后一个小于等于right的位置
            int rightPos = BinarySearch(indices, right, false);
            if (rightPos == -1) return 0;
            
            return rightPos - leftPos + 1;
        }
        
        private int BinarySearch(List<int> arr, int target, bool isLeft) {
            int left = 0;
            int right = arr.Count - 1;
            
            if (isLeft) {
                // 查找第一个大于等于target的位置
                if (arr[right] < target) return -1;
                if (arr[left] >= target) return 0;
                
                while (left < right) {
                    int mid = left + (right - left) / 2;
                    if (arr[mid] >= target) {
                        right = mid;
                    } else {
                        left = mid + 1;
                    }
                }
                return left;
            } else {
                // 查找最后一个小于等于target的位置
                if (arr[left] > target) return -1;
                if (arr[right] <= target) return right;
                
                while (left < right) {
                    int mid = left + (right - left + 1) / 2;
                    if (arr[mid] <= target) {
                        left = mid;
                    } else {
                        right = mid - 1;
                    }
                }
                return left;
            }
        }
    }
}
