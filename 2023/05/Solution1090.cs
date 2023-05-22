using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1090
    /// title: 受标签影响的最大值
    /// problems: https://leetcode.cn/problems/largest-values-from-labels/
    /// date: 20230523
    /// </summary>
    public static class Solution1090
    {
        public static int LargestValsFromLabels(int[] values, int[] labels, int numWanted, int useLimit) {
            return Enumerable.Range(0, values.Length)
                        .GroupBy(i => labels[i])
                        .SelectMany(g => g.Select(i => values[i])
                                        .OrderByDescending(v => v)
                                        .Take(useLimit))
                        .OrderByDescending(v => v)
                        .Take(numWanted)
                        .Sum();
        }

        // Dictionary 更快
        public static int LargestValsFromLabels_1(int[] values, int[] labels, int numWanted, int useLimit) {
            var ids = Enumerable.Range(0, values.Length)
                            .OrderByDescending(i => values[i])
                            .ToArray();

            var labelCount = new Dictionary<int, int>();
            bool Check(int id){
                var label = labels[id];
                if(!labelCount.ContainsKey(label))
                    labelCount[label] = 0;
                
                if(labelCount[label] < useLimit){
                    labelCount[label]++;
                    return true;
                }

                return false;
            }

            return ids.Where(id => Check(id))
                    .Take(numWanted)
                    .Sum(id => values[id]);
        }
    }
}