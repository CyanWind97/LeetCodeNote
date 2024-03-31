using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 466
    /// title: 统计重复个数
    /// problems: https://leetcode.cn/problems/count-the-repetitions/description/?envType=daily-question&envId=2024-01-02
    /// date: 20240102
    /// </summary>
    public static class Solution466
    {   
        // 参考解答
        public static int GetMaxRepetitions(string s1, int n1, string s2, int n2) {
            int count1 = 0;
            int count2 = 0;
            int index = 0;

            var recall = new Dictionary<int, (int V1, int V2)>();
            (int V1, int V2) preLoop = (0, 0);
            (int V1, int V2) inLoop = (0, 0);
            while(true){
                count1++;
                foreach(var c in s1){
                    if(c == s2[index]){
                        index++;
                        if(index == s2.Length){
                            index = 0;
                            count2++;
                        }
                    }
                }

                if(count1 == n1)
                    return count2 / n2;
                
                if(recall.ContainsKey(index)){
                    var (value1, value2) = recall[index];
                    preLoop = (value1, value2);
                    inLoop = (count1 - value1, count2 - value2);
                    break;
                }else{
                    recall.Add(index, (count1, count2));
                }
            }

            var result = preLoop.V2 + (n1 - preLoop.V1) / inLoop.V1 * inLoop.V2;
            var rest = (n1 - preLoop.V1) % inLoop.V1;
            for(int i = 0; i < rest; i++){
                foreach(var c in s1){
                    if(c == s2[index]){
                        index++;
                        if(index == s2.Length){
                            index = 0;
                            result++;
                        }
                    }
                }
            }

            return result / n2;
        }
    }
}