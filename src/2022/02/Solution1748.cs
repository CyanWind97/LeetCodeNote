using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1748
    /// title: 唯一元素的和
    /// problems: https://leetcode-cn.com/problems/sum-of-unique-elements/
    /// date: 20220206
    /// </summary>
    public static class Solution1748
    {
        public static int SumOfUnique(int[] nums) {
            int sum = 0;
            var dic = new Dictionary<int, int>();
            
            foreach (int num in nums) {
                if (!dic.ContainsKey(num)) {
                    sum += num;
                    dic.Add(num, 1);
                } else if (dic[num] == 1) {
                    sum -= num;
                    dic[num] = 2;
                }
            }
            
            return sum;
        }
    }
}