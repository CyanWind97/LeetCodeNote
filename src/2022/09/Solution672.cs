using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 672
    /// title: 灯泡开关 Ⅱ
    /// problems: https://leetcode.cn/problems/bulb-switcher-ii/
    /// date: 20220915
    /// </summary>

    public static class Solution672
    {
        // 参考解答
        public static int FlipLights(int n, int presses) {
            var seen = new HashSet<int>();
            for (int i = 0; i < 1 << 4; i++) {
                int[] pressArr = new int[4];
                for (int j = 0; j < 4; j++) {
                    pressArr[j] = (i >> j) & 1;
                }
                int sum = pressArr.Sum();
                if (sum % 2 == presses % 2 && sum <= presses) {
                    int status = pressArr[0] ^ pressArr[1] ^ pressArr[3];
                    if (n >= 2) 
                        status |= (pressArr[0] ^ pressArr[1]) << 1;
                    
                    if (n >= 3) 
                        status |= (pressArr[0] ^ pressArr[2]) << 2;
                    
                    if (n >= 4) 
                        status |= (pressArr[0] ^ pressArr[1] ^ pressArr[3]) << 3;
                    
                    seen.Add(status);
                }
            }
            
            return seen.Count;
        }
    }
}