namespace LeetCodeNote
{
    /// <summary>
    /// no: 162
    /// title: 寻找峰值
    /// problems: https://leetcode-cn.com/problems/find-peak-element/
    /// date: 20210915
    /// </summary>
    public static class Solution162
    {
        public static int FindPeakElement(int[] nums) {
            int length = nums.Length;
            int i = 0;
            while(i < length && nums[i + 1] > nums[i]){
                i++;
            }

            return i == length ? length - 1 : i;
        }

        // 参考解答 二分
        public static int FindPeakElement_1(int[] nums) {
            int length = nums.Length;
            int left = 0, right = length - 1, result = -1;

            while (left <= right) {
                int mid = (left + right) / 2;
                if ((mid == 0 || nums[mid - 1] < nums[mid])
                   && (mid == length - 1 || nums[mid] > nums[mid + 1])){
                    result = mid;
                    break;
                }

                if (mid != length - 1 && nums[mid] < nums[mid + 1]) 
                    left = mid + 1;
                else 
                    right = mid - 1;
                
            }

            return result;  
        }

    }
}