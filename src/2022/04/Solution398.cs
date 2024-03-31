using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 398
    /// title: 随机数索引
    /// problems: https://leetcode-cn.com/problems/random-pick-index/
    /// date: 20220425
    /// </summary>   

    public static class Solution398
    {
        public class Solution {
            private Dictionary<int, List<int>> _dic;

            private Random _random;

            public Solution(int[] nums) {
                _dic = nums.Select((num, index) => (num, index))
                            .GroupBy(x => x.num)
                            .ToDictionary(g => g.Key, g => g.Select(x => x.index).ToList());

                _random = new();
            }
            
            public int Pick(int target) {
                var list = _dic[target];
                var index = _random.Next(list.Count);

                return list[index];
            }
        }

        // 参考解答 水塘抽样
        public class Solution_1 {
            int[] nums;
            Random random;

            public Solution_1(int[] nums) {
                this.nums = nums;
                random = new Random();
            }

            public int Pick(int target) {
                int ans = 0;
                for (int i = 0, cnt = 0; i < nums.Length; ++i) {
                    if (nums[i] == target) {
                        ++cnt; // 第 cnt 次遇到 target
                        if (random.Next(cnt) == 0) 
                            ans = i;
                    }
                }
                return ans;
            }
        }

    }
}