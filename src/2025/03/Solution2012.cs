using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;


/// <summary>
/// no: 2012
/// title: 数组美丽值求和
/// problems: https://leetcode.cn/problems/sum-of-beauty-in-the-array
/// date: 20250311
/// </summary>
public static class Solution2012
{
    public static int SumOfBeauties(int[] nums) {
        int n = nums.Length;
        int[] leftMax = new int[n]; // 记录左侧的最大值
        int[] rightMin = new int[n]; // 记录右侧的最小值
        
        // 计算每个位置左边的最大值
        leftMax[0] = nums[0];
        for (int i = 1; i < n; i++) {
            leftMax[i] = Math.Max(leftMax[i - 1], nums[i - 1]);
        }
        
        // 计算每个位置右边的最小值
        rightMin[n - 1] = nums[n - 1];
        for (int i = n - 2; i >= 0; i--) {
            rightMin[i] = Math.Min(rightMin[i + 1], nums[i + 1]);
        }
        
        // 计算美丽值总和
        int sum = 0;
        for (int i = 1; i < n - 1; i++) {
            if (nums[i] > leftMax[i] && nums[i] < rightMin[i]) {
                // 所有左侧元素都小于nums[i]，且所有右侧元素都大于nums[i]
                sum += 2;
            }
            else if (nums[i] > nums[i - 1] && nums[i] < nums[i + 1]) {
                // 只满足相邻元素条件
                sum += 1;
            }
            // 其他情况美丽值为0，不增加sum
        }
        
        return sum;
    }
}
