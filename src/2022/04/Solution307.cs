namespace LeetCodeNote
{
    /// <summary>
    /// no: 307
    /// title: 区域和检索 - 数组可修改
    /// problems: https://leetcode-cn.com/problems/range-sum-query-mutable/
    /// date: 20220404
    /// </summary>
    public static partial class Solution307
    {
        // Todo : 线段树
        // 参考解答 树状数组
        public class NumArray {
            private int[] _tree;
            private int[] _nums;

            private int _length;
            

            public NumArray(int[] nums) {
                _length = nums.Length;
                _nums = nums;
                _tree = new int[_length + 1];

                for(int i = 0; i < _length; i++){
                    Add(i + 1, nums[i]);
                }
            }
            
            private int LowBit(int x)
                => x & -x;

            private void Add(int index, int val){
                while(index < _length + 1){
                    _tree[index] += val;
                    index += LowBit(index);
                }
            }

            public void Update(int index, int val) {
                Add(index + 1, val - _nums[index]);
                _nums[index] = val;
            }
            
            public int SumRange(int left, int right) 
                => PrefixSum(right + 1) - PrefixSum(left);

            
            private int PrefixSum(int index){
                int sum = 0;
                while(index > 0){
                    sum += _tree[index];
                    index -= LowBit(index);
                }

                return sum;
            }
        }
    }
}