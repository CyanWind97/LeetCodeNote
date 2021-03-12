using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 5705
    /// title: 设计哈希集合
    /// problems: https://leetcode-cn.com/problems/design-hashset/
    /// date: 20210313
    /// </summary>

    public static class Solution705
    {
        public class MyHashSet {

            private bool[] list;

            /** Initialize your data structure here. */
            public MyHashSet() {
                list = new bool[1000001];
            }
            
            public void Add(int key) {
                if(!list[key])
                    list[key] = true;
            }
            
            public void Remove(int key) {
                list[key] = false;
            }
            
            /** Returns true if this set contains the specified element */
            public bool Contains(int key) {
                return list[key];
            }
        }

    }
}