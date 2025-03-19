using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2612
/// title: 最少翻转操作数
/// problems: https://leetcode.cn/problems/minimum-reverse-operations
/// date: 20250320
/// </summary>
public static class Solution2612
{
    public static int[] MinReverseOperations(int n, int p, int[] banned, int k) {
        int[] result = new int[n];
        Array.Fill(result, -1);
        result[p] = 0; // 起始位置需要0次操作
        
        // 标记禁止位置
        HashSet<int> bannedSet = new HashSet<int>(banned);
        
        // 使用两个平衡二叉树来分别追踪偶数和奇数位置的可用点
        SortedSet<int> oddAvailable = new SortedSet<int>();
        SortedSet<int> evenAvailable = new SortedSet<int>();
        
        // 初始化可用位置，排除banned位置和起始位置
        for (int i = 0; i < n; i++) {
            if (i != p && !bannedSet.Contains(i)) {
                if (i % 2 == 0) {
                    evenAvailable.Add(i);
                } else {
                    oddAvailable.Add(i);
                }
            }
        }
        
        // BFS队列
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(p);
        
        while (queue.Count > 0) {
            int curr = queue.Dequeue();
            
            // 计算可以被翻转到的位置范围
            // 对于长度为k的翻转操作，如果当前位置是curr，那么翻转后可能的位置取决于选择哪个子数组
            int minLeft = Math.Max(0, curr - (k - 1)); // 子数组最左边的可能位置
            int maxLeft = Math.Min(curr, n - k);       // 子数组最左边的可能位置
            
            // 对于每个可能的左边界，计算翻转后curr的新位置
            // 如果左边界是left，那么curr会被映射到 left + (k-1) - (curr - left) = 2*left + k - 1 - curr
            int minNew = 2 * minLeft + k - 1 - curr;
            int maxNew = 2 * maxLeft + k - 1 - curr;
            
            // 确保范围正确排序
            if (minNew > maxNew) {
                int temp = minNew;
                minNew = maxNew;
                maxNew = temp;
            }
            
            // 根据新位置的奇偶性选择对应的可用位置集合
            SortedSet<int> available;
            if ((curr + minNew) % 2 == 0) { // 奇偶性保持不变
                available = (curr % 2 == 0) ? evenAvailable : oddAvailable;
            } else { // 奇偶性改变
                available = (curr % 2 == 0) ? oddAvailable : evenAvailable;
            }
            
            // 找到可达范围内的所有可用位置
            var toRemove = new List<int>();
            foreach (int next in available.GetViewBetween(minNew, maxNew)) {
                result[next] = result[curr] + 1;
                toRemove.Add(next);
                queue.Enqueue(next);
            }
            
            // 移除已处理的位置
            foreach (int next in toRemove) {
                available.Remove(next);
            }
        }
        
        return result;
    }
}
