using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 2671
/// title: 频率跟踪器
/// problems: https://leetcode.cn/problems/frequency-tracker
/// date: 20240321
/// </summary>
public static class Solution2671
{
    public class FrequencyTracker {
        private Dictionary<int, int> _frequency = new();
        private Dictionary<int, int> _count = new();

        public FrequencyTracker() {
            _count[0] = 0;
        }
        
        public void Add(int number) {
            if (!_frequency.ContainsKey(number))
                _frequency[number] = 0;
            
            OnCountChanged(_frequency[number], _frequency[number] + 1);
            _frequency[number]++;
        }
        
        public void DeleteOne(int number) {
            if (!_frequency.ContainsKey(number)
                || _frequency[number] == 0)
                return;
            
            OnCountChanged(_frequency[number], _frequency[number] - 1);
            _frequency[number]--;
        }
        
        public bool HasFrequency(int frequency) {
            return _count.ContainsKey(frequency) && _count[frequency] > 0;
        }

        private void OnCountChanged(int oldCount, int newCount) {
            _count[oldCount]--;

            if (!_count.ContainsKey(newCount))
                _count[newCount] = 0;
            
            _count[newCount]++;
        }
    }
}
