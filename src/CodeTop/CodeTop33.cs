namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 33
    /// title:  搜索旋转排序数组
    /// problems: https://leetcode-cn.com/problems/search-in-rotated-sorted-array/
    /// date: 20220506
    /// priority: 0012
    /// time: 00:28:27.09
    /// </summary>
    public static class CodeTop33
    {
        public static int Search(int[] nums, int target) {
            int length = nums.Length;
            int left = 0;
            int right = length - 1;

            while(left <= right){
                int mid = (right + left) / 2;
                if(nums[mid] == target)
                    return mid;
                
                if(nums[0] <= nums[mid])
                    if(nums[0] <= target && target < nums[mid])
                        right = mid - 1;
                    else
                        left = mid + 1;
                else
                    if(nums[mid] < target && target <= nums[length - 1])
                        left = mid + 1;
                    else
                        right = mid - 1;
            }

            return -1;
        }
    }
}