using System;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 189
    /// title:  轮转数组
    /// problems: https://leetcode.cn/problems/rotate-array/
    /// date: 20220516
    /// priority: 0068
    /// time: 00:17:11.36
    /// </summary> 
    public static class CodeTop189
    {
        public static void Rotate(int[] nums, int k) {
            int length = nums.Length;
            k = k % length;

            int count = 0;
            int start = 0;
            while(count < length){
                int index = start;
                int num = nums[index];

                do{
                    var nextIndex = (index + k) % length;
                    var tmp = nums[nextIndex];
                    nums[nextIndex] = num;
                    index = nextIndex;
                    num = tmp;

                    count++;
                }while(count < length && index != start);
                
                start++;
            }
        } 

        // 官方解答 数组翻转
        public static void Rotate_1(int[] nums, int k) {
            int n = nums.Length;
            k = k % n;
            if(k == 0)
                return;

            Array.Reverse(nums);
            Array.Reverse(nums, 0, k);
            Array.Reverse(nums, k, n - k);
        }
    }
}