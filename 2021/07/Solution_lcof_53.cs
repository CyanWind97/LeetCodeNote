namespace LeetCodeNote
{
    /// <summary>
    /// no: 53
    /// title: 在排序数组中查找数字 I
    /// problems: https://leetcode-cn.com/problems/zai-pai-xu-shu-zu-zhong-cha-zhao-shu-zi-lcof/
    /// date: 20210716
    /// type: 剑指Offer lcof
    /// </summary>
    public static class Solution_lcof_53
    {
        public static int Search(int[] nums, int target) {
            int BinarySearch(int start, int end, bool isLower){
                int result = end + 1;
                while(start <= end){
                    int mid = start + (end - start) / 2;
                    if(nums[mid] > target || (isLower && nums[mid] >= target))
                    {
                        end = mid - 1;
                        result = mid;
                    }
                    else
                        start = mid + 1;
                }

                return result;
            }
            
            int left = BinarySearch(0, nums.Length - 1, true);
            int right = BinarySearch(left, nums.Length - 1, false) - 1;
            
            return right - left + 1;
        }
    }
}