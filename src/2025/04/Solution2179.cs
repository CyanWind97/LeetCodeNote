using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2179
/// title: 统计数组中好三元组数目
/// problems: https://leetcode.cn/problems/count-good-triplets-in-an-array
/// date: 20250415
/// </summary>
public static class Solution2179
{
    private class BinaryIndexedTree {
        private readonly int[] tree;
        
        public BinaryIndexedTree(int n) {
            tree = new int[n + 1];
        }
        
        // 查询前缀和
        public int Query(int index) {
            int sum = 0;
            index++;  // 1-indexed
            while (index > 0) {
                sum += tree[index];
                index -= index & -index;  // 减去最低位的1
            }
            return sum;
        }
        
        // 更新树状数组
        public void Update(int index, int delta) {
            index++;  // 1-indexed
            while (index < tree.Length) {
                tree[index] += delta;
                index += index & -index;  // 加上最低位的1
            }
        }
    }

    public static long GoodTriplets(int[] nums1, int[] nums2) {
         int n = nums1.Length;
        
        // 创建映射，记录nums2中每个值的位置
        Dictionary<int, int> pos2 = new Dictionary<int, int>();
        for (int i = 0; i < n; i++) {
            pos2[nums2[i]] = i;
        }
        
        // 对于nums1中的每个元素，找到它在nums2中的位置
        int[] positions = new int[n];
        for (int i = 0; i < n; i++) {
            positions[i] = pos2[nums1[i]];
        }
        
        // 使用树状数组来高效计算
        BinaryIndexedTree bit = new BinaryIndexedTree(n);
        long result = 0;
        
        // 对于位置数组中的每个位置
        for (int i = 0; i < n; i++) {
            // positions[i]之前有多少个元素
            int smaller = bit.Query(positions[i]);
            
            // positions[i]之后有多少个元素
            int larger = n - positions[i] - 1 - (i - smaller);
            
            // 该元素可能形成的好三元组数目
            result += (long)smaller * larger;
            
            // 更新树状数组
            bit.Update(positions[i], 1);
        }
        
        return result;
    }
}
