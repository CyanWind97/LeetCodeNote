using System.Linq;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 677
    /// title:   键值映射
    /// problems: https://leetcode-cn.com/problems/map-sum-pairs/
    /// date: 20211114
    /// </summary>
    public static class Solution677
    {
        public class MapSum {
            
            public MapSum[] Children;

            public int Value;

            public MapSum() {
                
                Children = new MapSum[26];
                Value = 0;
            }
            
            public void Insert(string key, int val) {
                MapSum cur = this;
                foreach(var c in key){
                    int index = c - 'a';
                    if (cur.Children[index] == null)
                        cur.Children[index] = new MapSum();
                    
                    cur = cur.Children[index];
                }

                cur.Value = val;
            }
            
            public int Sum(string prefix) {
                MapSum cur = this;
                foreach(var c in prefix){
                    int index = c - 'a';
                    if (cur.Children[index] == null)
                        return 0;
                        
                    cur = cur.Children[index];
                }

                return cur.GetSumValue();
            }

            
            public int GetSumValue()
                => Value + Children.Sum(x => x is MapSum mapSum ? mapSum.GetSumValue() : 0);
        }
    }
}