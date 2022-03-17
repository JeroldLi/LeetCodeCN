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
        ans = Math.Max(ans, L + R + 1);
        return Math.Max(L , R) + 1;
    }
}
// @lc code=end

