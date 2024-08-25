using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 690
    /// title: 员工的重要性
    /// problems: https://leetcode-cn.com/problems/employee-importance/
    /// date: 20210501
    /// </summary>
    public static partial class Solution690
    {
        public class Employee {
            public int id;
            public int importance;
            public IList<int> subordinates;
        }

        public static int GetImportance(IList<Employee> employees, int id) {
            Dictionary<int, Employee> dic = new Dictionary<int, Employee>();

            foreach(var employee in employees){
                dic[employee.id] = employee;
            }
            
            int GetSum(Employee employee){
                int result = employee.importance;
                foreach(var subId in employee.subordinates){
                    result += GetSum(dic[subId]);
                }
                return result;
            }

            return GetSum(dic[id]);
        }
    }
}