using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 229
    /// title: 求众数 II
    /// problems: https://leetcode-cn.com/problems/majority-element-ii/
    /// date: 20211022
    /// </summary>
    public static class Solution229
    {
        public static IList<int> MajorityElement(int[] nums) {
            int length = nums.Length;
            
            return nums.GroupBy(x => x).Where(x => x.Count() > length / 3).Select(x => x.Key).ToArray();
        }

        // 时间复杂度为 O(n)、空间复杂度为 O(1)
        // 参考解答 摩尔投票法
        public static IList<int> MajorityElement_1(int[] nums) {
            int element1 = 0;
            int element2 = 0;
            int vote1 = 0;
            int vote2 = 0;

            foreach (int num in nums) {
                if (vote1 > 0 && num == element1) { //如果该元素为第一个元素，则计数加1
                    vote1++;
                } else if (vote2 > 0 && num == element2) { //如果该元素为第二个元素，则计数加1
                    vote2++;
                } else if (vote1 == 0) { // 选择第一个元素
                    element1 = num;
                    vote1++;
                } else if (vote2 == 0) { // 选择第二个元素
                    element2 = num;
                    vote2++;
                } else { //如果三个元素均不相同，则相互抵消1次
                    vote1--;
                    vote2--;
                }
            }

            int cnt1 = 0;
            int cnt2 = 0;
            foreach (int num in nums) {
                if (vote1 > 0 && num == element1) 
                    cnt1++;
                
                if (vote2 > 0 && num == element2) 
                    cnt2++;
            }
            // 检测元素出现的次数是否满足要求
            IList<int> ans = new List<int>();
            if (vote1 > 0 && cnt1 > nums.Length / 3) 
                ans.Add(element1);
            
            if (vote2 > 0 && cnt2 > nums.Length / 3) 
                ans.Add(element2);
            
            return ans;
        }
    }
}