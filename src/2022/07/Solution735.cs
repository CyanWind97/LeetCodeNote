using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 735
    /// title: 行星碰撞
    /// problems: https://leetcode.cn/problems/asteroid-collision/
    /// date: 20220713
    /// </summary>
    public static class Solution735
    {
        public static int[] AsteroidCollision(int[] asteroids) {
            var stack = new Stack<int>();
            foreach(var asteroid in asteroids){
                var cur = asteroid;
                while(stack.Count > 0 && cur < 0 && stack.Peek() > 0){
                    var pre = stack.Pop();
                    if(pre > -cur)
                        cur = pre;
                    else if(pre == -cur)
                        cur = 0;
                }
                
                if(cur != 0)
                    stack.Push(cur);
            }
            
            var result = new int[stack.Count];
            for(int i = stack.Count - 1; i >= 0; i--){
                result[i] = stack.Pop();
            }

            return result;
        }
    }
}