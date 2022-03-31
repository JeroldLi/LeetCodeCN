/*
 * @lc app=leetcode.cn id=110 lang=csharp
 *
 * [110] 平衡二叉树
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
public class Problem110 {
    public bool IsBalanced(TreeNode root) {
        //return function1(root);
        return function2(root);
    }

    /*
    解法一：自顶向下递归
    从根节点向下计算左右子树的高度求差
    时间复杂度O(n²) isBalanced遍历所有n GetHeight也遍历所有n
    空间复杂度O(n)树退化成链表时 需要的计算空间就是节点数n
    */
    public bool function1(TreeNode root){
        if(root == null){
            return true;
        }else{
            return Math.Abs(GetHeight1(root.left) - GetHeight1(root.right)) <= 1
            && function1(root.left) && function1(root.right);
        }
    }
    public int GetHeight1(TreeNode root){
        if(root == null){
            return 0;
        }else{
            //因为叶子节点的子节点肯定返回0 所以叶子节点要+1
            return Math.Max(GetHeight1(root.left), GetHeight1(root.right)) + 1;
        }
    }

    /*
    解法二：自底向上递归
    每个节点只算一遍，遇到不平衡的直接中断
    时间复杂度O(n)最多遍历一遍
    空间复杂度O(n)链表最多保存n的栈空间
    */
    public bool function2(TreeNode root){
        return GetHeight2(root) >= 0;
    }

    public int GetHeight2(TreeNode root){
        if(root == null){
            return 0;
        }
        int leftHeight = GetHeight2(root.left);
        int rightHeight = GetHeight2(root.right);
        if(leftHeight == -1 || rightHeight == -1 ||
        Math.Abs(leftHeight - rightHeight) > 1){
            return -1;
        }else{
            return Math.Max(leftHeight, rightHeight) + 1;
        }
    }
}
// @lc code=end

