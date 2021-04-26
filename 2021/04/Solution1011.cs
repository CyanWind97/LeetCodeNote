using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1011
    /// title: 在 D 天内送达包裹的能力
    /// problems: https://leetcode-cn.com/problems/capacity-to-ship-packages-within-d-days/
    /// date: 20210426
    /// </summary>
    public static class Solution1011
    {
        public static int ShipWithinDays(int[] weights, int D) {
            int length = weights.Length;
            int left = 1;
            int right = 0;

            foreach(var weight in weights)
            {
                if(weight > left)
                    left = weight;
                
                right += weight;
            }

            while(left < right){
                int mid = (left + right) / 2;

                int count = 1;
                int cur  = weights[0];
                int i = 1;
                while(i < length && count <= D){
                    if(cur + weights[i] > mid){
                        count++;
                        cur = weights[i];
                    }else{
                        cur += weights[i];
                    }

                    i++;
                }

                if(count > D)
                    left = mid + 1;
                else
                    right = mid;

            }

            return left;
        }
    }
}