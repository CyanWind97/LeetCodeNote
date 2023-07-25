using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 2569
    /// title:  更新数组后处理求和查询
    /// problems: https://leetcode.cn/problems/handling-sum-queries-after-update/
    /// date: 20230726
    /// </summary>
    public static class Solution2569
    {
        // 参考解答
        // 线段树 + 懒惰标记
        public static long[] HandleQuery(int[] nums1, int[] nums2, int[][] queries) {
            int n = nums1.Length;

            var tree = new SegTree(nums1);
            var sum = nums2.Sum(x => (long)x);

            var list = new List<long>();

            foreach(var query in queries){
               if (query[0] == 1){
                    (int l, int r) = (query[1], query[2]);
                    tree.ReverseRange(l, r);
               } else if (query[0] == 2){
                    sum += (long)tree.SumRange(0, n - 1) * query[1];
               } else if (query[0] == 3) {
                    list.Add(sum);
               }
            }

            return list.ToArray();
        }

        public class SegNode {
            public int L { get; set; } = 0;
            public int R { get; set; } = 0;
            public int Sum { get; set; } = 0;
            public bool LazyTag { get; set;} = false;
        }

        public class SegTree {
            private readonly SegNode[] _nodes;

            public SegTree(int[] nums){
                int n = nums.Length;
                _nodes = new SegNode[4 * n + 1];

                Build(1, 0, n - 1, nums);
            }

            public int SumRange(int left, int right)
                => Query(1, left, right);
            
            public void ReverseRange(int left, int right)
                => Modify(1, left, right);


            public void Build(int index, int l, int r, int[] nums){
                _nodes[index] = new SegNode()
                {
                    L = l,
                    R = r,
                };
                
                if(l == r){
                    _nodes[index].Sum = nums[l];
                    return;
                }

                int mid = (l + r) >> 1;
                (int left, int right) = (2 * index, 2 * index + 1);
                
                Build(left, l, mid, nums);
                Build(right, mid + 1, r, nums);
                _nodes[index].Sum = _nodes[left].Sum + _nodes[right].Sum;
            }

            public void PushDown(int index){
                if(!_nodes[index].LazyTag)
                    return;
                
                (int left, int right) = (2 * index, 2 * index + 1);
                    
                _nodes[left].LazyTag = !_nodes[left].LazyTag;
                _nodes[left].Sum = _nodes[left].R - _nodes[left].L + 1 - _nodes[left].Sum;
                _nodes[right].Sum = _nodes[right].R - _nodes[right].L + 1 - _nodes[right].Sum;
                _nodes[right].LazyTag = !_nodes[right].LazyTag;
                _nodes[index].LazyTag = false;
            }
            
            public void Modify(int index, int l, int r) {
                if (_nodes[index].L >= l && _nodes[index].R <= r) {
                    _nodes[index].Sum = _nodes[index].R - _nodes[index].L + 1 - _nodes[index].Sum;
                    _nodes[index].LazyTag = !_nodes[index].LazyTag;
                    return;
                }

                PushDown(index);
                (int left, int right) = (2 * index, 2 * index + 1);
                if (_nodes[left].R >= l)
                    Modify(left, l, r);
                
                if (_nodes[right].L <= r)
                    Modify(right, l, r);
                
                _nodes[index].Sum = _nodes[left].Sum + _nodes[right].Sum;
            }

            public int Query(int index, int l, int r){
                if ( _nodes[index].L >= l && _nodes[index].R <= r)
                    return _nodes[index].Sum;
                
                if (_nodes[index].R < l || _nodes[index].L > r)
                    return 0;
                
                PushDown(index);
                int result = 0;
                (int left, int right) = (2 * index, 2 * index + 1);
                if (_nodes[left].R >= l)
                    result += Query(left, l, r);
                
                if (_nodes[right].L <= r)
                    result += Query(right, l, r);
                
                return result;
            }
        }
        
        // 参考解答
        public static long[] HandleQuery_1(int[] nums1, int[] nums2, int[][] queries) {
            int n = nums1.Length;
            int m = 0, i = 0;
            var count = new int[4 * n];
            var flip = new bool[4 * n];

            void Maintain(int pos)
            {
                count[pos] = count[pos << 1] + count[pos << 1 | 1];
            }

            void Init(int pos,int left,int right)
            {
                if(left == right)
                {
                    count[pos] = nums1[left - 1];
                    return;
                }

                int mid = (left + right) >> 1;

                Init(pos << 1, left, mid);
                Init(pos << 1 | 1, mid+1, right);

                Maintain(pos);
            }
            
            void Opearte(int pos,int left,int right)
            {
                count[pos] = right-left + 1-count[pos];
                flip[pos] = !flip[pos];
            }

            void Update(int pos,int left,int right,int low,int high)
            {
                if(low <= left && right <= high)
                {
                    Opearte(pos,left,right);
                    return;
                }

                int mid = (left+right) >> 1;
                if(flip[pos])
                {
                    Opearte(pos<<1,left,mid);
                    Opearte(pos<<1|1,mid+1,right);
                    flip[pos] = false;
                }

                if(mid >= low)
                    Update(pos << 1,left, mid, low, high);
                if(mid < high)
                    Update(pos << 1 | 1,mid+1,right,low,high);
                
                Maintain(pos);
            }

            
            Init(1,1,n);

            var sum = nums2.Sum(x => (long)x);
            
            var result = new List<long>(m);
            foreach(var query in queries)
            {
                if(query[0] == 1)
                    Update(1, 1, n, query[1] + 1, query[2]+1);
                else if(query[0] == 2)
                    sum += (long)query[1]*count[1];
                else
                   result.Add(sum);
            }
            return result.ToArray();
        }
    
    }
}