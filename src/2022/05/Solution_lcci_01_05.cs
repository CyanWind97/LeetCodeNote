using System;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 01.05
    /// title: 01.05. 一次编辑
    /// problems: https://leetcode.cn/problems/one-away-lcci/
    /// date: 20220513
    /// type: 面试题 lcci
    /// </summary>
    public class Solution_lcci_01_05
    {
        public static bool OneEditAway(string first, string second) {
            int m = first.Length;
            int n = second.Length;
            var edit = new int[m + 1, n + 1];

            for(int i = 0; i < m + 1; i++){
                edit[i, 0] = i;
            }

            for(int j = 0; j < n + 1; j++){
                edit[0, j] = j;
            }

            for(int i = 0; i < m; i++){
                for(int j = 0; j < n; j++){
                    edit[i + 1, j + 1] = edit[i, j];
                    if(first[i] != second[j])
                        edit[i + 1, j + 1] = Math.Min(Math.Min(edit[i, j + 1], edit[i + 1, j]), edit[i, j]) + 1;
                }
            }

            return edit[m, n] <= 1;
        }

        public static bool OneEditAway_1(string first, string second) {
            int m = first.Length;
            int n = second.Length;

            bool OneInsert() {
                (var shorter, var longer, var length1, var length2)
                    = m > n
                    ? (second, first, n, m)
                    : (first, second, m, n);
                
                int index1 = 0, index2 = 0;
                while (index1 < length1 && index2 < length2) {
                    if (shorter[index1] == longer[index2]) 
                        index1++;
                    
                    index2++;
                    if (index2 - index1 > 1) 
                        return false;
                }

                return true;
            }    


            if (Math.Abs(m - n) == 1) 
                return OneInsert();
            else if (m == n) {
                bool foundDifference = false;
                for (int i = 0; i < m; i++) {
                    if (first[i] != second[i]) 
                        if (!foundDifference) 
                            foundDifference = true;
                        else 
                            return false;
                        
                }
                
                return true;
            }else
                return false;
            
        }


        // 参考解答 双指针
        public static bool OneEditAway_2(string first, string second) {
            int l1 = 0;
            int r1 = first.Length - 1;
            int l2 = 0;
            int r2 = second.Length - 1;

            while(l1 <= r1 && l2 <= r2){
                if(first[l1] == second[l1]){
                    l1++;
                    l2++;
                    continue;
                }

                if(first[r1] == second[r2]){
                    r1--;
                    r2--;
                }else{
                    break;
                }
            }

            return r1 - l1 + r2 - l2 <= 0 
                && Math.Abs(l1 - l2) <= 1
                && Math.Abs(r1 - r2) <= 1;

        }
    }
}