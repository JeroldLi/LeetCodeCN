/*
 * @lc app=leetcode.cn id=53 lang=csharp
 *
 * [53] 最大子数组和
 */

// @lc code=start
public class Problem53
{
    public struct Status
    {
        public int lsum { get; set; }  //包含左端点的最大区间和
        public int rsum { get; set; }  //包含右端点的最大区间和
        public int msum { get; set; }  //最大区间和
        public int isum { get; set; }  //区间和

        public Status(int lsum_, int rsum_, int msum_, int isum_){
            lsum = lsum_;
            rsum = rsum_;
            msum = msum_;
            isum = isum_;

        }
    }

    public int function1(int[] nums)
    {
        int pre = 0;
        int maxAns = nums[0];
        foreach (int x in nums)
        {
            pre = Math.Max(pre + x, x);
            //两个数的和只要不小于后一个数，在下一次相加时就不会拉低总和
            //a + b >= b
            //a + b + c >= b + c
            maxAns = Math.Max(maxAns, pre);
        }
        return maxAns;
    }

    public Status PushUp(Status left, Status right){
        int lsum = Math.Max(left.lsum, left.isum+right.lsum);
        int rsum = Math.Max(right.rsum, right.isum+left.rsum);
        int msum = Math.Max(Math.Max(left.msum, right.msum), 
                    left.rsum+right.lsum);
        int isum = left.isum + right.isum;
        return new Status(lsum, rsum, msum, isum);
    }

    public Status function2(int[] nums, int left, int right){
        if(left == right){
            return new Status(nums[left],nums[left],nums[left],nums[left]);
        }
        int m = (left + right) / 2;
        Status lsub= function2(nums, left, m);
        Status rsub = function2(nums, m+1, right);
        return PushUp(lsub, rsub);
    }

    public int MaxSubArray(int[] nums)
    {
        return function1(nums);
        //return function2(nums, 0, nums.Length - 1).msum;
    }
}
// @lc code=end

