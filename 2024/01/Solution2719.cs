using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    ///<summary>
    /// no: 2719
    /// title: 统计整数数目
    /// problems: https://leetcode.cn/problems/count-of-integers/description/?envType=daily-question&envId=2024-01-16
    /// date: 20240116
    /// </summary>
    public static class Solution2719
    {
        // 参考解答
        // 数位动态规划
        public static int Count(string num1, string num2, int min_sum, int max_sum) {
            const int N = 23;
            const int M = 401;
            const int MOD = 1000000007;

            var nums = new List<int>();

            var d = new int[N, M];
            for(int i = 0; i < N; i++){
                for(int j = 0; j < M; j++){
                    d[i, j] = -1;
                }
            }


            int DFS(int i, int j, bool limit){
                if (j > max_sum)
                    return 0;
                
                if (i == -1)
                    return j >= min_sum ? 1 : 0;
                
                if (!limit && d[i, j] != -1)
                    return d[i, j];
                
                int result = 0;
                int up = limit ? nums[i] : 9;
                for(int x = 0; x <= up; x++){
                    result = (result + DFS(i - 1, j + x, limit && x == up)) % MOD;
                }

                if (!limit)
                    d[i, j] = result;

                return result;
            }

            int Get(string num, bool sub){
                nums.Clear();
                foreach(var c in num){
                    nums.Add(c - '0');
                }

                if (sub){
                    Sub(nums);
                }

                nums.Reverse();
                
                if (nums.Last() == 0)
                    nums.RemoveAt(nums.Count - 1);

                return DFS(nums.Count - 1, 0, true);
            }

            void Sub(List<int> nums){
                
                int index = nums.Count - 1;
                while(index >= 0 && nums[index] == 0){
                    nums[index] = 9;
                    index--;
                }

                nums[index]--;
            }

            return (Get(num2, false) - Get(num1, true) + MOD) % MOD;
        }
    }
}