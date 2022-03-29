/*
 * @lc app=leetcode.cn id=543 lang=csharp
 *
 * [543] 二叉树的直径
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
public class Problem543 {
    public int DiameterOfBinaryTree(TreeNode root) {
        return function1(root);
    }

    /*
    解法一：递归调用 深度优先遍历
    一条路径=经过节点数-1
    所以直径（路径长度最大值） = 最大节点深度-1
    所以用深度优先算法求二叉树的深度
    */
    public int ans = 1;
    public int function1(TreeNode root){
        depth(root);
        return ans - 1;
    }

    public int depth(TreeNode root){
        if(root == null){
            return 0;
        }

        int L = depth(root.left);
        int R = depth(root.right);
        ans = Math.Max(ans, L + R + 1); //+1代表本层， L+R意味着可以不经过根节点 用ans来暂存最大值
        return Math.Max(L , R) + 1;  //最后的叶子节点深度记为1 此时叶子节点的左右节点均为null返回0
    }
}
// @lc code=end

