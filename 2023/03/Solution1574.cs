using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1574
    /// title: 删除最短的子数组使剩余数组有序
    /// problems: https://leetcode.cn/problems/shortest-subarray-to-be-removed-to-make-array-sorted/
    /// date: 20230325
    /// </summary>
    public static class Solution1574
    {
        public static int FindLengthOfShortestSubarray(int[] arr) {
            int length = arr.Length;
            int right = length - 1;
            while(right > 0 && arr[right - 1] <= arr[right]){
                right--;
            }

            if(right == 0)
                return 0;
            
            int result = right;
            for(int left = 0; left < length; left++){
                while(right < length && arr[right] < arr[left]){
                    right++;
                }

                result = Math.Min(result, right - left - 1);
                if(left + 1 < length && arr[left] > arr[left + 1] )
                    break;
            }

            return result;
        }
    }
}