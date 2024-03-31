using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1053
    /// title: 交换一次的先前排列
    /// problems: https://leetcode.cn/problems/previous-permutation-with-one-swap/
    /// date: 20230403
    /// </summary>
    public static class Solution1053
    {
        public static int[] PrevPermOpt1(int[] arr) {
            int length = arr.Length;
            for(int i = length - 2; i >= 0; i--){
                if(arr[i] <= arr[i + 1])
                    continue;

                int j = length - 1;
                while(arr[j] >= arr[i] || arr[j] == arr[j - 1]){
                    j--;
                }

                (arr[i], arr[j]) = (arr[j], arr[i]);
                break;
            }

            return arr;
        }
    }
}