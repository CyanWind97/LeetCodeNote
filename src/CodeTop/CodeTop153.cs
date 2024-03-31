namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 153
    /// title:  寻找旋转排序数组中的最小值
    /// problems: https://leetcode.cn/problems/find-minimum-in-rotated-sorted-array/
    /// date: 20220514
    /// priority: 0052
    /// time: 00:08:05.60
    /// </summary>
    public static class CodeTop153
    {

        public static int FindMin(int[] nums) {
            int length = nums.Length;
            
            int left = 0;
            int right = length - 1;
            
            while(left < right){
                int mid = (left + right) / 2;
                if(nums[mid] < nums[right])
                    right = mid;
                else
                    left = mid + 1;
            }

            return  nums[left];
        }
    }
}