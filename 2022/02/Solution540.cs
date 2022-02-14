using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 540
    /// title: 有序数组中的单一元素
    /// problems: https://leetcode-cn.com/problems/single-element-in-a-sorted-array/
    /// date: 20220214
    /// </summary>
    public static class Solution540
    {
        public static int SingleNonDuplicate(int[] nums) {
            int left = 0;
            int right = nums.Length - 1;
            
            while(left < right){
                int mid = (right + left) / 2;

                // 参考 控制奇数位的方法
                if(nums[mid] == nums[mid ^ 1])
                    left = mid + 1;
                else
                    right = mid;

            }

            return nums[left];
        }
    }
}