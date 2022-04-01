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
public class Solution104
{
    /*
    解法一：深度优先
    一棵树的深度等于其左右子树深度的最大值
    左右子树又可以分别对自身的左右子树进行递归计算
    子树为空时返回0 子树为空的叶子节点记为1
    */
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

    /*
    解法二：广度优先
    依次遍历每一层节点，最后记下层数
    进入队列后 队列的size记录当前这层有几个节点
    每遍历一个节点要对size-1
    每次遍历本层结束（size=0）要将层数+1
    */
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
        return function1(root);
        //return function2(root);
    }
}
// @lc code=end

