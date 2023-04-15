using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 1157
    /// title: 子数组中占绝大多数的元素
    /// problems: https://leetcode.cn/problems/online-majority-element-in-subarray/
    /// date: 20230416
    /// </summary>

    public static class Solution1157
    {
        // 25/32
        // 这样写内存不够
        public class MajorityChecker {

            private List<int> _nums;

            private List<int>[] _prefixSums;

            public MajorityChecker(int[] arr) {
                int length = arr.Length;
                _nums = new();
                _prefixSums = new List<int>[length + 1];
                _prefixSums[0] = new List<int>();

                var sums = new List<int>();
                var map = new Dictionary<int, int>();

                for(int i = 0; i < length; i++){
                    if(!map.ContainsKey(arr[i])){
                        map[arr[i]] = _nums.Count;
                        _nums.Add(arr[i]);
                        sums.Add(0);
                    }

                    sums[map[arr[i]]]++;
                    _prefixSums[i + 1] = new List<int>(sums);
                }
            }
            
            public int Query(int left, int right, int threshold) {
                var leftSum = _prefixSums[left];
                var rightSum = _prefixSums[right + 1];

                for(int i = 0; i < rightSum.Count; i++){
                    int freq = rightSum[i];
                    if(i < leftSum.Count)
                        freq -= leftSum[i];

                    if(freq >= threshold)
                        return _nums[i];
                }

                return -1;
            }
        }


        // 参考解答
        // 随机化 + 二分查找
        public class MajorityChecker_1 {
            public const int K = 20;
            private int[] _arr;
            private IDictionary<int, List<int>> _loc;
            private Random _random;

            public MajorityChecker_1(int[] arr) {
                _arr = arr;
                _loc = new Dictionary<int, List<int>>();
                for (int i = 0; i < arr.Length; ++i) {
                    _loc.TryAdd(arr[i], new List<int>());
                    _loc[arr[i]].Add(i);
                }

                _random = new Random();
            }

            public int Query(int left, int right, int threshold) {
                int length = right - left + 1;

                for (int i = 0; i < K; ++i) {
                    int x = _arr[left + _random.Next(length)];
                    List<int> pos = _loc[x];
                    int occ = SearchEnd(pos, right) - SearchStart(pos, left);
                    if (occ >= threshold)
                        return x;
                    else if (occ * 2 >= length)
                        return -1;
                    
                }

                return -1;
            }

            private int SearchStart(List<int> pos, int target) {
                int index = pos.BinarySearch(target);
                if (index < 0)
                    index = ~index;

                return index;
            }

            private int SearchEnd(List<int> pos, int target) {
                int index = pos.BinarySearch(target);
                if (index < 0)
                    index = ~index;
                else
                    index++;

                return index;
            }
        }

    
    
        // 参考解答
        // 前缀和 逐位分析
        public class MajorityChecker_2 {
            public const int M = 15;
            private int[,] A;
            private IDictionary<int, List<int>> _map;

            public MajorityChecker_2(int[] arr) {
                _map = new Dictionary<int, List<int>>();
                for (int i = 0; i < arr.Length; ++i) {
                    _map.TryAdd(arr[i], new List<int>());
                    _map[arr[i]].Add(i);
                }

                A = new int[M, arr.Length + 1];
                
                for(int i = 0; i < M; i++){
                    A[i, 0] = 0;
                    for(int j = 0; j < arr.Length; j++){
                        A[i, j + 1] = A[i, j] + ((arr[j] >> i) & 1);
                    }
                }
            }

            public int Query(int left, int right, int threshold) {
                int val = 0;
                for(int i = 0; i < M; i++){
                    int one = A[i, right + 1] - A[i, left];
                    if(one >= threshold)
                        val |= 1 << i;
                    else if(right + 1 - left - one < threshold)
                        return -1;
                }

                if(!_map.ContainsKey(val))
                    return -1;
                
                int count = _map[val].Count(x => x >= left && x <= right);
                return count >= threshold ? val : -1;
            }

        }

   
    }
}