using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

///<summary>
/// no: 1535
/// title: 找出数组游戏的赢家
/// problems: https://leetcode.cn/problems/find-the-winner-of-an-array-game
/// date: 20240519
/// </summary>
public static class Solution1535
{
    public static int GetWinner(int[] arr, int k) {
        int length = arr.Length;
        int count = 0;
        int max = arr[0];
        for(int i = 1; i < length; i++){
            if(arr[i] > max){
                max = arr[i];
                count = 1;
            }else{
                count++;
            }

            if(count == k)
                return max;
        }

        return max;
    }
}
