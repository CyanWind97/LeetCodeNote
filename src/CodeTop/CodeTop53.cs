using System;

namespace LeetCodeNote.CodeTop
{
    /// <summary>
    /// no: 53
    /// title:  最大子数组和
    /// problems: https://leetcode-cn.com/problems/maximum-subarray/
    /// date: 20220505
    /// priority: 0007
    /// time: 00:08:03.72
    /// </summary>
    public static class CodeTop53
    {
        public static int MaxSubArray(int[] nums) {
            var result = nums[0];
            var sum = 0;
            var length = nums.Length;
            
            for(int i = 0; i < length; i++)
            {
                if(sum + nums[i] < 0)
                    sum = nums[i];
                else
                    sum += nums[i];
                
                result = Math.Max(result, sum);
                sum = Math.Max(sum, 0);
            }

            return result;
        }


        // 参考解答 分治法 线段树
        public static int MaxSubArray_1(int[] nums) {
            Status PushUp(Status l, Status r) 
                => new Status()
                {
                    ISum = l.ISum + r.ISum,
                    LSum = Math.Max(l.LSum, l.ISum + r.LSum),
                    RSum = Math.Max(r.RSum, r.ISum + l.RSum),
                    MSum = Math.Max(Math.Max(l.MSum, r.MSum), l.RSum + r.LSum)
                };


            Status GetInfo(int l, int r)
            {
                if(l == r)
                    return new Status(nums[l], nums[l], nums[l], nums[l]);
                
                int m = (l + r) / 2;
                var lSub = GetInfo(l, m);
                var rSub = GetInfo(m + 1, r);

                return PushUp(lSub, rSub);
            }

            return GetInfo(0, nums.Length - 1).MSum;
        }


        public struct Status 
        {
            public int LSum;
            public int RSum;
            
            public int MSum;
            
            public int ISum;


            public Status(int lSum, int rSum, int mSum, int iSum)
            {
                LSum = lSum;
                RSum = rSum;
                MSum = mSum;
                ISum = iSum;
            }
        }
        
    }
}