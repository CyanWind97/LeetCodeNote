using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 682
/// title: 棒球比赛
/// problems: https://leetcode-cn.com/problems/baseball-game/
/// date: 20240729
/// </summary>
public static partial class Solution682
{

    public static int CalPoints(string[] operations) {
        var nums = new List<int>();
        
        foreach(var s in operations){
            if(s == "C")
                nums.RemoveAt(nums.Count - 1);
            else if(s == "D")
                nums.Add(2 * nums[^1]);
            else if(s == "+")
                nums.Add(nums[^1] + nums[^2]);
            else
                nums.Add(int.Parse(s));
        }

        return nums.Sum();
    }
}
