using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1629
    /// title: 按键持续时间最长的键
    /// problems: https://leetcode-cn.com/problems/slowest-key/
    /// date: 20220109
    /// </summary>
    public static class Solution1629
    {
        public static char SlowestKey(int[] releaseTimes, string keysPressed) {
            var result = keysPressed[0];
            int maxTime = releaseTimes[0];
            int length = releaseTimes.Length;

            for(int i = 1; i < length; i++){
                var c = keysPressed[i];
                var time = releaseTimes[i] - releaseTimes[i - 1];
                
                if(time > maxTime || (time == maxTime && c > result)){
                    result = c;
                    maxTime = time;
                }
            }
            
            return result;
        }
    }
}