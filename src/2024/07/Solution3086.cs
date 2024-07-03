using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3086
/// title: 拾起 K 个 1 需要的最少行动次数
/// problems: https://leetcode.cn/problems/minimum-moves-to-pick-k-ones
/// date: 20240704
/// </summary>
public static class Solution3086
{
    // 参考解答
    // 贪心 + 双指针
    public static long MinimumMoves(int[] nums, int k, int maxChanges) {
        int length = nums.Length;
        var (left, right) = (0, -1);
        var (leftSum, rightSum) = (0L, 0L);
        var (leftCount, rightCount) = (0L, 0L);
        long result = long.MaxValue;    

        void F(int i, ref int x)
        {
            if (i >= 2)
                x -= nums[i - 2];
            
            if (i + 1 < length)
                x += nums[i + 1];
        }

        int f = nums[0];
        for(int i = 0; i < length; i++){
            F(i, ref f);

            if(f + maxChanges >= k){
                long value = k <= f
                        ? k - nums[i]
                        : 2L * k - f - nums[i];
                result = Math.Min(result, value);
            }

            if (k <= maxChanges)
                continue;
            
            while(right + 1 < length 
                && (right - i < i - left
                    || leftCount + rightCount + maxChanges < k)){
                
                if (nums[right + 1] == 1){
                    rightCount++;
                    rightSum += right + 1;
                }

                right++;
            }

            while(leftCount + rightCount + maxChanges > k){
                if (right - i < i - left
                || (right - i == i - left && nums[left] == 1)){
                    if (nums[left] == 1){
                        leftCount--;
                        leftSum -= left;
                    }
                    left++;
                } else {
                    if (nums[right] == 1){
                        rightCount--;
                        rightSum -= right;
                    }
                    right--;
                }
            }

            result = Math.Min(result, leftCount * i - leftSum + rightSum - rightCount * i + 2 * maxChanges);
            if (nums[i] == 1){
                leftCount++;
                leftSum += i;
                rightCount--;
                rightSum -= i;
            }
        }

        return result;
    }
}
