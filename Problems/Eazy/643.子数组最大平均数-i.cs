/*
 * @lc app=leetcode.cn id=643 lang=csharp
 *
 * [643] 子数组最大平均数 I
 */

// @lc code=start
public class Solution643 {
    public double FindMaxAverage(int[] nums, int k) {
        return function1(nums, k);
    }
    /*
    解法一：滑动窗口
    固定左边界， 扩大右边界 并计算边界内的和值
    当窗口长度达到要求时，右移边界一格 左边界也要跟着移动一格
    */
    public double function1(int[] nums, int k){
        double sum = 0;
        double maxAvg = double.MinValue;
        int start = 0;
        for(int cur = start; cur < nums.Length; cur++){
            sum += nums[cur];
            if(cur - start + 1 == k){
                maxAvg = Math.Max(maxAvg, sum / k);
            }

            if(cur >= k - 1){
                sum -= nums[start];
                start++;
            }
        }
        return maxAvg;
    }
}
// @lc code=end

