using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2506
/// title:  设计内存分配器
/// problems: https://leetcode.cn/problems/design-memory-allocator
/// date: 20250225
/// </summary>
public static class Solution2502
{
    // 参考解答
    public class Allocator {
        private int[] _memory;

        public Allocator(int n) { 
            _memory = new int[n];
        }
        
        public int Allocate(int size, int mID) {
            for (int i = 0; i <= _memory.Length - size; i++) {
                if (_memory[i] != 0) continue;
                for (int j = 1; j < size; j++) {
                    if (_memory[i + j] != 0) {
                        i += j;
                        goto skip;
                    }
                }
                Array.Fill(_memory, mID, i, size);
                return i;
                skip:;
            }
            return -1;
        }
        
        public int FreeMemory(int mID) {
            int count = 0;
            for (int i = 0; i < _memory.Length; ++i) {
                if (_memory[i] == mID) {
                    ++count;
                    _memory[i] = 0;
                }
            }
            return count;
        }
    }
}
