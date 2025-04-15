using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2537
/// title: 统计好子数组的数目
/// problems: https://leetcode.cn/problems/count-the-number-of-good-subarrays
/// date: 20250416
/// </summary>
public static class Solution2537
{
    public static long CountGood(int[] nums, int k) {
        int n = nums.Length;
        Dictionary<int, int> count = new Dictionary<int, int>();
        long result = 0;
        long pairs = 0; // 当前窗口中的配对数
        
        int left = 0;
        for (int right = 0; right < n; right++) {
            // 添加右边界元素并更新配对数
            if (count.ContainsKey(nums[right])) {
                // 新增的配对数是当前元素的出现次数
                pairs += count[nums[right]];
                count[nums[right]]++;
            } else {
                count[nums[right]] = 1;
            }
            
            // 当配对数满足条件时，尝试收缩左边界
            while (left <= right && pairs >= k) {
                // 对于以right为右边界的子数组，从当前left开始的所有可能的左边界都能形成好子数组
                // 这里加上从left到n-1共有n-left个位置
                result += n - right;
                
                // 移除左边界元素并更新配对数
                count[nums[left]]--;
                pairs -= count[nums[left]]; // 减少的配对数等于剩余的出现次数
                
                left++;
                
                // 如果某个元素计数为0，可以移除它
                if (count[nums[left - 1]] == 0) {
                    count.Remove(nums[left - 1]);
                }
            }
        }
        
        return result;
    }
}
