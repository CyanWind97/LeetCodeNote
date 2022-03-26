using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 682
    /// title: 棒球比赛
    /// problems: https://leetcode-cn.com/problems/baseball-game/
    /// date: 20220326
    /// </summary>
    public static class Solution682
    {
        public static int CalPoints(string[] ops) {
            var nums = new List<int>();
            
            foreach(var s in ops){
                if(s == "C")
                    nums.RemoveAt(nums.Count - 1);
                else if(s == "D")
                    nums.Add(2 * nums.Last());
                else if(s == "+")
                    nums.Add(nums.Last() + nums[nums.Count - 2]);
                else
                    nums.Add(int.Parse(s));
            }

            return nums.Sum();
        }
    }
}