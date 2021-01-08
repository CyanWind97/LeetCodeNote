using System;
using System.Linq;

namespace LeetCodeNote
{

    /// <summary>
    /// no: 189
    /// title: 旋转数组
    /// problems: https://leetcode-cn.com/problems/rotate-array/
    /// date: 20210108
    /// </summary>
    public static class Solution189
    {
        public static void Rotate(int[] nums, int k) {
            int n = nums.Length;
            k = k % n;
            if(k == 0)
                return;

            int m = k, gcd = n;
            while(m > 0){
                int rem  = gcd % m;
                gcd = m;
                m = rem;
            }

            for(int i = 0; i < gcd; i++){
                int cur = i;
                int pre = nums[i];
                do{
                    int next = (cur + k) % n;
                    (nums[next], pre) = (pre, nums[next]);
                    cur = next;
                }while(cur != i);
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