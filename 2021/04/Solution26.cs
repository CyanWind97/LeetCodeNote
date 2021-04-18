namespace LeetCodeNote
{
    /// <summary>
    /// no: 26
    /// title: 删除有序数组中的重复项
    /// problems: https://leetcode-cn.com/problems/remove-duplicates-from-sorted-array/
    /// date: 20210418
    /// </summary>
    public static class Solution26
    {
        public static int RemoveDuplicates(int[] nums) {
            int length = nums.Length;
            if(length <= 1)
                return length;

            int slow = 1;
            int fast = 1;
            while(fast < length){
                if(nums[slow - 1] != nums[fast]){
                    nums[slow] = nums[fast];
                    slow++;
                }
                fast++;
            }

            return slow;
        }
    }
}