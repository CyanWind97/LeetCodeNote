using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 30
/// title: 魔塔游戏
/// problems: https://leetcode.cn/problems/p0NxJO/description/?envType=daily-question&envId=2024-02-06
/// date: 20240206
/// type: lcp
/// </summary>

public static class Solution_lcp_30
{
    public static int MagicTower(int[] nums) {
        int length = nums.Length;
        long hp = 1;
        long lostHp = 0;
        int count = 0;
        var pq = new PriorityQueue<int, int>();

        for(int i = 0; i < length; i++){
            if(nums[i] < 0)
                pq.Enqueue(nums[i], nums[i]);
            
            hp += nums[i];
            
            if(hp <= 0){
                if(pq.Count == 0)
                    return -1;
                
                var min = pq.Dequeue();
                hp -= min;
                lostHp += min;
                count++;
            }
        }

        return hp + lostHp > 0 ? count : -1;
    }
}
