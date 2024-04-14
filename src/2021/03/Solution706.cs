using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 706
    /// title: 设计哈希映射
    /// problems: https://leetcode-cn.com/problems/design-hashmap/
    /// date: 20210314
    /// </summary>
    public static partial class Solution706
    {
        public class MyHashMap {

            private int[] map;

            /** Initialize your data structure here. */
            public MyHashMap() {
                map = new int[1000001];
                Array.Fill(map, - 1);
            }
            
            /** value will always be non-negative. */
            public void Put(int key, int value) {
                map[key] = value;
            }
            
            /** Returns the value to which the specified key is mapped, or -1 if this map contains no mapping for the key */
            public int Get(int key) {
                return map[key];
            }
            
            /** Removes the mapping of the specified value key if this map contains a mapping for the key */
            public void Remove(int key) {
                map[key] = -1;
            }
        }   
    }
}