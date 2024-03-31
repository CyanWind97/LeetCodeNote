using System.Collections.Generic;
using System;
using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 781
    /// title: 森林中的兔子
    /// problems: https://leetcode-cn.com/problems/rabbits-in-forest/
    /// date: 20210405
    /// </summary>
    public static class Solution781
    {
        public static int NumRabbits(int[] answers) {
           int length = answers.Length;
           if(length == 0)
                return 0;
            
            int result = 0;
            Array.Sort(answers);
            int cur = answers[0];
            int count = 1;

            for(int i = 1; i < length; i++)
            {
                if(cur == answers[i])
                    count++;
                else
                {
                    if(cur >= count - 1)
                    {
                        result += cur + 1;
                    }else
                    {
                        result += (cur + 1) * ((count - 1) / (cur + 1) + 1);
                    }

                    cur = answers[i];
                    count = 1;
                }
            }

            if(cur >= count - 1)
            {
                result += cur + 1;
            }else
            {
                result += (cur + 1) * ((count - 1) / (cur + 1) + 1);
            }

            return  result;
        }

        public static int NumRabbits_1(int[] answers) {
            int length = answers.Length;
            if(length == 0)
                return 0;
            
            int result = 0;
            Dictionary<int, int> dic = new Dictionary<int, int>();

            for(int i = 0; i < length; i++)
            {
                if(!dic.ContainsKey(answers[i]))
                    dic[answers[i]] = 0;

                dic[answers[i]]++;
            }

            foreach(var info in dic)
            {
                int x = info.Value;
                int y = info.Key;
                result += (x + y) / (y + 1) * (y + 1);
            }

            return  result;
        }
    }
}