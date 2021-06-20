using System.Collections.Generic;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1600
    /// title: 皇位继承顺序
    /// problems: https://leetcode-cn.com/problems/throne-inheritance/
    /// date: 20210620
    /// </summary>
    public static class Solution1600
    {
        // 参考解答 多叉树
        public class ThroneInheritance {
            Dictionary<string, IList<string>> edges;
            ISet<string> dead;
            string king;

            public ThroneInheritance(string kingName) {
                edges = new Dictionary<string, IList<string>>();
                dead = new HashSet<string>();
                king = kingName;
            }
            
            public void Birth(string parentName, string childName) {
                IList<string> children;
                if (edges.TryGetValue(parentName, out children)) {
                    children.Add(childName);
                    edges[parentName] = children;
                } else {
                    children = new List<string>();
                    children.Add(childName);
                    edges.Add(parentName, children);
                }
            }
            
            public void Death(string name) {
                dead.Add(name);
            }
            
            public IList<string> GetInheritanceOrder() {
                IList<string> ans = new List<string>();
                Preorder(ans, king);
                return ans;
            }

            private void Preorder(IList<string> ans, string name) {
                if (!dead.Contains(name)) {
                    ans.Add(name);
                }
                IList<string> children = edges.TryGetValue(name, out children) ? children : new List<string>();
                foreach (string childName in children) {
                    Preorder(ans, childName);
                }
            }

        }
    }
}