using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 911
    /// title:  在线选举
    /// problems: https://leetcode-cn.com/problems/online-election/
    /// date: 20211211
    /// </summary>
    public static class Solution911
    {
        public class TopVotedCandidate {
            List<int> _tops;

            Dictionary<int, int> _voteCounts;

            List<int> _times;

        
            public TopVotedCandidate(int[] persons, int[] times) {
                _tops = new List<int>();
                _voteCounts = new Dictionary<int, int>();
                _voteCounts.Add(-1, -1);

                int top = -1;
                int length = persons.Length;
                for(int i = 0; i < length; i++){
                    int p = persons[i];
                    if(!_voteCounts.ContainsKey(p))
                        _voteCounts.Add(p, 0);
                    else
                        _voteCounts[p]++;
                    
                    if (_voteCounts[p] >= _voteCounts[top])
                        top = p;
                    
                    _tops.Add(top);
                }

                _times = times.ToList();
            }
            
            public int Q(int t) {
                var index = _times.BinarySearch(t);
                if (index < 0)
                    index = ~index - 1;
                
                return _tops[index];
            }
        }
    }
}