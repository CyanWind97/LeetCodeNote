namespace LeetCodeNote
{
    /// <summary>
    /// no: 29
    /// title: 移除元素
    /// problems: https://leetcode-cn.com/problems/remove-element/
    /// date: 20210419
    /// </summary>
    public static class Solution27
    {
        public static int RemoveElement(int[] nums, int val) {
            int length = nums.Length;
            if(length == 0)
                return 0;
            
            int slow = 0;
            int fast = 0;
            while(fast  < length){
                if(nums[fast] != val){
                    nums[slow] = nums[fast];
                    slow++;
                }

                fast++;
            }

            return slow;
        }
    }
}