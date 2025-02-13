using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 1552
/// title: 两球之间的磁力
/// problems: https://leetcode.cn/problems/magnetic-force-between-two-balls
/// date: 20250214
/// </summary>
public static class Solution1552
{
    public static int MaxDistance(int[] position, int m) {
        Array.Sort(position);

        bool Check(int force) {
            int count = 1; // 第一个球放在第一个位置
            int prev = position[0];
            
            for (int i = 1; i < position.Length; i++) {
                if (position[i] - prev >= force) {
                    count++;
                    prev = position[i];
                }
            }
            
            return count >= m;
        }

        int n = position.Length;
    
        // 二分查找的左右边界
        int left = 1;
        int right = position[n - 1] - position[0];
        int ans = -1;
        
        // 二分查找过程
        while (left <= right) {
            int mid = left + (right - left) / 2;
            
            // 如果当前的最小距离mid可行，尝试更大的距离
            if (Check(mid)) {
                ans = mid;
                left = mid + 1;
            } else {
                // 如果不可行，需要减小距离
                right = mid - 1;
            }
        }
        
        return ans;
    }
}
