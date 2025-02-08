namespace LeetCodeNote
{
    /// <summary>
    /// no: 80
    /// title: 删除有序数组中的重复项 II
    /// problems: https://leetcode-cn.com/problems/remove-duplicates-from-sorted-array-ii/
    /// date: 20210406
    /// </summary>
    public static partial class Solution80
    {
        public static int RemoveDuplicates_1(int[] nums) {
            int length = nums.Length;
            if(length == 1)
                return  1;
            
            int cur = nums[0];
            int count = 1;
            int i = 1; 
            int j = 1;
            while(j < length)
            {
                while(j < length && cur == nums[j] && count < 2)
                {
                    nums[i++] = nums[j++];
                    count++;
                }

                while(j < length && cur == nums[j])
                {
                    j++;
                }

                if(j < length){
                    cur = nums[j];
                    count = 1;
                    nums[i++] = nums[j++];
                }
            }

            return i;
        }

    }
}