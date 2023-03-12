using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2383
    /// title: 赢得比赛需要的最少训练时长
    /// problems: https://leetcode.cn/problems/minimum-hours-of-training-to-win-a-competition/
    /// date: 20230313
    /// </summary>
    public static class Solution2383
    {
        public static int MinNumberOfHours(int initialEnergy, int initialExperience, int[] energy, int[] experience) {
            int needEnergy = energy.Sum() + 1;
            int hours =  Math.Max(needEnergy, initialEnergy) - initialEnergy;
            int curExp = initialExperience;

            foreach(var exp in experience){
                if(curExp <= exp){
                    int diff = exp - curExp + 1;
                    hours += diff;
                    curExp += diff;
                }
                
                curExp += exp;
            }

            return hours;
        }
    }
}