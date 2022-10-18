using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1700
    /// title: 无法吃午餐的学生数量
    /// problems: https://leetcode.cn/problems/number-of-students-unable-to-eat-lunch/
    /// date: 20221019
    /// </summary>
    public static class Solution1700
    {
        public static int CountStudents(int[] students, int[] sandwiches) {
            int length = students.Length;
            int ones = students.Count(num => num == 1);
            int zeros = length - ones;

            for(int i = 0; i < length; i++){
                if(sandwiches[i] == 0){
                    if(zeros == 0)
                        break;
                    
                    zeros--;
                }else{
                    if(ones == 0)
                        break;
                    
                    ones--;
                }
            }

            return zeros + ones;
        }
    }
}