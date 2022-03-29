/*
 * @lc app=leetcode.cn id=53 lang=csharp
 *
 * [53] 最大子数组和
 */

// @lc code=start
public class Solution
{
    /*
    解法一：动态规划法
    【两个数的和只要不小于后一个数，在下一次相加时就不会拉低总和】
    【a + b >= b -> a + b + c >= b + c】
    【a + b < b -> a + b + c < b + c】
    遍历数组，判断当前元素和当前元素+前元素和的值，
    如果前元素和更大，则说明继续相加会让值更大
    如果当前元素更大，则说明应从当前元素开始重新计算
    并且每次都将最大元素和与前元素和进行比较，暂存最大值

    适用于DP的问题：【能将大问题拆成几个小问题，且满足无后效性、最优子结构性质】
    【无后效性】：未来不影响过去，f(n)只关心f(n-1)的状态，f(n-1)怎么来的此时并不关心。
    【最优子结构性】：大问题的最优解可以由小问题的最优解推导出。
    一般来说：动态规划方程（状态转移方程）：f(P) = Min/Max{f{R} + w};

    【我是谁？我从哪里来？我要到哪里去？】
    我是谁？ 设计状态，表示局面
    我从哪里来？
    我要到哪里去？设计状态转移方程

    时间复杂度：O(n) 遍历一次数组
    空间复杂度：O(1) 只需要常数个变量
    */
    public int function11(int[] nums)
    {
        //空间优化版
        int pre = 0;
        int maxAns = nums[0];
        foreach (int x in nums)
        {
            pre = Math.Max(pre + x, x);
            maxAns = Math.Max(maxAns, pre);
        }
        return maxAns;
    }

    public int function12(int[] nums){
        //空间不优化版
        int len = nums.Length;
        int[] dp = new int[len];
        dp[0] = nums[0];  //dp[0]初始化动态规划数组
        for(int i = 1; i < len; i++){
            if(dp[i - 1] > 0){
                dp[i] = dp[i - 1] + nums[i];
            }else{
                dp[i] = nums[i];
            }
        }
        int res = dp[0];
        for(int i = 1; i < len; i++){
            res = Math.Max(res, dp[i]);
        }

        return res;
    }
    /*
    解法二：分治法
    将大的问题划分为小的问题
    而小的问题可以使用相同的思路、相同的方法进行划分
    最后将小的问题依次计算 倒推得出大问题的结果
    分而治之
    当问题递归划分为最小：本题中为区间长度=1
    递归[开始回升]

    将递归的过程看作二叉树，那么二叉树的深度的渐进上界为O(logn)
    还要引入渐进复杂度：当n趋于无穷大时O(n)取到的极限值
    时间复杂度：O(logn) 要遍历二叉树的所有节点
    渐进复杂度：O(n) 当n趋于无穷大
    空间复杂度:O(logn) 递归要维护栈空间 栈的深度与二叉树深度有关
    */
    public struct Status
    {
        public int lsum { get; set; }  //包含左端点的最大区间和
        public int rsum { get; set; }  //包含右端点的最大区间和
        public int msum { get; set; }  //最大区间和
        public int isum { get; set; }  //区间和

        public Status(int lsum_, int rsum_, int msum_, int isum_)
        {
            lsum = lsum_;
            rsum = rsum_;
            msum = msum_;
            isum = isum_;

        }
    }
    public Status PushUp(Status left, Status right)
    {
        int lsum = Math.Max(left.lsum, left.isum + right.lsum);
        int rsum = Math.Max(right.rsum, right.isum + left.rsum);
        int msum = Math.Max(Math.Max(left.msum, right.msum),
                    left.rsum + right.lsum);
        int isum = left.isum + right.isum;
        return new Status(lsum, rsum, msum, isum);
    }

    public Status function2(int[] nums, int left, int right)
    {
        if (left == right)
        {
            return new Status(nums[left], nums[left], nums[left], nums[left]);
        }
        int m = (left + right) / 2;
        Status lsub = function2(nums, left, m);
        Status rsub = function2(nums, m + 1, right);
        return PushUp(lsub, rsub);
    }

    /*
    解法三：暴力迭代法
    遍历数组中每一个数，记录下每一个元素作为开头时的连续和最大值
    每遍历一遍都更新最大值
    【会超时】
    */
    public int function3(int[] nums){
        int max = Int32.MinValue;
        for(int i = 0; i < nums.Length; i++){
            int sum = 0;
            for(int j = i; j < nums.Length; j++){
                sum += nums[j];
                if(sum > max){
                    max = sum;
                }
            }
        }
        return max;
    }

    /*
    解法四：贪心算法
    【贪心算法目光短浅】只关注是否出现临界值
    本题中临界值就是前元素和小于0时，再加上前元素和只会让总和减小
    因此前元素和小于0时，就舍弃之前的前元素和，以当前元素作为第一位重新开始
    */
    public int function4(int[] nums){
        int max = Int16.MinValue;
        int sum = 0;
        for(int i = 0; i < nums.Length; i++){
            sum += nums[i];
            max = Math.Max(max, sum);
            if(sum < 0){
                sum = 0;  //以当前元素重新开始
            }
        }
        return max;
    }

    public int MaxSubArray(int[] nums)
    {
        return function12(nums);
        //return function2(nums, 0, nums.Length - 1).msum;
    }
}
// @lc code=end

