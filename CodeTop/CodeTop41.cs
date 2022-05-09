namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 41
    /// title:  缺失的第一个正数
    /// problems: https://leetcode.cn/problems/first-missing-positive/
    /// date: 20220509
    /// priority: 0027
    /// time: 00:27:01.83
    public class CodeTop41
    {
        public static int FirstMissingPositive(int[] nums) {
            int length = nums.Length;
            int right = length;

            for(int i = 0; i < right; i++){
                while(i < right && nums[i] != i + 1){
                    if(nums[i] <= 0 || nums[i] > right){
                        (nums[i], nums[right - 1]) = (nums[right - 1], nums[i]);
                        right--;
                    }else{
                        int j = nums[i] - 1;
                        if(nums[j] == j + 1){
                            (nums[i], nums[right - 1]) = (nums[right - 1], nums[i]);
                            right--;
                        }else{
                            (nums[i], nums[j]) = (nums[j], nums[i]);
                        }

                    }
                }
            }

            return right + 1;
        }
    }
}