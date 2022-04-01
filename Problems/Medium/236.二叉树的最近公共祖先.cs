/*
 * @lc app=leetcode.cn id=236 lang=csharp
 *
 * [236] 二叉树的最近公共祖先
 */

// @lc code=start
/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     public int val;
 *     public TreeNode left;
 *     public TreeNode right;
 *     public TreeNode(int x) { val = x; }
 * }
 */
using leetcode;
public class Problem236 {
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        return function1(root, p, q);
        //return function2(root, p, q);
        //return function3(root, p, q);
    }
    /*
    解法二：存储父节点
    从根节点向下遍历每个节点，并且用List保存其父节点的值
    当两个目标节点都被找到时
    便获得了通往两个目标的路径列表
    随后对比路径列表的每一个节点，找到最后一个相同的节点并返回
    */
    public TreeNode function2(TreeNode root, TreeNode p, TreeNode q){
        List<List<TreeNode>> result = new List<List<TreeNode>>();
        Backtrack(root, p.val, q.val, new List<TreeNode>(), result);

        int minCount = Math.Min(result[0].Count, result[1].Count);
        TreeNode node = root;
        for(int i = 0; i < minCount; i++){
            if(result[0][i].val == result[1][i].val){
                node = result[0][i];
            }
        }
        return node;
    }
    public bool Backtrack(TreeNode root, int p, int q,List<TreeNode> path, List<List<TreeNode>> result){
        if(root == null) return false;
        path.Add(root);
        if(root.val == p || root.val == q){
            result.Add(path);
            if(result.Count == 2){
                return true;
            }
        }
        if(root.left != null && Backtrack(root.left, p, q, path, result)){
            return true;
        }
        if(root.right != null && Backtrack(root.right, p, q, path, result)){
            return true;
        }
        path.RemoveAt(path.Count - 1);
        return false;
    }
    /*
    解法三：递归法
    自顶向下递归
    如果某一结点的左右子树分别包含p和q，那么该节点就是最近公共节点
    如果某一结点本身是目标值，且其中一棵子树包含另一个目标，那么该节点就是最近公共节点
    如果某一结点本身不是目标，其子树也不包含目标，那么该节点返回null
    那么有返回值的就是碰上了p和q
    没有返回值的就不是所需的节点
    判断返回值==null即可
    */
    public TreeNode function3(TreeNode root, TreeNode p, TreeNode q){
        if(root == null){ //第一步还是先边界
            return null;
        }
        if((root.val == p.val)||(root.val == q.val)){
            //某一结点本身是目标 再往下就不能包含自己了
            //因此就是该节点本身
            return root;
        }
        //递归计算该节点的左右子树
        TreeNode left = function3(root.left, p, q);
        TreeNode right = function3(root.right, p, q);
        if(left != null && right != null){ //如果左右子树都有返回值，说明pq分别在两边
            return root;
        }
        //如果其中一边子树是null 那么直接返回另一边子树
        return left == null ? right : left;
    }

    /*
    解法一：递归法
    有点重复了 效率极低 感觉find多此一举 多运算了一轮
    */
    public TreeNode function1(TreeNode root, TreeNode p, TreeNode q){
        if(root == null){
            return null;
        }
        if((root.val == p.val) || (root.val == q.val)){
            return root;
        }
        if(find(root.left, p) && find(root.left, q)){
            return function1(root.left, p, q);
        }
        if(find(root.right, p) && find(root.right, q)){
            return function1(root.right, p, q);
        }
        return root;
    }

    public bool find(TreeNode root, TreeNode c){
        if(root == null){
            return false;
        }
        if(root.val == c.val){
            return true;
        }
        return find(root.left, c) || find(root.right, c);
    }

}
// @lc code=end

