using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2386
/// title: 找出数组的第 K 大和
/// problems: https://leetcode.cn/problems/find-the-k-sum-of-an-array/description/?envType=daily-question&envId=2024-03-09
/// date: 20240309
/// </summary> 
public static class Solution2386
{   
    // 参考解答
    public static long KSum(int[] nums, int k) {
        var length = nums.Length;
        var total = 0L;

        for (var i = 0; i < length; i++){
            if (nums[i] >= 0) 
                total += nums[i];
            else
                nums[i] = -nums[i];
        }

        Array.Sort(nums);

        var result = 0L;
        var pq = new PriorityQueue<(long Sum, int Index), long>();
        pq.Enqueue((nums[0], 0), nums[0]);

        for(int j = 2; j <= k; j++){
            var (sum, index) = pq.Dequeue();
            result = sum;
            if (index == length - 1)
                continue;
            
            var sum1 = sum + nums[index + 1];
            var sum2 = sum - nums[index] + nums[index + 1];
            pq.Enqueue((sum1, index + 1), sum1);
            pq.Enqueue((sum2, index + 1), sum2);
        }

        return total - result;
    }
}
