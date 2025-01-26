using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 45
/// title: 跳跃游戏 II
/// problems: https://leetcode.cn/problems/jump-game-ii
/// date: 20250127
/// </summary>
public static class Solution45
{
    public static int Jump(int[] nums) {
        int length = nums.Length;
        // 如果数组长度为1，不需要跳跃
        if (length == 1) return 0;
        
        int jumps = 0;          // 跳跃次数
        int curCover = 0;       // 当前位置能覆盖的最远距离
        int maxCover = 0;       // 从当前位置能跳到的最远距离
        
        // 最后一个位置不需要处理，因为已经到达目标
        for (int i = 0; i < length - 1; i++) {
            // 更新从当前位置能跳到的最远距离
            maxCover = Math.Max(maxCover, i + nums[i]);
            
            // 到达当前跳跃能覆盖的最远距离，需要进行下一跳
            if (i == curCover) {
                jumps++;
                curCover = maxCover;
                // 如果已经可以到达最后位置，不需要继续遍历
                if (curCover >= length - 1) {
                    break;
                }
            }
        }
        
        return jumps;
    }
}
