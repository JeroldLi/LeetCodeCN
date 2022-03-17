/*
 * @lc app=leetcode.cn id=104 lang=csharp
 *
 * [104] 二叉树的最大深度
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
public class Problem104
{
    //深度优先
    public int function1(TreeNode root)
    {
        if (root == null)
        {
            return 0;
        }
        else
        {
            int leftHeight = function1(root.left);
            int rightHeight = function1(root.right);

            //最后一个叶子点算1层
            return Math.Max(leftHeight, rightHeight) + 1;
        }
    }

    // 广度优先
    public int function2(TreeNode root)
    {
        Queue<TreeNode> q = new Queue<TreeNode>();
        if (root == null)
        {
            return 0;
        }

        int ans = 0;
        q.Enqueue(root);
        while (q.Count > 0)
        {
            int size = q.Count;
            while (size > 0)
            {
                TreeNode node1 = q.Peek();
                q.Dequeue();
                if (node1.left != null)
                {
                    q.Enqueue(node1.left);
                }
                if (node1.right != null)
                {
                    q.Enqueue(node1.right);
                }
                size -= 1;
            }
            ans += 1;
        }

        return ans;
    }

    public int MaxDepth(TreeNode root)
    {
        {
            return function1(root);
            //return function2(root);
        }
    }
}
// @lc code=end

