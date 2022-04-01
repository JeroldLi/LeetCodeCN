/*
 * @lc app=leetcode.cn id=47 lang=csharp
 *
 * [47] 全排列 II
 */

// @lc code=start
public class Solution47 {
    public IList<IList<int>> PermuteUnique(int[] nums) {
        return function1(nums);
    }
    /*
    解法一：DFS+回溯算法+剪枝
    */
    public IList<IList<int>> function1(int[] nums){
        int len = nums.Length;
        IList<IList<int>> res = new List<IList<int>>(); //接口的初始化
        if(len == 0){
            return res;
        }
        Array.Sort(nums); //先将数组排序 方便后续比较

        bool[] used = new bool[len];  //使用状态数组
        Stack<int> path = new Stack<int>(len); //栈 用来实现恢复现场
        DFS(nums, len, 0, used, path, res);
        return res;
    }
    public void DFS(int[] nums, int len, int depth, bool[] used, Stack<int> path, IList<IList<int>> res){
        if(depth == len){ //当接入的数字长度depth等于总数组长度len时 一个组合完成了
            res.Add(new List<int>(path)); //add的传参是传引用的，因此要new一个新list添加
            //否则最后所有的元素都指向同一个path
            return;
        }
        for(int i = 0; i < len; ++i){
            if(used[i]){ //如果该元素正在被使用就跳过
                continue;
            }
            //i>0是为了确保i-1合法
            //nums[i] == nums[i-1] 意味着出现了重复
            //但是used[i-1]并没有被使用（对于i来说,i-1就是排序后它的前一位
            //在上一轮的遍历中已经使用过了，这次如果再带上它就会产生重复）
            //因此剪枝
            if(i > 0 && nums[i] == nums[i-1] && !used[i-1]){
                continue;
            }
            path.Push(nums[i]);
            used[i] = true;

            DFS(nums, len, depth + 1, used, path, res);

            used[i] = false;
            path.Pop();
        }
    }
}
// @lc code=end

