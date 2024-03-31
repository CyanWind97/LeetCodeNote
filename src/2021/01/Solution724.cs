using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 724
    /// title: 寻找数组的中心索引
    /// problems: https://leetcode-cn.com/problems/find-pivot-index/
    /// date: 20210128
    /// </summary>
    public static class Solution724
    {
        public static int PivotIndex(int[] nums) {
            int length = nums.Length;
            int sum = nums.Sum();
            int index = 0;
            int left = 0;
            while(index < length &&  2 * left != sum - nums[index]){
                left += nums[index];
                index++;
            }

            return index == length ? - 1 : index;
        }
    }
}