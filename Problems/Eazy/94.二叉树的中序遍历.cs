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

/*
前序遍历：左、中、右
中序遍历：中、左、右
后序遍历：左、右、中
层次遍历：按层次遍历
 */
using leetcode;
public class Problem94
{
    /*
    解法一：递归算法
    */
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

    /*
    解法二：迭代算法
    利用栈的后进先出特性
    遇到左就进栈，左为空则退出至中节点
    随后拐向右节点
    */
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

