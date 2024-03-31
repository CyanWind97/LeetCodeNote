namespace LeetCodeNote
{
    /// <summary>
    /// no: 665
    /// title: 非递减数列
    /// problems: https://leetcode-cn.com/problems/non-decreasing-array/
    /// date: 20210207
    /// </summary>
    public static class Solution665
    {
        public static bool CheckPossibility(int[] nums) {
            int length = nums.Length;
            if(length <= 2)
                return true;

            int count = 0;
            int delta1 = nums[1] - nums[0];
            int delta2 = 0;
            if(delta1 < 0){
                count++;
                delta1 = 0;
            }
            
            for(int i = 2; i < length && count < 2; i++){
                delta2 = nums[i] - nums[i - 1];
                if(delta2 < 0){
                    count++;
                    if(delta1 + delta2 >= 0){
                        delta2 = delta1 + delta2;
                    }else{
                        delta2 = 0;
                        nums[i] = nums[i - 1];
                    }
                }
                delta1 = delta2;
            }

            return count < 2;
        }

        // 参考解答
        public static bool CheckPossibility_1(int[] nums) {
            int length = nums.Length;
            if(length <= 2)
                return true;

            int count = 0;
            for(int i = 0; i < length - 1; i++){
                if(nums[i + 1]  < nums[i]){
                    count++;
                    if(count > 1)
                        return false;

                    if(i > 0 && nums[i + 1] < nums[i - 1])
                        nums[i + 1] = nums[i];
                }
            }

            return true;
        }
    }
}