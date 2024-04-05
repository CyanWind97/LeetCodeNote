using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCodeNote
{
    /// <summary>
    /// no: 1483
    /// title: 树节点的第 K 个祖先
    /// problems: https://leetcode.cn/problems/kth-ancestor-of-a-tree-node/
    /// date: 20230612
    /// </summary>
    public static partial class Solution1483
    {
        // 参考解答
        // 倍增
        public class TreeAncestor {
            private const int LOG = 16;
            
            private int[,] ancestors;

            public TreeAncestor(int n, int[] parent) {
                ancestors = new int[n, LOG];
                for(int j = 0; j < LOG; j++) {
                    for(int i = 0; i < n; i++) {
                        ancestors[i, j] = -1;
                    }
                }

                for(int i = 0; i < n; i++) {
                    ancestors[i, 0] = parent[i];
                }

                for(int j = 1; j < LOG; j++){
                    for(int i = 0; i < n; i++){
                        if(ancestors[i, j - 1] != -1){
                            ancestors[i,j] = ancestors[ancestors[i, j - 1], j - 1];
                        }
                    }
                }
            }
            
            public int GetKthAncestor(int node, int k) {
                for(int j = 0; j < LOG; j++){
                    if(((k >> j) & 1) != 0){
                        node = ancestors[node, j];
                        if(node == -1)
                            break;
                    }
                }
                
                return node;
            }
        }
    }
}