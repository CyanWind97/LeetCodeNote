using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 895
    /// title:  最大频率栈
    /// problems: https://leetcode.cn/problems/maximum-frequency-stack/
    /// date: 20221130
    /// </summary>
    public static class Solution895
    {
        // 参考解答
        public class FreqStack {
            private IDictionary<int, int> freq;
            private IDictionary<int, Stack<int>> group;
            private int maxFreq;

            public FreqStack() {
                freq = new Dictionary<int, int>();
                group = new Dictionary<int, Stack<int>>();
                maxFreq = 0;
            }

            public void Push(int val) {
                if (!freq.ContainsKey(val)) {
                    freq.Add(val, 0);
                }
                freq[val]++;
                if (!group.ContainsKey(freq[val])) {
                    group.Add(freq[val], new Stack<int>());
                }
                group[freq[val]].Push(val);
                maxFreq = Math.Max(maxFreq, freq[val]);
            }

            public int Pop() {
                int val = group[maxFreq].Peek();
                freq[val]--;
                group[maxFreq].Pop();
                if (group[maxFreq].Count == 0) {
                    maxFreq--;
                }
                return val;
            }
        }

    }
}