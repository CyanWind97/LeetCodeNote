using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 642
    /// title: Dota2 参议院
    /// problems: https://leetcode-cn.com/problems/dota2-senate/
    /// date: 20201211
    /// </summary>
    public static class Solution642
    {
        public static string PredictPartyVictory(string senate) {
            return Victory(senate, 0, 0);
        }

        public static string Victory(string s, int rightR, int rightD) {
            int remainR = 0;
            int remainD = 0;
            char[] chars = new char[s.Length];
            List<char> list = new List<char>();
            foreach(char c  in s) {
                if(c == 'R') {
                    if(rightD == 0) {
                        rightR++;
                        remainR++;
                        list.Add(c);
                    }else{
                        rightD--;
                    }
                }
                else {
                    if(rightR == 0) {
                        rightD++;
                        remainD++;
                        list.Add(c);
                    }else{
                        rightR--;
                    }
                } 
            }
            
            if(remainD == 0)
                return "Radiant";
            else if(remainR == 0)
                return "Dire";
            else 
                return Victory(new string(list.ToArray()), rightR, rightD);
        }


        // 官方解答：双队列模拟投票
        public static string PredictPartyVictory_1(string senate) {
            char[] chars = senate.ToCharArray();
            int length  = chars.Length;
            Queue<int> R = new(length), D = new(length);
            for(int i = 0; i < length; i++) {
                if(chars[i] == 'R')
                    R.Enqueue(i);
                else
                    D.Enqueue(i);
            }

            while(R.Count > 0 && D.Count > 0){
                int r = R.Dequeue();
                int d = D.Dequeue();
                if(r < d)
                    R.Enqueue(r + length);
                else 
                    D.Enqueue(d + length);
            }

            return R.Count > 0 ? "Radiant" : "Dire";
        }
    }
}