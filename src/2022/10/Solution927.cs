using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 927
    /// title: 三等分
    /// problems: https://leetcode.cn/problems/three-equal-parts/
    /// date: 20221005
    /// </summary>
    public static class Solution927
    {
        // 参考解答
        public static int[] ThreeEqualParts(int[] arr) {
            int sum = arr.Sum();
            if (sum % 3 != 0) 
                return new int[]{-1, -1};
            
            if (sum == 0) 
                return new int[]{0, 2};
            
            int partial = sum / 3;
            int first = 0, second = 0, third = 0, cur = 0;
            for (int i = 0; i < arr.Length; i++) {
                if (arr[i] == 1) {
                    if (cur == 0) 
                        first = i;
                    else if (cur == partial)
                        second = i;
                    else if (cur == 2 * partial)
                        third = i;
                    
                    cur++;
                }
            }

            int len = arr.Length - third;
            if (first + len <= second && second + len <= third) {
                int i = 0;
                while (third + i < arr.Length) {
                    if (arr[first + i] != arr[second + i] 
                    || arr[first + i] != arr[third + i]) 
                        return new int[]{-1, -1};
                    
                    i++;
                }
                return new int[]{first + len - 1, second + len};
            }

            return new int[]{-1, -1};
        }
    }
}