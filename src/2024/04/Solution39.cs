using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;


/// <summary>
/// no: 39
/// title:  组合总和
/// problems: https://leetcode.cn/problems/combination-sum/
/// date: 20240420
public static partial class Solution39
{
    public static IList<IList<int>> CombinationSum_1(int[] candidates, int target) {
        int length = candidates.Length;
        var result = new List<IList<int>>();
        var combine = new List<int>();

        void DFS(int value, int index){
            if(index == length)
                return;
            
            if(value == 0){
                result.Add(new List<int>(combine));
                return;
            }

            // 跳过
            DFS(value, index + 1);
            // 选择
            if(value - candidates[index] >= 0){
                combine.Add(candidates[index]);
                DFS(value - candidates[index], index);
                combine.RemoveAt(combine.Count - 1);
            }
        }

        DFS(target, 0);

        return result;
    } 
}
