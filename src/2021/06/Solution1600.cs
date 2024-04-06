using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1600
    /// title: 皇位继承顺序
    /// problems: https://leetcode-cn.com/problems/throne-inheritance/
    /// date: 20210620
    /// </summary>
    public static partial class Solution1600
    {
        // 参考解答 多叉树
        public class ThroneInheritance {
            readonly Dictionary<string, IList<string>> _edges = [];
            readonly HashSet<string> _dead = [];
            readonly string _king;

            public ThroneInheritance(string kingName) {
                _king = kingName;
            }
            
            public void Birth(string parentName, string childName) {
                if (_edges.TryGetValue(parentName, out var children))
                    children.Add(childName);
                else 
                    _edges[parentName] = [childName];
            }
            
            public void Death(string name) {
                _dead.Add(name);
            }
            
            public IList<string> GetInheritanceOrder() {
                var reulst = new List<string>();

                void Preorder(string name) {
                    if (!_dead.Contains(name)) 
                        reulst.Add(name);
                    
                    if (!_edges.TryGetValue(name, out var children)) 
                        return;
                    
                    foreach (string childName in children) {
                        Preorder(childName);
                    }
                }

                Preorder(_king);

                return reulst;
            }
        }
    }
}