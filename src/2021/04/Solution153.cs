namespace LeetCodeNote
{
    /// <summary>
    /// no: 153
    /// title: 寻找旋转排序数组中的最小值
    /// problems: https://leetcode-cn.com/problems/find-minimum-in-rotated-sorted-array/
    /// date: 20210408
    /// </summary>
    public class Solution153
    {
        public static int FindMin(int[] nums) 
        {
            int length = nums.Length;
            int left = 0;
            int right = length - 1;

            while(left < right)
            {
                int mid = left + ((right - left) >> 1);
                if(nums[mid] < nums[right])
                    right = mid;
                else
                    left = mid + 1;
            }

            return nums[left];
        }
    }
}