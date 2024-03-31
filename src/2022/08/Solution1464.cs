namespace LeetCodeNote
{
    /// <summary>
    /// no: 1464
    /// title:  数组中两元素的最大乘积
    /// problems: https://leetcode.cn/problems/maximum-product-of-two-elements-in-an-array/
    /// date: 20220826
    /// </summary>
    public static class Solution1464
    {
        public static int MaxProduct(int[] nums) {
            int a = int.MinValue;
            int b = int.MinValue;

            foreach(var num in nums){
                if(num > a){
                    b = a;
                    a = num;
                }else if(num > b){
                    b = num;
                }
            }

            return (a - 1) * (b - 1);
        }
    }
}