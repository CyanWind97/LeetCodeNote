using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 17.10
    /// title: 主要元素
    /// problems: https://leetcode-cn.com/problems/find-majority-element-lcci/
    /// date: 20210709
    /// type: 面试题 lcci
    /// </summary>
    public static class Solution_lcci_17_10
    {
        public static int MajorityElement(int[] nums) {
            Dictionary<int,int> dic = new Dictionary<int, int>();
            foreach(var num in nums){
                if(dic.ContainsKey(num))
                    dic[num]++;
                else
                    dic.Add(num, 1);
            }
            int length = nums.Length;
            foreach(var pair in dic){
                if(pair.Value > length / 2)
                    return pair.Key;
            }

            return -1;
        }

        // 参考解答 投票算法
        public static int MajorityElement_1(int[] nums) {
            int length = nums.Length;
            int count = 0;
            int result = -1;
            foreach(var num in nums){
                if(count == 0){
                    result = num;
                    count++;
                }else if(result == num)
                    count++;
                else
                    count--;
            }

            count = nums.Where(x => x == result).Count();

            return 2 * count > length ? result : -1;
        }
    }
}