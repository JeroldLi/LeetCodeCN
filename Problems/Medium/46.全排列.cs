/*
 * @lc app=leetcode.cn id=46 lang=csharp
 *
 * [46] 全排列
 */

// @lc code=start
public class Solution46 {
    public IList<IList<int>> Permute(int[] nums) {
        return function1(nums);
    }
    /*
    解法一：DFS + 回溯算法
    做题时先画出树形图，想清楚递归结构，想清楚如何剪枝
    思考：
    1、分支如何产生
    2、题目需要的解是叶子节点，还是非叶子节点，还是根节点至叶子节点的路径?
    3、哪些搜索会产生不需要的解？为什么会产生重复？如果在浅层就知道这个解不合理，如何剪枝？
    */
    public List<IList<int>> function1(int[] nums){
        int len = nums.Length;
        List<IList<int>> res = new List<IList<int>>();
        if(len == 0){
            return res;
        }
        bool[] used = new bool[len];
        List<int> path = new List<int>();
        DFS(nums, len, 0, path, used, res);
        return res;
    }

    public void DFS(int[] nums, int len, int depth, List<int> path, bool[] used, List<IList<int>> res){
        if(depth == len){
            //res.Add(path); //赋值的是变量地址 其实最后都指向同一块地址
            res.Add(new List<int>(path)); //每次赋值时新拷贝一个list
            return;
        }
        for(int i = 0; i < len; i++){
            if(!used[i]){
                path.Add(nums[i]);
                used[i] = true;
                DFS(nums, len, depth + 1, path, used, res);
                used[i] = false;
                path.RemoveAt(path.Count - 1);
            }
        }
    }
}
// @lc code=end

