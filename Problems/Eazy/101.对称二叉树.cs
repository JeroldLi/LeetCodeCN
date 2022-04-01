/*
 * @lc app=leetcode.cn id=101 lang=csharp
 *
 * [101] 对称二叉树
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
using leetcode;
public class Solution101 {

    public bool IsSymmetric(TreeNode root) {
        return function1(root, root);
        //return function2(root, root);
        //return CheckTreeNode(root, root);
    }

    /*
    解法一：递归
    左右节点同时为空或值相等时->对称
    左右节点不同时为空时->不对称
    */
    public bool function1(TreeNode node1, TreeNode node2){
        if(node1 == null && node2 == null){
            return true;
        }
        if(node1 == null || node2 == null){
            return false;
        }

        return node1.val == node2.val
        && function1(node1.left, node2.right)
        && function1(node1.right, node2.left);
    }

    /*
    解法二：迭代
    利用队列先进先出的特性
    同时将两个节点进队 同时作比较 同时出队
    */
    public bool function2(TreeNode root1, TreeNode root2) {
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root1);
        queue.Enqueue(root2);

        while(queue.Count > 0){
            TreeNode node1 = queue.Peek(); queue.Dequeue();
            TreeNode node2 = queue.Peek(); queue.Dequeue();

            if(node1 == null && node2 == null){
                continue;
            }

            if( (node1 == null || node2 == null) ||
                (node1.val != node2.val)){
                return false;
            }

            queue.Enqueue(node1.left);
            queue.Enqueue(node2.right);

            queue.Enqueue(node1.right);
            queue.Enqueue(node2.left);
        }
        return true;
    }
}
// @lc code=end

