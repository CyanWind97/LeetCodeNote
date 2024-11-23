using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote;

/// <summary>
/// no: 632
/// title: 最小区间
/// problems: https://leetcode.cn/problems/smallest-range-covering-elements-from-k-lists
/// date: 20241124
/// </summary>
public static class Solution632
{
    public static int[] SmallestRange(IList<IList<int>> nums) {
        int k = nums.Count;
        var range = new SortedDictionary<int, int>();
        var queue = new PriorityQueue<(int ValueIndex, int ListIndex), int>();
        
        for(int i = 0; i < k; i++){
            if (!range.ContainsKey(nums[i][0]))
                range[nums[i][0]] = 0;
            
            range[nums[i][0]]++;
            if (nums[i].Count == 1)
                continue;
            
            queue.Enqueue((1, i), nums[i][1]);
        }

        var minRange = range.Last().Key - range.First().Key;
        var result = ((int L, int R))(range.First().Key, range.Last().Key);

        while(queue.Count > 0){
            var (valueIndex, listIndex) = queue.Dequeue();
            var value = nums[listIndex][valueIndex];
            if (!range.ContainsKey(value))
                range[value] = 0;
            
            range[value]++;
            int prevValue = nums[listIndex][valueIndex - 1];
            range[prevValue]--;
            if (range[prevValue] == 0)
                range.Remove(prevValue);
            
            (int left, int right) = (range.First().Key, range.Last().Key);
            var currRange = right - left;
            if (currRange < minRange){
                minRange = currRange;
                result = (left, right);
            }

            if (valueIndex + 1 < nums[listIndex].Count)
                queue.Enqueue((valueIndex + 1, listIndex), nums[listIndex][valueIndex + 1]);
        }

        return [result.L, result.R];
    }

    // 参考解答
    // 哈希表 + 滑动窗口
    public static int[] SmallestRange_1(IList<IList<int>> nums){
        int k = nums.Count;
        var indices = new Dictionary<int, List<int>>();
        (int xMin, int xMax) = (int.MaxValue, int.MinValue);
        for(int i = 0; i < k; i++){
            foreach(var x in nums[i]){
                if (!indices.ContainsKey(x))
                    indices[x] = [];
                
                indices[x].Add(i);
                xMin = Math.Min(xMin, x);
                xMax = Math.Max(xMax, x);
            }
        }

        var freq = new int[k];
        int inside = 0;
        (int left, int right) = (xMin, xMin - 1);
        (int bestLeft, int bestRight) = (xMin, xMax);
        while(right < xMax){
            right++;
            if (indices.ContainsKey(right)){
                foreach(var x in indices[right]){
                    freq[x]++;
                    if (freq[x] == 1)
                        inside++;
                }
            }

            while(inside == k){
                if (right - left < bestRight - bestLeft)
                    (bestLeft, bestRight) = (left, right);

                if (indices.ContainsKey(left)){
                    foreach(var x in indices[left]){
                        freq[x]--;
                        if (freq[x] == 0)
                            inside--;
                    }
                }

                left++;
            }
        }

        return [bestLeft, bestRight];
    }

    // 参考解答
    public static int[] SmallestRange_2(IList<IList<int>> nums){
        var rangeNums = new List<(int Value, int ListIndex)>();
        var len = nums.Count;

        for (var i = 0; i < len; i++){
            var item = nums[i];
            foreach (var t in item){
                rangeNums.Add((t, i));
            }
        }

        rangeNums.Sort((t1, t2) => t1.Value - t2.ListIndex);
        var (left, right) = (0, 0);
        var rangeMap = new Dictionary<int, int>();
        var result = new int[2];
        var lastdiff = int.MaxValue;
        while (right < rangeNums.Count){
            var (value, listIndex) = rangeNums[right];
            rangeMap[listIndex] = rangeMap.GetValueOrDefault(listIndex) + 1;
            if (rangeMap[listIndex] == 1)
                len--;

            if (len == 0){
                while (rangeMap[rangeNums[left].ListIndex] > 1){
                    rangeMap[rangeNums[left++].ListIndex]--;
                }

                var (a, b) = (rangeNums[left].Value, rangeNums[right].Value);
                var currentDiff = b - a;
                if (currentDiff < lastdiff) {
                    (result[0], result[1]) = (a, b);
                    lastdiff = currentDiff;
                }
            }

            right++;
        }

        return result;
    }
}
