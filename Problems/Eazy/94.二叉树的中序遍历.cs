/*
 * @lc app=leetcode.cn id=94 lang=csharp
 *
 * [94] 二叉树的中序遍历
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
public class Problem94
{
    //递归
    public IList<int> function1(TreeNode root)
    {
        List<int> result = new List<int>();
        if (root != null)
        {
            inorder(root, result);
        }
        return result;
    }

    public void inorder(TreeNode root, IList<int> res)
    {
        if (root != null)
        {
            inorder(root.left, res);
            res.Add(root.val);
            inorder(root.right, res);
        }
    }

    public IList<int> function2(TreeNode root)
    {
        List<int> result = new List<int>();
        Stack<TreeNode> stk = new Stack<TreeNode>();
        while (root != null || stk.Count != 0)
        {
            while (root != null)
            {
                stk.Push(root);
                root = root.left;
            }

            root = stk.Pop();
            result.Add(root.val);
            root = root.right;
        }
        return result;
    }

    public IList<int> InorderTraversal(TreeNode root){
        return function1(root);
        //return function2(root);
    }

}
// @lc code=end

