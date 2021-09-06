namespace LeetCodeNote
{
    /// <summary>
    /// no: 704
    /// title: 二分查找
    /// problems: https://leetcode-cn.com/problems/binary-search/
    /// date: 20210906
    /// </summary>
    public static class Solution704
    {
        public static int Search(int[] nums, int target) {
            int left = 0;
            int right = nums.Length - 1;

            while(left <= right){
                int mid = left + (right - left) / 2;
                if(nums[mid] == target)
                    return mid;
                else if(nums[mid] < target)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return -1;
        }
    }
}