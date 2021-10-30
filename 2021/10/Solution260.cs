namespace LeetCodeNote
{

    /// <summary>
    /// no: 260
    /// title: 只出现一次的数字 III
    /// problems: https://leetcode-cn.com/problems/single-number-iii/
    /// date: 20211030
    /// </summary>
    public static class Solution260
    {
        public static int[] SingleNumber(int[] nums) {
            int xorsum = 0;
            foreach(var num in nums){
                xorsum ^= num;
            }

            int lsb = (xorsum == int.MinValue)
                    ? xorsum
                    : xorsum & (-xorsum);
            
            int num1 = 0; 
            int num2 = 0;
            foreach(var num in nums){
                if ((num & lsb) != 0)
                    num1 ^= num;
                else 
                    num2 ^= num;
            }

            return new int[] { num1, num2 };
        }
    }
}