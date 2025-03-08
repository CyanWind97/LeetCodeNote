using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;


/// <summary>
/// no: 2597
/// title: 美丽子集的数目
/// problems: https://leetcode.cn/problems/the-number-of-beautiful-subsets/
/// date: 20250307
/// </summary>
public static class Solution2597
{
    public static int BeautifulSubsets(int[] nums, int k) {
        // 用字典记录每个数字的使用次数
        Dictionary<int, int> count = new Dictionary<int, int>();
        
        // 回溯函数
        int Backtrack(int index) {
            // 基础情况：已处理完所有数字
            if (index == nums.Length) {
                // 空集不计入结果，所以当count为空时返回0
                return count.Count == 0 ? 0 : 1;
            }

            // 不选择当前数字的情况
            int result = Backtrack(index + 1);

            // 检查是否可以选择当前数字
            bool canPick = true;
            int num = nums[index];
            
            // 检查当前数字是否与已选择的数字违反条件
            if (count.ContainsKey(num - k) || count.ContainsKey(num + k)) {
                canPick = false;
            }

            // 如果可以选择当前数字
            if (canPick) {
                // 将当前数字加入选择集合
                count[num] = count.GetValueOrDefault(num, 0) + 1;
                
                // 继续处理下一个数字
                result += Backtrack(index + 1);
                
                // 回溯：移除当前数字
                if (count[num] == 1) {
                    count.Remove(num);
                } else {
                    count[num]--;
                }
            }

            return result;
        }

        // 从索引0开始回溯
        return Backtrack(0);
    }
}
