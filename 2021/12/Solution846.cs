using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 846
    /// title:  一手顺子
    /// problems: https://leetcode-cn.com/problems/hand-of-straights/
    /// date: 20211230
    /// </summary>
    public static class Solution846
    {
        public static bool IsNStraightHand(int[] hand, int groupSize) {
            int length = hand.Length;
            if(length % groupSize != 0)
                return false;
            
            Array.Sort(hand);
            var dic = new Dictionary<int, int>();
            foreach(var num in hand){
                if(!dic.ContainsKey(num))
                    dic.Add(num, 1);
                else
                    dic[num]++;
            }
            
            foreach(var num in hand){
                if(!dic.ContainsKey(num))
                    continue;
                
                for(int i = 0; i < groupSize; i++){
                    int key = num + i;
                    if(!dic.ContainsKey(key))
                        return false;
                    
                    dic[key]--;
                    if(dic[key] == 0)
                        dic.Remove(key);
                }
            }

            return true;
        }
    }
}