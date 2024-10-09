using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3171
/// title: 到按位或最接近 K 的子数组
/// problems: https://leetcode.cn/problems/find-subarray-with-bitwise-or-closest-to-k
/// date: 20241009
/// </summary>
public static class Solutin3171
{
    public static int MinimumDifference(int[] nums, int k) {
        int length = nums.Length;
        var maxPos = Enumerable.Repeat(-1, 31).ToArray();
        int result = int.MaxValue;
        var posToBit = new List<(int MaxPos, int Pos)>();
        for (int i = 0; i < length; i++) {
            for (int j = 0; j < 31; j++) {
                if ((nums[i] >> j & 1) != 0) 
                    maxPos[j] = i;
            }
            
            posToBit.Clear();
            for(int j = 0; j < 31; j++){
                if (maxPos[j] != -1) 
                    posToBit.Add((maxPos[j], j));
            }

            posToBit = posToBit.OrderByDescending(x => x.MaxPos)
                        .ThenByDescending(x => x.Pos) 
                        .ToList();

            int val = 0;
            for (int j = 0, p = 0; j < posToBit.Count;) {
                while(j < posToBit.Count && posToBit[j].MaxPos == posToBit[p].MaxPos) {
                    val |= 1 << posToBit[j].Pos;
                    j++;
                }

                result = Math.Min(result, Math.Abs(val - k));
                p = j;
            }
        }

        return result;
    }
}
