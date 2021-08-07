using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 457
    /// title: 环形数组是否存在循环
    /// problems: https://leetcode-cn.com/problems/circular-array-loop/
    /// date: 20210807
    /// </summary>
    public static class Solution457
    {
        public static bool CircularArrayLoop(int[] nums) {
            int length = nums.Length;
            int Next(int cur) {
                return ((cur + nums[cur]) % length + length) % length;
            }

            for(int i = 0; i < length; i++){
                if (nums[i] == 0)
                    continue;
                
                int slow = i, fast = Next(i);
                // 判断非零且方向相同
                while (nums[slow] * nums[fast] > 0 && nums[slow] * nums[Next(fast)] > 0) {
                    if (slow == fast) {
                        if (slow != Next(slow))
                            return true;
                        else
                            break;
                    }

                    slow = Next(slow);
                    fast = Next(Next(fast));
                }
                int add = i;
                while (nums[add] * nums[Next(add)] > 0) {
                    int tmp = add;
                    add = Next(add);
                    nums[tmp] = 0;
                }
            }

            return false;
        }

        // 参考解答 图论寻环
        public static bool CircularArrayLoop_1(int[] nums) {
            const int OFFSET = 100010;
            int length = nums.Length;
            for (int i = 0; i < length; i++) {
                if (nums[i] >= OFFSET) 
                    continue;
                
                int cur = i, tag = OFFSET + i, last = -1;
                bool flag = nums[cur] > 0;
                while (true) {
                    int next = ((cur + nums[cur]) % length + length ) % length;
                    last = nums[cur];
                    nums[cur] = tag;
                    cur = next;
                    if (cur == i) 
                        break;
                    if (nums[cur] >= OFFSET) 
                        break;
                    if (flag && nums[cur] < 0) 
                        break;
                    if (!flag && nums[cur] > 0) 
                        break;
                }
                if (last % length != 0 && nums[cur] == tag) 
                    return true;
            }
            return false;
        }
    }
}