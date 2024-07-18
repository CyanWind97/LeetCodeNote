using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 3096
/// title: 得到更多分数的最少关卡数目
/// problems: https://leetcode.cn/problems/minimum-levels-to-gain-more-points
/// date: 20240719
/// </summary>
public static class Solution3096
{
    public static int MinimumLevels(int[] possible) {
        int length = possible.Length;
        int alice = 0;
        int bob = 0;

        int min = 1;        
        alice += possible[0] == 0 ? -1 : 1;
    
        for(int i = 1; i < length; i++){
            bob += possible[i] == 0 ? -1 : 1;
        }

        while(min < length - 1 && alice <= bob){
            int score = possible[min] == 0 ? -1 : 1;
            alice += score;
            bob -= score;
            min++;
        }

        return alice > bob ? min : -1;
    }
}
