namespace LeetCodeNote;

/// <summary>
/// no: 81
/// title: 搜索旋转排序数组 II
/// problems: https://leetcode-cn.com/problems/search-in-rotated-sorted-array-ii/
/// date: 20250201
/// </summary>
public static partial class Solution81
{
    public static bool Search(int[] nums, int target) {
        int length = nums.Length;
        if(length == 1)
            return target == nums[0];
        
        int left = 0;
        int right = length - 1; 
        while(left <= right) {
            int mid = (left + right) / 2;
            
            if(target == nums[mid])
                return true;
            
            if (nums[left] == nums[mid] && nums[mid] == nums[right]) {
                ++left;
                --right;
            }else if(nums[left] <= nums[mid]) {
                if (nums[left] <= target && target < nums[mid])
                    right = mid - 1;
                else
                    left = mid + 1;
                
            } else {
                if (nums[mid] < target && target <= nums[length - 1])
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            
        }

        return false;
    }
}
