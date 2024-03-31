using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1803
    /// title: 统计异或值在范围内的数对有多少
    /// problems: https://leetcode.cn/problems/count-pairs-with-xor-in-a-range/
    /// date: 20230105
    /// </summary>
    public static class Solution1803
    {
        // 参考解答
        // 字典树 前缀和
        public static int CountPairs(int[] nums, int low, int high) {
            var root = new Trie();
            int result = 0;
            for(int i = 1; i < nums.Length; i++){
                root.Add(nums[i - 1]);
                result += root.Get(nums[i], high) - root.Get(nums[i], low - 1);
            }

            return result;
        }

        public class Trie {
            public Trie[] Children = new Trie[2];
            public int Sum;

            public Trie(){
                Sum = 0;
            }
            
            public void Add(int num){
                Trie cur = this;

                for(int k = 14; k >= 0; k--){
                    int bit = (num >> k) & 1;
                    if(cur.Children[bit] == null)
                        cur.Children[bit] = new Trie();
                    
                    cur = cur.Children[bit];
                    cur.Sum++;
                }
            }

            public int Get(int num, int x){
                Trie cur = this;
                int sum = 0;
                for(int k = 14; k >= 0; k--){
                    int r = (num >> k) & 1;
                    if(((x >> k) & 1) != 0){
                        if(cur.Children[r] != null)
                            sum += cur.Children[r].Sum;
                        
                        if(cur.Children[r ^ 1] == null)
                            return sum;
                        
                        cur = cur.Children[r ^ 1];
                    }else {
                        if(cur.Children[r] == null)
                            return sum;
                        
                        cur = cur.Children[r];
                    }
                } 

                sum += cur.Sum;
                return sum;
            }
        }
    }
}