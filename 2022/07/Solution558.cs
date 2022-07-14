namespace LeetCodeNote
{
    /// <summary>
    /// no: 558
    /// title:  四叉树交集
    /// problems: https://leetcode.cn/problems/logical-or-of-two-binary-grids-represented-as-quad-trees/
    /// date: 20220715
    /// </summary>

    public static class Solution558
    {
        public class Node {
            public bool val;
            public bool isLeaf;
            public Node topLeft;
            public Node topRight;
            public Node bottomLeft;
            public Node bottomRight;

            public Node(){}

            public Node(bool _val, bool _isLeaf){
                val = _val;
                isLeaf = _isLeaf;
            }

            public Node(bool _val,bool _isLeaf,Node _topLeft,Node _topRight,Node _bottomLeft,Node _bottomRight) {
                val = _val;
                isLeaf = _isLeaf;
                topLeft = _topLeft;
                topRight = _topRight;
                bottomLeft = _bottomLeft;
                bottomRight = _bottomRight;
            }
        }

        public static Node Intersect(Node quadTree1, Node quadTree2) {
            
            Node MergeNode(Node node1, Node node2){
                if(node1.isLeaf){
                    if(node1.val)
                        return node1;
                    else
                        return node2;
                }else if(node2.isLeaf){
                    if(node2.val)
                        return node2;
                    else
                        return node1;
                }else{
                    var node = new Node();
                    node.topLeft = MergeNode(node1.topLeft, node2.topLeft);
                    node.isLeaf = node.topLeft.isLeaf;
                    node.val = node.topLeft.val;
                    
                    node.topRight = MergeNode(node1.topRight, node2.topRight);
                    if(node.isLeaf && (!node.topRight.isLeaf ||  node.val != node.topRight.val))
                        node.isLeaf = false;
                    
                    node.bottomLeft = MergeNode(node1.bottomLeft, node2.bottomLeft);
                    if(node.isLeaf &&  (!node.bottomLeft.isLeaf || node.val != node.bottomLeft.val))
                        node.isLeaf = false;
                    
                    node.bottomRight = MergeNode(node1.bottomRight, node2.bottomRight);
                    if(node.isLeaf &&  (!node.bottomRight.isLeaf || node.val != node.bottomRight.val))
                        node.isLeaf = false;

                    if(node.isLeaf){
                        node.topLeft = null;
                        node.topRight = null;
                        node.bottomLeft = null;
                        node.bottomRight = null;
                    }

                    return node;
                }
            }

            return MergeNode(quadTree1, quadTree2);
        }
    }
}