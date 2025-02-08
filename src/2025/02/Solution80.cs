namespace LeetCodeNote;

/// <summary>
/// no: 80
/// title: 删除有序数组中的重复项 II
/// problems: https://leetcode-cn.com/problems/remove-duplicates-from-sorted-array-ii/
/// date: 20250209
/// </summary>
public static partial class Solution80
{
    
    public static int RemoveDuplicates(int[] nums) {
        int length = nums.Length;
        if(length <= 2)
            return length;
        
        int slow = 2, fast = 2;
        while(fast < length){
            if(nums[slow - 2] != nums[fast]){
                nums[slow] = nums[fast];
                slow++;
            }

            fast++;
        }

        return slow;
    }
}
