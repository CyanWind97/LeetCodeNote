using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 47
/// title: 全排列 II
/// problems: https://leetcode.cn/problems/permutations-ii
/// date: 20250206
/// </summary>
public static class Solution47
{
    public static IList<IList<int>> PermuteUnique(int[] nums) {
        int length = nums.Length;
        var result = new List<IList<int>>();
        var perm = new List<int>();
        var visited = new bool[length];
        Array.Sort(nums);
        BackTrack(0);

        void BackTrack(int index){
            if(index == length){
                result.Add([.. perm]);

                return;
            }

            for(int i = 0; i < length; i++){
                if(visited[i] || (i > 0 && nums[i] == nums[i - 1] && !visited[i - 1]))
                    continue;
                
                perm.Add(nums[i]);
                visited[i] = true;
                BackTrack(index + 1);
                visited[i] = false;
                perm.RemoveAt(index);
            }
        }

        return result;
    }
}
